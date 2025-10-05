using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class PropertyInstance : IEquatable<PropertyInstance>
    {
        public readonly ClassInstance ContainingClass;
        public readonly string Type;
        public readonly string Name;
        public readonly bool Reference;
        public readonly bool IsStatic;
        public readonly bool IsDeprecated;

        public PropertyInstance(ClassInstance containingClass, string type, string name, bool reference = false, bool isStatic = false, bool isDeprecated = false)
        {
            ContainingClass = containingClass;
            Type = type;
            Name = name;
            Reference = reference;
            IsStatic = isStatic;
            IsDeprecated = isDeprecated;
        }

        public ObjectiveCInstance Generate(List<SelectorInstance> selectorInstances, List<EnumInstance> enumCache, List<StructInstance> structCache, CodeGenContext context)
        {
            var selector = selectorInstances.Find(x => string.Equals(x.Selector, Name, StringComparison.InvariantCultureIgnoreCase));
            var type = "";

            if (selector == null)
            {
                // This can sometimes select the wrong selector, so we only want to use it as a backup
                selector = selectorInstances.Find(x => x.Selector.Contains(Name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (selector != null)
            {
                selector.UsedInProperty = true;
                // We assume a type of IntPtr, which encapsulates any possible type
                var runtimeFuncReturn = "IntPtr";
                // Check for existing get/set pair
                var setterSelector = ResolveSetterSelector(selectorInstances, selector);

                // If the property is a type that exists in C# then we can safely set the
                // return type to be that type, otherwise further conversion will be needed later
                if (Types.CSharpNativeTypes.Contains(Type))
                {
                    runtimeFuncReturn = Type;
                }

                var enumInstance = enumCache.Find(x => x.Name == Type);
                var structInstance = structCache.Find(x => x.Name == Type);

                var target = IsStatic ? $"new ObjectiveCClass(\"{ContainingClass.Name}\")" : "NativePtr";
                var modifier = IsStatic ? "static " : "";

                if (IsDeprecated)
                {
                    context.WriteLine("[System.Obsolete]");
                }

                if (setterSelector != null)
                {
                    setterSelector.UsedInProperty = true;
                    context.WriteLine($"public {modifier}{Type} {Name}");
                    context.EnterScope();

                    if (enumInstance != null)
                    {
                        type = enumInstance.Type;

                        context.WriteLine($"get => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend({target}, {selector.Name});");
                        context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, ({enumInstance.Type})value);");
                    }
                    else if (structInstance != null)
                    {
                        type = structInstance.Name;

                        context.WriteLine($"get => ObjectiveCRuntime.{structInstance.Name}_objc_msgSend({target}, {selector.Name});");
                        context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend({target}, {setterSelector.Name}, value);");
                    }
                    else
                    {
                        type = runtimeFuncReturn;

                        if (runtimeFuncReturn == "IntPtr")
                        {
                            context.WriteLine($"get => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend({target}, {selector.Name}));");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend({target}, {setterSelector.Name}, value);");
                        }
                        else
                        {
                            context.WriteLine($"get => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend({target}, {selector.Name});");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend({target}, {setterSelector.Name}, value);");
                        }
                    }

                    context.LeaveScope();
                }
                else
                {
                    if (enumInstance != null)
                    {
                        type = enumInstance.Type;

                        context.WriteLine($"public {modifier}{Type} {Name} => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend({target}, {selector.Name});");
                    }
                    else if (structInstance != null)
                    {
                        type = structInstance.Name;

                        context.WriteLine($"public {modifier}{Type} {Name} => ObjectiveCRuntime.{structInstance.Name}_objc_msgSend({target}, {selector.Name});");
                    }
                    else
                    {
                        type = runtimeFuncReturn;

                        if (runtimeFuncReturn == "IntPtr")
                        {
                            context.WriteLine($"public {modifier}{Type} {Name} => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend({target}, {selector.Name}));");
                        }
                        else
                        {
                            context.WriteLine($"public {modifier}{Type} {Name} => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend({target}, {selector.Name});");
                        }
                    }
                }
            }

            return new ObjectiveCInstance(type, []);
        }

        private static SelectorInstance? ResolveSetterSelector(List<SelectorInstance> selectorInstances, SelectorInstance selector)
        {
            // Try to match the "isFoo" + "setFoo" as a get/set property
            var setterSelectorNameCandidate = selector.Selector;
            if (setterSelectorNameCandidate.StartsWith("is"))
            {
                setterSelectorNameCandidate = setterSelectorNameCandidate.Substring(2);
            }
            setterSelectorNameCandidate = "set" + setterSelectorNameCandidate;
            var setterSelector = selectorInstances.Find(x => x.Selector.Contains(setterSelectorNameCandidate, StringComparison.InvariantCultureIgnoreCase));

            if (setterSelector == null)
            {
                // Fallback to setIsFoo, which apparently has some occurrences in the metal-cpp bindings
                setterSelectorNameCandidate = "set" + selector.Selector;
                setterSelector = selectorInstances.Find(x => x.Selector.Contains(setterSelectorNameCandidate, StringComparison.InvariantCultureIgnoreCase));
            }

            return setterSelector;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine($"public {Type} {Name};");
        }

        public bool Equals(PropertyInstance? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Type == other.Type && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((PropertyInstance)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type.GetHashCode() * 397) ^ Name.GetHashCode();
            }
        }
    }
}
