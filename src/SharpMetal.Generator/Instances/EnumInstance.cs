using CppAst;

namespace SharpMetal.Generator.Instances
{
    public class EnumInstance
    {
        public CppType Type;
        public string Name;
        public bool IsFlag;
        public Dictionary<string, string> Values;

        public EnumInstance(CppEnum cppEnum)
        {
            var type = cppEnum.IntegerType;
            var name = cppEnum.Name;
            var values = cppEnum.Items.ToArray();

            if (type.TypeKind == CppTypeKind.Typedef)
            {
                var typedef = type as CppTypedef;
                Type = typedef.ElementType;
            }
            else
            {
                Type = type;
            }

            // ClangSharp failed to get the real name
            if (name.Contains("("))
            {
                name = type.GetDisplayName();
            }

            Type = type;
            Name = name;
            IsFlag = type.TypeKind == CppTypeKind.Typedef;

            var commonStart = GetCommonStartingSubString(values.Select(x => x.Name).ToList());
            var valuesDict = new Dictionary<string, string>();

            foreach (var value in values)
            {
                // TODO: This algorithm is overly aggressive and it fails on enums with only one member
                var cleanName = string.IsNullOrEmpty(commonStart) ? value.Name : value.Name.Replace(commonStart, "");

                valuesDict.Add(cleanName, value.Value.ToString());
            }

            Values = valuesDict;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            if (IsFlag)
            {
                context.WriteLine("[Flags]");
            }

            // TODO: The type here is not a valid C# type, it will need to be mapped properly
            context.WriteLine($"public enum {Name} : {Type}");
            context.EnterScope();

            foreach (var value in Values)
            {
                context.WriteLine($"{value.Key} = {value.Value},");
            }

            context.LeaveScope();
            context.WriteLine();
        }

        // Source: https://stackoverflow.com/questions/3760639/any-framework-functions-helping-to-find-the-longest-common-starting-substring-of
        public static string GetCommonStartingSubString(IList<string> strings)
        {
            if (strings.Count == 0)
            {
                return "";
            }

            if (strings.Count == 1)
            {
                return strings[0];
            }

            int charIdx = 0;

            while (IsCommonChar(strings, charIdx))
            {
                ++charIdx;
            }

            return strings[0].Substring(0, charIdx);
        }

        private static bool IsCommonChar(IList<string> strings, int charIdx)
        {
            if(strings[0].Length <= charIdx)
            {
                return false;
            }

            for (int strIdx = 1; strIdx < strings.Count; ++strIdx)
            {
                if (strings[strIdx].Length <= charIdx || strings[strIdx][charIdx] != strings[0][charIdx])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
