using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLFunctionConstantValues
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionConstantValues obj) => obj.NativePtr;
        public MTLFunctionConstantValues(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionConstantValues()
        {
            var cls = new ObjectiveCClass("MTLFunctionConstantValues");
            NativePtr = cls.AllocInit();
        }

        public void SetConstantValue(IntPtr value, MTLDataType type, ulong index) {

        }

        public void SetConstantValues(IntPtr values, MTLDataType type, NSRange range) {

        }

        public void SetConstantValue(IntPtr value, MTLDataType type, NSString name) {

        }

        private static readonly Selector sel_setConstantValuetypeatIndex = "setConstantValue:type:atIndex:";
        private static readonly Selector sel_setConstantValuestypewithRange = "setConstantValues:type:withRange:";
        private static readonly Selector sel_setConstantValuetypewithName = "setConstantValue:type:withName:";
        private static readonly Selector sel_reset = "reset";
    }
}
