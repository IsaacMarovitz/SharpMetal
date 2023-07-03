using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSDate
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSDate obj) => obj.NativePtr;
        public NSDate(IntPtr ptr) => NativePtr = ptr;

        public NSDate DateWithTimeIntervalSinceNow(IntPtr secs) {

        }

        private static readonly Selector sel_dateWithTimeIntervalSinceNow = "dateWithTimeIntervalSinceNow:";
    }
}
