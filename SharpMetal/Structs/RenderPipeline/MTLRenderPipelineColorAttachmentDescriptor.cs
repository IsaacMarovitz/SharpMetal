using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineColorAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, Selectors.pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setPixelFormat, (uint)value);
        }

        public MTLColorWriteMask WriteMask
        {
            get => (MTLColorWriteMask)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_writeMask);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWriteMask, (uint)value);
        }

        public bool BlendingEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isBlendingEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBlendingEnabled, value);
        }

        public MTLBlendOperation AlphaBlendOperation
        {
            get => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alphaBlendOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaBlendOperation, (uint)value);
        }

        public MTLBlendOperation RGBBlendOperation
        {
            get => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rgbBlendOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRGBBlendOperation, (uint)value);
        }

        public MTLBlendFactor DestinationAlphaBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationAlphaBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestinationAlphaBlendFactor, (uint)value);
        }

        public MTLBlendFactor DestinationRGBBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationRGBBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestinationRGBBlendFactor, (uint)value);
        }

        public MTLBlendFactor SourceAlphaBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceAlphaBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSourceAlphaBlendFactor, (uint)value);
        }

        public MTLBlendFactor SourceRGBBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceRGBBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSourceRGBBlendFactor, (uint)value);
        }

        private static readonly Selector sel_isBlendingEnabled = "isBlendingEnabled";
        private static readonly Selector sel_setBlendingEnabled = "setBlendingEnabled:";
        private static readonly Selector sel_writeMask = "writeMask";
        private static readonly Selector sel_setWriteMask = "setWriteMask:";
        private static readonly Selector sel_alphaBlendOperation = "alphaBlendOperation";
        private static readonly Selector sel_setAlphaBlendOperation = "setAlphaBlendOperation:";
        private static readonly Selector sel_rgbBlendOperation = "rgbBlendOperation";
        private static readonly Selector sel_setRGBBlendOperation = "setRgbBlendOperation:";
        private static readonly Selector sel_destinationAlphaBlendFactor = "destinationAlphaBlendFactor";
        private static readonly Selector sel_setDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";
        private static readonly Selector sel_destinationRGBBlendFactor = "destinationRGBBlendFactor";
        private static readonly Selector sel_setDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";
        private static readonly Selector sel_sourceAlphaBlendFactor = "sourceAlphaBlendFactor";
        private static readonly Selector sel_setSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";
        private static readonly Selector sel_sourceRGBBlendFactor = "sourceRGBBlendFactor";
        private static readonly Selector sel_setSourceRGBBlendFactor = "setSourceRGBBlendFactor:";
    }
}