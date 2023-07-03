namespace SharpMetal.Generator.Instances
{
    public class PropertyInstance
    {
        public string Type;
        public string Name;

        public PropertyInstance(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public void Generate(StructInstance instance, List<EnumInstance> enumCache, CodeGenContext context)
        {
            var selector = instance.SelectorInstances.Find(x => x.Selector.ToLower() == Name.ToLower());

            if (selector == null)
            {
                // This can sometimes select the wrong selector, so we only want to use it as a backup
                selector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains(Name.ToLower()));
            }

            if (selector != null)
            {
                // We assume a type of IntPtr, which encapsulates any possible type
                var runtimeFuncReturn = "IntPtr";
                var setterSelector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains("set" + selector.Selector.ToLower()));

                // If the property is a type that exists in C# then we can safely set the
                // return type to be that type, otherwise further conversion will be needed later
                if (Types.CSharpNativeTypes.Contains(Type))
                {
                    runtimeFuncReturn = Type;
                }

                // Return type of IntPtr could either mean it returns a struct of some kind
                // or it returns an enum value, so we need to check if an enum with a matching
                // name exists.
                if (runtimeFuncReturn == "IntPtr")
                {
                    var enumInstance = enumCache.Find(x => x.Name == Type);

                    if (enumInstance != null)
                    {
                        if (setterSelector != null)
                        {
                            context.WriteLine($"public {Type} {Name}");
                            context.EnterScope();

                            context.WriteLine($"get => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, ({enumInstance.Type})value);");

                            context.LeaveScope();
                        }
                        else
                        {
                            context.WriteLine($"public {Type} {Name} => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                        }
                    }
                    else
                    {
                        if (setterSelector != null)
                        {
                            context.WriteLine($"public {Type} {Name}");
                            context.EnterScope();

                            context.WriteLine($"get => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");

                            context.LeaveScope();
                        }
                        else
                        {
                            context.WriteLine($"public {Type} {Name} => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                        }
                    }
                }
                else
                {
                    if (setterSelector != null)
                    {
                        context.WriteLine($"public {Type} {Name}");
                        context.EnterScope();

                        context.WriteLine($"get => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                        context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");

                        context.LeaveScope();
                    }
                    else
                    {
                        context.WriteLine($"public {Type} {Name} => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                    }
                }
            }
            else
            {
                context.WriteLine($"public {Type} {Name};");
            }
        }
    }
}