using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.QuartzCore
{
    [SupportedOSPlatform("macos")]
    public partial class CAMetalLayer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalLayer obj) => obj.NativePtr;
        public CAMetalLayer(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDevice, value);
        }

        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPixelFormat);

        public bool FramebufferOnly
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_framebufferOnly);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFramebufferOnly, value);
        }

        public IntPtr DrawableSize
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_drawableSize));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDrawableSize, value);
        }

        public CAMetalDrawable NextDrawable;

        public void SetDevice(MTLDevice device)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDevice, device);
        }

        public void SetPixelFormat(MTLPixelFormat pixelFormat)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)pixelFormat);
        }

        public void SetFramebufferOnly(bool framebufferOnly)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFramebufferOnly, framebufferOnly);
        }

        public void SetDrawableSize(IntPtr drawableSize)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDrawableSize, drawableSize);
        }

        private static readonly Selector sel_layer = "layer";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_setDevice = "setDevice:";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_framebufferOnly = "framebufferOnly";
        private static readonly Selector sel_setFramebufferOnly = "setFramebufferOnly:";
        private static readonly Selector sel_drawableSize = "drawableSize";
        private static readonly Selector sel_setDrawableSize = "setDrawableSize:";
    }
}
