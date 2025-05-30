using System.Diagnostics;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public enum NSStringEncoding : ulong
    {
        ASCII = 1,
        NEXTSTEP = 2,
        JapaneseEUC = 3,
        UTF8 = 4,
        ISOLatin1 = 5,
        Symbol = 6,
        NonLossyASCII = 7,
        ShiftJIS = 8,
        ISOLatin2 = 9,
        Unicode = 10,
        WindowsCP1251 = 11,
        WindowsCP1252 = 12,
        WindowsCP1253 = 13,
        WindowsCP1254 = 14,
        WindowsCP1250 = 15,
        ISO2022JP = 21,
        MacOSRoman = 30,
        UTF16 = Unicode,
        UTF16BigEndian = 0x90000100,
        UTF16LittleEndian = 0x94000100,
        UTF32 = 0x8c000100,
        UTF32BigEndian = 0x98000100,
        UTF32LittleEndian = 0x9c000100,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum NSStringCompareOptions : ulong
    {
        CaseInsensitiveSearch = 1,
        LiteralSearch = 2,
        BackwardsSearch = 4,
        AnchoredSearch = 8,
        NumericSearch = 64,
        DiacriticInsensitiveSearch = 128,
        WidthInsensitiveSearch = 256,
        ForcedOrderingSearch = 512,
        RegularExpressionSearch = 1024,
    }

    [SupportedOSPlatform("macos")]
    public struct NSString : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSString obj) => obj.NativePtr;
        public static implicit operator NSString(string? value) => String(value);

        public NSString(IntPtr ptr) => NativePtr = ptr;

        public NSString()
        {
            var cls = new ObjectiveCClass("NSString");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong Length => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_length);

        public ushort Utf8String => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_UTF8String);

        public ushort FileSystemRepresentation => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_fileSystemRepresentation);

        public static NSString String(NSString pString)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), sel_stringWithString, pString));
        }

        public static NSString String(ushort pString, NSStringEncoding encoding)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), sel_stringWithCStringencoding, pString, (ulong)encoding));
        }

        public static NSString String(string? value)
        {
            if (value == null)
            {
                return new NSString(IntPtr.Zero);
            }
            return new(ObjectiveC.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), sel_cStringWithUTF8String, value));
        }

        public NSString Init(NSString pString)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithString, pString));
        }

        public NSString Init(ushort pString, NSStringEncoding encoding)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithCStringencoding, pString, (ulong)encoding));
        }

        public NSString Init(IntPtr pBytes, ulong len, NSStringEncoding encoding, bool freeBuffer)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithBytesNoCopylengthencodingfreeWhenDone, pBytes, len, (ulong)encoding, freeBuffer));
        }

        public ushort Character(ulong index)
        {
            return ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_characterAtIndex, index);
        }

        public ushort CString(NSStringEncoding encoding)
        {
            return ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_cStringUsingEncoding, (ulong)encoding);
        }

        public ulong MaximumLengthOfBytes(NSStringEncoding encoding)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maximumLengthOfBytesUsingEncoding, (ulong)encoding);
        }

        public ulong LengthOfBytes(NSStringEncoding encoding)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maximumLengthOfBytesUsingEncoding, (ulong)encoding);
        }

        public bool IsEqualToString(NSString pString)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isEqualToString, pString);
        }

        public NSRange RangeOfString(NSString pString, NSStringCompareOptions options)
        {
            return ObjectiveCRuntime.NSRange_objc_msgSend(NativePtr, sel_rangeOfStringoptions, pString, (ulong)options);
        }

        public NSString StringByAppendingString(NSString pString)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stringByAppendingString, pString));
        }

        public NSComparisonResult CaseInsensitiveCompare(NSString pString)
        {
            return (NSComparisonResult)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_caseInsensitiveCompare, pString);
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

        private static readonly Selector sel_string = "string";
        private static readonly Selector sel_stringWithString = "stringWithString:";
        private static readonly Selector sel_stringWithCStringencoding = "stringWithCString:encoding:";
        private static readonly Selector sel_initWithString = "initWithString:";
        private static readonly Selector sel_initWithCStringencoding = "initWithCString:encoding:";
        private static readonly Selector sel_initWithBytesNoCopylengthencodingfreeWhenDone = "initWithBytesNoCopy:length:encoding:freeWhenDone:";
        private static readonly Selector sel_characterAtIndex = "characterAtIndex:";
        private static readonly Selector sel_length = "length";
        private static readonly Selector sel_cStringUsingEncoding = "cStringUsingEncoding:";
        private static readonly Selector sel_cStringWithUTF8String = "stringWithUTF8String:";
        private static readonly Selector sel_UTF8String = "UTF8String";
        private static readonly Selector sel_maximumLengthOfBytesUsingEncoding = "maximumLengthOfBytesUsingEncoding:";
        private static readonly Selector sel_lengthOfBytesUsingEncoding = "lengthOfBytesUsingEncoding:";
        private static readonly Selector sel_isEqualToString = "isEqualToString:";
        private static readonly Selector sel_rangeOfStringoptions = "rangeOfString:options:";
        private static readonly Selector sel_fileSystemRepresentation = "fileSystemRepresentation";
        private static readonly Selector sel_stringByAppendingString = "stringByAppendingString:";
        private static readonly Selector sel_caseInsensitiveCompare = "caseInsensitiveCompare:";
        private static readonly Selector sel_release = "release";
    }
}
