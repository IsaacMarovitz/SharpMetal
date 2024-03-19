using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLIOCompressionStatus : long
    {
        Complete = 0,
        Error = 1,
    }

}
