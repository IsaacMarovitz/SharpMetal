using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public class NSValue
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSValue obj) => obj.NativePtr;
        public NSValue(IntPtr ptr) => NativePtr = ptr;

        public NSValue()
        {
            var cls = new ObjectiveCClass("NSValue");
            NativePtr = cls.Alloc();
        }

        public ushort ObjCType => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_objCType);

        public IntPtr PointerValue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_pointerValue));

        public NSValue Value(IntPtr pValue, ushort pType)
        {
            throw new NotImplementedException();
        }

        public NSValue Value(IntPtr pPointer)
        {
            throw new NotImplementedException();
        }

        public NSValue Init(IntPtr pValue, ushort pType)
        {
            throw new NotImplementedException();
        }

        public NSValue Init(IntPtr pCoder)
        {
            throw new NotImplementedException();
        }

        public void GetValue(IntPtr pValue, ulong size)
        {
            throw new NotImplementedException();
        }

        public bool IsEqualToValue(NSValue pValue)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_valueWithBytesobjCType = "valueWithBytes:objCType:";
        private static readonly Selector sel_valueWithPointer = "valueWithPointer:";
        private static readonly Selector sel_initWithBytesobjCType = "initWithBytes:objCType:";
        private static readonly Selector sel_initWithCoder = "initWithCoder:";
        private static readonly Selector sel_getValuesize = "getValue:size:";
        private static readonly Selector sel_objCType = "objCType";
        private static readonly Selector sel_isEqualToValue = "isEqualToValue:";
        private static readonly Selector sel_pointerValue = "pointerValue";
    }

    [SupportedOSPlatform("macos")]
    public class NSNumber
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSNumber obj) => obj.NativePtr;
        public NSNumber(IntPtr ptr) => NativePtr = ptr;

        public NSNumber()
        {
            var cls = new ObjectiveCClass("NSNumber");
            NativePtr = cls.Alloc();
        }

        public ushort CharValue => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_charValue);

        public byte UnsignedCharValue => ObjectiveCRuntime.byte_objc_msgSend(NativePtr, sel_unsignedCharValue);

        public short ShortValue => ObjectiveCRuntime.short_objc_msgSend(NativePtr, sel_shortValue);

        public ushort UnsignedShortValue => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_unsignedShortValue);

        public int IntValue => ObjectiveCRuntime.int_objc_msgSend(NativePtr, sel_intValue);

        public uint UnsignedIntValue => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_unsignedIntValue);

        public long LongValue => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_longValue);

        public ulong UnsignedLongValue => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_unsignedLongValue);

        public long LongLongValue => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_longLongValue);

        public ulong UnsignedLongLongValue => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_unsignedLongLongValue);

        public float FloatValue => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_floatValue);

        public double DoubleValue => ObjectiveCRuntime.double_objc_msgSend(NativePtr, sel_doubleValue);

        public bool BoolValue => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_boolValue);

        public long IntegerValue => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_integerValue);

        public ulong UnsignedIntegerValue => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_unsignedIntegerValue);

        public NSString StringValue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stringValue));

        public NSNumber Number(ushort value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Number()
        {
            throw new NotImplementedException();
        }

        public NSNumber Number(short value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Number()
        {
            throw new NotImplementedException();
        }

        public NSNumber Number(int value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Number()
        {
            throw new NotImplementedException();
        }

        public NSNumber Number(long value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Number()
        {
            throw new NotImplementedException();
        }

        public NSNumber Number()
        {
            throw new NotImplementedException();
        }

        public NSNumber Number()
        {
            throw new NotImplementedException();
        }

        public NSNumber Number(float value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Number(double value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Number(bool value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(IntPtr pCoder)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(ushort value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init()
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(short value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init()
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(int value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init()
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(long value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init()
        {
            throw new NotImplementedException();
        }

        public NSNumber Init()
        {
            throw new NotImplementedException();
        }

        public NSNumber Init()
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(float value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(double value)
        {
            throw new NotImplementedException();
        }

        public NSNumber Init(bool value)
        {
            throw new NotImplementedException();
        }

        public NSComparisonResult Compare(NSNumber pOtherNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsEqualToNumber(NSNumber pNumber)
        {
            throw new NotImplementedException();
        }

        public NSString DescriptionWithLocale(NSObject pLocale)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_numberWithChar = "numberWithChar:";
        private static readonly Selector sel_numberWithUnsignedChar = "numberWithUnsignedChar:";
        private static readonly Selector sel_numberWithShort = "numberWithShort:";
        private static readonly Selector sel_numberWithUnsignedShort = "numberWithUnsignedShort:";
        private static readonly Selector sel_numberWithInt = "numberWithInt:";
        private static readonly Selector sel_numberWithUnsignedInt = "numberWithUnsignedInt:";
        private static readonly Selector sel_numberWithLong = "numberWithLong:";
        private static readonly Selector sel_numberWithUnsignedLong = "numberWithUnsignedLong:";
        private static readonly Selector sel_numberWithLongLong = "numberWithLongLong:";
        private static readonly Selector sel_numberWithUnsignedLongLong = "numberWithUnsignedLongLong:";
        private static readonly Selector sel_numberWithFloat = "numberWithFloat:";
        private static readonly Selector sel_numberWithDouble = "numberWithDouble:";
        private static readonly Selector sel_numberWithBool = "numberWithBool:";
        private static readonly Selector sel_initWithCoder = "initWithCoder:";
        private static readonly Selector sel_initWithChar = "initWithChar:";
        private static readonly Selector sel_initWithUnsignedChar = "initWithUnsignedChar:";
        private static readonly Selector sel_initWithShort = "initWithShort:";
        private static readonly Selector sel_initWithUnsignedShort = "initWithUnsignedShort:";
        private static readonly Selector sel_initWithInt = "initWithInt:";
        private static readonly Selector sel_initWithUnsignedInt = "initWithUnsignedInt:";
        private static readonly Selector sel_initWithLong = "initWithLong:";
        private static readonly Selector sel_initWithUnsignedLong = "initWithUnsignedLong:";
        private static readonly Selector sel_initWithLongLong = "initWithLongLong:";
        private static readonly Selector sel_initWithUnsignedLongLong = "initWithUnsignedLongLong:";
        private static readonly Selector sel_initWithFloat = "initWithFloat:";
        private static readonly Selector sel_initWithDouble = "initWithDouble:";
        private static readonly Selector sel_initWithBool = "initWithBool:";
        private static readonly Selector sel_charValue = "charValue";
        private static readonly Selector sel_unsignedCharValue = "unsignedCharValue";
        private static readonly Selector sel_shortValue = "shortValue";
        private static readonly Selector sel_unsignedShortValue = "unsignedShortValue";
        private static readonly Selector sel_intValue = "intValue";
        private static readonly Selector sel_unsignedIntValue = "unsignedIntValue";
        private static readonly Selector sel_longValue = "longValue";
        private static readonly Selector sel_unsignedLongValue = "unsignedLongValue";
        private static readonly Selector sel_longLongValue = "longLongValue";
        private static readonly Selector sel_unsignedLongLongValue = "unsignedLongLongValue";
        private static readonly Selector sel_floatValue = "floatValue";
        private static readonly Selector sel_doubleValue = "doubleValue";
        private static readonly Selector sel_boolValue = "boolValue";
        private static readonly Selector sel_integerValue = "integerValue";
        private static readonly Selector sel_unsignedIntegerValue = "unsignedIntegerValue";
        private static readonly Selector sel_stringValue = "stringValue";
        private static readonly Selector sel_compare = "compare:";
        private static readonly Selector sel_isEqualToNumber = "isEqualToNumber:";
        private static readonly Selector sel_descriptionWithLocale = "descriptionWithLocale:";
    }
}
