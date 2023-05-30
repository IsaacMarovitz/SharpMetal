using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLDrawable
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDrawable obj) => obj.NativePtr;
        public MTLDrawable(IntPtr ptr) => NativePtr = ptr;

        public IntPtr PresentedTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_presentedTime));
        public ulong DrawableID => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_drawableID);

        private static readonly Selector sel_present = "present";
        private static readonly Selector sel_presentAtTime = "presentAtTime:";
        private static readonly Selector sel_presentAfterMinimumDuration = "presentAfterMinimumDuration:";
        private static readonly Selector sel_addPresentedHandler = "addPresentedHandler:";
        private static readonly Selector sel_presentedTime = "presentedTime";
        private static readonly Selector sel_drawableID = "drawableID";
    }
}
