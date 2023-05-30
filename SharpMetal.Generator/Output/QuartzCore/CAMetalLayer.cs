using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct CAMetalLayer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalLayer obj) => obj.NativePtr;
        public CAMetalLayer(IntPtr ptr) => NativePtr = ptr;

        public CAMetalLayer Layer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layer));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPixelFormat);
        public bool FramebufferOnly => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_framebufferOnly);
        public IntPtr DrawableSize => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_drawableSize));
        public CAMetalDrawable NextDrawable;

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
