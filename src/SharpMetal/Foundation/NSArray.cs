using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public struct NSArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSArray obj) => obj.NativePtr;
        public NSArray(IntPtr ptr) => NativePtr = ptr;

        public NSArray()
        {
            var cls = new ObjectiveCClass("NSArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong Count => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_count);

        public static NSArray Array(NSObject pObject)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSArray"), sel_arrayWithObject, pObject));
        }

        public static NSArray Array(NSObject pObjects, ulong count)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSArray"), sel_arrayWithObjectscount, pObjects, count));
        }

        public NSArray Init(NSObject pObjects, ulong count)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithObjectscount, pObjects, count));
        }

        public NSArray Init(IntPtr pCoder)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithCoder, pCoder));
        }

        public IntPtr Object(ulong index)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndex, index));
        }

        private static readonly Selector sel_array = "array";
        private static readonly Selector sel_arrayWithObject = "arrayWithObject:";
        private static readonly Selector sel_arrayWithObjectscount = "arrayWithObjects:count:";
        private static readonly Selector sel_initWithObjectscount = "initWithObjects:count:";
        private static readonly Selector sel_initWithCoder = "initWithCoder:";
        private static readonly Selector sel_count = "count";
        private static readonly Selector sel_objectAtIndex = "objectAtIndex:";
        private static readonly Selector sel_release = "release";
    }
}
