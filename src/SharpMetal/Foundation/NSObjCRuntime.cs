using System.Runtime.Versioning;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public enum NSComparisonResult : long
    {
        OrderedAscending = -1L,
        OrderedSame,
        OrderedDescending,
    }

}
