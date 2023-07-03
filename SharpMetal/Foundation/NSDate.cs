using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSDate
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSDate obj) => obj.NativePtr;
        public NSDate(IntPtr ptr) => NativePtr = ptr;

        public NSDate DateWithTimeIntervalSinceNow(IntPtr secs)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_dateWithTimeIntervalSinceNow = "dateWithTimeIntervalSinceNow:";
    }
}
