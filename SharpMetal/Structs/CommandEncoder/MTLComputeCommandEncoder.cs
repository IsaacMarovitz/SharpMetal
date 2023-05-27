using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLComputeCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputeCommandEncoder encoder) => encoder.NativePtr;
        public MTLComputeCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}