using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSArray obj) => obj.NativePtr;
        public NSArray(IntPtr ptr) => NativePtr = ptr;

        public NSArray()
        {
            var cls = new ObjectiveCClass("NSArray");
            NativePtr = cls.AllocInit();
        }

        public ulong Count => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_count);

        public NSArray Array(NSObject pObject)
        {
            throw new NotImplementedException();
        }

        public NSArray Array()
        {
            throw new NotImplementedException();
        }

        public NSArray Array(NSObject pObjects, ulong count)
        {
            throw new NotImplementedException();
        }

        public NSArray Init(NSObject pObjects, ulong count)
        {
            throw new NotImplementedException();
        }

        public NSArray Init(IntPtr pCoder)
        {
            throw new NotImplementedException();
        }

        public IntPtr Object(ulong index)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_array = "array";
        private static readonly Selector sel_arrayWithObject = "arrayWithObject:";
        private static readonly Selector sel_arrayWithObjectscount = "arrayWithObjects:count:";
        private static readonly Selector sel_initWithObjectscount = "initWithObjects:count:";
        private static readonly Selector sel_initWithCoder = "initWithCoder:";
        private static readonly Selector sel_count = "count";
        private static readonly Selector sel_objectAtIndex = "objectAtIndex:";
    }
}
