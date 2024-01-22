namespace SharpMetal.Generator.Instances
{
    public struct Compatability
    {
        public string? MacOSMinVersion;
        public string? MacCatalystMinVersion;
        public string? IOSMinVersion;
        public string? TvOSMinVersion;
        public string? VisionOSMinVersion;

        public Compatability(
            string? macOSMinVerson = null,
            string? macCatalystMinVersion = null,
            string? iOSMinVersion = null,
            string? tvOSMinVersion = null,
            string? visionOSMinVersion = null)
        {
            MacOSMinVersion = macOSMinVerson;
            MacCatalystMinVersion = macCatalystMinVersion;
            IOSMinVersion = iOSMinVersion;
            TvOSMinVersion = tvOSMinVersion;
            VisionOSMinVersion = visionOSMinVersion;
        }

        public void Generate(CodeGenContext context)
        {
            if (MacOSMinVersion is not null)
            {
                context.WriteLine($"[SupportedOSPlatform(\"macos{MacOSMinVersion}\")]");
            }
            if (MacCatalystMinVersion is not null)
            {
                context.WriteLine($"[SupportedOSPlatform(\"macCatalyst{MacCatalystMinVersion}\")]");
            }
            if (IOSMinVersion is not null)
            {
                context.WriteLine($"[SupportedOSPlatform(\"iOS{IOSMinVersion}\")]");
            }
            if (TvOSMinVersion is not null)
            {
                context.WriteLine($"[SupportedOSPlatform(\"tvOS{TvOSMinVersion}\")]");
            }
            if (VisionOSMinVersion is not null)
            {
                context.WriteLine($"[SupportedOSPlatform(\"visionOS{VisionOSMinVersion}\")]");
            }
        }
    }
}
