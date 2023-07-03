using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public class NSDictionary
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSDictionary obj) => obj.NativePtr;
        public NSDictionary(IntPtr ptr) => NativePtr = ptr;

        public NSDictionary()
        {
            var cls = new ObjectiveCClass("NSDictionary");
            NativePtr = cls.AllocInit();
        }

        public NSDictionary Dictionary => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_dictionary));

        public NSEnumerator KeyEnumerator => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_keyEnumerator));

        public ulong Count => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_count);

        public NSDictionary Dictionary(NSObject pObject, NSObject pKey)
        {
            throw new NotImplementedException();
        }

        public NSDictionary Dictionary(NSObject pObjects, NSObject pKeys, ulong count)
        {
            throw new NotImplementedException();
        }

        public NSDictionary Init(NSObject pObjects, NSObject pKeys, ulong count)
        {
            throw new NotImplementedException();
        }

        public NSDictionary Init(IntPtr pCoder)
        {
            throw new NotImplementedException();
        }

        public IntPtr Object(NSObject pKey)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_dictionary = "dictionary";
        private static readonly Selector sel_dictionaryWithObjectforKey = "dictionaryWithObject:forKey:";
        private static readonly Selector sel_dictionaryWithObjectsforKeyscount = "dictionaryWithObjects:forKeys:count:";
        private static readonly Selector sel_initWithObjectsforKeyscount = "initWithObjects:forKeys:count:";
        private static readonly Selector sel_initWithCoder = "initWithCoder:";
        private static readonly Selector sel_keyEnumerator = "keyEnumerator";
        private static readonly Selector sel_objectForKey = "objectForKey:";
        private static readonly Selector sel_count = "count";
    }
}
