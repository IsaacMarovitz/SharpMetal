using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLBlitPassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitPassSampleBufferAttachmentDescriptorArray array) => array.NativePtr;
        public MTLBlitPassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLBlitPassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLBlitPassSampleBufferAttachmentDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLBlitPassSampleBufferAttachmentDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value, index);
            }
        }
    }
}