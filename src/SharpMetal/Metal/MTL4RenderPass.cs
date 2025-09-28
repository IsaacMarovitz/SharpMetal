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

        // missing MTLRenderPassColorAttachmentDescriptorArray ColorAttachments

        // missing ulong DefaultRasterSampleCount

        // missing MTLRenderPassDepthAttachmentDescriptor DepthAttachment

        // missing ulong ImageblockSampleLength

        // missing MTLRasterizationRateMap RasterizationRateMap

        // missing ulong RenderTargetArrayLength

        // missing ulong RenderTargetHeight

        // missing ulong RenderTargetWidth

        // missing MTLRenderPassStencilAttachmentDescriptor StencilAttachment

        // missing bool SupportColorAttachmentMapping

        // missing ulong ThreadgroupMemoryLength

        // missing ulong TileHeight

        // missing ulong TileWidth

        // missing MTLBuffer VisibilityResultBuffer

        // missing MTLVisibilityResultType VisibilityResultType
        private static readonly Selector sel_release = "release";
    }
}
