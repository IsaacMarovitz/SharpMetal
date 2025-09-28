using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4LibraryFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4LibraryFunctionDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4FunctionDescriptor(MTL4LibraryFunctionDescriptor obj) => new(obj.NativePtr);
        public MTL4LibraryFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4LibraryFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4LibraryFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTLLibrary Library

        // missing NSString Name
        private static readonly Selector sel_release = "release";
    }
}
