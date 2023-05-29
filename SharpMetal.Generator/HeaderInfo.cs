using System.Text.RegularExpressions;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        public List<EnumInstance> EnumInstances = new();
        public List<StructInstance> StructInstances = new();

        public HeaderInfo(string filePath)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (line.StartsWith("class"))
                    {
                        if (!line.Contains(";"))
                        {
                            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            var structName = "MTL" + structInfo[1];

                            StructInstances.Add(new StructInstance(structName, true));

                            bool structEnded = false;

                            while (!structEnded)
                            {
                                if (sr.ReadLine().Contains("}"))
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
                            var structName = "MTL" + structInfo[1];

                            var instance = new StructInstance(structName, false);

                            bool structEnded = false;
                            sr.ReadLine();

                            while (!structEnded)
                            {
                                var propertyLine = sr.ReadLine();
                                if (propertyLine.Contains("}"))
                                {
                                    structEnded = true;
                                }
                                else
                                {
                                    if (!propertyLine.Contains("(") || !propertyLine.Contains(")"))
                                    {
                                        var propertyInfo = propertyLine.Replace(";", "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                                        if (propertyInfo.Length == 2)
                                        {
                                            var typeString = propertyInfo[0].Replace("::", "");
                                            var type = "";
                                            var propertyName = propertyInfo[1];

                                            switch (typeString)
                                            {
                                                case "uint64_t" or "NSUInteger" or "UInteger":
                                                    type = "ulong";
                                                    break;
                                                case "Integer":
                                                    type = "long";
                                                    break;
                                                case "uint32_t":
                                                    type = "uint";
                                                    break;
                                                case "int32_t":
                                                    type = "int";
                                                    break;
                                                case "uint16_t":
                                                    type = "byte";
                                                    break;
                                                case "float":
                                                    type = "float";
                                                    break;
                                                case "double":
                                                    type = "double";
                                                    break;
                                                case "Object**":
                                                    type = "IntPtr";
                                                    break;
                                                default:
                                                    if (!typeString.StartsWith("MTL"))
                                                    {
                                                        type = "MTL" + typeString;
                                                    }
                                                    else
                                                    {
                                                        type = typeString;
                                                    }
                                                    break;
                                            }

                                            string pattern = @"\[.*?\]";
                                            propertyName = Regex.Replace(propertyName, pattern, "");

                                            instance.ProperyInstances.Add(new PropertyInstance(type, propertyName));
                                        }
                                    }
                                }
                            }
                            StructInstances.Add(instance);
                        }
                    }

                    if (line.StartsWith("_MTL_ENUM") || line.StartsWith("_MTL_OPTIONS"))
                    {
                        line = line.Replace("_MTL_ENUM(", "");
                        line = line.Replace("_MTL_OPTIONS(", "");
                        line = line.Replace(") {", "");
                        var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        var type = info[0];
                        var ogName = info[1];

                        var name = "MTL" + ogName;

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

                            nextLine = nextLine.Trim().Replace(",", "");
                            var valueInfo = nextLine.Split("=", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                            // Remove original name from each enum's name IOCompressionMethodZlib -> Zlib
                            var cleanedValueName = valueInfo[0].Replace(ogName, "");
                            var cleanedValueValue = valueInfo[1];

                            // Sometimes the first character of en enum value's name will be a number after we
                            // remove the full name. In that case, add back the last part of the enum's name
                            if (Char.IsDigit(cleanedValueName[0]))
                            {
                                Regex regex = new Regex(
                                    @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"
                                );
                                cleanedValueName = regex.Replace(name, " ").Split(" ").Last() + cleanedValueName;
                            }

                            cleanedValueName = cleanedValueName.Replace("_", "");

                            // Happens in one place in MTLDevice
                            if (cleanedValueValue == "NS::UIntegerMax")
                            {
                                cleanedValueValue = "UInt64.MaxValue";
                            }

                            values.Add(cleanedValueName, cleanedValueValue);
                        }

                        switch (type)
                        {
                            case "NS::UInteger":
                                EnumInstances.Add(new EnumInstance("ulong", name, values));
                                break;
                            case "NS::Integer":
                                EnumInstances.Add(new EnumInstance("long", name, values));
                                break;
                            case "uint8_t":
                                EnumInstances.Add(new EnumInstance("byte", name, values));
                                break;
                        }
                    }

                    // These contain all the selectors we need
                    if (line.StartsWith("_MTL_INLINE"))
                    {
                        string pattern = @"\s(?![^()]*\))";
                        string[] result = Regex.Split(line, pattern);
                        var parentStructName = "";

                        if (result.Count() == 2)
                        {
                            parentStructName = "MTL" + result[1].Split("::")[1];
                        }
                        else
                        {
                            parentStructName = "MTL" + result[2].Split("::")[1];
                        }

                        sr.ReadLine();
                        var selector = sr.ReadLine();
                        sr.ReadLine();

                        string lookingFor = "_MTL_PRIVATE_SEL(";
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
        }
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
            SelectorInstances.Add(selectorInstance);
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
            Name = selector.Replace(":", "");
            Selector = selector;
        }
    }
}