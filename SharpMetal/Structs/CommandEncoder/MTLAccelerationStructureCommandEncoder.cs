using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public MTLAccelerationStructureCommandEncoder(IntPtr ptr) => NativePtr = ptr;
    }
}