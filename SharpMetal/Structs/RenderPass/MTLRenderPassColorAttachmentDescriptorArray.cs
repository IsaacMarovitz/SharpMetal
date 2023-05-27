using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassColorAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptorArray array) => array.NativePtr;
        public MTLRenderPassColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLRenderPassColorAttachmentDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLRenderPassColorAttachmentDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value, index);
            }
        }
    }
}