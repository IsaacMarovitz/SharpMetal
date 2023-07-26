namespace SharpMetal.Generator
{
    public static class Namespaces
    {
        public static string[] Prefixes = { "MTL", "NS", "CA", "CF", "CG", "IO" };

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

            return "Metal";
        }
    }
}
