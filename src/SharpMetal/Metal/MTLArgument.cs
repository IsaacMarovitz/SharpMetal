using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLDataType : ulong
    {
        None = 0,
        Struct = 1,
        Array = 2,
        Float = 3,
        Float2 = 4,
        Float3 = 5,
        Float4 = 6,
        Float2x2 = 7,
        Float2x3 = 8,
        Float2x4 = 9,
        Float3x2 = 10,
        Float3x3 = 11,
        Float3x4 = 12,
        Float4x2 = 13,
        Float4x3 = 14,
        Float4x4 = 15,
        Half = 16,
        Half2 = 17,
        Half3 = 18,
        Half4 = 19,
        Half2x2 = 20,
        Half2x3 = 21,
        Half2x4 = 22,
        Half3x2 = 23,
        Half3x3 = 24,
        Half3x4 = 25,
        Half4x2 = 26,
        Half4x3 = 27,
        Half4x4 = 28,
        Int = 29,
        Int2 = 30,
        Int3 = 31,
        Int4 = 32,
        UInt = 33,
        UInt2 = 34,
        UInt3 = 35,
        UInt4 = 36,
        Short = 37,
        Short2 = 38,
        Short3 = 39,
        Short4 = 40,
        UShort = 41,
        UShort2 = 42,
        UShort3 = 43,
        UShort4 = 44,
        Char = 45,
        Char2 = 46,
        Char3 = 47,
        Char4 = 48,
        UChar = 49,
        UChar2 = 50,
        UChar3 = 51,
        UChar4 = 52,
        Bool = 53,
        Bool2 = 54,
        Bool3 = 55,
        Bool4 = 56,
        Texture = 58,
        Sampler = 59,
        Pointer = 60,
        R8Unorm = 62,
        R8Snorm = 63,
        R16Unorm = 64,
        R16Snorm = 65,
        RG8Unorm = 66,
        RG8Snorm = 67,
        RG16Unorm = 68,
        RG16Snorm = 69,
        RGBA8Unorm = 70,
        RGBA8UnormsRGB = 71,
        RGBA8Snorm = 72,
        RGBA16Unorm = 73,
        RGBA16Snorm = 74,
        RGB10A2Unorm = 75,
        RG11B10Float = 76,
        RGB9E5Float = 77,
        RenderPipeline = 78,
        ComputePipeline = 79,
        IndirectCommandBuffer = 80,
        Long = 81,
        Long2 = 82,
        Long3 = 83,
        Long4 = 84,
        ULong = 85,
        ULong2 = 86,
        ULong3 = 87,
        ULong4 = 88,
        VisibleFunctionTable = 115,
        IntersectionFunctionTable = 116,
        PrimitiveAccelerationStructure = 117,
        InstanceAccelerationStructure = 118,
        BFloat = 121,
        BFloat2 = 122,
        BFloat3 = 123,
        BFloat4 = 124,
    }

    public enum MTLBindingType : long
    {
        Buffer = 0,
        ThreadgroupMemory = 1,
        Texture = 2,
        Sampler = 3,
        ImageblockData = 16,
        Imageblock = 17,
        VisibleFunctionTable = 24,
        PrimitiveAccelerationStructure = 25,
        InstanceAccelerationStructure = 26,
        IntersectionFunctionTable = 27,
        ObjectPayload = 34,
    }

    public enum MTLArgumentType : ulong
    {
        Buffer = 0,
        ThreadgroupMemory = 1,
        Texture = 2,
        Sampler = 3,
        ImageblockData = 16,
        Imageblock = 17,
        VisibleFunctionTable = 24,
        PrimitiveAccelerationStructure = 25,
        InstanceAccelerationStructure = 26,
        IntersectionFunctionTable = 27,
    }

    public enum MTLBindingAccess : ulong
    {
        ReadOnly = 0,
        ReadWrite = 1,
        WriteOnly = 2,
        ArgumentAccessReadOnly = 0,
        ArgumentAccessReadWrite = 1,
        ArgumentAccessWriteOnly = 2,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLType
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLType obj) => obj.NativePtr;
        public MTLType(IntPtr ptr) => NativePtr = ptr;

        public MTLType()
        {
            var cls = new ObjectiveCClass("MTLType");
            NativePtr = cls.AllocInit();
        }

        public MTLDataType DataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataType);

        private static readonly Selector sel_dataType = "dataType";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLStructMember
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStructMember obj) => obj.NativePtr;
        public MTLStructMember(IntPtr ptr) => NativePtr = ptr;

        public MTLStructMember()
        {
            var cls = new ObjectiveCClass("MTLStructMember");
            NativePtr = cls.AllocInit();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public ulong Offset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_offset);

        public MTLDataType DataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataType);

        public MTLStructType StructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_structType));

        public MTLArrayType ArrayType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arrayType));

        public MTLTextureReferenceType TextureReferenceType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_textureReferenceType));

        public MTLPointerType PointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_pointerType));

        public ulong ArgumentIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndex);

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_dataType = "dataType";
        private static readonly Selector sel_structType = "structType";
        private static readonly Selector sel_arrayType = "arrayType";
        private static readonly Selector sel_textureReferenceType = "textureReferenceType";
        private static readonly Selector sel_pointerType = "pointerType";
        private static readonly Selector sel_argumentIndex = "argumentIndex";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLStructType
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStructType obj) => obj.NativePtr;
        public MTLStructType(IntPtr ptr) => NativePtr = ptr;

        public MTLStructType()
        {
            var cls = new ObjectiveCClass("MTLStructType");
            NativePtr = cls.AllocInit();
        }

        public NSArray Members => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_members));

        public MTLStructMember MemberByName(NSString name)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_memberByName, name));
        }

        private static readonly Selector sel_members = "members";
        private static readonly Selector sel_memberByName = "memberByName:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLArrayType
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLArrayType obj) => obj.NativePtr;
        public MTLArrayType(IntPtr ptr) => NativePtr = ptr;

        public MTLArrayType()
        {
            var cls = new ObjectiveCClass("MTLArrayType");
            NativePtr = cls.AllocInit();
        }

        public MTLDataType ElementType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_elementType);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        public ulong Stride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stride);

        public ulong ArgumentIndexStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndexStride);

        public MTLStructType ElementStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementStructType));

        public MTLArrayType ElementArrayType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementArrayType));

        public MTLTextureReferenceType ElementTextureReferenceType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementTextureReferenceType));

        public MTLPointerType ElementPointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementPointerType));

        private static readonly Selector sel_elementType = "elementType";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_stride = "stride";
        private static readonly Selector sel_argumentIndexStride = "argumentIndexStride";
        private static readonly Selector sel_elementStructType = "elementStructType";
        private static readonly Selector sel_elementArrayType = "elementArrayType";
        private static readonly Selector sel_elementTextureReferenceType = "elementTextureReferenceType";
        private static readonly Selector sel_elementPointerType = "elementPointerType";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLPointerType
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPointerType obj) => obj.NativePtr;
        public MTLPointerType(IntPtr ptr) => NativePtr = ptr;

        public MTLPointerType()
        {
            var cls = new ObjectiveCClass("MTLPointerType");
            NativePtr = cls.AllocInit();
        }

        public MTLDataType ElementType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_elementType);

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public ulong Alignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alignment);

        public ulong DataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataSize);

        public bool ElementIsArgumentBuffer => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_elementIsArgumentBuffer);

        public MTLStructType ElementStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementStructType));

        public MTLArrayType ElementArrayType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementArrayType));

        private static readonly Selector sel_elementType = "elementType";
        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_alignment = "alignment";
        private static readonly Selector sel_dataSize = "dataSize";
        private static readonly Selector sel_elementIsArgumentBuffer = "elementIsArgumentBuffer";
        private static readonly Selector sel_elementStructType = "elementStructType";
        private static readonly Selector sel_elementArrayType = "elementArrayType";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLTextureReferenceType
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureReferenceType obj) => obj.NativePtr;
        public MTLTextureReferenceType(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureReferenceType()
        {
            var cls = new ObjectiveCClass("MTLTextureReferenceType");
            NativePtr = cls.AllocInit();
        }

        public MTLDataType TextureDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureDataType);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public bool IsDepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        private static readonly Selector sel_textureDataType = "textureDataType";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_isDepthTexture = "isDepthTexture";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLArgument
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLArgument obj) => obj.NativePtr;
        public MTLArgument(IntPtr ptr) => NativePtr = ptr;

        public MTLArgument()
        {
            var cls = new ObjectiveCClass("MTLArgument");
            NativePtr = cls.AllocInit();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLArgumentType Type => (MTLArgumentType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_type);

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool Active => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isActive);

        public ulong BufferAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferAlignment);

        public ulong BufferDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataSize);

        public MTLDataType BufferDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataType);

        public MTLStructType BufferStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferStructType));

        public MTLPointerType BufferPointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferPointerType));

        public ulong ThreadgroupMemoryAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryAlignment);

        public ulong ThreadgroupMemoryDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryDataSize);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLDataType TextureDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureDataType);

        public bool IsDepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isActive = "isActive";
        private static readonly Selector sel_bufferAlignment = "bufferAlignment";
        private static readonly Selector sel_bufferDataSize = "bufferDataSize";
        private static readonly Selector sel_bufferDataType = "bufferDataType";
        private static readonly Selector sel_bufferStructType = "bufferStructType";
        private static readonly Selector sel_bufferPointerType = "bufferPointerType";
        private static readonly Selector sel_threadgroupMemoryAlignment = "threadgroupMemoryAlignment";
        private static readonly Selector sel_threadgroupMemoryDataSize = "threadgroupMemoryDataSize";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_textureDataType = "textureDataType";
        private static readonly Selector sel_isDepthTexture = "isDepthTexture";
        private static readonly Selector sel_arrayLength = "arrayLength";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLBinding
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBinding obj) => obj.NativePtr;
        public MTLBinding(IntPtr ptr) => NativePtr = ptr;

        protected MTLBinding()
        {
            throw new NotImplementedException();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_isArgument = "isArgument";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLBufferBinding : MTLBinding
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBufferBinding obj) => obj.NativePtr;
        public MTLBufferBinding(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLBufferBinding()
        {
            throw new NotImplementedException();
        }

        public ulong BufferAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferAlignment);

        public ulong BufferDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataSize);

        public MTLDataType BufferDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataType);

        public MTLStructType BufferStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferStructType));

        public MTLPointerType BufferPointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferPointerType));

        private static readonly Selector sel_bufferAlignment = "bufferAlignment";
        private static readonly Selector sel_bufferDataSize = "bufferDataSize";
        private static readonly Selector sel_bufferDataType = "bufferDataType";
        private static readonly Selector sel_bufferStructType = "bufferStructType";
        private static readonly Selector sel_bufferPointerType = "bufferPointerType";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLThreadgroupBinding : MTLBinding
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLThreadgroupBinding obj) => obj.NativePtr;
        public MTLThreadgroupBinding(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLThreadgroupBinding()
        {
            throw new NotImplementedException();
        }

        public ulong ThreadgroupMemoryAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryAlignment);

        public ulong ThreadgroupMemoryDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryDataSize);

        private static readonly Selector sel_threadgroupMemoryAlignment = "threadgroupMemoryAlignment";
        private static readonly Selector sel_threadgroupMemoryDataSize = "threadgroupMemoryDataSize";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLTextureBinding : MTLBinding
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureBinding obj) => obj.NativePtr;
        public MTLTextureBinding(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLTextureBinding()
        {
            throw new NotImplementedException();
        }

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLDataType TextureDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureDataType);

        public bool DepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_textureDataType = "textureDataType";
        private static readonly Selector sel_isDepthTexture = "isDepthTexture";
        private static readonly Selector sel_arrayLength = "arrayLength";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLObjectPayloadBinding : MTLBinding
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLObjectPayloadBinding obj) => obj.NativePtr;
        public MTLObjectPayloadBinding(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLObjectPayloadBinding()
        {
            throw new NotImplementedException();
        }

        public ulong ObjectPayloadAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_objectPayloadAlignment);

        public ulong ObjectPayloadDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_objectPayloadDataSize);

        private static readonly Selector sel_objectPayloadAlignment = "objectPayloadAlignment";
        private static readonly Selector sel_objectPayloadDataSize = "objectPayloadDataSize";
    }
}
