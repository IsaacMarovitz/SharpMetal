using System.Runtime.InteropServices;

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
