using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class EnumInstance
    {
        private bool _isBitflag = false;
        private Types.NativeType _type;
        private string _name;
        private Dictionary<string, string> _values = new();

        public EnumInstance(StreamReader sr, string line)
        {
            _isBitflag = line.Contains("OPTIONS");

            // Example Line:
            // "typedef NS_ENUM(NSUInteger, MTLDataType) {"
            // "NSUInteger" is the underlying type
            // "MTLDataType" is the enum's name

            var enumInfoString = StringUtils.StringBetween(line, '(', ')');
            var enumInfo = enumInfoString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            _type = Types.ConvertType(enumInfo[0]);
            _name = enumInfo[1];

            var parsingComplete = false;

            while (!parsingComplete)
            {
                line = sr.ReadLine();

                if (line.Contains("}"))
                {
                    parsingComplete = true;
                    continue;
                }

                // Example Line:
                // "MTLStepFunctionPerPatch API_AVAILABLE(macos(10.12), ios(10.0)) = 3, // Comment"
                // Definitions can span multiple lines
                // The final "," is optional if it's the final value definition
                // Spacing between value name and "=" not guaranteed or consistent
                // Bitwise definitions may reference other enum members
                // There may be multiple pre-processor defines between the value name and the "="
            }
        }
    }
}
