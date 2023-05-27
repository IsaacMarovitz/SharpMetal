using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPipelineBufferDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPipelineBufferDescriptorArray array) => array.NativePtr;
        public MTLPipelineBufferDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLPipelineBufferDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLPipelineBufferDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLPipelineBufferDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLPipelineBufferDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value, index);
            }
        }
    }
}