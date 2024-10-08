using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public struct NSDate : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSDate obj) => obj.NativePtr;
        public NSDate(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public static NSDate DateWithTimeIntervalSinceNow(IntPtr secs)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSDate"), sel_dateWithTimeIntervalSinceNow, secs));
        }

        private static readonly Selector sel_dateWithTimeIntervalSinceNow = "dateWithTimeIntervalSinceNow:";
        private static readonly Selector sel_release = "release";
    }
}
