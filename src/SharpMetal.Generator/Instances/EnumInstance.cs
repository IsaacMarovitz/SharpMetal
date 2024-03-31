using CppAst;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class EnumInstance
    {
        private CppEnum _cppEnum;

        public EnumInstance(CppEnum cppEnum)
        {
            _cppEnum = cppEnum;
        }

        public void Generate(CodeGenContext context)
        {
            var type = _cppEnum.IntegerType;
            var name = _cppEnum.Name;
            var values = _cppEnum.Items.ToArray();
            var isFlag = type.TypeKind == CppTypeKind.Typedef;

            if (type.TypeKind == CppTypeKind.Typedef)
            {
                var typedef = type as CppTypedef;
                type = typedef.ElementType;
            }
            else
            {
                type = type;
            }

            // ClangSharp failed to get the real name
            if (name.Contains("("))
            {
                name = type.GetDisplayName();
            }

            var commonStart = GetCommonStartingSubString(values.Select(x => x.Name).ToList());
            var valuesDict = new Dictionary<string, string>();

            foreach (var value in values)
            {
                // TODO: This algorithm is overly aggressive and it fails on enums with only one member
                var cleanName = string.IsNullOrEmpty(commonStart) ? value.Name : value.Name.Replace(commonStart, "");

                valuesDict.Add(cleanName, value.Value.ToString());
            }

            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            if (isFlag)
            {
                context.WriteLine("[Flags]");
            }

            context.WriteLine($"public enum {name} : {StringUtils.TypeToString(type).Type}");
            context.EnterScope();

            foreach (var value in valuesDict)
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
