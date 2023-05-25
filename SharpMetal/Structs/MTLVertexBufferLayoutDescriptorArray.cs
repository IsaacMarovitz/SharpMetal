using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLVertexBufferLayoutDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public MTLVertexBufferLayoutDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexBufferLayoutDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLVertexBufferLayoutDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLVertexBufferLayoutDescriptor this[uint index]
        {
            get
            {
                IntPtr ptr = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLVertexBufferLayoutDescriptor(ptr);
            }
            set
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value.NativePtr, index);
            }
        }
    }
}