using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLBlitPassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitPassDescriptor mtlRegion) => mtlRegion.NativePtr;
        public MTLBlitPassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLBlitPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLBlitPassDescriptor");
            NativePtr = ObjectiveCRuntime.IntPtr_objc_msgSend(cls, sel_blitPassDescriptor);
        }

        // TODO: Needs MTLBlitPassSampleBufferAttachmentDescriptorArray
        // public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments;

        private static readonly Selector sel_blitPassDescriptor = "blitPassDescriptor";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}