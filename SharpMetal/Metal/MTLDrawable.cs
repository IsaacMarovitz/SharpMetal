using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLDrawable
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDrawable obj) => obj.NativePtr;
        public MTLDrawable(IntPtr ptr) => NativePtr = ptr;

        public IntPtr PresentedTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_presentedTime));

        public ulong DrawableID => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_drawableID);

        public void Present()
        {
            objc_msgSend(NativePtr, , );
        }

        public void PresentAtTime(IntPtr presentationTime)
        {
            objc_msgSend(NativePtr, , presentationTime);
        }

        public void PresentAfterMinimumDuration(IntPtr duration)
        {
            objc_msgSend(NativePtr, , duration);
        }

        private static readonly Selector sel_present = "present";
        private static readonly Selector sel_presentAtTime = "presentAtTime:";
        private static readonly Selector sel_presentAfterMinimumDuration = "presentAfterMinimumDuration:";
        private static readonly Selector sel_presentedTime = "presentedTime";
        private static readonly Selector sel_drawableID = "drawableID";
    }
}
