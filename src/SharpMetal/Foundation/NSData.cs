using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public struct NSData : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSData obj) => obj.NativePtr;
        public NSData(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public IntPtr MutableBytes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_mutableBytes));

        public ulong Length => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_length);

        private static readonly Selector sel_mutableBytes = "mutableBytes";
        private static readonly Selector sel_length = "length";
        private static readonly Selector sel_release = "release";
    }
}
