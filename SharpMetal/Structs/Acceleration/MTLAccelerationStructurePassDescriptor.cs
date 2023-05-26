using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructurePassDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLAccelerationStructurePassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructurePassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructurePassDescriptor");
            NativePtr = new(ObjectiveCRuntime.IntPtr_objc_msgSend(cls, sel_accelerationStructurePassDescriptor));
        }

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
        private static readonly Selector sel_accelerationStructurePassDescriptor = "accelerationStructurePassDescriptor";
    }
}