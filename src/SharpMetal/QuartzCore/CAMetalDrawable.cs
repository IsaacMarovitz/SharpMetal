using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.QuartzCore
{
    [SupportedOSPlatform("macos")]
    public struct CAMetalDrawable : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalDrawable obj) => obj.NativePtr;
        public static implicit operator MTLDrawable(CAMetalDrawable obj) => new(obj.NativePtr);
        public CAMetalDrawable(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong DrawableID => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_drawableID);

        public CAMetalLayer Layer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layer));

        public IntPtr PresentedTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_presentedTime));

        public MTLTexture Texture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));

        public void Present()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_present);
        }

        public void PresentAfterMinimumDuration(IntPtr duration)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentAfterMinimumDuration, duration);
        }

        public void PresentAtTime(IntPtr presentationTime)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentAtTime, presentationTime);
        }

        private static readonly Selector sel_drawableID = "drawableID";
        private static readonly Selector sel_layer = "layer";
        private static readonly Selector sel_present = "present";
        private static readonly Selector sel_presentAfterMinimumDuration = "presentAfterMinimumDuration:";
        private static readonly Selector sel_presentAtTime = "presentAtTime:";
        private static readonly Selector sel_presentedTime = "presentedTime";
        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_release = "release";
    }
}
