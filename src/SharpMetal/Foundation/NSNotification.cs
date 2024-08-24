using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public struct NSNotification : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSNotification obj) => obj.NativePtr;
        public NSNotification(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public NSObject Object => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_object));

        public NSDictionary UserInfo => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_userInfo));

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_object = "object";
        private static readonly Selector sel_userInfo = "userInfo";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct NSNotificationCenter : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSNotificationCenter obj) => obj.NativePtr;
        public NSNotificationCenter(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public static NSNotificationCenter DefaultCenter()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSNotificationCenter"), sel_defaultCenter));
        }

        private static readonly Selector sel_defaultCenter = "defaultCenter";
        private static readonly Selector sel_release = "release";
    }
}
