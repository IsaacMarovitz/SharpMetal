using System.Text.RegularExpressions;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public partial class EnumInstance : TypeInstance
    {
        public readonly string BackingType;
        public readonly bool IsFlag;
        public readonly Dictionary<string, string> Values;

        private EnumInstance(string backingType, string name, bool isFlag, Dictionary<string, string> values) : base(name)
        {
            BackingType = backingType;
            IsFlag = isFlag;
            Values = values;
        }

        public static EnumInstance Build(string line, string namespacePrefix, StreamReader sr, bool skipValues = false)
        {
            var isFlag = line.Contains($"_{namespacePrefix}_OPTIONS(");

            var macroNamespaces = Namespaces.GetMacroNamespace(namespacePrefix);

            line = line.Replace($"_{macroNamespaces}_ENUM(", "");
            line = line.Replace($"_{macroNamespaces}_OPTIONS(", "");

            if (line.Contains('{'))
            {
                line = line.Replace(") {", "");
            }
            else
            {
                line = line.Replace(")", "");
                // Consume the next line
                sr.ReadLine();
            }

            var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var convertedType = Types.ConvertType(info[0], namespacePrefix);
            var ogName = info[1];

            var name = namespacePrefix + ogName;

            var values = new Dictionary<string, string>();
            var finishedEnumerating = false;

            while (!finishedEnumerating)
            {
                var nextLine = GeneratorUtils.ReadNextCodeLine(sr);

                if (nextLine == null)
                {
                    break;
                }

                if (nextLine.Contains("};"))
                {
                    finishedEnumerating = true;
                    continue;
                }

                if (skipValues)
                {
                    continue;
                }

                nextLine = nextLine.Trim().Replace(",", "");
                var cleanedValueName = string.Empty;
                var cleanedValueValue = string.Empty;

                if (nextLine.Contains('='))
                {
                    var valueInfo = nextLine.Split("=", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    cleanedValueName = valueInfo[0];
                    cleanedValueValue = valueInfo[1];
                }
                else
                {
                    cleanedValueName = nextLine;
                }

                var nameTrim = ogName;

                // MTLAccelerationStructureInstanceOptions vs AccelerationStructureInstanceOption for it's values
                nameTrim = nameTrim.Replace("Options", "Option");

                // Remove original name from each enum's name and value IOCompressionMethodZlib -> Zlib
                cleanedValueName = cleanedValueName.Replace(nameTrim, "");
                cleanedValueValue = cleanedValueValue.Replace(nameTrim, "");

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

                try
                {
                    values.Add(cleanedValueName, cleanedValueValue);
                }
                catch
                {
                    Console.WriteLine($"Attempted to write repeat value! {line}");
                }
            }

            return new EnumInstance(convertedType, name, isFlag, values);
        }

        [GeneratedRegex("(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])")]
        private static partial Regex NameRegex();
    }
}
