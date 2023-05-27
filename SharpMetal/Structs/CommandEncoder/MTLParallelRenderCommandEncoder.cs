using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLParallelRenderCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLParallelRenderCommandEncoder encoder) => encoder.NativePtr;
        public MTLParallelRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}