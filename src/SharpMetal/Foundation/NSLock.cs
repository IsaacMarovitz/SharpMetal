using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public struct NSCondition : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSCondition obj) => obj.NativePtr;
        public NSCondition(IntPtr ptr) => NativePtr = ptr;

        public NSCondition()
        {
            var cls = new ObjectiveCClass("NSCondition");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public void Broadcast()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_broadcast);
        }

        public void Signal()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_signal);
        }

        public void Wait()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_wait);
        }

        public bool WaitUntilDate(NSDate pLimit)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_waitUntilDate, pLimit);
        }

        private static readonly Selector sel_broadcast = "broadcast";
        private static readonly Selector sel_signal = "signal";
        private static readonly Selector sel_wait = "wait";
        private static readonly Selector sel_waitUntilDate = "waitUntilDate:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct NSLocking : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSLocking obj) => obj.NativePtr;
        public NSLocking(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }
        private static readonly Selector sel_release = "release";
    }
}
