using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLComputeCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public MTLComputeCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}