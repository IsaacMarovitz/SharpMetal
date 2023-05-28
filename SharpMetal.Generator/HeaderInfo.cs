using System.Text.RegularExpressions;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        public List<EnumInstance> EnumInstances = new List<EnumInstance>();

        public HeaderInfo(string filePath)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Contains("_MTL_ENUM"))
                    {
                        line = line.Replace("_MTL_ENUM(", "");
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
                                EnumInstances.Add(new EnumInstance(typeof(ulong), name, values));
                                break;
                            case "NS::Integer":
                                EnumInstances.Add(new EnumInstance(typeof(long), name, values));
                                break;
                            case "uint8_t":
                                EnumInstances.Add(new EnumInstance(typeof(byte), name, values));
                                break;
                        }
                    }
                }
            }
        }
    }

    public class EnumInstance
    {
        public Type Type;
        public string Name;
        public Dictionary<string, string> Values;

        public EnumInstance(Type type, string name, Dictionary<string, string> values)
        {
            Type = type;
            Name = name;
            Values = values;
        }
    }
}