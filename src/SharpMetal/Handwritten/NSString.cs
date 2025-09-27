using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    public partial struct NSString
    {
        public static implicit operator NSString(string? value) => String(value);

        public static NSString String(string? value)
        {
            if (value == null)
            {
                return new NSString(IntPtr.Zero);
            }
            return new(ObjectiveC.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), sel_cStringWithUTF8String, value));
        }

        public override unsafe string? ToString()
        {
            if (NativePtr == IntPtr.Zero)
            {
                return null;
            }

            char[] sourceBuffer = new char[Length];
            fixed (char* pSourceBuffer = sourceBuffer)
            {
                ObjectiveC.bool_objc_msgSend(NativePtr, "getCString:maxLength:encoding:", pSourceBuffer, MaximumLengthOfBytes(NSStringEncoding.UTF16) + 1, (ulong)NSStringEncoding.UTF16);

                return new string(pSourceBuffer);
            }
        }

        private static readonly Selector sel_cStringWithUTF8String = "stringWithUTF8String:";
    }
}
