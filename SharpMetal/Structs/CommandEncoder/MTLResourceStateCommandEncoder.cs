using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLResourceStateCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public MTLResourceStateCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}