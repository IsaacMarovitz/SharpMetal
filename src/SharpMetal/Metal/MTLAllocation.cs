using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLAllocation : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAllocation obj) => obj.NativePtr;
        public MTLAllocation(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_release = "release";
    }
}
