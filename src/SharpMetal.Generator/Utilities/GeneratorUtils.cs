namespace SharpMetal.Generator.Utilities
{
    public static class GeneratorUtils
    {
        private static readonly string[] PartialTypes =
        [
            "CAMetalLayer",
            "MTLDevice",
            "MTLRenderPipelineDescriptor",
            "MTLSamplerDescriptor",
            "NSString",
        ];

        private static readonly string[] BannedTypes =
        [
            "NS_NS_EXPORT",
        ];

        public static bool IsPartialType(string name) => PartialTypes.Contains(name);

        public static bool IsBannedType(string name) => BannedTypes.Contains(name);
    }
}
