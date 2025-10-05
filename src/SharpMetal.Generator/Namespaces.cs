namespace SharpMetal.Generator
{
    public static class Namespaces
    {
        public static string[] Prefixes { get; } = ["MTLFX", "MTL4FX", "MTL", "MTL4", "NS", "CA", "CF", "CG", "IO", "kern"];

        public static string GetNamespace(string filePath)
        {
            if (filePath.Contains("Foundation"))
            {
                return "NS";
            }

            if (filePath.Contains("QuartzCore"))
            {
                return "CA";
            }

            if (filePath.Contains("MTL4FX"))
            {
                return "MTL4FX";
            }

            if (filePath.Contains("MetalFX"))
            {
                return "MTLFX";
            }

            if (filePath.Contains("MTL4"))
            {
                return "MTL4";
            }

            return "MTL";
        }

        public static string GetFullNamespace(string filePath)
        {
            if (filePath.Contains("Foundation"))
            {
                return "Foundation";
            }

            if (filePath.Contains("QuartzCore"))
            {
                return "QuartzCore";
            }

            if (filePath.Contains("MetalFX"))
            {
                return "MetalFX";
            }

            return "Metal";
        }

        public static string GetMacroNamespace(string namespacePrefix)
        {
            if (namespacePrefix == "MTL4")
            {
                return "MTL";
            }
            else if (namespacePrefix == "MTL4FX")
            {
                return "MTLFX";
            }

            return namespacePrefix;
        }

        /// <summary>
        /// Some MTL4 types are defined inside MTL headers, so we need to override its name for a few specific types with hardcoded rules
        /// The better solution would be namespace-aware parsing of headers, but that is a little bit more complicated and would require bigger rewrite of the parser
        /// </summary>
        public static string GetOverrideForSpecificTypes(string typeName)
        {
            if (typeName == "MTLBufferRange")
            {
                return "MTL4BufferRange";
            }

            return typeName;
        }
    }
}
