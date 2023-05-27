using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLVertexAttributeDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAttributeDescriptorArray array) => array.NativePtr;
        public MTLVertexAttributeDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLVertexAttributeDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLVertexAttributeDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLVertexAttributeDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value, index);
            }
        }
    }
}