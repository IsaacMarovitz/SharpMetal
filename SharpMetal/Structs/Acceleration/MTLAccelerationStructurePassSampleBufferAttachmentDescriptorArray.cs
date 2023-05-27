using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray array) => array.NativePtr;
        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value, index);
            }
        }
    }
}