using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4MeshRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MeshRenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4MeshRenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4MeshRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4MeshRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4MeshRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }




























        private static readonly Selector sel_release = "release";
    }
}
