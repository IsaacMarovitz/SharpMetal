using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSError
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSError obj) => obj.NativePtr;
        public NSError(IntPtr ptr) => NativePtr = ptr;

        public NSError()
        {
            var cls = new ObjectiveCClass("NSError");
            NativePtr = cls.AllocInit();
        }

        public long Code => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_code);

        public IntPtr Domain => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_domain));

        public NSDictionary UserInfo => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_userInfo));

        public NSString LocalizedDescription => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_localizedDescription));

        public NSArray LocalizedRecoveryOptions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_localizedRecoveryOptions));

        public NSString LocalizedRecoverySuggestion => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_localizedRecoverySuggestion));

        public NSString LocalizedFailureReason => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_localizedFailureReason));

        public NSError Error(IntPtr domain, long code, NSDictionary pDictionary) {

        }

        public NSError Init(IntPtr domain, long code, NSDictionary pDictionary) {

        }

        private static readonly Selector sel_errorWithDomaincodeuserInfo = "errorWithDomain:code:userInfo:";
        private static readonly Selector sel_initWithDomaincodeuserInfo = "initWithDomain:code:userInfo:";
        private static readonly Selector sel_code = "code";
        private static readonly Selector sel_domain = "domain";
        private static readonly Selector sel_userInfo = "userInfo";
        private static readonly Selector sel_localizedDescription = "localizedDescription";
        private static readonly Selector sel_localizedRecoveryOptions = "localizedRecoveryOptions";
        private static readonly Selector sel_localizedRecoverySuggestion = "localizedRecoverySuggestion";
        private static readonly Selector sel_localizedFailureReason = "localizedFailureReason";
    }
}
