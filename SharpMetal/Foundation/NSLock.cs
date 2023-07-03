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
            throw new NotImplementedException();
        }

        public void Unlock()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool WaitUntilDate(NSDate pLimit)
        {
            throw new NotImplementedException();
        }

        public void Signal()
        {
            throw new NotImplementedException();
        }

        public void Broadcast()
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_wait = "wait";
        private static readonly Selector sel_waitUntilDate = "waitUntilDate:";
        private static readonly Selector sel_signal = "signal";
        private static readonly Selector sel_broadcast = "broadcast";
    }
}
