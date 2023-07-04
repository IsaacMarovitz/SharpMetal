using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public partial class NSNotification
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSNotification obj) => obj.NativePtr;
        public NSNotification(IntPtr ptr) => NativePtr = ptr;

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public NSObject Object => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_object));

        public NSDictionary UserInfo => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_userInfo));

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_object = "object";
        private static readonly Selector sel_userInfo = "userInfo";
    }

    [SupportedOSPlatform("macos")]
    public partial class NSNotificationCenter
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSNotificationCenter obj) => obj.NativePtr;
        public NSNotificationCenter(IntPtr ptr) => NativePtr = ptr;

        public static NSNotificationCenter DefaultCenter()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSNotificationCenter"), sel_defaultCenter));
        }

        private static readonly Selector sel_defaultCenter = "defaultCenter";
    }
}
