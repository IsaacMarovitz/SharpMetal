using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public struct MTL4FXTemporalScaler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4FXTemporalScaler obj) => obj.NativePtr;
        public static implicit operator MTLFXTemporalScalerBase(MTL4FXTemporalScaler obj) => new(obj.NativePtr);
        public MTL4FXTemporalScaler(IntPtr ptr) => NativePtr = ptr;

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

        public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
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
}
