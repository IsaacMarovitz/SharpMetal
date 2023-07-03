using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NSOperatingSystemVersion
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSOperatingSystemVersion obj) => obj.NativePtr;
        public NSOperatingSystemVersion(IntPtr ptr) => NativePtr = ptr;

        public long majorVersion;

        public long minorVersion;

        public long patchVersion;
    }
}
