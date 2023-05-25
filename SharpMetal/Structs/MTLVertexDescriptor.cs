using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLVertexDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLVertexDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptorArray Attributes => new MTLVertexAttributeDescriptorArray(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_attributes));
        public MTLVertexBufferLayoutDescriptorArray Layouts => new MTLVertexBufferLayoutDescriptorArray(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layouts));

        private static readonly Selector sel_attributes= "attributes";
        private static readonly Selector sel_layouts = "layouts";
    }
}