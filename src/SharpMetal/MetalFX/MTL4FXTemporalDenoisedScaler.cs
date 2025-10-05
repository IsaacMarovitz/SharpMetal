using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public struct MTL4FXTemporalDenoisedScaler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4FXTemporalDenoisedScaler obj) => obj.NativePtr;
        public static implicit operator MTLFXTemporalDenoisedScalerBase(MTL4FXTemporalDenoisedScaler obj) => new(obj.NativePtr);
        public MTL4FXTemporalDenoisedScaler(IntPtr ptr) => NativePtr = ptr;

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

        public MTLTexture DenoiseStrengthMaskTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_denoiseStrengthMaskTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDenoiseStrengthMaskTexture, value);
        }

        public MTLPixelFormat DenoiseStrengthMaskTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_denoiseStrengthMaskTextureFormat);

        public MTLTextureUsage DenoiseStrengthMaskTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_denoiseStrengthMaskTextureUsage);

        public MTLTexture DepthTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthTexture, value);
        }

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLTextureUsage DepthTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureUsage);

        public MTLTexture DiffuseAlbedoTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_diffuseAlbedoTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDiffuseAlbedoTexture, value);
        }

        public MTLPixelFormat DiffuseAlbedoTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_diffuseAlbedoTextureFormat);

        public MTLTextureUsage DiffuseAlbedoTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_diffuseAlbedoTextureUsage);

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

        public float InputContentMaxScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMaxScale);

        public float InputContentMinScale => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_inputContentMinScale);

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

        public MTLTexture NormalTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_normalTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNormalTexture, value);
        }

        public MTLPixelFormat NormalTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_normalTextureFormat);

        public MTLTextureUsage NormalTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_normalTextureUsage);

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

        public MTLPixelFormat ReactiveMaskTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_reactiveMaskTextureFormat);

        public MTLTextureUsage ReactiveTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_reactiveTextureUsage);

        public MTLTexture RoughnessTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_roughnessTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRoughnessTexture, value);
        }

        public MTLPixelFormat RoughnessTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_roughnessTextureFormat);

        public MTLTextureUsage RoughnessTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_roughnessTextureUsage);

        public bool ShouldResetHistory
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_shouldResetHistory);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShouldResetHistory, value);
        }

        public MTLTexture SpecularAlbedoTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_specularAlbedoTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSpecularAlbedoTexture, value);
        }

        public MTLPixelFormat SpecularAlbedoTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_specularAlbedoTextureFormat);

        public MTLTextureUsage SpecularAlbedoTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_specularAlbedoTextureUsage);

        public MTLTexture SpecularHitDistanceTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_specularHitDistanceTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSpecularHitDistanceTexture, value);
        }

        public MTLPixelFormat SpecularHitDistanceTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_specularHitDistanceTextureFormat);

        public MTLTextureUsage SpecularHitDistanceTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_specularHitDistanceTextureUsage);

        public MTLTexture TransparencyOverlayTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_transparencyOverlayTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransparencyOverlayTexture, value);
        }

        public MTLPixelFormat TransparencyOverlayTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_transparencyOverlayTextureFormat);

        public MTLTextureUsage TransparencyOverlayTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_transparencyOverlayTextureUsage);

        public SimdMatrix4x4 ViewToClipMatrix
        {
            get => ObjectiveCRuntime.SimdMatrix4x4_objc_msgSend(NativePtr, sel_viewToClipMatrix);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setViewToClipMatrix, value);
        }

        public SimdMatrix4x4 WorldToViewMatrix
        {
            get => ObjectiveCRuntime.SimdMatrix4x4_objc_msgSend(NativePtr, sel_worldToViewMatrix);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWorldToViewMatrix, value);
        }

        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_denoiseStrengthMaskTexture = "denoiseStrengthMaskTexture";
        private static readonly Selector sel_denoiseStrengthMaskTextureFormat = "denoiseStrengthMaskTextureFormat";
        private static readonly Selector sel_denoiseStrengthMaskTextureUsage = "denoiseStrengthMaskTextureUsage";
        private static readonly Selector sel_depthTexture = "depthTexture";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_depthTextureUsage = "depthTextureUsage";
        private static readonly Selector sel_diffuseAlbedoTexture = "diffuseAlbedoTexture";
        private static readonly Selector sel_diffuseAlbedoTextureFormat = "diffuseAlbedoTextureFormat";
        private static readonly Selector sel_diffuseAlbedoTextureUsage = "diffuseAlbedoTextureUsage";
        private static readonly Selector sel_encodeToCommandBuffer = "encodeToCommandBuffer:";
        private static readonly Selector sel_exposureTexture = "exposureTexture";
        private static readonly Selector sel_fence = "fence";
        private static readonly Selector sel_inputContentMaxScale = "inputContentMaxScale";
        private static readonly Selector sel_inputContentMinScale = "inputContentMinScale";
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
        private static readonly Selector sel_normalTexture = "normalTexture";
        private static readonly Selector sel_normalTextureFormat = "normalTextureFormat";
        private static readonly Selector sel_normalTextureUsage = "normalTextureUsage";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_preExposure = "preExposure";
        private static readonly Selector sel_reactiveMaskTexture = "reactiveMaskTexture";
        private static readonly Selector sel_reactiveMaskTextureFormat = "reactiveMaskTextureFormat";
        private static readonly Selector sel_reactiveTextureUsage = "reactiveTextureUsage";
        private static readonly Selector sel_roughnessTexture = "roughnessTexture";
        private static readonly Selector sel_roughnessTextureFormat = "roughnessTextureFormat";
        private static readonly Selector sel_roughnessTextureUsage = "roughnessTextureUsage";
        private static readonly Selector sel_setColorTexture = "setColorTexture:";
        private static readonly Selector sel_setDenoiseStrengthMaskTexture = "setDenoiseStrengthMaskTexture:";
        private static readonly Selector sel_setDepthReversed = "setDepthReversed:";
        private static readonly Selector sel_setDepthTexture = "setDepthTexture:";
        private static readonly Selector sel_setDiffuseAlbedoTexture = "setDiffuseAlbedoTexture:";
        private static readonly Selector sel_setExposureTexture = "setExposureTexture:";
        private static readonly Selector sel_setFence = "setFence:";
        private static readonly Selector sel_setJitterOffsetX = "setJitterOffsetX:";
        private static readonly Selector sel_setJitterOffsetY = "setJitterOffsetY:";
        private static readonly Selector sel_setMotionTexture = "setMotionTexture:";
        private static readonly Selector sel_setMotionVectorScaleX = "setMotionVectorScaleX:";
        private static readonly Selector sel_setMotionVectorScaleY = "setMotionVectorScaleY:";
        private static readonly Selector sel_setNormalTexture = "setNormalTexture:";
        private static readonly Selector sel_setOutputTexture = "setOutputTexture:";
        private static readonly Selector sel_setPreExposure = "setPreExposure:";
        private static readonly Selector sel_setReactiveMaskTexture = "setReactiveMaskTexture:";
        private static readonly Selector sel_setRoughnessTexture = "setRoughnessTexture:";
        private static readonly Selector sel_setShouldResetHistory = "setShouldResetHistory:";
        private static readonly Selector sel_setSpecularAlbedoTexture = "setSpecularAlbedoTexture:";
        private static readonly Selector sel_setSpecularHitDistanceTexture = "setSpecularHitDistanceTexture:";
        private static readonly Selector sel_setTransparencyOverlayTexture = "setTransparencyOverlayTexture:";
        private static readonly Selector sel_setViewToClipMatrix = "setViewToClipMatrix:";
        private static readonly Selector sel_setWorldToViewMatrix = "setWorldToViewMatrix:";
        private static readonly Selector sel_shouldResetHistory = "shouldResetHistory";
        private static readonly Selector sel_specularAlbedoTexture = "specularAlbedoTexture";
        private static readonly Selector sel_specularAlbedoTextureFormat = "specularAlbedoTextureFormat";
        private static readonly Selector sel_specularAlbedoTextureUsage = "specularAlbedoTextureUsage";
        private static readonly Selector sel_specularHitDistanceTexture = "specularHitDistanceTexture";
        private static readonly Selector sel_specularHitDistanceTextureFormat = "specularHitDistanceTextureFormat";
        private static readonly Selector sel_specularHitDistanceTextureUsage = "specularHitDistanceTextureUsage";
        private static readonly Selector sel_transparencyOverlayTexture = "transparencyOverlayTexture";
        private static readonly Selector sel_transparencyOverlayTextureFormat = "transparencyOverlayTextureFormat";
        private static readonly Selector sel_transparencyOverlayTextureUsage = "transparencyOverlayTextureUsage";
        private static readonly Selector sel_viewToClipMatrix = "viewToClipMatrix";
        private static readonly Selector sel_worldToViewMatrix = "worldToViewMatrix";
        private static readonly Selector sel_release = "release";
    }
}
