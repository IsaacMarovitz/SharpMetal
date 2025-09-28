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


        private static readonly Selector sel_release = "release";
    }
}
