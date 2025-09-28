using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4ArgumentTable : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ArgumentTable obj) => obj.NativePtr;
        public MTL4ArgumentTable(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }


        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4ArgumentTableDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ArgumentTableDescriptor obj) => obj.NativePtr;
        public MTL4ArgumentTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4ArgumentTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4ArgumentTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }






        private static readonly Selector sel_release = "release";
    }
}
