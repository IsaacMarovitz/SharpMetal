using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLFunction
    {
        public readonly IntPtr NativePtr;
        public MTLFunction(IntPtr ptr) => NativePtr = ptr;
    }
}