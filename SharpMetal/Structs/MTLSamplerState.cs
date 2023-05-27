using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSamplerState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerState samplerState) => samplerState.NativePtr;
        public MTLSamplerState(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_label);

        // TODO: Needs MTLResourceID
        // public MTLResourceID GPUResourceID;

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
    }
}