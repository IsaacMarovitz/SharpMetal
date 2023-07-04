using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public partial class NSLocking
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSLocking obj) => obj.NativePtr;
        public NSLocking(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public partial class NSCondition
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSCondition obj) => obj.NativePtr;
        public NSCondition(IntPtr ptr) => NativePtr = ptr;

        public NSCondition()
        {
            var cls = new ObjectiveCClass("NSCondition");
            NativePtr = cls.AllocInit();
        }

        public void Wait()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_wait);
        }

        public bool WaitUntilDate(NSDate pLimit)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_waitUntilDate, pLimit);
        }

        public void Signal()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_signal);
        }

        public void Broadcast()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_broadcast);
        }

        private static readonly Selector sel_wait = "wait";
        private static readonly Selector sel_waitUntilDate = "waitUntilDate:";
        private static readonly Selector sel_signal = "signal";
        private static readonly Selector sel_broadcast = "broadcast";
    }
}
