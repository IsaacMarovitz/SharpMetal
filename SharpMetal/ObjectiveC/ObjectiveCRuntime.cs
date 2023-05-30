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

        [LibraryImport("libdl.dylib", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void dlopen(string path, int mode);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, ulong b, ulong c, IntPtr d, ulong e, ulong f);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, ulong b, IntPtr c, ulong d);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, ulong d);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, IntPtr b, IntPtr c, ulong d, ulong e);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, ulong value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, ulong a, ulong b);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr value, uint a);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, double value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, float value);

        [LibraryImport(ObjCRuntime, StringMarshalling = StringMarshalling.Utf8)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, NSString value);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, [MarshalAs(UnmanagedType.Bool)] bool value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool bool_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool bool_objc_msgSend(IntPtr receiver, Selector selector, long a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool bool_objc_msgSend(IntPtr receiver, Selector selector, ulong a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial long long_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial int int_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial uint uint_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial float float_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ulong ulong_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ulong ulong_objc_msgSend(IntPtr receiver, Selector selector, ulong a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ulong uint64_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial uint uint32_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial double double_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial byte byte_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial char char_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial short short_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ushort ushort_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial string string_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial NSString nsString_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, string value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, ulong a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, ulong a, ulong b);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, uint a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, ulong b, ulong c);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a, ulong b, ulong c, IntPtr d);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, ulong b, ulong c, ulong d, long e);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, ulong b, ulong c, ulong d);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, MTLPixelFormat pixelFormat, ulong width, ulong height, [MarshalAs(UnmanagedType.Bool)] bool mipmapped);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, MTLPixelFormat pixelFormat, ulong width, [MarshalAs(UnmanagedType.Bool)] bool mipmapped);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, MTLPixelFormat pixelFormat, ulong width, MTLResourceOptions resourceOptions, MTLTextureUsage usage);

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