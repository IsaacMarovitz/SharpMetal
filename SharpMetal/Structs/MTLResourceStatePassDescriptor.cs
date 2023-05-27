using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLResourceStatePassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStatePassDescriptor mtlRegion) => mtlRegion.NativePtr;
        public MTLResourceStatePassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceStatePassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLResourceStatePassDescriptor");
            NativePtr = ObjectiveCRuntime.IntPtr_objc_msgSend(cls, sel_resourceStatePassDescriptor);
        }

        // TODO: Needs MTLResourceStatePassSampleBufferAttachmentDescriptorArray
        // public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments;

        private static readonly Selector sel_resourceStatePassDescriptor = "resourceStatePassDescriptor";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}