using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLBlitCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public MTLBlitCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}