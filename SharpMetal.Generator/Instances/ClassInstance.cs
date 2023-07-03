using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class ClassInstance : IPropertyOwner
    {
        public string Name { get; set; }
        public bool HasAlloc;
        public bool HasInit;
        private List<PropertyInstance> _propertyInstances;
        private List<MethodInstance> _methodInstances;
        private List<SelectorInstance> _selectorInstances;

        private ClassInstance(string name)
        {
            Name = name;
            _selectorInstances = new();
            _methodInstances = new();
            _propertyInstances = new();
        }

        public void AddSelector(SelectorInstance selectorInstance)
        {
            if (!_selectorInstances.Exists(x => x.Selector == selectorInstance.Selector))
            {
                _selectorInstances.Add(selectorInstance);
            }
        }

        public void AddMethod(MethodInstance methodInstance)
        {
            bool methodExists = false;

            foreach (var method in _methodInstances)
            {
                if (method.Name == methodInstance.Name)
                {
                    if (method.InputInstances.All(methodInstance.InputInstances.Contains) && methodInstance.InputInstances.All(method.InputInstances.Contains))
                    {
                        return;
                    }
                }
            }

            _methodInstances.Add(methodInstance);
        }

        public void AddProperty(PropertyInstance propertyInstance)
        {
            if (!_propertyInstances.Exists(x => x.Name == propertyInstance.Name))
            {
                _propertyInstances.Add(propertyInstance);
            }
        }

        public void Generate(List<EnumInstance> enumCache, CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");

            context.WriteLine($"public class {Name}");
            context.EnterScope();

            context.WriteLine("public readonly IntPtr NativePtr;");
            context.WriteLine($"public static implicit operator IntPtr({Name} obj) => obj.NativePtr;");
            context.WriteLine($"public {Name}(IntPtr ptr) => NativePtr = ptr;");

            if (HasAlloc)
            {
                context.WriteLine();
                context.WriteLine($"public {Name}()");
                context.EnterScope();

                context.WriteLine($"var cls = new ObjectiveCClass(\"{Name}\");");

                if (HasInit)
                {
                    context.WriteLine("NativePtr = cls.AllocInit();");
                }
                else
                {
                    context.WriteLine("NativePtr = cls.Alloc();");
                }

                context.LeaveScope();
            }

            if (_propertyInstances.Any())
            {
                context.WriteLine();
            }

            for (var j = 0; j < _propertyInstances.Count; j++)
            {
                _propertyInstances[j].Generate(this, enumCache, context);

                if (j != _propertyInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            foreach (var method in _methodInstances)
            {
                method.Generate(context);
            }

            if (_selectorInstances.Any())
            {
                context.WriteLine();
            }

            foreach (var selector in _selectorInstances)
            {
                context.WriteLine($"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            }

            context.LeaveScope();
        }

        public static ClassInstance Build(string line, string namespacePrefix, StreamReader sr, List<MethodInstance> inFlightUnscopedMethods)
        {
            var classInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var className = namespacePrefix + classInfo[1];

            var instance = new ClassInstance(className);
            // TODO: Add selectors
            instance._methodInstances.AddRange(inFlightUnscopedMethods);

            bool classEnded = false;
            bool enteredComment = false;

            while (!classEnded)
            {
                var nextLine = sr.ReadLine();

                if (nextLine.Contains("/**"))
                {
                    enteredComment = true;
                    continue;
                }

                if (enteredComment)
                {
                    if (nextLine.Contains("*/"))
                    {
                        enteredComment = false;
                    }
                    continue;
                }

                if (nextLine.Contains('}') || nextLine.Contains("private:") || nextLine.Contains("protected:"))
                {
                    classEnded = true;
                    continue;
                }

                // Ignore empty lines etc...
                if (nextLine == String.Empty || nextLine == "{" || nextLine == "public:")
                {
                    continue;
                }

                if (!StringUtils.IsValidFunctionSignature(nextLine))
                {
                    continue;
                }

                nextLine = StringUtils.FunctionSignautreCleanup(nextLine);

                bool isStatic = false;

                if (nextLine.Contains("static "))
                {
                    isStatic = true;
                    nextLine = nextLine.Replace("static ", "");
                }

                var info = nextLine.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                var returnType = "";
                var name = "";
                var nameIndex = 0;

                for (int i = 0; i < info.Length; i++)
                {
                    if (info[i].Contains("("))
                    {
                        // This element is the function name
                        // everything before it is the returnType
                        nameIndex = i;
                        returnType = Types.ConvertType(string.Join(" ", info, 0, i), namespacePrefix);

                        int index = info[i].IndexOf("(");
                        if (index >= 0)
                        {
                            name = info[i].Substring(0, index);
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

                    if (returnType == "void" || returnType == string.Empty || isStatic)
                    {
                        // This is probably a constructor, in which case we have our own implementation
                        if (!returnType.Contains(name))
                        {
                            instance.AddMethod(new MethodInstance(returnType, name, "", isStatic, new List<PropertyInstance>()));
                        }
                    }
                    else
                    {
                        instance.AddProperty(new PropertyInstance(returnType, name));
                    }
                }
                else
                {
                    var inputs = info[Range.StartAt(nameIndex)];
                    var inputString = String.Join(" ", inputs);

                    // Remove everything before and including (
                    int startIndex = inputString.IndexOf("(");
                    if (startIndex >= 0)
                    {
                        inputString = inputString.Substring(startIndex + 1);
                    }

                    // Remove everything after and include )
                    int endIndex = inputString.IndexOf(")");
                    if (endIndex >= 0)
                    {
                        inputString = inputString.Substring(0, endIndex);
                    }

                    var inputArguments = inputString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    List<PropertyInstance> arguments = new();

                    foreach (var argument in inputArguments)
                    {
                        var array = argument.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        var argumentType = Types.ConvertType(string.Join(" ", array[..^1]), namespacePrefix);
                        var argumentName = array.Last();

                        // Fix array inputs
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
                            argumentName = "mltEvent";
                        }

                        arguments.Add(new PropertyInstance(argumentType, argumentName));
                    }

                    if (returnType != string.Empty)
                    {
                        instance.AddMethod(new MethodInstance(returnType, name, "", isStatic, arguments));
                    }
                }

                for (int i = instance._propertyInstances.Count - 1; i >= 0; i--)
                {
                    var property = instance._propertyInstances[i];
                    if (instance._methodInstances.Exists(x => x.Name == property.Name))
                    {
                        // We can't have a property AND methods with the same name
                        // in this case, the solution is to turn the property into a method
                        instance._propertyInstances.RemoveAt(i);
                        instance.AddMethod(new MethodInstance(property.Type, property.Name, "", isStatic, new List<PropertyInstance>()));
                    }
                }
            }

            return instance;
        }

        public List<SelectorInstance> GetSelectors()
        {
            return _selectorInstances;
        }
    }
}