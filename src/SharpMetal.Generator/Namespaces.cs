namespace SharpMetal.Generator
{
    public static class Namespaces
    {
        public static string GetPrettyNamespace(string space)
        {
            return space switch
            {
                "NS" => "Foundation",
                "MTL" => "Metal",
                "MTLFX" => "MetalFX",
                "CA" => "QuartzCore",
                _ => space
            };
        }
    }
}
