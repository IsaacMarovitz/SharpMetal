using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.QuartzCore
{
    [SupportedOSPlatform("macos")]
    public struct CAMetalLayer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalLayer obj) => obj.NativePtr;
        public CAMetalLayer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDevice, value);
        }

        public IntPtr Colorspace
        {
            get => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorspace);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorspace, value);
        }

        public bool DisplaySyncEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_displaySyncEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDisplaySyncEnabled, value);
        }

        public IntPtr DrawableSize
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_drawableSize));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDrawableSize, value);
        }

        public bool FramebufferOnly
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_framebufferOnly);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFramebufferOnly, value);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
        }

        private static readonly Selector sel_colorspace = "colorspace";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_displaySyncEnabled = "displaySyncEnabled";
        private static readonly Selector sel_drawableSize = "drawableSize";
        private static readonly Selector sel_framebufferOnly = "framebufferOnly";
        private static readonly Selector sel_layer = "layer";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setColorspace = "setColorspace:";
        private static readonly Selector sel_setDevice = "setDevice:";
        private static readonly Selector sel_setDisplaySyncEnabled = "setDisplaySyncEnabled:";
        private static readonly Selector sel_setDrawableSize = "setDrawableSize:";
        private static readonly Selector sel_setFramebufferOnly = "setFramebufferOnly:";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_release = "release";
    }
}
