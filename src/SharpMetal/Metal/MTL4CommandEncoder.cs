using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4CommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandEncoder obj) => obj.NativePtr;
        public MTL4CommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTL4CommandBuffer CommandBuffer

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }
}
