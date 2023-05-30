using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSLocking
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSLocking obj) => obj.NativePtr;
        public NSLocking(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public struct NSCondition
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSCondition obj) => obj.NativePtr;
        public NSCondition(IntPtr ptr) => NativePtr = ptr;

        public NSCondition()
        {
            var cls = new ObjectiveCClass("NSCondition");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_wait = "wait";
        private static readonly Selector sel_waitUntilDate = "waitUntilDate:";
        private static readonly Selector sel_signal = "signal";
        private static readonly Selector sel_broadcast = "broadcast";
    }
}
