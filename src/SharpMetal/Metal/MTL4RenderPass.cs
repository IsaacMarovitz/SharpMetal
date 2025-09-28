using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPassDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPassDescriptor obj) => obj.NativePtr;
        public MTL4RenderPassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }















        private static readonly Selector sel_release = "release";
    }
}
