namespace SharpMetal.Generator.Instances
{
    public class PropertyInstance : IEquatable<PropertyInstance>
    {
        public string Type;
        public string Name;

        public PropertyInstance(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public ObjectiveCInstance Generate(List<SelectorInstance> selectorInstances, List<EnumInstance> enumCache, List<StructInstance> structCache, CodeGenContext context)
        {
            var selector = selectorInstances.Find(x => x.Selector.ToLower() == Name.ToLower());
            var objcInstance = new ObjectiveCInstance("", new List<string>());

            if (selector == null)
            {
                // This can sometimes select the wrong selector, so we only want to use it as a backup
                selector = selectorInstances.Find(x => x.Selector.ToLower().Contains(Name.ToLower()));
            }

            if (selector != null)
            {
                selectorInstances.Remove(selector);
                // We assume a type of IntPtr, which encapsulates any possible type
                var runtimeFuncReturn = "IntPtr";
                var setterSelector = selectorInstances.Find(x => x.Selector.ToLower().Contains("set" + selector.Selector.ToLower()));

                // If the property is a type that exists in C# then we can safely set the
                // return type to be that type, otherwise further conversion will be needed later
                if (Types.CSharpNativeTypes.Contains(Type))
                {
                    runtimeFuncReturn = Type;
                }

                var enumInstance = enumCache.Find(x => x.Name == Type);
                var structInstance = structCache.Find(x => x.Name == Type);

                if (setterSelector != null)
                {
                    selectorInstances.Remove(setterSelector);
                    context.WriteLine($"public {Type} {Name}");
                    context.EnterScope();

                    if (enumInstance != null)
                    {
                        objcInstance.Type = enumInstance.Type;

                        context.WriteLine($"get => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                        context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, ({enumInstance.Type})value);");
                    }
                    else if (structInstance != null)
                    {
                        objcInstance.Type = structInstance.Name;

                        context.WriteLine($"get => ObjectiveCRuntime.{structInstance.Name}_objc_msgSend(NativePtr, {selector.Name});");
                        context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");
                    }
                    else
                    {
                        objcInstance.Type = runtimeFuncReturn;

                        if (runtimeFuncReturn == "IntPtr")
                        {
                            context.WriteLine($"get => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");
                        }
                        else
                        {
                            context.WriteLine($"get => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");
                        }
                    }

                    context.LeaveScope();
                }
                else
                {
                    if (enumInstance != null)
                    {
                        context.WriteLine($"public {Type} {Name} => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                    }
                    else if (structInstance != null)
                    {
                        context.WriteLine($"public {Type} {Name} => ObjectiveCRuntime.{structInstance.Name}_objc_msgSend(NativePtr, {selector.Name});");
                    }
                    else
                    {
                        if (runtimeFuncReturn == "IntPtr")
                        {
                            context.WriteLine($"public {Type} {Name} => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                        }
                        else
                        {
                            context.WriteLine($"public {Type} {Name} => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                        }
                    }
                }
            }

            return objcInstance;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine($"public {Type} {Name};");
        }

        public bool Equals(PropertyInstance? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Type == other.Type && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
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