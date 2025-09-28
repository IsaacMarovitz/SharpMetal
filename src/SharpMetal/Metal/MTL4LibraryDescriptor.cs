using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4LibraryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4LibraryDescriptor obj) => obj.NativePtr;
        public MTL4LibraryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4LibraryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4LibraryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing NSString Name

        // missing MTLCompileOptions Options

        // missing NSString Source
        private static readonly Selector sel_release = "release";
    }
}
