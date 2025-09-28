using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4StitchedFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4StitchedFunctionDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4FunctionDescriptor(MTL4StitchedFunctionDescriptor obj) => new(obj.NativePtr);
        public MTL4StitchedFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4StitchedFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4StitchedFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }


        private static readonly Selector sel_release = "release";
    }
}
