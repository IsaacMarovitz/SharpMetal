using System.Text.RegularExpressions;

namespace SharpMetal.Generator
{
    public partial class EnumInstance
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

        public static EnumInstance BuildEnum(string line, string namespacePrefix, StreamReader sr)
        {
            line = line.Replace($"_{namespacePrefix}_ENUM(", "");
            line = line.Replace($"_{namespacePrefix}_OPTIONS(", "");
            line = line.Replace(") {", "");
            var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var type = info[0].Replace("::", "");
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

            var convertedType = Types.ConvertType(type, namespacePrefix);
            return new EnumInstance(convertedType, name, values);
        }

        [GeneratedRegex("(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")]
        private static partial Regex NameRegex();
    }
}