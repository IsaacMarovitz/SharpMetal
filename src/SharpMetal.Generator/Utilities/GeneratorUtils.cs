namespace SharpMetal.Generator.Utilities
{
    public static class GeneratorUtils
    {
        private static readonly string[] PartialTypes =
        [
            "CAMetalLayer",
            "MTLDevice",
            "MTLRenderPipelineDescriptor",
            "NSString",
        ];

        private static readonly string[] BannedTypes =
        [
            "NS_NS_EXPORT",
        ];

        public static bool IsPartialType(string name) => PartialTypes.Contains(name);

        public static bool IsBannedType(string name) => BannedTypes.Contains(name);

        /// <summary>
        /// Consumes given stream lines until it hits a non-empty line that is not part of a comment
        /// </summary>
        /// <returns>The code line or null if stream ended</returns>
        public static string? ReadNextCodeLine(StreamReader sr)
        {
            var insideComment = false;
            while (!sr.EndOfStream)
            {
                var line = (sr.ReadLine() ?? "").Trim();
                if (line == string.Empty || line.StartsWith("//"))
                {
                    continue;
                }

                if (line.Contains("/**"))
                {
                    insideComment = true;
                }

                if (line.Contains("*/"))
                {
                    insideComment = false;
                }

                if (!insideComment)
                {
                    return line;
                }
            }

            return null;
        }
    }
}
