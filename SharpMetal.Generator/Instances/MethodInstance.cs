namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public string ReturnType;
        public string Name;
        public string RawName;
        public bool IsStatic;
        public List<PropertyInstance> InputInstances;

        public MethodInstance(string returnType, string name, string rawName, bool isStatic, List<PropertyInstance> inputInstances)
        {
            ReturnType = returnType;
            Name = name;
            RawName = rawName;
            IsStatic = isStatic;
            InputInstances = inputInstances;
        }

        public ObjectiveCInstance Generate(List<SelectorInstance> selectorInstances, List<EnumInstance> enumCache, List<StructInstance> structCache, CodeGenContext context, string namespacePrefix, bool prependSpace = true)
        {
            var rawNameComponents = RawName.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            for (var index = 0; index < rawNameComponents.Length; index++)
            {
                var component = rawNameComponents[index];
                if (component.Contains("("))
                {
                    var splitIndex = RawName.IndexOf(component);
                    if (splitIndex >= 0)
                    {
                        RawName = RawName.Substring(splitIndex, RawName.Length - splitIndex);
                    }
                }
            }

            // TODO: Clean this up
            RawName = RawName.Replace(";", "");
            RawName = RawName.Replace(" class ", " ");
            RawName = RawName.Replace("(class ", "(");
            RawName = RawName.Replace("MTL::", "");
            RawName = RawName.Replace("NS::", "");

            var selector = selectorInstances.Find(x => x.RawName.ToLower().Replace(" class ", " ").Replace("mtl::", "").Replace("ns::", "").Contains(RawName.ToLower()));

            if (selector == null)
            {
                // if (RawName != "lock()" && RawName != "unlock()" && RawName != "release()")
                // {
                //     if (prependSpace)
                //     {
                //         context.WriteLine();
                //     }
                //     context.WriteLine("[LibraryImport(ObjectiveC.MetalFramework)]");
                //     context.WriteLine($"private static partial IntPtr {namespacePrefix}{RawName};");
                //     context.WriteLine();
                //     context.WriteLine($"public static {ReturnType} {RawName}");
                //     context.EnterScope();
                //     context.WriteLine($"return new({namespacePrefix}{RawName});");
                //     context.LeaveScope();
                // }
            }
            else
            {
                var staticString = IsStatic ? "static " : "";
                // TODO: Handle array inputs
                var hasArrayInput = false;

                if (prependSpace)
                {
                    context.WriteLine();
                }
                context.Write(context.Indentation + $"public {staticString}{ReturnType} {Name}(");

                for (var i = 0; i < InputInstances.Count; i++)
                {
                    var input = InputInstances[i];

                    if (input.Type.Contains("[]"))
                    {
                        hasArrayInput = true;
                    }

                    context.Write($"{input.Type} {input.Name}");

                    if (i != InputInstances.Count - 1)
                    {
                        context.Write(", ");
                    }
                }

                context.Write(")\n");
                context.EnterScope();
                if (ReturnType == "void" && !hasArrayInput)
                {
                    if (IsStatic)
                    {
                        context.WriteLine("throw new NotSupportedException();");
                    }
                    else
                    {
                        context.Write($"{context.Indentation}ObjectiveCRuntime.objc_msgSend(NativePtr, {selector.Name}");

                        for (var index = 0; index < InputInstances.Count; index++)
                        {
                            var cast = "";
                            var enumInstance = enumCache.Find(x => x.Name == InputInstances[index].Type);

                            if (enumInstance != null)
                            {
                                cast = $"({enumInstance.Type})";
                            }

                            context.Write($", {cast}{InputInstances[index].Name}");
                        }
                        context.Write(");\n");
                    }
                }
                else if (!hasArrayInput)
                {
                    context.Write($"{context.Indentation}return ");
                    var returnEnum = enumCache.Find(x => x.Name == ReturnType);
                    var returnStruct = structCache.Find(x => x.Name == ReturnType);
                    var needsOuterBracket = false;

                    if (returnEnum != null)
                    {
                        context.Write($"({ReturnType})ObjectiveCRuntime.{returnEnum.Type}_");
                    }
                    else
                    {
                        if (Types.CSharpNativeTypes.Contains(ReturnType) || returnStruct != null)
                        {
                            context.Write($"ObjectiveCRuntime.{ReturnType}_");
                        }
                        else
                        {
                            context.Write($"new(ObjectiveCRuntime.IntPtr_");
                            needsOuterBracket = true;
                        }
                    }

                    context.Write($"objc_msgSend(");

                    if (IsStatic)
                    {
                        context.Write($"new ObjectiveCClass(\"{ReturnType}\")");
                    }
                    else
                    {
                        context.Write("NativePtr");
                    }

                    context.Write($", {selector.Name}");

                    for (var index = 0; index < InputInstances.Count; index++)
                    {
                        var cast = "";
                        var enumInstance = enumCache.Find(x => x.Name == InputInstances[index].Type);

                        if (enumInstance != null)
                        {
                            cast = $"({enumInstance.Type})";
                        }

                        context.Write($", {cast}{InputInstances[index].Name}");
                    }

                    if (needsOuterBracket)
                    {
                        context.Write(")");
                    }

                    context.Write(");\n");
                }
                else
                {
                    context.WriteLine("throw new NotImplementedException();");
                }
                context.LeaveScope();
            }

            ObjectiveCInstance objcInstance = new ObjectiveCInstance("", new List<string>());
            for (var i = 0; i < InputInstances.Count; i++)
            {
                if (Types.CSharpNativeTypes.Contains(InputInstances[i].Type))
                {
                    objcInstance.Inputs.Add(InputInstances[i].Type);
                }
                else
                {
                    var enumInstance = enumCache.Find(x => x.Name == InputInstances[i].Type);
                    var structInstance = structCache.Find(x => x.Name == InputInstances[i].Type);

                    if (enumInstance != null)
                    {
                        objcInstance.Inputs.Add(enumInstance.Type);
                    }
                    else if (structInstance != null)
                    {
                        objcInstance.Inputs.Add(structInstance.Name);
                    }
                    else
                    {
                        objcInstance.Inputs.Add("IntPtr");
                    }
                }
            }

            if (ReturnType == "void")
            {
                objcInstance.Type = ReturnType;
            }
            else
            {
                var returnStruct = structCache.Find(x => x.Name == ReturnType);
                if (Types.CSharpNativeTypes.Contains(ReturnType) || returnStruct != null)
                {
                    objcInstance.Type = ReturnType;
                }
                else
                {
                    var returnEnum = enumCache.Find(x => x.Name == ReturnType);
                    if (returnEnum != null)
                    {
                        objcInstance.Type = returnEnum.Type;
                    }
                    else
                    {
                        objcInstance.Type = "IntPtr";
                    }
                }
            }

            return objcInstance;
        }
    }
}