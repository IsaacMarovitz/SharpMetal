using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSNotification
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
    public class NSNotificationCenter
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSNotificationCenter obj) => obj.NativePtr;
        public NSNotificationCenter(IntPtr ptr) => NativePtr = ptr;

        public NSNotificationCenter DefaultCenter => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_defaultCenter));

        public  (NS public:)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_defaultCenter = "defaultCenter";
    }
}
