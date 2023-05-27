using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineColorAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineColorAttachmentDescriptorArray array) => array.NativePtr;
        public MTLRenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLRenderPipelineColorAttachmentDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLRenderPipelineColorAttachmentDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value, index);
            }
        }
    }
}