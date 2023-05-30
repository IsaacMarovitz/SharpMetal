using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLVertexFormat: ulong
    {
        Invalid = 0,
        UChar2 = 1,
        UChar3 = 2,
        UChar4 = 3,
        Char2 = 4,
        Char3 = 5,
        Char4 = 6,
        UChar2Normalized = 7,
        UChar3Normalized = 8,
        UChar4Normalized = 9,
        Char2Normalized = 10,
        Char3Normalized = 11,
        Char4Normalized = 12,
        UShort2 = 13,
        UShort3 = 14,
        UShort4 = 15,
        Short2 = 16,
        Short3 = 17,
        Short4 = 18,
        UShort2Normalized = 19,
        UShort3Normalized = 20,
        UShort4Normalized = 21,
        Short2Normalized = 22,
        Short3Normalized = 23,
        Short4Normalized = 24,
        Half2 = 25,
        Half3 = 26,
        Half4 = 27,
        Float = 28,
        Float2 = 29,
        Float3 = 30,
        Float4 = 31,
        Int = 32,
        Int2 = 33,
        Int3 = 34,
        Int4 = 35,
        UInt = 36,
        UInt2 = 37,
        UInt3 = 38,
        UInt4 = 39,
        Int1010102Normalized = 40,
        UInt1010102Normalized = 41,
        UChar4NormalizedBGRA = 42,
        UChar = 45,
        Char = 46,
        UCharNormalized = 47,
        CharNormalized = 48,
        UShort = 49,
        Short = 50,
        UShortNormalized = 51,
        ShortNormalized = 52,
        Half = 53,
    }

    public enum MTLVertexStepFunction: ulong
    {
        Constant = 0,
        PerVertex = 1,
        PerInstance = 2,
        PerPatch = 3,
        PerPatchControlPoint = 4,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexBufferLayoutDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexBufferLayoutDescriptor obj) => obj.NativePtr;
        public MTLVertexBufferLayoutDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexBufferLayoutDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexBufferLayoutDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong Stride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stride);
        public MTLVertexStepFunction StepFunction => (MTLVertexStepFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stepFunction);
        public ulong StepRate => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stepRate);

        private static readonly Selector sel_stride = "stride";
        private static readonly Selector sel_setStride = "setStride:";
        private static readonly Selector sel_stepFunction = "stepFunction";
        private static readonly Selector sel_setStepFunction = "setStepFunction:";
        private static readonly Selector sel_stepRate = "stepRate";
        private static readonly Selector sel_setStepRate = "setStepRate:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexBufferLayoutDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexBufferLayoutDescriptorArray obj) => obj.NativePtr;
        public MTLVertexBufferLayoutDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexBufferLayoutDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLVertexBufferLayoutDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexAttributeDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAttributeDescriptor obj) => obj.NativePtr;
        public MTLVertexAttributeDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexAttributeDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLVertexFormat Format => (MTLVertexFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_format);
        public ulong Offset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_offset);
        public ulong BufferIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferIndex);

        private static readonly Selector sel_format = "format";
        private static readonly Selector sel_setFormat = "setFormat:";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_setOffset = "setOffset:";
        private static readonly Selector sel_bufferIndex = "bufferIndex";
        private static readonly Selector sel_setBufferIndex = "setBufferIndex:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexAttributeDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAttributeDescriptorArray obj) => obj.NativePtr;
        public MTLVertexAttributeDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLVertexAttributeDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexDescriptor obj) => obj.NativePtr;
        public MTLVertexDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLVertexDescriptor VertexDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexDescriptor));
        public MTLVertexBufferLayoutDescriptorArray Layouts => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layouts));
        public MTLVertexAttributeDescriptorArray Attributes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_attributes));

        private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        private static readonly Selector sel_layouts = "layouts";
        private static readonly Selector sel_attributes = "attributes";
        private static readonly Selector sel_reset = "reset";
    }
}