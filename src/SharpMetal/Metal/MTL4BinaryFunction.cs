using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4BinaryFunction : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4BinaryFunction obj) => obj.NativePtr;
        public MTL4BinaryFunction(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLFunctionType FunctionType => (MTLFunctionType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionType);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        private static readonly Selector sel_functionType = "functionType";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_release = "release";
    }
}
