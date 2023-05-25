using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public static unsafe partial class ObjectiveCRuntime
    {
        private const string ObjCRuntime = "/usr/lib/libobjc.A.dylib";

        [LibraryImport(ObjCRuntime, StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr objc_getClass(string name);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, byte value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr value, uint a);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, double value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, [MarshalAs(UnmanagedType.Bool)] bool value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool bool_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial long long_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ulong ulong_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ulong uint64_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial uint uint32_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial double double_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial string string_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, uint a);

        [LibraryImport(ObjCRuntime)]
        public static partial IntPtr class_getProperty(ObjectiveCClass cls, IntPtr namePtr);

        [LibraryImport(ObjCRuntime)]
        public static partial IntPtr class_getName(ObjectiveCClass cls);

        [LibraryImport(ObjCRuntime)]
        public static partial ObjectiveCMethod* class_copyMethodList(ObjectiveCClass cls, out uint outCount);

        [LibraryImport(ObjCRuntime)]
        public static partial Selector method_getName(ObjectiveCMethod method);

        public static T objc_msgSend<T>(IntPtr receiver, Selector selector) where T : struct
        {
            IntPtr value = IntPtr_objc_msgSend(receiver, selector);
            return Unsafe.AsRef<T>(&value);
        }
        public static T objc_msgSend<T>(IntPtr receiver, Selector selector, IntPtr a) where T : struct
        {
            IntPtr value = IntPtr_objc_msgSend(receiver, selector, a);
            return Unsafe.AsRef<T>(&value);
        }
    }
}