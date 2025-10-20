using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public struct MTLFXFrameInterpolatableScaler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXFrameInterpolatableScaler obj) => obj.NativePtr;
        public MTLFXFrameInterpolatableScaler(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXTemporalScaler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXTemporalScaler obj) => obj.NativePtr;
        public static implicit operator MTLFXTemporalScalerBase(MTLFXTemporalScaler obj) => new(obj.NativePtr);
        public MTLFXTemporalScaler(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLTexture ColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTexture, value);
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public MTLTexture DepthTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthTexture, value);
        }

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLTextureUsage DepthTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureUsage);

        public MTLTexture ExposureTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_exposureTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setExposureTexture, value);
        }

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

        public float InputContentMaxScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMaxScale);

        public float InputContentMinScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMinScale);

        public ulong InputContentWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentWidth, value);
        }

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public bool IsDepthReversed
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthReversed);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthReversed, value);
        }

        public float JitterOffsetX
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_jitterOffsetX);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setJitterOffsetX, value);
        }

        public float JitterOffsetY
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_jitterOffsetY);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setJitterOffsetY, value);
        }

        public MTLTexture MotionTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_motionTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTexture, value);
        }

        public MTLPixelFormat MotionTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureFormat);

        public MTLTextureUsage MotionTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureUsage);

        public float MotionVectorScaleX
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionVectorScaleX);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionVectorScaleX, value);
        }

        public float MotionVectorScaleY
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionVectorScaleY);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionVectorScaleY, value);
        }

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public MTLTexture OutputTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputTexture, value);
        }

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public MTLTextureUsage OutputTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureUsage);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public float PreExposure
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_preExposure);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreExposure, value);
        }

        public MTLTexture ReactiveMaskTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_reactiveMaskTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReactiveMaskTexture, value);
        }

        public MTLTextureUsage ReactiveTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_reactiveTextureUsage);

        public bool Reset
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_reset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReset, value);
        }

        public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeToCommandBuffer, pCommandBuffer);
        }

        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_depthTexture = "depthTexture";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_depthTextureUsage = "depthTextureUsage";
        private static readonly Selector sel_encodeToCommandBuffer = "encodeToCommandBuffer:";
        private static readonly Selector sel_exposureTexture = "exposureTexture";
        private static readonly Selector sel_fence = "fence";
        private static readonly Selector sel_inputContentHeight = "inputContentHeight";
        private static readonly Selector sel_inputContentMaxScale = "inputContentMaxScale";
        private static readonly Selector sel_inputContentMinScale = "inputContentMinScale";
        private static readonly Selector sel_inputContentWidth = "inputContentWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_isDepthReversed = "isDepthReversed";
        private static readonly Selector sel_jitterOffsetX = "jitterOffsetX";
        private static readonly Selector sel_jitterOffsetY = "jitterOffsetY";
        private static readonly Selector sel_motionTexture = "motionTexture";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_motionTextureUsage = "motionTextureUsage";
        private static readonly Selector sel_motionVectorScaleX = "motionVectorScaleX";
        private static readonly Selector sel_motionVectorScaleY = "motionVectorScaleY";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_preExposure = "preExposure";
        private static readonly Selector sel_reactiveMaskTexture = "reactiveMaskTexture";
        private static readonly Selector sel_reactiveTextureUsage = "reactiveTextureUsage";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setColorTexture = "setColorTexture:";
        private static readonly Selector sel_setDepthReversed = "setDepthReversed:";
        private static readonly Selector sel_setDepthTexture = "setDepthTexture:";
        private static readonly Selector sel_setExposureTexture = "setExposureTexture:";
        private static readonly Selector sel_setFence = "setFence:";
        private static readonly Selector sel_setInputContentHeight = "setInputContentHeight:";
        private static readonly Selector sel_setInputContentWidth = "setInputContentWidth:";
        private static readonly Selector sel_setJitterOffsetX = "setJitterOffsetX:";
        private static readonly Selector sel_setJitterOffsetY = "setJitterOffsetY:";
        private static readonly Selector sel_setMotionTexture = "setMotionTexture:";
        private static readonly Selector sel_setMotionVectorScaleX = "setMotionVectorScaleX:";
        private static readonly Selector sel_setMotionVectorScaleY = "setMotionVectorScaleY:";
        private static readonly Selector sel_setOutputTexture = "setOutputTexture:";
        private static readonly Selector sel_setPreExposure = "setPreExposure:";
        private static readonly Selector sel_setReactiveMaskTexture = "setReactiveMaskTexture:";
        private static readonly Selector sel_setReset = "setReset:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXTemporalScalerBase : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXTemporalScalerBase obj) => obj.NativePtr;
        public static implicit operator MTLFXFrameInterpolatableScaler(MTLFXTemporalScalerBase obj) => new(obj.NativePtr);
        public MTLFXTemporalScalerBase(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLTexture ColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTexture, value);
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public MTLTexture DepthTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthTexture, value);
        }

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLTextureUsage DepthTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureUsage);

        public MTLTexture ExposureTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_exposureTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setExposureTexture, value);
        }

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

        public float InputContentMaxScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMaxScale);

        public float InputContentMinScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMinScale);

        public ulong InputContentWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentWidth, value);
        }

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public bool IsDepthReversed
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthReversed);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthReversed, value);
        }

        public float JitterOffsetX
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_jitterOffsetX);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setJitterOffsetX, value);
        }

        public float JitterOffsetY
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_jitterOffsetY);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setJitterOffsetY, value);
        }

        public MTLTexture MotionTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_motionTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTexture, value);
        }

        public MTLPixelFormat MotionTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureFormat);

        public MTLTextureUsage MotionTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureUsage);

        public float MotionVectorScaleX
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionVectorScaleX);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionVectorScaleX, value);
        }

        public float MotionVectorScaleY
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionVectorScaleY);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionVectorScaleY, value);
        }

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public MTLTexture OutputTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputTexture, value);
        }

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public MTLTextureUsage OutputTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureUsage);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public float PreExposure
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_preExposure);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreExposure, value);
        }

        public MTLTexture ReactiveMaskTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_reactiveMaskTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReactiveMaskTexture, value);
        }

        public MTLTextureUsage ReactiveTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_reactiveTextureUsage);

        public bool Reset
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_reset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReset, value);
        }

        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_depthTexture = "depthTexture";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_depthTextureUsage = "depthTextureUsage";
        private static readonly Selector sel_exposureTexture = "exposureTexture";
        private static readonly Selector sel_fence = "fence";
        private static readonly Selector sel_inputContentHeight = "inputContentHeight";
        private static readonly Selector sel_inputContentMaxScale = "inputContentMaxScale";
        private static readonly Selector sel_inputContentMinScale = "inputContentMinScale";
        private static readonly Selector sel_inputContentWidth = "inputContentWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_isDepthReversed = "isDepthReversed";
        private static readonly Selector sel_jitterOffsetX = "jitterOffsetX";
        private static readonly Selector sel_jitterOffsetY = "jitterOffsetY";
        private static readonly Selector sel_motionTexture = "motionTexture";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_motionTextureUsage = "motionTextureUsage";
        private static readonly Selector sel_motionVectorScaleX = "motionVectorScaleX";
        private static readonly Selector sel_motionVectorScaleY = "motionVectorScaleY";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_preExposure = "preExposure";
        private static readonly Selector sel_reactiveMaskTexture = "reactiveMaskTexture";
        private static readonly Selector sel_reactiveTextureUsage = "reactiveTextureUsage";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setColorTexture = "setColorTexture:";
        private static readonly Selector sel_setDepthReversed = "setDepthReversed:";
        private static readonly Selector sel_setDepthTexture = "setDepthTexture:";
        private static readonly Selector sel_setExposureTexture = "setExposureTexture:";
        private static readonly Selector sel_setFence = "setFence:";
        private static readonly Selector sel_setInputContentHeight = "setInputContentHeight:";
        private static readonly Selector sel_setInputContentWidth = "setInputContentWidth:";
        private static readonly Selector sel_setJitterOffsetX = "setJitterOffsetX:";
        private static readonly Selector sel_setJitterOffsetY = "setJitterOffsetY:";
        private static readonly Selector sel_setMotionTexture = "setMotionTexture:";
        private static readonly Selector sel_setMotionVectorScaleX = "setMotionVectorScaleX:";
        private static readonly Selector sel_setMotionVectorScaleY = "setMotionVectorScaleY:";
        private static readonly Selector sel_setOutputTexture = "setOutputTexture:";
        private static readonly Selector sel_setPreExposure = "setPreExposure:";
        private static readonly Selector sel_setReactiveMaskTexture = "setReactiveMaskTexture:";
        private static readonly Selector sel_setReset = "setReset:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXTemporalScalerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXTemporalScalerDescriptor obj) => obj.NativePtr;
        public MTLFXTemporalScalerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFXTemporalScalerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFXTemporalScalerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLPixelFormat ColorTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTextureFormat, (ulong)value);
        }

        public MTLPixelFormat DepthTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthTextureFormat, (ulong)value);
        }

        public float InputContentMaxScale
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMaxScale);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentMaxScale, value);
        }

        public float InputContentMinScale
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMinScale);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentMinScale, value);
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

        public bool IsAutoExposureEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAutoExposureEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAutoExposureEnabled, value);
        }

        public bool IsInputContentPropertiesEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isInputContentPropertiesEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputContentPropertiesEnabled, value);
        }

        public bool IsReactiveMaskTextureEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isReactiveMaskTextureEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReactiveMaskTextureEnabled, value);
        }

        public MTLPixelFormat MotionTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTextureFormat, (ulong)value);
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

        public MTLPixelFormat ReactiveMaskTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_reactiveMaskTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReactiveMaskTextureFormat, (ulong)value);
        }

        public bool RequiresSynchronousInitialization
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_requiresSynchronousInitialization);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRequiresSynchronousInitialization, value);
        }

        public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTemporalScalerWithDevice, pDevice));
        }

        public static bool SupportsDevice(MTLDevice pDevice)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(new ObjectiveCClass("bool"), sel_supportsDevice, pDevice);
        }

        public static bool SupportsMetal4FX(MTLDevice pDevice)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(new ObjectiveCClass("bool"), sel_supportsMetal4FX, pDevice);
        }

        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_inputContentMaxScale = "inputContentMaxScale";
        private static readonly Selector sel_inputContentMinScale = "inputContentMinScale";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_isAutoExposureEnabled = "isAutoExposureEnabled";
        private static readonly Selector sel_isInputContentPropertiesEnabled = "isInputContentPropertiesEnabled";
        private static readonly Selector sel_isReactiveMaskTextureEnabled = "isReactiveMaskTextureEnabled";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_newTemporalScalerWithDevice = "newTemporalScalerWithDevice:";
        private static readonly Selector sel_newTemporalScalerWithDevicecompiler = "newTemporalScalerWithDevice:compiler:";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_reactiveMaskTextureFormat = "reactiveMaskTextureFormat";
        private static readonly Selector sel_requiresSynchronousInitialization = "requiresSynchronousInitialization";
        private static readonly Selector sel_setAutoExposureEnabled = "setAutoExposureEnabled:";
        private static readonly Selector sel_setColorTextureFormat = "setColorTextureFormat:";
        private static readonly Selector sel_setDepthTextureFormat = "setDepthTextureFormat:";
        private static readonly Selector sel_setInputContentMaxScale = "setInputContentMaxScale:";
        private static readonly Selector sel_setInputContentMinScale = "setInputContentMinScale:";
        private static readonly Selector sel_setInputContentPropertiesEnabled = "setInputContentPropertiesEnabled:";
        private static readonly Selector sel_setInputHeight = "setInputHeight:";
        private static readonly Selector sel_setInputWidth = "setInputWidth:";
        private static readonly Selector sel_setMotionTextureFormat = "setMotionTextureFormat:";
        private static readonly Selector sel_setOutputHeight = "setOutputHeight:";
        private static readonly Selector sel_setOutputTextureFormat = "setOutputTextureFormat:";
        private static readonly Selector sel_setOutputWidth = "setOutputWidth:";
        private static readonly Selector sel_setReactiveMaskTextureEnabled = "setReactiveMaskTextureEnabled:";
        private static readonly Selector sel_setReactiveMaskTextureFormat = "setReactiveMaskTextureFormat:";
        private static readonly Selector sel_setRequiresSynchronousInitialization = "setRequiresSynchronousInitialization:";
        private static readonly Selector sel_supportsDevice = "supportsDevice:";
        private static readonly Selector sel_supportsMetal4FX = "supportsMetal4FX:";
        private static readonly Selector sel_release = "release";
    }
}
