using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
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
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantValuetypeatIndex, value, (ulong)type, index);
        }

        public void SetConstantValues(IntPtr values, MTLDataType type, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantValuestypewithRange, values, (ulong)type, range);
        }

        public void SetConstantValue(IntPtr value, MTLDataType type, NSString name)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantValuetypewithName, value, (ulong)type, name);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_setConstantValuetypeatIndex = "setConstantValue:type:atIndex:";
        private static readonly Selector sel_setConstantValuestypewithRange = "setConstantValues:type:withRange:";
        private static readonly Selector sel_setConstantValuetypewithName = "setConstantValue:type:withName:";
        private static readonly Selector sel_reset = "reset";
    }
}
