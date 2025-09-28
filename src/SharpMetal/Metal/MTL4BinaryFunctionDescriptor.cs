using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4BinaryFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4BinaryFunctionDescriptor obj) => obj.NativePtr;
        public MTL4BinaryFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4BinaryFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4BinaryFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }



        private static readonly Selector sel_release = "release";
    }
}
