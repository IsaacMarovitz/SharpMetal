using System.Runtime.Versioning;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSSharedPtr
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSSharedPtr obj) => obj.NativePtr;
        public NSSharedPtr(IntPtr ptr) => NativePtr = ptr;

        public IntPtr Get;
    }
}
