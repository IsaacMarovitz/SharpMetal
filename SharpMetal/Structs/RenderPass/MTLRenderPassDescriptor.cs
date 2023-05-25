using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassDescriptor
    {
        private static readonly ObjectiveCClass s_class = new(nameof(MTLRenderPassDescriptor));
        public readonly IntPtr NativePtr;

        public MTLRenderPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLRenderPassColorAttachmentDescriptorArray colorAttachments => ObjectiveCRuntime.objc_msgSend<MTLRenderPassColorAttachmentDescriptorArray>(NativePtr, sel_colorAttachments);

        public MTLRenderPassDepthAttachmentDescriptor depthAttachment => ObjectiveCRuntime.objc_msgSend<MTLRenderPassDepthAttachmentDescriptor>(NativePtr, sel_depthAttachment);

        public MTLRenderPassStencilAttachmentDescriptor stencilAttachment => ObjectiveCRuntime.objc_msgSend<MTLRenderPassStencilAttachmentDescriptor>(NativePtr, sel_stencilAttachment);

        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_depthAttachment = "depthAttachment";
        private static readonly Selector sel_stencilAttachment = "stencilAttachment";
    }
}