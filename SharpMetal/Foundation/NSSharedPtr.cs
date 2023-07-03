using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSSharedPtr
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSSharedPtr obj) => obj.NativePtr;
        public NSSharedPtr(IntPtr ptr) => NativePtr = ptr;

        public IntPtr Get;
    }
}
