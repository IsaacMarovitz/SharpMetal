using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLResourceStateCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStateCommandEncoder encoder) => encoder.NativePtr;
        public MTLResourceStateCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}