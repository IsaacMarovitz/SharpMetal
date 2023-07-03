using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public class NSData
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSData obj) => obj.NativePtr;
        public NSData(IntPtr ptr) => NativePtr = ptr;

        public IntPtr MutableBytes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_mutableBytes));

        public ulong Length => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_length);

        private static readonly Selector sel_mutableBytes = "mutableBytes";
        private static readonly Selector sel_length = "length";
    }
}
