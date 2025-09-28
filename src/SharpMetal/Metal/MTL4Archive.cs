using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4Archive : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4Archive obj) => obj.NativePtr;
        public MTL4Archive(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }
}
