using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public partial class NSAutoreleasePool
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
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drain);
        }

        public void AddObject(NSObject pObject)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addObject, pObject);
        }

        public static void ShowPools()
        {
            throw new NotSupportedException();
        }

        private static readonly Selector sel_drain = "drain";
        private static readonly Selector sel_addObject = "addObject:";
        private static readonly Selector sel_showPools = "showPools";
    }
}
