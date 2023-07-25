using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public partial class NSDictionary
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSDictionary obj) => obj.NativePtr;
        public NSDictionary(IntPtr ptr) => NativePtr = ptr;

        public NSDictionary()
        {
            var cls = new ObjectiveCClass("NSDictionary");
            NativePtr = cls.AllocInit();
        }

        public NSEnumerator KeyEnumerator => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_keyEnumerator));

        public ulong Count => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_count);

        public static NSDictionary Dictionary(NSObject pObject, NSObject pKey)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSDictionary"), sel_dictionaryWithObjectforKey, pObject, pKey));
        }

        public static NSDictionary Dictionary(NSObject pObjects, NSObject pKeys, ulong count)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSDictionary"), sel_dictionaryWithObjectsforKeyscount, pObjects, pKeys, count));
        }

        public NSDictionary Init(NSObject pObjects, NSObject pKeys, ulong count)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithObjectsforKeyscount, pObjects, pKeys, count));
        }

        public NSDictionary Init(IntPtr pCoder)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithCoder, pCoder));
        }

        public IntPtr Object(NSObject pKey)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectForKey, pKey));
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
