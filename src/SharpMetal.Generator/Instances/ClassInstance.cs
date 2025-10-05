using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class ClassInstance
    {
        public readonly string Name;
        private string _namespacePrefix = "";

        public bool HasAlloc { get; private set; }
        public bool HasInit { get; private set; }
        public string Parent { get; private set; } = string.Empty;
        public List<PropertyInstance> PropertyInstances { get; } = [];
        public List<MethodInstance> MethodInstances { get; } = [];
        public List<SelectorInstance> SelectorInstances { get; } = [];

        public bool IsValid => !string.IsNullOrWhiteSpace(Name);

        private ClassInstance(string name)
        {
            Name = name;
        }

        public void AddSelector(SelectorInstance selectorInstance)
        {
            if (!SelectorInstances.Exists(x => x.Selector == selectorInstance.Selector))
            {
                SelectorInstances.Add(selectorInstance);
            }
        }

        public void AddMethod(MethodInstance methodInstance)
        {
            foreach (var method in MethodInstances)
            {
                if (method.Name == methodInstance.Name)
                {
                    if (method.InputInstances.All(methodInstance.InputInstances.Contains) && methodInstance.InputInstances.All(method.InputInstances.Contains))
                    {
                        return;
                    }
                }
            }

            MethodInstances.Add(methodInstance);
        }

        public void AddProperty(PropertyInstance propertyInstance)
        {
            if (!PropertyInstances.Exists(x => x.Name == propertyInstance.Name))
            {
                PropertyInstances.Add(propertyInstance);
            }
        }

        public static ClassInstance Build(string classDeclarationLine, string namespacePrefix, StreamReader sr)
        {
            var classInfo = classDeclarationLine.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            if (classInfo.Length < 3)
            {
                Console.WriteLine($"BAD CLASS! {classDeclarationLine}");
                return new ClassInstance("");
            }

            var className = namespacePrefix + classInfo[1];
            var instance = new ClassInstance(className);

            if (classInfo[2] == ":")
            {
                var ancestorInfo = string.Join(" ", classInfo[3..]);
                var index = ancestorInfo.IndexOf('<');
                if (index >= 0)
                {
                    var info = ancestorInfo[index..];
                    info = info.Replace(">", "").Replace("<", "");
                    var ancestors = info.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 1; i < ancestors.Length; i++)
                    {
                        if (ancestors[i] != "_Base" && ancestors[i] != "Type" && ancestors[i] != "objc_object" && ancestors[i] != "Value")
                        {
                            instance.Parent = Types.ConvertType(ancestors[i], namespacePrefix);
                        }
                    }
                }
            }

            instance._namespacePrefix = namespacePrefix;

            var classEnded = false;
            var isDeprecated = false;

            while (!classEnded)
            {
                var nextLine = GeneratorUtils.ReadNextCodeLine(sr);

                if (nextLine == null)
                {
                    break;
                }

                if (nextLine.Contains('}') || nextLine.Contains("private:") || nextLine.Contains("protected:"))
                {
                    classEnded = true;
                    continue;
                }

                if (nextLine.Contains("[[deprecated"))
                {
                    isDeprecated = true;
                    continue;
                }

                // Ignore opening literals for scopes we are interested in
                if (nextLine is "{" or "public:")
                {
                    continue;
                }

                if (!StringUtils.IsValidFunctionSignature(nextLine))
                {
                    continue;
                }

                // Temp to not having to track all early returns
                var tempDeprecated = isDeprecated;
                isDeprecated = false;

                var rawName = nextLine;
                nextLine = StringUtils.FunctionSignatureCleanup(nextLine);

                var isStatic = false;

                if (nextLine.Contains("static "))
                {
                    isStatic = true;
                    nextLine = nextLine.Replace("static ", "");
                }

                var info = nextLine.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                var returnType = "";
                var name = "";
                var nameIndex = 0;

                for (var i = 0; i < info.Length; i++)
                {
                    if (info[i].Contains('('))
                    {
                        // This element is the function name
                        // everything before it is the returnType
                        nameIndex = i;
                        returnType = Types.ConvertType(string.Join(" ", info, 0, i), namespacePrefix);

                        var index = info[i].IndexOf('(');
                        if (index >= 0)
                        {
                            name = info[i][..index];
                        }
                    }
                }

                name = StringUtils.CamelToPascale(name);

                // Function has no arguments
                if (nextLine.Contains("()"))
                {
                    if (name == "Alloc")
                    {
                        instance.HasAlloc = true;
                        continue;
                    }

                    if (name == "Init")
                    {
                        instance.HasInit = true;
                        continue;
                    }

                    if (returnType == "void" || returnType == string.Empty)
                    {
                        // This is probably a constructor, in which case we have our own implementation
                        if (!returnType.Contains(name))
                        {
                            instance.AddMethod(new MethodInstance(returnType, name, rawName, isStatic, tempDeprecated, []));
                        }
                    }
                    else if (!(isStatic && returnType.Contains(name)))
                    {
                        instance.AddProperty(new PropertyInstance(instance, returnType, name, rawName, isStatic: isStatic, isDeprecated: tempDeprecated));
                    }
                }
                else
                {
                    var inputs = info[Range.StartAt(nameIndex)];
                    var inputString = string.Join(" ", inputs);

                    // Remove everything before and including (
                    var startIndex = inputString.IndexOf('(');
                    if (startIndex >= 0)
                    {
                        inputString = inputString[(startIndex + 1)..];
                    }

                    // Remove everything after and include )
                    var endIndex = inputString.IndexOf(')');
                    if (endIndex >= 0)
                    {
                        inputString = inputString[..endIndex];
                    }

                    var inputArguments = inputString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    List<FunctionParameterInstance> arguments = [];

                    foreach (var argument in inputArguments)
                    {
                        var array = argument.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        var argumentType = Types.ConvertType(string.Join(" ", array[..^1]), namespacePrefix);
                        var argumentName = array.Last();
                        var reference = false;

                        // TODO: Fix array inputs
                        // Might need to be NSArray
                        if (argumentName.Contains("[]"))
                        {
                            argumentType += "[]";
                            argumentName = argumentName.Replace("[]", "");
                        }

                        // String is a keyword in C#
                        if (argumentName == "string")
                        {
                            argumentName = "nsString";
                        }

                        // Event is a keyword in C#
                        if (argumentName == "event")
                        {
                            argumentName = "mtlEvent";
                        }

                        if (argumentType == "NSError")
                        {
                            reference = true;
                        }

                        arguments.Add(new FunctionParameterInstance(argumentType, argumentName, reference));
                    }

                    if (returnType != string.Empty)
                    {
                        instance.AddMethod(new MethodInstance(returnType, name, rawName, isStatic, tempDeprecated, arguments));
                    }
                }

                for (var i = instance.PropertyInstances.Count - 1; i >= 0; i--)
                {
                    var property = instance.PropertyInstances[i];
                    if (instance.MethodInstances.Exists(x => x.Name == property.Name))
                    {
                        // We can't have a property AND methods with the same name
                        // in this case, the solution is to turn the property into a method
                        instance.PropertyInstances.RemoveAt(i);
                        instance.AddMethod(new MethodInstance(property.Type, property.Name, property.RawName, property.IsStatic, property.IsDeprecated, []));
                    }
                }
            }

            return instance;
        }
    }
}
