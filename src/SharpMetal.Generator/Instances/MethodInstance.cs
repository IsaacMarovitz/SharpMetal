namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public readonly string Name;
        public readonly List<FunctionParameterInstance> InputInstances;

        private readonly string _returnType;
        private readonly bool _isStatic;
        private readonly string _rawName;
        private readonly bool _isDeprecated;

        public MethodInstance(string returnType, string name, string rawName, bool isStatic, bool isDeprecated, List<FunctionParameterInstance> inputInstances)
        {
            Name = name;
            InputInstances = inputInstances;

            _returnType = returnType;
            _isStatic = isStatic;
            _isDeprecated = isDeprecated;

            var rawNameComponents = rawName.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            for (var index = 0; index < rawNameComponents.Length; index++)
            {
                var component = rawNameComponents[index];
                if (component.Contains('('))
                {
                    var splitIndex = rawName.IndexOf(component);
                    if (splitIndex >= 0)
                    {
                        rawName = rawName.Substring(splitIndex, rawName.Length - splitIndex);
                    }
                }
            }

            // TODO: Clean this up
            rawName = rawName.Replace(";", "");
            rawName = rawName.Replace(" class ", " ");
            rawName = rawName.Replace("(class ", "(");
            rawName = rawName.Replace("MTL::", "");
            rawName = rawName.Replace("NS::", "");

            _rawName = rawName;
        }

        public ObjectiveCInstance Generate(List<SelectorInstance> selectorInstances, List<EnumInstance> enumCache, List<StructInstance> structCache, CodeGenContext context, string namespacePrefix, bool prependSpace = true)
        {
            // Disallow the selectors used in properties to prevent doubling of properties and methods that do the same
            var selector = selectorInstances.Find(x => !x.UsedInProperty && x.RawName.ToLower().Replace(" class ", " ").Replace("mtl::", "").Replace("ns::", "").Contains(_rawName.ToLower()));

            if (selector != null)
            {
                var staticString = _isStatic ? "static " : "";
                // TODO: Handle array inputs
                var hasArrayInput = false;

                if (prependSpace)
                {
                    context.WriteLine();
                }
                context.Write(context.Indentation + $"public {staticString}{_returnType} {Name}(");

                for (var i = 0; i < InputInstances.Count; i++)
                {
                    var input = InputInstances[i];

                    if (input.Type.Contains("[]"))
                    {
                        hasArrayInput = true;
                    }

                    context.Write($"{(input.Reference ? "ref " : "")}{input.Type} {input.Name}");

                    if (i != InputInstances.Count - 1)
                    {
                        context.Write(", ");
                    }
                }

                context.Write(")\n");
                context.EnterScope();
                if (_returnType == "void" && !hasArrayInput)
                {
                    if (_isStatic)
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
                    var returnEnum = enumCache.Find(x => x.Name == _returnType);
                    var returnStruct = structCache.Find(x => x.Name == _returnType);
                    var needsOuterBracket = false;

                    if (returnEnum != null)
                    {
                        context.Write($"({_returnType})ObjectiveCRuntime.{returnEnum.Type}_");
                    }
                    else
                    {
                        if (Types.CSharpNativeTypes.Contains(_returnType) || returnStruct != null)
                        {
                            context.Write($"ObjectiveCRuntime.{_returnType}_");
                        }
                        else
                        {
                            context.Write($"new(ObjectiveCRuntime.IntPtr_");
                            needsOuterBracket = true;
                        }
                    }

                    context.Write($"objc_msgSend(");

                    if (_isStatic)
                    {
                        context.Write($"new ObjectiveCClass(\"{_returnType}\")");
                    }
                    else
                    {
                        context.Write("NativePtr");
                    }

                    context.Write($", {selector.Name}");

                    for (var index = 0; index < InputInstances.Count; index++)
                    {
                        var enumInstance = enumCache.Find(x => x.Name == InputInstances[index].Type);
                        var input = InputInstances[index];

                        if (enumInstance != null)
                        {
                            context.Write($", ({enumInstance.Type}){input.Name}");
                        }
                        else if (input.Reference)
                        {
                            context.Write($", ref {input.Name}.NativePtr");
                        }
                        else
                        {
                            context.Write($", {input.Name}");
                        }
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

            string type;
            List<string> inputs = [];

            for (var i = 0; i < InputInstances.Count; i++)
            {
                if (Types.CSharpNativeTypes.Contains(InputInstances[i].Type))
                {
                    inputs.Add(InputInstances[i].Type);
                }
                else
                {
                    var enumInstance = enumCache.Find(x => x.Name == InputInstances[i].Type);
                    var structInstance = structCache.Find(x => x.Name == InputInstances[i].Type);

                    if (enumInstance != null)
                    {
                        inputs.Add(enumInstance.Type);
                    }
                    else if (structInstance != null)
                    {
                        inputs.Add(structInstance.Name);
                    }
                    else if (InputInstances[i].Type == "NSError")
                    {
                        inputs.Add("ref IntPtr");
                    }
                    else
                    {
                        inputs.Add("IntPtr");
                    }
                }
            }

            if (_returnType == "void")
            {
                type = _returnType;
            }
            else
            {
                var returnStruct = structCache.Find(x => x.Name == _returnType);
                if (Types.CSharpNativeTypes.Contains(_returnType) || returnStruct != null)
                {
                    type = _returnType;
                }
                else
                {
                    var returnEnum = enumCache.Find(x => x.Name == _returnType);
                    if (returnEnum != null)
                    {
                        type = returnEnum.Type;
                    }
                    else
                    {
                        type = "IntPtr";
                    }
                }
            }

            return new ObjectiveCInstance(type, inputs);
        }
    }
}
