using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Label
        {
            get => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_label);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLFunction VertexFunction
        {
            get => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexFunction, value.NativePtr);
        }

        public MTLFunction FragmentFunction
        {
            get => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentFunction, value.NativePtr);
        }

        public ulong MaxVertexCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexCallStackDepth, value);
        }

        public ulong MaxFragmentCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxFragmentCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxFragmentCallStackDepth, value);
        }

        public MTLVertexDescriptor VertexDescriptor
        {
            get => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexDescriptor);
        }

        public MTLPipelineBufferDescriptorArray VertexBuffers => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffers));
        public MTLPipelineBufferDescriptorArray FragmentBuffers => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentBuffers));
        public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public MTLPixelFormat DepthAttachmentPixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthAttachmentPixelFormat, (ulong)value);
        }

        public MTLPixelFormat StencilAttachmentPixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilAttachmentPixelFormat, (ulong)value);
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";

        private static readonly Selector sel_vertexFunction = "vertexFunction";
        private static readonly Selector sel_setVertexFunction = "setVertexFunction:";
        private static readonly Selector sel_fragmentFunction = "fragmentFunction";
        private static readonly Selector sel_setFragmentFunction = "setFragmentFunction:";
        private static readonly Selector sel_maxVertexCallStackDepth = "maxVertexCallStackDepth";
        private static readonly Selector sel_setMaxVertexCallStackDepth = "setMaxVertexCallStackDepth:";
        private static readonly Selector sel_maxFragmentCallStackDepth = "maxFragmentCallStackDepth";
        private static readonly Selector sel_setMaxFragmentCallStackDepth = "setMaxFragmentCallStackDepth:";

        private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        private static readonly Selector sel_setVertexDescriptor = "setVertexDescriptor:";

        private static readonly Selector sel_vertexBuffers = "vertexBuffers";
        private static readonly Selector sel_fragmentBuffers = "fragmentBuffers";

        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_depthAttachmentPixelFormat = "depthAttachmentPixelFormat";
        private static readonly Selector sel_setDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";
        private static readonly Selector sel_stencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";
        private static readonly Selector sel_setStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";
    }
}