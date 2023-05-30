using System.Globalization;
using System.Text.RegularExpressions;

namespace SharpMetal.Generator
{
    public partial class HeaderInfo
    {
        public List<EnumInstance> EnumInstances = new();
        public List<StructInstance> StructInstances = new();

        public static string ConvertType(string type, string namespacePrefix)
        {
            switch (type)
            {
                case "uint64_t" or "stduint64_t" or "NSUInteger" or "UInteger" or "unsigned long" or "unsigned long long":
                    return "ulong";
                case "NSInteger" or "Integer" or "long" or "long long":
                    return "long";
                case "short":
                    return "short";
                case "unsigned short" or "char":
                    return "ushort";
                case "uint32_t" or "unsigned int":
                    return "uint";
                case "int32_t" or "int":
                    return "int";
                case "uint16_t":
                    return "ushort";
                case "uint8_t" or "unsigned char":
                    return "byte";
                case "float":
                    return "float";
                case "double":
                    return "double";
                case "bool":
                    return "bool";
                case "Object**" or "id" or "CGSize" or "dispatch_queue_t" or "CFTimeInterval" or "ErrorDomain" or "TimeInterval" or "IOSurfaceRef" or "IntPtr":
                    return "IntPtr";
                default:
                    if (!type.StartsWith("NS") && !type.StartsWith("MTL") && !type.StartsWith("CA") && !type.StartsWith("CF") && !type.StartsWith("CG") && !type.StartsWith("IO"))
                    {
                        return namespacePrefix + type;
                    }

                    return type;
            }
        }

        public static string GetNamespace(string filePath)
        {
            if (filePath.Contains("Foundation"))
            {
                return "NS";
            }
            else if (filePath.Contains("QuartzCore"))
            {
                return "CA";
            }
            else
            {
                return "MTL";
            }
        }

        public HeaderInfo(string filePath)
        {
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = GetNamespace(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (line.StartsWith("class"))
                {
                    if (!line.Contains(';'))
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
                            nextLine = nextLine.Replace("*", "");
                            nextLine = nextLine.Replace("class", "");
                            nextLine = nextLine.Replace("const", "");
                            nextLine = nextLine.Replace("static", "");

                            var parts = ClassRegex().Split(nextLine).ToList();

                            parts.RemoveAll(x => x == string.Empty);

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

                                type = ConvertType(type, namespacePrefix);

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
                        }

                        StructInstances.Add(instance);
                    }
                }

                if (line.StartsWith("struct"))
                {
                    if (!line.Contains(";"))
                    {
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
                            var type = ConvertType(typeString, namespacePrefix);
                            var propertyName = propertyInfo[1];

                            string pattern = @"\[.*?\]";
                            propertyName = Regex.Replace(propertyName, pattern, "");

                            instance.AddProperty(new PropertyInstance(type, propertyName));
                        }
                        StructInstances.Add(instance);
                    }
                }

                if (line.StartsWith($"_{namespacePrefix}_ENUM") || line.StartsWith($"_{namespacePrefix}_OPTIONS"))
                {
                    line = line.Replace($"_{namespacePrefix}_ENUM(", "");
                    line = line.Replace($"_{namespacePrefix}_OPTIONS(", "");
                    line = line.Replace(") {", "");
                    var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    var type = info[0].Replace("::", "");
                    var ogName = info[1];

                    var name = GetNamespace(filePath) + ogName;

                    var values = new Dictionary<string, string>();
                    var finishedEnumerating = false;

                    while (!finishedEnumerating)
                    {
                        var nextLine = sr.ReadLine();
                        if (nextLine == "};")
                        {
                            finishedEnumerating = true;
                            continue;
                        }

                        if (nextLine == String.Empty)
                        {
                            continue;
                        }

                        nextLine = nextLine.Trim().Replace(",", "");
                        var cleanedValueName = string.Empty;
                        var cleanedValueValue = string.Empty;

                        if (nextLine.Contains("="))
                        {
                            var valueInfo = nextLine.Split("=", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            cleanedValueName = valueInfo[0];
                            cleanedValueValue = valueInfo[1];
                        }
                        else
                        {
                            cleanedValueName = nextLine;
                        }

                        // Remove original name from each enum's name IOCompressionMethodZlib -> Zlib
                        cleanedValueName = cleanedValueName.Replace(ogName, "");

                        // Sometimes the first character of en enum value's name will be a number after we
                        // remove the full name. In that case, add back the last part of the enum's name
                        if (char.IsDigit(cleanedValueName[0]))
                        {
                            cleanedValueName = NameRegex().Replace(name, " ").Split(" ").Last() + cleanedValueName;
                        }

                        cleanedValueName = cleanedValueName.Replace("_", "");

                        // Happens in one place in MTLDevice
                        if (cleanedValueValue == "NS::UIntegerMax")
                        {
                            cleanedValueValue = "UInt64.MaxValue";
                        }

                        // Happens in NSProcessInfo
                        cleanedValueValue = cleanedValueValue.Replace("ULL", "UL");

                        // Happens in NSString
                        cleanedValueValue = cleanedValueValue.Replace(ogName, "");

                        values.Add(cleanedValueName, cleanedValueValue);
                    }

                    var convertedType = ConvertType(type, namespacePrefix);
                    EnumInstances.Add(new EnumInstance(convertedType, name, values));
                }

                // These contain all the selectors we need
                if (line.StartsWith($"_{namespacePrefix}_INLINE"))
                {
                    var inlineInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    var parentStructName = string.Empty;

                    foreach (var section in inlineInfo)
                    {
                        if (section.Contains("::") && section.Contains("("))
                        {
                            var parentStructInfo = section.Split("::");
                            parentStructName = namespacePrefix + parentStructInfo[1];
                        }
                    }

                    sr.ReadLine();
                    var selector = sr.ReadLine();
                    sr.ReadLine();

                    string lookingFor = $"_{namespacePrefix}_PRIVATE_SEL(";
                    int index = selector.IndexOf(lookingFor);

                    if (index != -1)
                    {
                        // Only get stuff in the brackets of the _MTL_PRIVATE_SEL
                        selector = selector.Substring(index + lookingFor.Length);
                        selector = selector.Substring(0, selector.IndexOf(")"));
                        selector = selector.Replace("_", ":");
                        var parentIndex = StructInstances.FindIndex(x => x.Name == parentStructName);

                        if (parentIndex != -1)
                        {
                            StructInstances[parentIndex].AddSelector(new SelectorInstance(selector));
                        }
                        else
                        {
                            Console.WriteLine($"Orphaned Selector! Looking for {parentStructName}");
                        }
                    }
                }
            }
        }

        [GeneratedRegex("(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")]
        private static partial Regex NameRegex();

        [GeneratedRegex("(?<!\\(.*)\\s+(?![^(]*\\))|\\s+(?![^(]*?\\))")]
        private static partial Regex ClassRegex();
    }

    public class StructInstance
    {
        public string Name;
        public bool IsClass;
        public bool HasAlloc = false;
        public bool HasInit = false;
        public List<PropertyInstance> PropertyInstances;
        public List<SelectorInstance> SelectorInstances;

        public StructInstance(string name, bool isClass)
        {
            Name = name;
            IsClass = isClass;
            SelectorInstances = new();
            PropertyInstances = new();
        }

        public void AddSelector(SelectorInstance selectorInstance)
        {
            if (!SelectorInstances.Exists(x => x.Selector == selectorInstance.Selector))
            {
                SelectorInstances.Add(selectorInstance);
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
    }

    public class EnumInstance
    {
        public string Type;
        public string Name;
        public Dictionary<string, string> Values;

        public EnumInstance(string type, string name, Dictionary<string, string> values)
        {
            Type = type;
            Name = name;
            Values = values;
        }
    }

    public class PropertyInstance
    {
        public string Type;
        public string Name;

        public PropertyInstance(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public class SelectorInstance
    {
        public string Name;
        public string Selector;

        public SelectorInstance(string selector)
        {
            Name = "sel_" + selector.Replace(":", "");
            Selector = selector;
        }
    }
}