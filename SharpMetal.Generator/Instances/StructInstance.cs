using System.Globalization;
using System.Text.RegularExpressions;

namespace SharpMetal.Generator.Instances
{
    public partial class StructInstance
    {
        public string Name;
        public bool IsClass;
        public bool HasAlloc;
        public bool HasInit;
        public List<PropertyInstance> PropertyInstances;
        public List<MethodInstance> MethodInstances;
        public List<SelectorInstance> SelectorInstances;

        public StructInstance(string name, bool isClass)
        {
            Name = name;
            IsClass = isClass;
            SelectorInstances = new();
            MethodInstances = new();
            PropertyInstances = new();
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
            if (!MethodInstances.Exists(x => x.Name == methodInstance.Name && x.InputInstances == methodInstance.InputInstances))
            {
                MethodInstances.Add(methodInstance);
            }
        }

        public void AddProperty(PropertyInstance propertyInstance)
        {
            // We don't want to include functions in this pass
            if (propertyInstance.Name.Contains("("))
            {
                return;
            }

            if (!PropertyInstances.Exists(x => x.Name == propertyInstance.Name))
            {
                PropertyInstances.Add(propertyInstance);
            }
        }

        public void Generate(List<EnumCacheInstance> enumCache, CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");

            if (!IsClass)
            {
                context.WriteLine("[StructLayout(LayoutKind.Sequential)]");
            }

            context.WriteLine($"public struct {Name}");
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

            if (PropertyInstances.Any())
            {
                context.WriteLine();
            }

            for (var j = 0; j < PropertyInstances.Count; j++)
            {
                PropertyInstances[j].Generate(this, enumCache, context);

                if (j != PropertyInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            foreach (var method in MethodInstances)
            {
                context.WriteLine();
                context.Write(context.Indentation + $"public {method.ReturnType} {method.Name}(");

                for (var i = 0; i < method.InputInstances.Count; i++)
                {
                    var input = method.InputInstances[i];

                    context.Write($"{input.Type} {input.Name}");

                    if (i != method.InputInstances.Count - 1)
                    {
                        context.Write(", ");
                    }
                }

                context.Write(") {\n");
                context.WriteLine();
                context.WriteLine("}");
            }

            if (SelectorInstances.Any())
            {
                context.WriteLine();
            }

            foreach (var selector in SelectorInstances)
            {
                context.WriteLine($"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            }

            context.LeaveScope();
        }

        public static StructInstance Build(string line, string namespacePrefix, StreamReader sr) {
            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var structName = namespacePrefix + structInfo[1];

            var instance = new StructInstance(structName, false);

            bool structEnded = false;
            sr.ReadLine();

            while (!structEnded)
            {
                var propertyLine = sr.ReadLine();
                if (propertyLine.Contains('}'))
                {
                    structEnded = true;
                    continue;
                }

                if (propertyLine.Contains('(') && propertyLine.Contains(')')) continue;

                var propertyInfo = propertyLine.Replace(";", "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                if (propertyInfo.Length != 2) continue;

                var typeString = propertyInfo[0].Replace("::", "");
                var type = Types.ConvertType(typeString, namespacePrefix);
                var propertyName = propertyInfo[1];

                string pattern = @"\[.*?\]";
                propertyName = Regex.Replace(propertyName, pattern, "");

                instance.AddProperty(new PropertyInstance(type, propertyName));
            }

            return instance;
        }

        public static StructInstance BuildClass(string line, string namespacePrefix, StreamReader sr)
        {
            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var structName = namespacePrefix + structInfo[1];

            var instance = new StructInstance(structName, true);

            bool structEnded = false;
            bool enteredComment = false;

            while (!structEnded)
            {
                var nextLine = sr.ReadLine();

                if (nextLine.Contains('}') || nextLine.Contains("private:") || nextLine.Contains("protected:"))
                {
                    structEnded = true;
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

                if (nextLine.Contains("template") || nextLine.Contains("typename") || nextLine.Contains("operator"))
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
                    var info = CultureInfo.CurrentCulture.TextInfo;
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
                        instance.MethodInstances.Add(MethodInstance.BuildMethod(parts, namespacePrefix));
                    }
                    else
                    {
                        Console.WriteLine($"Failed to find \"(\" in \"{parts[1]}\"");
                    }
                }
            }

            return instance;
        }

        [GeneratedRegex("(?<!\\(.*)\\s+(?![^(]*\\))|\\s+(?![^(]*?\\))")]
        private static partial Regex ClassRegex();
    }
}