using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLDrawable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDrawable obj) => obj.NativePtr;
        public MTLDrawable(IntPtr ptr) => NativePtr = ptr;

        public IntPtr PresentedTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_presentedTime));

        public ulong DrawableID => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_drawableID);

        public void Present()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_present);
        }

        public void PresentAtTime(IntPtr presentationTime)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentAtTime, presentationTime);
        }

        public void PresentAfterMinimumDuration(IntPtr duration)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentAfterMinimumDuration, duration);
        }

        private static readonly Selector sel_present = "present";
        private static readonly Selector sel_presentAtTime = "presentAtTime:";
        private static readonly Selector sel_presentAfterMinimumDuration = "presentAfterMinimumDuration:";
        private static readonly Selector sel_presentedTime = "presentedTime";
        private static readonly Selector sel_drawableID = "drawableID";
    }
}
