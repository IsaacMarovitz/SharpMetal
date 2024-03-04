using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public partial class MTLFXTemporalScalerDescriptor
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXTemporalScalerDescriptor obj) => obj.NativePtr;
        public MTLFXTemporalScalerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFXTemporalScalerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFXTemporalScalerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLPixelFormat MotionTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureFormat);

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public bool IsAutoExposureEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAutoExposureEnabled);

        public bool IsInputContentPropertiesEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isInputContentPropertiesEnabled);

        public float InputContentMinScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMinScale);

        public float InputContentMaxScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMaxScale);

        public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTemporalScalerWithDevice, pDevice));
        }

        public static bool SupportsDevice(MTLDevice pDevice)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(new ObjectiveCClass("bool"), sel_supportsDevice, pDevice);
        }

        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_isAutoExposureEnabled = "isAutoExposureEnabled";
        private static readonly Selector sel_isInputContentPropertiesEnabled = "isInputContentPropertiesEnabled";
        private static readonly Selector sel_inputContentMinScale = "inputContentMinScale";
        private static readonly Selector sel_inputContentMaxScale = "inputContentMaxScale";
        private static readonly Selector sel_newTemporalScalerWithDevice = "newTemporalScalerWithDevice:";
        private static readonly Selector sel_supportsDevice = "supportsDevice:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLFXTemporalScaler
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXTemporalScaler obj) => obj.NativePtr;
        public MTLFXTemporalScaler(IntPtr ptr) => NativePtr = ptr;

        protected MTLFXTemporalScaler()
        {
            throw new NotImplementedException();
        }

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public MTLTextureUsage DepthTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureUsage);

        public MTLTextureUsage MotionTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureUsage);

        public MTLTextureUsage OutputTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureUsage);

        public ulong InputContentWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentWidth);

        public ulong InputContentHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputContentHeight);

        public MTLTexture ColorTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));

        public MTLTexture DepthTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthTexture));

        public MTLTexture MotionTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_motionTexture));

        public MTLTexture OutputTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputTexture));

        public MTLTexture ExposureTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_exposureTexture));

        public float PreExposure => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_preExposure);

        public float JitterOffsetX => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_jitterOffsetX);

        public float JitterOffsetY => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_jitterOffsetY);

        public float MotionVectorScaleX => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionVectorScaleX);

        public float MotionVectorScaleY => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionVectorScaleY);

        public bool Reset => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_reset);

        public bool IsDepthReversed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthReversed);

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLPixelFormat MotionTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTextureFormat);

        public MTLPixelFormat OutputTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputTextureFormat);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong OutputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputWidth);

        public ulong OutputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_outputHeight);

        public float InputContentMinScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMinScale);

        public float InputContentMaxScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMaxScale);

        public MTLFence Fence => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fence));

        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_depthTextureUsage = "depthTextureUsage";
        private static readonly Selector sel_motionTextureUsage = "motionTextureUsage";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_inputContentWidth = "inputContentWidth";
        private static readonly Selector sel_inputContentHeight = "inputContentHeight";
        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_depthTexture = "depthTexture";
        private static readonly Selector sel_motionTexture = "motionTexture";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_exposureTexture = "exposureTexture";
        private static readonly Selector sel_preExposure = "preExposure";
        private static readonly Selector sel_jitterOffsetX = "jitterOffsetX";
        private static readonly Selector sel_jitterOffsetY = "jitterOffsetY";
        private static readonly Selector sel_motionVectorScaleX = "motionVectorScaleX";
        private static readonly Selector sel_motionVectorScaleY = "motionVectorScaleY";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_isDepthReversed = "isDepthReversed";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_inputContentMinScale = "inputContentMinScale";
        private static readonly Selector sel_inputContentMaxScale = "inputContentMaxScale";
        private static readonly Selector sel_fence = "fence";
    }
}
