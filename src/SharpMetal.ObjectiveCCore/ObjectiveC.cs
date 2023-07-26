using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveCCore
{
    [SupportedOSPlatform("macos")]
    public static partial class ObjectiveC
    {
        public const string ObjCRuntime = "/usr/lib/libobjc.A.dylib";
        public const string MetalFramework = "/System/Library/Frameworks/Metal.framework/Metal";

        [LibraryImport(ObjCRuntime, StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr objc_getClass(string name);

        [LibraryImport("libdl.dylib", StringMarshalling = StringMarshalling.Utf8)]
        private static partial void dlopen(string path, int mode);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, NSRect rect);

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
        public static partial void objc_msgSend(IntPtr receiver, Selector selector, NSRect rect, byte value);

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

        public static void LinkMetal()
        {
            dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
        }

        public static void LinkCoreGraphics()
        {
            dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);
        }

        public static void LinkAppKit()
        {
            dlopen("/System/Library/Frameworks/AppKit.framework/AppKit", 0);
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
