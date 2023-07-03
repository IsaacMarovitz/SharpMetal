namespace SharpMetal.Generator.Utilities
{
    public static class StringUtils
    {
        /// <summary>
        /// Turns camelCase text to PascaleCase.
        /// </summary>
        /// <param name="value">Input value in camelCase</param>
        /// <returns>Input value in PascaleCase</returns>
        public static string CamelToPascale(string value)
        {
            if (value != string.Empty)
            {
                var firstChar = char.ToUpper(value[0]);
                return firstChar + value[1..];
            }

            return value;
        }

        public static string FunctionSignautreCleanup(string value)
        {
            value = value.Replace(";", "");
            value = value.Replace("~", "Destroy");
            value = value.Replace("::", "");
            value = value.Replace("void*", "IntPtr");
            value = value.Replace("void()", "void");
            value = value.Replace("*", "");
            value = value.Replace("class ", "");
            value = value.Replace("const ", "");
            return value;
        }

        public static bool IsValidFunctionSignature(string value)
        {
            return !(value.Contains("template") || value.Contains("^") || value.Contains("typename") || value.Contains("operator") || value.Contains("std::function") || value.Contains("Handler") || value.Contains("Observer"));
        }
    }
}