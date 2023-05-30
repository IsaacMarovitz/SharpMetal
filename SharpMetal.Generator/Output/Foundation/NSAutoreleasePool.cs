using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSAutoreleasePool
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSAutoreleasePool obj) => obj.NativePtr;
        public NSAutoreleasePool(IntPtr ptr) => NativePtr = ptr;

        public NSAutoreleasePool()
        {
            var cls = new ObjectiveCClass("NSAutoreleasePool");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_drain = "drain";
        private static readonly Selector sel_addObject = "addObject:";
        private static readonly Selector sel_showPools = "showPools";
    }
}
