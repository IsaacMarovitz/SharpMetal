using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Metal;

namespace SharpMetal.ObjectiveCCore
{
    [SupportedOSPlatform("macos")]
    public static partial class ObjectiveC
    {
        public const string ObjCRuntime = "/usr/lib/libobjc.A.dylib";
        public const string Libdl = "libdl.dylib";
        public const string LibSystem = "/usr/lib/libSystem.dylib";

        public const string CoreGraphicsFramework = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";
        public const string AppKitFramework = "/System/Library/Frameworks/AppKit.framework/AppKit";
        public const string MetalFramework = "/System/Library/Frameworks/Metal.framework/Metal";
        public const string MetalKitFramework = "/System/Library/Frameworks/MetalKit.framework/MetalKit";

        [LibraryImport(ObjCRuntime, StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr objc_getClass(string name);

        [LibraryImport(Libdl, StringMarshalling = StringMarshalling.Utf8)]
        private static partial IntPtr dlopen(string path, int mode);

        [LibraryImport(LibSystem, StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr dlsym(IntPtr handle, string symbol);

        [LibraryImport(ObjCRuntime)]
        public static unsafe partial IntPtr objc_allocateClassPair(IntPtr superclass, char* name, int extraBytes);

        [LibraryImport(ObjCRuntime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool class_addMethod(IntPtr cls, Selector selector, IntPtr imp, char* types);

        [LibraryImport(ObjCRuntime)]
        public static partial void objc_registerClassPair(IntPtr cls);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, NSRect rect);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, IntPtr selector, MTLClearColor a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, IntPtr selector, MTLPixelFormat a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, IntPtr selector, MTLPixelFormat a, int b);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, byte value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, double value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, IntPtr ptr);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool bool_objc_msgSend(IntPtr receiver, Selector selector, char* buffer, ulong maxBufferCount, ulong encoding);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool bool_objc_msgSend(IntPtr receiver, Selector selector, long activationPolicy);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, ulong format, ulong index);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, NSRect rect, byte value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, NSRect rect, IntPtr value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, [MarshalAs(UnmanagedType.Bool)] bool value);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, NSRect contentRect, ulong style, ulong backingStoreType, [MarshalAs(UnmanagedType.Bool)] bool flag);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, string param);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial string string_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool bool_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial ulong ulong_objc_msgSend(IntPtr receiver, Selector selector);

        public static IntPtr LinkMetal()
        {
            return dlopen(MetalFramework, 0);
        }

        public static IntPtr LinkCoreGraphics()
        {
            return dlopen(CoreGraphicsFramework, 0);
        }

        public static IntPtr LinkAppKit()
        {
            return dlopen(AppKitFramework, 0);
        }

        public static IntPtr LinkMetalKit()
        {
            return dlopen(MetalKitFramework, 0);
        }

        public static IntPtr LinkLibSystem()
        {
            return dlopen(LibSystem, 0);
        }
    }

    public readonly struct NSPoint
    {
        public readonly double X;
        public readonly double Y;

        public NSPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public readonly struct NSRect
    {
        public readonly NSPoint Pos;
        public readonly NSPoint Size;

        public NSRect(double x, double y, double width, double height)
        {
            Pos = new NSPoint(x, y);
            Size = new NSPoint(width, height);
        }
    }
}
