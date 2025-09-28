using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.MetalFX
{
    [SupportedOSPlatform("macos")]
    public struct MTLFXFrameInterpolator : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXFrameInterpolator obj) => obj.NativePtr;
        public static implicit operator MTLFXFrameInterpolatorBase(MTLFXFrameInterpolator obj) => new(obj.NativePtr);
        public MTLFXFrameInterpolator(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public float AspectRatio
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_aspectRatio);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAspectRatio, value);
        }

        public MTLTexture ColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTexture, value);
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public float DeltaTime
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_deltaTime);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDeltaTime, value);
        }

        public MTLTexture DepthTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthTexture, value);
        }

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLTextureUsage DepthTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureUsage);

        public float FarPlane
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_farPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFarPlane, value);
        }

        public MTLFence Fence
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fence));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFence, value);
        }

        public float FieldOfView
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_fieldOfView);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFieldOfView, value);
        }

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public bool IsDepthReversed
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthReversed);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthReversed, value);
        }

        public bool IsUITextureComposited
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUITextureComposited);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIsUITextureComposited, value);
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

        public float NearPlane
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_nearPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNearPlane, value);
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

        public MTLTexture PrevColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_prevColorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrevColorTexture, value);
        }

        public bool ShouldResetHistory
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_shouldResetHistory);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShouldResetHistory, value);
        }

        public MTLTexture UiTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_uiTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUITexture, value);
        }

        public MTLPixelFormat UiTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_uiTextureFormat);

        public MTLTextureUsage UiTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_uiTextureUsage);

        public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeToCommandBuffer, commandBuffer);
        }

        private static readonly Selector sel_aspectRatio = "aspectRatio";
        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_deltaTime = "deltaTime";
        private static readonly Selector sel_depthTexture = "depthTexture";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_depthTextureUsage = "depthTextureUsage";
        private static readonly Selector sel_encodeToCommandBuffer = "encodeToCommandBuffer:";
        private static readonly Selector sel_farPlane = "farPlane";
        private static readonly Selector sel_fence = "fence";
        private static readonly Selector sel_fieldOfView = "fieldOfView";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_isDepthReversed = "isDepthReversed";
        private static readonly Selector sel_isUITextureComposited = "isUITextureComposited";
        private static readonly Selector sel_jitterOffsetX = "jitterOffsetX";
        private static readonly Selector sel_jitterOffsetY = "jitterOffsetY";
        private static readonly Selector sel_motionTexture = "motionTexture";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_motionTextureUsage = "motionTextureUsage";
        private static readonly Selector sel_motionVectorScaleX = "motionVectorScaleX";
        private static readonly Selector sel_motionVectorScaleY = "motionVectorScaleY";
        private static readonly Selector sel_nearPlane = "nearPlane";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_prevColorTexture = "prevColorTexture";
        private static readonly Selector sel_setAspectRatio = "setAspectRatio:";
        private static readonly Selector sel_setColorTexture = "setColorTexture:";
        private static readonly Selector sel_setDeltaTime = "setDeltaTime:";
        private static readonly Selector sel_setDepthReversed = "setDepthReversed:";
        private static readonly Selector sel_setDepthTexture = "setDepthTexture:";
        private static readonly Selector sel_setFarPlane = "setFarPlane:";
        private static readonly Selector sel_setFence = "setFence:";
        private static readonly Selector sel_setFieldOfView = "setFieldOfView:";
        private static readonly Selector sel_setIsUITextureComposited = "setIsUITextureComposited:";
        private static readonly Selector sel_setJitterOffsetX = "setJitterOffsetX:";
        private static readonly Selector sel_setJitterOffsetY = "setJitterOffsetY:";
        private static readonly Selector sel_setMotionTexture = "setMotionTexture:";
        private static readonly Selector sel_setMotionVectorScaleX = "setMotionVectorScaleX:";
        private static readonly Selector sel_setMotionVectorScaleY = "setMotionVectorScaleY:";
        private static readonly Selector sel_setNearPlane = "setNearPlane:";
        private static readonly Selector sel_setOutputTexture = "setOutputTexture:";
        private static readonly Selector sel_setPrevColorTexture = "setPrevColorTexture:";
        private static readonly Selector sel_setShouldResetHistory = "setShouldResetHistory:";
        private static readonly Selector sel_setUITexture = "setUITexture:";
        private static readonly Selector sel_shouldResetHistory = "shouldResetHistory";
        private static readonly Selector sel_uiTexture = "uiTexture";
        private static readonly Selector sel_uiTextureFormat = "uiTextureFormat";
        private static readonly Selector sel_uiTextureUsage = "uiTextureUsage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXFrameInterpolatorBase : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXFrameInterpolatorBase obj) => obj.NativePtr;
        public MTLFXFrameInterpolatorBase(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public float AspectRatio
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_aspectRatio);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAspectRatio, value);
        }

        public MTLTexture ColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorTexture, value);
        }

        public MTLPixelFormat ColorTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureFormat);

        public MTLTextureUsage ColorTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_colorTextureUsage);

        public float DeltaTime
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_deltaTime);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDeltaTime, value);
        }

        public MTLTexture DepthTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthTexture, value);
        }

        public MTLPixelFormat DepthTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureFormat);

        public MTLTextureUsage DepthTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthTextureUsage);

        public float FarPlane
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_farPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFarPlane, value);
        }

        public MTLFence Fence
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fence));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFence, value);
        }

        public float FieldOfView
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_fieldOfView);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFieldOfView, value);
        }

        public ulong InputHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputHeight);

        public ulong InputWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputWidth);

        public bool IsDepthReversed
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthReversed);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthReversed, value);
        }

        public bool IsUITextureComposited
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUITextureComposited);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIsUITextureComposited, value);
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

        public float NearPlane
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_nearPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNearPlane, value);
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

        public MTLTexture PrevColorTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_prevColorTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrevColorTexture, value);
        }

        public bool ShouldResetHistory
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_shouldResetHistory);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShouldResetHistory, value);
        }

        public MTLTexture UiTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_uiTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUITexture, value);
        }

        public MTLPixelFormat UiTextureFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_uiTextureFormat);

        public MTLTextureUsage UiTextureUsage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_uiTextureUsage);

        private static readonly Selector sel_aspectRatio = "aspectRatio";
        private static readonly Selector sel_colorTexture = "colorTexture";
        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_colorTextureUsage = "colorTextureUsage";
        private static readonly Selector sel_deltaTime = "deltaTime";
        private static readonly Selector sel_depthTexture = "depthTexture";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_depthTextureUsage = "depthTextureUsage";
        private static readonly Selector sel_farPlane = "farPlane";
        private static readonly Selector sel_fence = "fence";
        private static readonly Selector sel_fieldOfView = "fieldOfView";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_isDepthReversed = "isDepthReversed";
        private static readonly Selector sel_isUITextureComposited = "isUITextureComposited";
        private static readonly Selector sel_jitterOffsetX = "jitterOffsetX";
        private static readonly Selector sel_jitterOffsetY = "jitterOffsetY";
        private static readonly Selector sel_motionTexture = "motionTexture";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_motionTextureUsage = "motionTextureUsage";
        private static readonly Selector sel_motionVectorScaleX = "motionVectorScaleX";
        private static readonly Selector sel_motionVectorScaleY = "motionVectorScaleY";
        private static readonly Selector sel_nearPlane = "nearPlane";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTexture = "outputTexture";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputTextureUsage = "outputTextureUsage";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_prevColorTexture = "prevColorTexture";
        private static readonly Selector sel_setAspectRatio = "setAspectRatio:";
        private static readonly Selector sel_setColorTexture = "setColorTexture:";
        private static readonly Selector sel_setDeltaTime = "setDeltaTime:";
        private static readonly Selector sel_setDepthReversed = "setDepthReversed:";
        private static readonly Selector sel_setDepthTexture = "setDepthTexture:";
        private static readonly Selector sel_setFarPlane = "setFarPlane:";
        private static readonly Selector sel_setFence = "setFence:";
        private static readonly Selector sel_setFieldOfView = "setFieldOfView:";
        private static readonly Selector sel_setIsUITextureComposited = "setIsUITextureComposited:";
        private static readonly Selector sel_setJitterOffsetX = "setJitterOffsetX:";
        private static readonly Selector sel_setJitterOffsetY = "setJitterOffsetY:";
        private static readonly Selector sel_setMotionTexture = "setMotionTexture:";
        private static readonly Selector sel_setMotionVectorScaleX = "setMotionVectorScaleX:";
        private static readonly Selector sel_setMotionVectorScaleY = "setMotionVectorScaleY:";
        private static readonly Selector sel_setNearPlane = "setNearPlane:";
        private static readonly Selector sel_setOutputTexture = "setOutputTexture:";
        private static readonly Selector sel_setPrevColorTexture = "setPrevColorTexture:";
        private static readonly Selector sel_setShouldResetHistory = "setShouldResetHistory:";
        private static readonly Selector sel_setUITexture = "setUITexture:";
        private static readonly Selector sel_shouldResetHistory = "shouldResetHistory";
        private static readonly Selector sel_uiTexture = "uiTexture";
        private static readonly Selector sel_uiTextureFormat = "uiTextureFormat";
        private static readonly Selector sel_uiTextureUsage = "uiTextureUsage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFXFrameInterpolatorDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFXFrameInterpolatorDescriptor obj) => obj.NativePtr;
        public MTLFXFrameInterpolatorDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFXFrameInterpolatorDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFXFrameInterpolatorDescriptor");
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

        public MTLFXFrameInterpolatableScaler Scaler
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_scaler));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScaler, value);
        }

        public MTLPixelFormat UiTextureFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_uiTextureFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUITextureFormat, (ulong)value);
        }

        public static bool SupportsDevice(MTLDevice device)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(new ObjectiveCClass("bool"), sel_supportsDevice, device);
        }

        public static bool SupportsMetal4FX(MTLDevice device)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(new ObjectiveCClass("bool"), sel_supportsMetal4FX, device);
        }

        private static readonly Selector sel_colorTextureFormat = "colorTextureFormat";
        private static readonly Selector sel_depthTextureFormat = "depthTextureFormat";
        private static readonly Selector sel_inputHeight = "inputHeight";
        private static readonly Selector sel_inputWidth = "inputWidth";
        private static readonly Selector sel_motionTextureFormat = "motionTextureFormat";
        private static readonly Selector sel_newFrameInterpolatorWithDevice = "newFrameInterpolatorWithDevice:";
        private static readonly Selector sel_newFrameInterpolatorWithDevicecompiler = "newFrameInterpolatorWithDevice:compiler:";
        private static readonly Selector sel_outputHeight = "outputHeight";
        private static readonly Selector sel_outputTextureFormat = "outputTextureFormat";
        private static readonly Selector sel_outputWidth = "outputWidth";
        private static readonly Selector sel_scaler = "scaler";
        private static readonly Selector sel_setColorTextureFormat = "setColorTextureFormat:";
        private static readonly Selector sel_setDepthTextureFormat = "setDepthTextureFormat:";
        private static readonly Selector sel_setInputHeight = "setInputHeight:";
        private static readonly Selector sel_setInputWidth = "setInputWidth:";
        private static readonly Selector sel_setMotionTextureFormat = "setMotionTextureFormat:";
        private static readonly Selector sel_setOutputHeight = "setOutputHeight:";
        private static readonly Selector sel_setOutputTextureFormat = "setOutputTextureFormat:";
        private static readonly Selector sel_setOutputWidth = "setOutputWidth:";
        private static readonly Selector sel_setScaler = "setScaler:";
        private static readonly Selector sel_setUITextureFormat = "setUITextureFormat:";
        private static readonly Selector sel_supportsDevice = "supportsDevice:";
        private static readonly Selector sel_supportsMetal4FX = "supportsMetal4FX:";
        private static readonly Selector sel_uiTextureFormat = "uiTextureFormat";
        private static readonly Selector sel_release = "release";
    }
}
