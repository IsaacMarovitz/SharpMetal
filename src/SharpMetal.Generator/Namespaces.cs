namespace SharpMetal.Generator
{
    public static class Namespaces
    {
        public static string[] Prefixes { get; } = ["MTLFX", "MTL4FX", "MTL", "MTL4", "NS", "CA", "CF", "CG", "IO", "kern" ];

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
    }
}
