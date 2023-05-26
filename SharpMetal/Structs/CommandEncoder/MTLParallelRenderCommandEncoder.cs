using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLParallelRenderCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public MTLParallelRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}