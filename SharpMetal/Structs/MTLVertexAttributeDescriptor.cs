using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLVertexAttributeDescriptor
    {
        public readonly IntPtr NativePtr { get; }
        public static implicit operator IntPtr(MTLVertexAttributeDescriptor descriptor) => descriptor;
        public MTLVertexAttributeDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexAttributeDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLVertexFormat Format
        {
            get => (MTLVertexFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_format);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFormat, (ulong)value);
        }

        public ulong Offset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_offset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOffset, value);
        }

        public ulong BufferIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferIndex, value);
        }

        private static readonly Selector sel_format = "format";
        private static readonly Selector sel_setFormat = "setFormat:";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_setOffset = "setOffset:";
        private static readonly Selector sel_bufferIndex = "bufferIndex";
        private static readonly Selector sel_setBufferIndex = "setBufferIndex:";
    }
}