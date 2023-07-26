using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NSOperatingSystemVersion
    {
        public long majorVersion;
        public long minorVersion;
        public long patchVersion;
    }
}
