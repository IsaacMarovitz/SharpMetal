using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4ComputeCommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ComputeCommandEncoder obj) => obj.NativePtr;
        public static implicit operator MTL4CommandEncoder(MTL4ComputeCommandEncoder obj) => new(obj.NativePtr);
        public MTL4ComputeCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }



        private static readonly Selector sel_release = "release";
    }
}
