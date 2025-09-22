using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLVertexFormat : ulong
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
        FloatRG11B10 = 54,
        FloatRGB9E5 = 55,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLVertexStepFunction : ulong
    {
        Constant = 0,
        PerVertex = 1,
        PerInstance = 2,
        PerPatch = 3,
        PerPatchControlPoint = 4,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexAttributeDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAttributeDescriptor obj) => obj.NativePtr;
        public MTLVertexAttributeDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexAttributeDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong BufferIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferIndex, value);
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

        private static readonly Selector sel_bufferIndex = "bufferIndex";
        private static readonly Selector sel_format = "format";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_setBufferIndex = "setBufferIndex:";
        private static readonly Selector sel_setFormat = "setFormat:";
        private static readonly Selector sel_setOffset = "setOffset:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexAttributeDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAttributeDescriptorArray obj) => obj.NativePtr;
        public MTLVertexAttributeDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttributeDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLVertexAttributeDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLVertexAttributeDescriptor Object(ulong index)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, index));
        }

        public void SetObject(MTLVertexAttributeDescriptor attributeDesc, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attributeDesc, index);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexBufferLayoutDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexBufferLayoutDescriptor obj) => obj.NativePtr;
        public MTLVertexBufferLayoutDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexBufferLayoutDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexBufferLayoutDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLVertexStepFunction StepFunction
        {
            get => (MTLVertexStepFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stepFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStepFunction, (ulong)value);
        }

        public ulong StepRate
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stepRate);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStepRate, value);
        }

        public ulong Stride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStride, value);
        }

        private static readonly Selector sel_setStepFunction = "setStepFunction:";
        private static readonly Selector sel_setStepRate = "setStepRate:";
        private static readonly Selector sel_setStride = "setStride:";
        private static readonly Selector sel_stepFunction = "stepFunction";
        private static readonly Selector sel_stepRate = "stepRate";
        private static readonly Selector sel_stride = "stride";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexBufferLayoutDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexBufferLayoutDescriptorArray obj) => obj.NativePtr;
        public MTLVertexBufferLayoutDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexBufferLayoutDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLVertexBufferLayoutDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLVertexBufferLayoutDescriptor Object(ulong index)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, index));
        }

        public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, bufferDesc, index);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexDescriptor obj) => obj.NativePtr;
        public MTLVertexDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLVertexAttributeDescriptorArray Attributes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_attributes));

        public MTLVertexBufferLayoutDescriptorArray Layouts => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layouts));

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_attributes = "attributes";
        private static readonly Selector sel_layouts = "layouts";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        private static readonly Selector sel_release = "release";
    }
}
