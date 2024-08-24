using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]

    [SupportedOSPlatform("macos")]
    public struct NSCopying : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSCopying obj) => obj.NativePtr;
        public NSCopying(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct NSSecureCoding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSSecureCoding obj) => obj.NativePtr;
        public NSSecureCoding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct NSObject : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSObject obj) => obj.NativePtr;
        public NSObject(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong Hash => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hash);

        public NSString Description => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_description));

        public NSString DebugDescription => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_debugDescription));

        public bool IsEqual(NSObject pObject)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isEqual, pObject);
        }

        private static readonly Selector sel_methodSignatureForSelector = "methodSignatureForSelector:";
        private static readonly Selector sel_respondsToSelector = "respondsToSelector:";
        private static readonly Selector sel_alloc = "alloc";
        private static readonly Selector sel_init = "init";
        private static readonly Selector sel_hash = "hash";
        private static readonly Selector sel_isEqual = "isEqual:";
        private static readonly Selector sel_description = "description";
        private static readonly Selector sel_debugDescription = "debugDescription";
        private static readonly Selector sel_release = "release";
    }
}
