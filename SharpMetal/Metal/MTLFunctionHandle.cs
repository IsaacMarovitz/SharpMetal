using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public partial class MTLFunctionHandle
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionHandle obj) => obj.NativePtr;
        public MTLFunctionHandle(IntPtr ptr) => NativePtr = ptr;

        protected MTLFunctionHandle()
        {
            throw new NotImplementedException();
        }

        public MTLFunctionType FunctionType => (MTLFunctionType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionType);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        private static readonly Selector sel_functionType = "functionType";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_device = "device";
    }
}
