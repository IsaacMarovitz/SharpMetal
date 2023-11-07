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

        public static string StringBetween(string source, char left, char right)
        {
            var indexOfLeft = source.IndexOf(left) + 1;
            var indexOfRight = source.IndexOf(right);

            return source.Substring(indexOfLeft, indexOfRight - indexOfLeft);
        }
    }
}
