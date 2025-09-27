namespace SharpMetal.Generator.Utilities
{
    public static class GeneratorUtils
    {
        private static readonly string[] partialTypes =
        [
            "CAMetalLayer",
            "MTLDevice",
            "MTLRenderPipelineDescriptor",
            "MTLSamplerDescriptor",
            "NSString",
        ];

        private static readonly string[] bannedTypes =
        [
            "NS_NS_EXPORT",
        ];

        public static bool IsPartialType(string name) => partialTypes.Contains(name);

        public static bool IsBannedType(string name) => bannedTypes.Contains(name);
    }
}
