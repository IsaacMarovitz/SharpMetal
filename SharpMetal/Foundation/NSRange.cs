using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NSRange
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSRange obj) => obj.NativePtr;
        public NSRange(IntPtr ptr) => NativePtr = ptr;

        public ulong location;

        public ulong length;
    }
}
