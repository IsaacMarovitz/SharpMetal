using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSSet
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSSet obj) => obj.NativePtr;
        public NSSet(IntPtr ptr) => NativePtr = ptr;

        public NSSet()
        {
            var cls = new ObjectiveCClass("NSSet");
            NativePtr = cls.AllocInit();
        }

        public ulong Count => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_count);

        public IntPtr ObjectEnumerator => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectEnumerator));

        public NSSet Init(NSObject pObjects, ulong count)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithObjectscount, pObjects, count));
        }

        public NSSet Init(IntPtr pCoder)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithCoder, pCoder));
        }

        private static readonly Selector sel_count = "count";
        private static readonly Selector sel_objectEnumerator = "objectEnumerator";
        private static readonly Selector sel_initWithObjectscount = "initWithObjects:count:";
        private static readonly Selector sel_initWithCoder = "initWithCoder:";
    }
}
