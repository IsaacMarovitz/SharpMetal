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
    public struct MTLFXSpatialScaler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXSpatialScaler obj) => obj.NativePtr;
        public static implicit operator MTLFXSpatialScalerBase(MTLFXSpatialScaler obj) => new(obj.NativePtr);
        public MTLFXSpatialScaler(IntPtr ptr) => NativePtr = ptr;

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

        public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
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

    [SupportedOSPlatform("macos")]
    public struct MTLFXSpatialScalerBase : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXSpatialScalerBase obj) => obj.NativePtr;
        public MTLFXSpatialScalerBase(IntPtr ptr) => NativePtr = ptr;

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

        private static readonly Selector sel_colorProcessingMode = "colorProcessingMode";
        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
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

    [SupportedOSPlatform("macos")]
    public struct MTLFXSpatialScalerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXSpatialScalerDescriptor obj) => obj.NativePtr;
        public MTLFXSpatialScalerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFXSpatialScalerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFXSpatialScalerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
        {
            get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_colorProcessingMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorProcessingMode, (long)value);
        }

        public MTLPixelFormat ColorTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTextureFormat, (ulong)value);
        }

        public ulong InputHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputHeight, value);
        }

        public ulong InputWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputWidth, value);
        }

        public ulong OutputHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputHeight, value);
        }

        public MTLPixelFormat OutputTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputTextureFormat, (ulong)value);
        }

        public ulong OutputWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputWidth, value);
        }

        public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newSpatialScalerWithDevice, pDevice));
        }

        public MTL4FXSpatialScaler NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newSpatialScalerWithDevicecompiler, pDevice, pCompiler));
        }

        public static bool SupportsMetal4FX(MTLDevice pDevice)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(new ObjectiveCClass("bool"), sel_supportsMetal4FX, pDevice);
        }

        private static readonly Selector sel_colorProcessingMode = "colorProcessingMode";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_newSpatialScalerWithDevice = "newSpatialScalerWithDevice:";
        private static readonly Selector sel_newSpatialScalerWithDevicecompiler = "newSpatialScalerWithDevice:compiler:";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_setColorProcessingMode = "setColorProcessingMode:";
        private static readonly Selector sel_setColorTextureFormat = "setColorTextureFormat:";
        private static readonly Selector sel_setInputHeight = "setInputHeight:";
        private static readonly Selector sel_setInputWidth = "setInputWidth:";
        private static readonly Selector sel_setOutputHeight = "setOutputHeight:";
        private static readonly Selector sel_setOutputTextureFormat = "setOutputTextureFormat:";
        private static readonly Selector sel_setOutputWidth = "setOutputWidth:";
        private static readonly Selector sel_supportsDevice = "supportsDevice:";
        private static readonly Selector sel_supportsMetal4FX = "supportsMetal4FX:";
        private static readonly Selector sel_release = "release";
    }
}
