using System.Text.RegularExpressions;

namespace SharpMetal.Generator.Instances
{
    public partial class EnumInstance
    {
        public string Type;
        public string Name;
        public Dictionary<string, string> Values;

        private EnumInstance(string type, string name, Dictionary<string, string> values)
        {
            Type = type;
            Name = name;
            Values = values;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine($"public enum {Name}: {Type}");
            context.EnterScope();

            foreach (var value in Values)
            {
                if (value.Value != string.Empty)
                {
                    context.WriteLine($"{value.Key} = {value.Value},");
                }
                else
                {
                    context.WriteLine($"{value.Key},");
                }
            }

            context.LeaveScope();
            context.WriteLine();
        }

        public static EnumInstance Build(string line, string namespacePrefix, StreamReader sr, bool skipValues = false)
        {
            line = line.Replace($"_{namespacePrefix}_ENUM(", "");
            line = line.Replace($"_{namespacePrefix}_OPTIONS(", "");
            line = line.Replace(") {", "");
            var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var convertedType = Types.ConvertType(info[0], namespacePrefix);
            var ogName = info[1];

            var name = namespacePrefix + ogName;

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


                if (!skipValues)
                {
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

                    // Remove original name from each enum's name and value IOCompressionMethodZlib -> Zlib
                    cleanedValueName = cleanedValueName.Replace(ogName, "");
                    cleanedValueValue = cleanedValueValue.Replace(ogName, "");

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

                    values.Add(cleanedValueName, cleanedValueValue);
                }
            }

            return new EnumInstance(convertedType, name, values);
        }

        [GeneratedRegex("(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")]
        private static partial Regex NameRegex();
    }
}