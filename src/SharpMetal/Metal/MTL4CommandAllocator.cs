using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4CommandAllocator : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandAllocator obj) => obj.NativePtr;
        public MTL4CommandAllocator(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing ulong AllocatedSize

        // missing MTLDevice Device

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandAllocatorDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandAllocatorDescriptor obj) => obj.NativePtr;
        public MTL4CommandAllocatorDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommandAllocatorDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4CommandAllocatorDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }
}
