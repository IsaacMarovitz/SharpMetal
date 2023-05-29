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
                case "uint64_t" or "stduint64_t" or "NSUInteger" or "UInteger":
                    return "ulong";
                case "NSInteger" or "Integer":
                    return "long";
                case "uint32_t":
                    return "uint";
                case "int32_t":
                    return "int";
                case "uint16_t":
                    return "ushort";
                case "uint8_t":
                    return "byte";
                case "float":
                    return "float";
                case "double":
                    return "double";
                case "Object**":
                    return "IntPtr";
                default:
                    if (!type.StartsWith(namespacePrefix))
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

                        StructInstances.Add(new StructInstance(structName, true));

                        bool structEnded = false;

                        while (!structEnded)
                        {
                            if (sr.ReadLine().Contains('}'))
                            {
                                structEnded = true;
                            }
                        }
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
                            }
                            else
                            {
                                if (propertyLine.Contains('(') && propertyLine.Contains(')')) continue;

                                var propertyInfo = propertyLine.Replace(";", "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                                if (propertyInfo.Length != 2) continue;

                                var typeString = propertyInfo[0].Replace("::", "");
                                var type = ConvertType(typeString, namespacePrefix);
                                var propertyName = propertyInfo[1];

                                string pattern = @"\[.*?\]";
                                propertyName = Regex.Replace(propertyName, pattern, "");

                                instance.ProperyInstances.Add(new PropertyInstance(type, propertyName));
                            }
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
                            cleanedValueName = MyRegex().Replace(name, " ").Split(" ").Last() + cleanedValueName;
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
        private static partial Regex MyRegex();
    }

    public class StructInstance
    {
        public string Name;
        public bool IsClass;
        public List<PropertyInstance> ProperyInstances;
        public List<SelectorInstance> SelectorInstances;

        public StructInstance(string name, bool isClass)
        {
            Name = name;
            IsClass = isClass;
            SelectorInstances = new();
            ProperyInstances = new();
        }

        public void AddSelector(SelectorInstance selectorInstance)
        {
            if (!SelectorInstances.Exists(x => x.Selector == selectorInstance.Selector))
            {
                SelectorInstances.Add(selectorInstance);
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