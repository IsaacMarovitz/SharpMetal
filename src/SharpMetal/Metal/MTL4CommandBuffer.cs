using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4CommandBuffer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandBuffer obj) => obj.NativePtr;
        public MTL4CommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }




        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandBufferOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandBufferOptions obj) => obj.NativePtr;
        public MTL4CommandBufferOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommandBufferOptions()
        {
            var cls = new ObjectiveCClass("MTL4CommandBufferOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }
}
