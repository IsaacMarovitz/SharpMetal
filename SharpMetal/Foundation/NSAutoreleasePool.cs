using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSAutoreleasePool
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSAutoreleasePool obj) => obj.NativePtr;
        public NSAutoreleasePool(IntPtr ptr) => NativePtr = ptr;

        public NSAutoreleasePool()
        {
            var cls = new ObjectiveCClass("NSAutoreleasePool");
            NativePtr = cls.AllocInit();
        }

        public void Drain()
        {
            throw new NotImplementedException();
        }

        public void AddObject(NSObject pObject)
        {
            throw new NotImplementedException();
        }

        public void ShowPools()
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_drain = "drain";
        private static readonly Selector sel_addObject = "addObject:";
        private static readonly Selector sel_showPools = "showPools";
    }
}
