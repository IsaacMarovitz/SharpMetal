using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public enum MTLFXSpatialScalerColorProcessingMode : long
    {
        Perceptual = 0,
        Linear = 1,
        HDR = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXSpatialScalerDescriptor
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXSpatialScalerDescriptor obj) => obj.NativePtr;
        public MTLFXSpatialScalerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFXSpatialScalerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFXSpatialScalerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_colorProcessingMode);

        public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newSpatialScalerWithDevice, pDevice));
        }

        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_colorProcessingMode = "colorProcessingMode";
        private static readonly Selector sel_newSpatialScalerWithDevice = "newSpatialScalerWithDevice:";
        private static readonly Selector sel_supportsDevice = "supportsDevice:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXSpatialScaler
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXSpatialScaler obj) => obj.NativePtr;
        public MTLFXSpatialScaler(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public MTLTextureUsage OutputTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureUsage);

        public ulong InputContentWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentWidth);

        public ulong InputContentHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentHeight);

        public MTLTexture ColorTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));

        public MTLTexture OutputTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputTexture));

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_colorProcessingMode);

        public MTLFence Fence => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fence));

        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_inputContentWidth = "inputContentWidth";
        private static readonly Selector sel_inputContentHeight = "inputContentHeight";
        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_colorProcessingMode = "colorProcessingMode";
        private static readonly Selector sel_fence = "fence";
    }
}
