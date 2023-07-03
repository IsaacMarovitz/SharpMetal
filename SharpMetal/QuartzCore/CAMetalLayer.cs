using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Metal;

namespace SharpMetal.QuartzCore
{
    [SupportedOSPlatform("macos")]
    public class CAMetalLayer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalLayer obj) => obj.NativePtr;
        public CAMetalLayer(IntPtr ptr) => NativePtr = ptr;

        public CAMetalLayer Layer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layer));

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
            throw new NotImplementedException();
        }

        public void SetPixelFormat(MTLPixelFormat pixelFormat)
        {
            throw new NotImplementedException();
        }

        public void SetFramebufferOnly(bool framebufferOnly)
        {
            throw new NotImplementedException();
        }

        public void SetDrawableSize(IntPtr drawableSize)
        {
            throw new NotImplementedException();
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
