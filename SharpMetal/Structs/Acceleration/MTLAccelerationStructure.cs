using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructure
    {
        public readonly IntPtr NativePtr;
        public MTLAccelerationStructure(IntPtr ptr) => NativePtr = ptr;

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);

        // TODO: Needs MTLResourceID
        // public MTLResourceID GPUResourceID;

        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
    }
}