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

        public static MTLRenderPipelineDescriptor New()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineDescriptor");
            var ret = cls.AllocInit<MTLRenderPipelineDescriptor>();
            return ret;
        }

        public string Label
        {
            get => ObjectiveCRuntime.string_objc_msgSend(NativePtr, sel_label);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLFunction VertexFunction
        {
            get => new MTLFunction(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexFunction, value.NativePtr);
        }

        public MTLFunction FragmentFunction
        {
            get => new MTLFunction(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentFunction, value.NativePtr);
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

        /* private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";

        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_depthAttachmentPixelFormat = "depthAttachmentPixelFormat";
        private static readonly Selector sel_setDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";
        private static readonly Selector sel_stencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";
        private static readonly Selector sel_setStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        private static readonly Selector sel_isAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";
        private static readonly Selector sel_setAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";*/
    }
}