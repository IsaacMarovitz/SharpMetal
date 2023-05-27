using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLRenderCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderCommandEncoder encoder) => encoder.NativePtr;
        public MTLRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}