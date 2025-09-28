using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4CompilerTask : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CompilerTask obj) => obj.NativePtr;
        public MTL4CompilerTask(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }


        private static readonly Selector sel_release = "release";
    }
}
