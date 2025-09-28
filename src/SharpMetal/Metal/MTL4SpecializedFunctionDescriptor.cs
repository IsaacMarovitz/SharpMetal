using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4SpecializedFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4SpecializedFunctionDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4FunctionDescriptor(MTL4SpecializedFunctionDescriptor obj) => new(obj.NativePtr);
        public MTL4SpecializedFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4SpecializedFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4SpecializedFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }



        private static readonly Selector sel_release = "release";
    }
}
