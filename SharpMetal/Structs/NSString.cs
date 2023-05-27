using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSString
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSString nsString) => nsString.NativePtr;
        public NSString(IntPtr ptr) => NativePtr = ptr;

        public override string ToString()
        {
            return UTF8String;
        }

        public NSString(string value)
        {
            var cls = new ObjectiveCClass("NSString");
            var alloc = cls.Alloc();
            NativePtr = ObjectiveCRuntime.IntPtr_objc_msgSend(alloc, sel_initWithUTF8String, value);
        }

        public string UTF8String
        {
            get
            {
                var ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_UTF8String);
                return Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
            }
        }

        private static readonly Selector sel_initWithUTF8String = "initWithUTF8String:";
        private static readonly Selector sel_UTF8String = "UTF8String";
    }
}