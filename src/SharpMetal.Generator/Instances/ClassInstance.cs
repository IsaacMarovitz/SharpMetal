using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class ClassInstance
    {
        public string Name { get; set; }
        public string NamespacePrefix = "";
        public bool HasAlloc;
        public bool HasInit;
        private List<PropertyInstance> _propertyInstances;
        private List<MethodInstance> _methodInstances;
        private List<SelectorInstance> _selectorInstances;
        private string _parent = string.Empty;

        public List<PropertyInstance> PropertyInstances => _propertyInstances;
        public List<MethodInstance> MethodInstances => _methodInstances;
        public List<SelectorInstance> SelectorInstances => _selectorInstances;

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

        public List<ObjectiveCInstance> Generate(List<ClassInstance> classCache, List<EnumInstance> enumCache, List<StructInstance> structCache, CodeGenContext context)
        {
            if (_parent != string.Empty)
            {
                // To properly fit within expected C# patterns, we
                // should generate an interface to hold the associated
                // properties and methods to allow for proper casting
                // between types. Right now, due to the limitations of
                // struct inheritance, we will just duplicate all
                // properties and methods from the parent to the child.
                // This limitation is not present with the old method
                // using classes, however that comes with performance
                // and memory drawbacks, that structs are able to avoid.

                var parent = classCache.FirstOrDefault(x => x.Name == _parent);
                _propertyInstances.AddRange(parent.PropertyInstances);
                _methodInstances.AddRange(parent.MethodInstances);
                _selectorInstances.AddRange(parent.SelectorInstances);
            }

            var objectiveCInstances = new List<ObjectiveCInstance>();

            context.WriteLine("[SupportedOSPlatform(\"macos\")]");

            // TODO: Handle LibraryImport usage on MTLDevice (requires partial)
            var classDecl = $"public struct {Name} : IDisposable";

            context.WriteLine(classDecl);

            context.EnterScope();

            context.WriteLine("public IntPtr NativePtr;");
            context.WriteLine($"public static implicit operator IntPtr({Name} obj) => obj.NativePtr;");
            if (_parent != string.Empty)
            {
                context.WriteLine($"public static implicit operator {_parent}({Name} obj) => new(obj.NativePtr);");
            }
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

            context.WriteLine();
            context.WriteLine("public void Dispose()");
            context.EnterScope();

            context.WriteLine("ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);");

            context.LeaveScope();

            if (_propertyInstances.Any())
            {
                context.WriteLine();
            }

            var selectorInstances = new List<SelectorInstance>(_selectorInstances);

            for (var j = 0; j < _propertyInstances.Count; j++)
            {
                objectiveCInstances.Add(_propertyInstances[j].Generate(selectorInstances, enumCache, structCache, context));

                if (j != _propertyInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            foreach (var method in _methodInstances)
            {
                objectiveCInstances.Add(method.Generate(selectorInstances, enumCache, structCache, context, NamespacePrefix));
            }

            if (_selectorInstances.Any())
            {
                context.WriteLine();
            }

            foreach (var selector in _selectorInstances)
            {
                context.WriteLine($"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            }

            context.WriteLine($"private static readonly Selector sel_release = \"release\";");

            context.LeaveScope();
            return objectiveCInstances;
        }

        public static ClassInstance Build(string line, string namespacePrefix, StreamReader sr, List<MethodInstance> inFlightUnscopedMethods)
        {
            var classInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            if (classInfo.Length < 3)
            {
                Console.WriteLine($"BAD CLASS! {line}");
                return new ClassInstance("");
            }

            var className = namespacePrefix + classInfo[1];
            var instance = new ClassInstance(className);

            if (classInfo[2] == ":")
            {
                var ancestorInfo = string.Join(" ", classInfo[3..]);
                int index = ancestorInfo.IndexOf("<");
                if (index >= 0)
                {
                    var info = ancestorInfo.Substring(index);
                    info = info.Replace(">", "").Replace("<", "");
                    var ancestors = info.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < ancestors.Length; i++)
                    {
                        if (i > 0)
                        {
                            if (ancestors[i] != "_Base" && ancestors[i] != "Type" && ancestors[i] != "objc_object" &&
                                ancestors[i] != "Value")
                            {
                                instance._parent = Types.ConvertType(ancestors[i], namespacePrefix);
                            }
                        }
                    }
                }
            }

            instance._methodInstances.AddRange(inFlightUnscopedMethods);
            instance.NamespacePrefix = namespacePrefix;

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

                var rawName = nextLine;
                nextLine = StringUtils.FunctionSignatureCleanup(nextLine);

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
                            instance.AddMethod(new MethodInstance(returnType, name, rawName, isStatic, false, new List<PropertyInstance>()));
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

                        arguments.Add(new PropertyInstance(argumentType, argumentName, reference));
                    }

                    if (returnType != string.Empty)
                    {
                        instance.AddMethod(new MethodInstance(returnType, name, rawName, isStatic, false, arguments));
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
                        instance.AddMethod(new MethodInstance(property.Type, property.Name, rawName, isStatic, false, new List<PropertyInstance>()));
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
