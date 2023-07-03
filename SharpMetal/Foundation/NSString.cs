using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Foundation
{
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
    public class NSString
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSString obj) => obj.NativePtr;
        public NSString(IntPtr ptr) => NativePtr = ptr;

        public NSString()
        {
            var cls = new ObjectiveCClass("NSString");
            NativePtr = cls.AllocInit();
        }

        public ulong Length => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_length);

        public ushort Utf8String => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_UTF8String);

        public ushort FileSystemRepresentation => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_fileSystemRepresentation);

        public NSString String(NSString pString)
        {
            throw new NotImplementedException();
        }

        public NSString String()
        {
            throw new NotImplementedException();
        }

        public NSString String(ushort pString, NSStringEncoding encoding)
        {
            throw new NotImplementedException();
        }

        public NSString Init(NSString pString)
        {
            throw new NotImplementedException();
        }

        public NSString Init(ushort pString, NSStringEncoding encoding)
        {
            throw new NotImplementedException();
        }

        public NSString Init(IntPtr pBytes, ulong len, NSStringEncoding encoding, bool freeBuffer)
        {
            throw new NotImplementedException();
        }

        public ushort Character(ulong index)
        {
            throw new NotImplementedException();
        }

        public ushort CString(NSStringEncoding encoding)
        {
            throw new NotImplementedException();
        }

        public ulong MaximumLengthOfBytes(NSStringEncoding encoding)
        {
            throw new NotImplementedException();
        }

        public ulong LengthOfBytes(NSStringEncoding encoding)
        {
            throw new NotImplementedException();
        }

        public bool IsEqualToString(NSString pString)
        {
            throw new NotImplementedException();
        }

        public NSRange RangeOfString(NSString pString, NSStringCompareOptions options)
        {
            throw new NotImplementedException();
        }

        public NSString StringByAppendingString(NSString pString)
        {
            throw new NotImplementedException();
        }

        public NSComparisonResult CaseInsensitiveCompare(NSString pString)
        {
            throw new NotImplementedException();
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
        private static readonly Selector sel_UTF8String = "UTF8String";
        private static readonly Selector sel_maximumLengthOfBytesUsingEncoding = "maximumLengthOfBytesUsingEncoding:";
        private static readonly Selector sel_lengthOfBytesUsingEncoding = "lengthOfBytesUsingEncoding:";
        private static readonly Selector sel_isEqualToString = "isEqualToString:";
        private static readonly Selector sel_rangeOfStringoptions = "rangeOfString:options:";
        private static readonly Selector sel_fileSystemRepresentation = "fileSystemRepresentation";
        private static readonly Selector sel_stringByAppendingString = "stringByAppendingString:";
        private static readonly Selector sel_caseInsensitiveCompare = "caseInsensitiveCompare:";
    }
}
