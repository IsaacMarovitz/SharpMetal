using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSLocking
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSLocking obj) => obj.NativePtr;
        public NSLocking(IntPtr ptr) => NativePtr = ptr;

        public void Lock()
        {
            objc_msgSend(NativePtr, , );
        }

        public void Unlock()
        {
            objc_msgSend(NativePtr, , );
        }
    }

    [SupportedOSPlatform("macos")]
    public class NSCondition
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
            objc_msgSend(NativePtr, , );
        }

        public bool WaitUntilDate(NSDate pLimit)
        {
            throw new NotImplementedException();
        }

        public void Signal()
        {
            objc_msgSend(NativePtr, , );
        }

        public void Broadcast()
        {
            objc_msgSend(NativePtr, , );
        }

        private static readonly Selector sel_wait = "wait";
        private static readonly Selector sel_waitUntilDate = "waitUntilDate:";
        private static readonly Selector sel_signal = "signal";
        private static readonly Selector sel_broadcast = "broadcast";
    }
}
