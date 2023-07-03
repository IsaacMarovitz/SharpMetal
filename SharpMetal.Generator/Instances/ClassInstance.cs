using System.Text.RegularExpressions;

namespace SharpMetal.Generator.Instances
{
    public partial class ClassInstance : IPropertyOwner
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
            // We don't want to include functions in this pass
            if (propertyInstance.Name.Contains("("))
            {
                return;
            }

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

        public static ClassInstance Build(string line, string namespacePrefix, StreamReader sr)
        {
            var classInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var className = namespacePrefix + classInfo[1];

            var instance = new ClassInstance(className);

            bool classEnded = false;
            bool enteredComment = false;

            while (!classEnded)
            {
                var nextLine = sr.ReadLine();

                if (nextLine.Contains('}') || nextLine.Contains("private:") || nextLine.Contains("protected:"))
                {
                    classEnded = true;
                    continue;
                }

                if (nextLine == "/**")
                {
                    enteredComment = true;
                    continue;
                }

                if (nextLine == "*/")
                {
                    enteredComment = false;
                    continue;
                }

                if (enteredComment)
                {
                    continue;
                }

                // Ignore empty lines etc...
                if (nextLine == String.Empty || nextLine == "{" || nextLine == "public:")
                {
                    continue;
                }

                if (nextLine.Contains("template") || nextLine.Contains("typename") || nextLine.Contains("operator") || nextLine.Contains("Handler") || nextLine.Contains("Observer"))
                {
                    continue;
                }

                nextLine = nextLine.Replace(";", "");
                nextLine = nextLine.Replace("~", "Destroy");
                nextLine = nextLine.Replace("::", "");
                nextLine = nextLine.Replace("void*", "IntPtr");
                nextLine = nextLine.Replace("void()", "void");
                nextLine = nextLine.Replace("*", "");
                nextLine = nextLine.Replace("class ", "");
                nextLine = nextLine.Replace("const ", "");
                nextLine = nextLine.Replace("static ", "");

                var parts = ClassRegex().Split(nextLine).ToList();

                parts.RemoveAll(x => x == string.Empty);

                if (parts.Count < 2)
                {
                    continue;
                }

                // Method has no parameters, i.e. readonly property
                var index = parts.FindIndex(x => x.Contains("()"));

                if (index != -1)
                {
                    var type = "";

                    for (int i = 0; i < index; i++)
                    {
                        type += parts[i] + " ";
                    }

                    type = type.TrimEnd();

                    if (type == "void")
                    {
                        continue;
                    }

                    type = Types.ConvertType(type, namespacePrefix);

                    var name = parts[index].Replace("()", "");
                    name = Regex.Replace(name, @"\b\p{Ll}", match => match.Value.ToUpper());

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

                    instance.AddProperty(new PropertyInstance(type, name));
                }
                else
                {
                    // Method has inputs
                    var parenIndex = parts[1].IndexOf("(");
                    if (parenIndex != -1)
                    {
                        var method = MethodInstance.BuildMethod(parts, namespacePrefix);
                        if (method != null)
                        {
                            instance.AddMethod(method);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to find \"(\" in \"{parts[1]}\"");
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
                        instance.AddMethod(new MethodInstance(property.Type, property.Name, new List<PropertyInstance>()));
                    }
                }
            }

            return instance;
        }

        public List<SelectorInstance> GetSelectors()
        {
            return _selectorInstances;
        }

        [GeneratedRegex("(?<!\\(.*)\\s+(?![^(]*\\))|\\s+(?![^(]*?\\))")]
        private static partial Regex ClassRegex();
    }
}