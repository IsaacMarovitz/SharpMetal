using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLFunctionConstantValues
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionConstantValues obj) => obj.NativePtr;
        public MTLFunctionConstantValues(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionConstantValues()
        {
            var cls = new ObjectiveCClass("MTLFunctionConstantValues");
            NativePtr = cls.AllocInit();
        }

        public void SetConstantValue(IntPtr value, MTLDataType type, ulong index)
        {
            objc_msgSend(NativePtr, , value, type, index);
        }

        public void SetConstantValues(IntPtr values, MTLDataType type, NSRange range)
        {
            objc_msgSend(NativePtr, , values, type, range);
        }

        public void SetConstantValue(IntPtr value, MTLDataType type, NSString name)
        {
            objc_msgSend(NativePtr, , value, type, name);
        }

        public void Reset()
        {
            objc_msgSend(NativePtr, , );
        }

        private static readonly Selector sel_setConstantValuetypeatIndex = "setConstantValue:type:atIndex:";
        private static readonly Selector sel_setConstantValuestypewithRange = "setConstantValues:type:withRange:";
        private static readonly Selector sel_setConstantValuetypewithName = "setConstantValue:type:withName:";
        private static readonly Selector sel_reset = "reset";
    }
}
