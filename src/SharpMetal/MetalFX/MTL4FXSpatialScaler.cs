using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public struct MTL4FXSpatialScaler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4FXSpatialScaler obj) => obj.NativePtr;
        public static implicit operator MTLFXSpatialScalerBase(MTL4FXSpatialScaler obj) => new(obj.NativePtr);
        public MTL4FXSpatialScaler(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_colorProcessingMode);

        public MTLTexture ColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTexture, value);
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public MTLFence Fence
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fence));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFence, value);
        }

        public ulong InputContentHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentHeight, value);
        }

        public ulong InputContentWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentWidth, value);
        }

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public MTLTexture OutputTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputTexture, value);
        }

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public MTLTextureUsage OutputTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureUsage);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeToCommandBuffer, pCommandBuffer);
        }

        private static readonly Selector sel_colorProcessingMode = "colorProcessingMode";
        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_encodeToCommandBuffer = "encodeToCommandBuffer:";
        private static readonly Selector sel_fence = "fence";
        private static readonly Selector sel_inputContentHeight = "inputContentHeight";
        private static readonly Selector sel_inputContentWidth = "inputContentWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_setColorTexture = "setColorTexture:";
        private static readonly Selector sel_setFence = "setFence:";
        private static readonly Selector sel_setInputContentHeight = "setInputContentHeight:";
        private static readonly Selector sel_setInputContentWidth = "setInputContentWidth:";
        private static readonly Selector sel_setOutputTexture = "setOutputTexture:";
        private static readonly Selector sel_release = "release";
    }
}
