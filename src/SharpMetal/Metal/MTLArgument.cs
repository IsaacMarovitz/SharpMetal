using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
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

    [SupportedOSPlatform("macos")]
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
        Tensor = 37,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLIndexType : ulong
    {
        UInt16 = 0,
        UInt32 = 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLArgument : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLArgument obj) => obj.NativePtr;
        public MTLArgument(IntPtr ptr) => NativePtr = ptr;

        public MTLArgument()
        {
            var cls = new ObjectiveCClass("MTLArgument");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Active => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isActive);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        public ulong BufferAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferAlignment);

        public ulong BufferDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataSize);

        public MTLDataType BufferDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataType);

        public MTLPointerType BufferPointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferPointerType));

        public MTLStructType BufferStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferStructType));

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool IsActive => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isActive);

        public bool IsDepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLDataType TextureDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureDataType);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public ulong ThreadgroupMemoryAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryAlignment);

        public ulong ThreadgroupMemoryDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryDataSize);

        public MTLArgumentType Type => (MTLArgumentType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_type);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_bufferAlignment = "bufferAlignment";
        private static readonly Selector sel_bufferDataSize = "bufferDataSize";
        private static readonly Selector sel_bufferDataType = "bufferDataType";
        private static readonly Selector sel_bufferPointerType = "bufferPointerType";
        private static readonly Selector sel_bufferStructType = "bufferStructType";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isActive = "isActive";
        private static readonly Selector sel_isDepthTexture = "isDepthTexture";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_textureDataType = "textureDataType";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_threadgroupMemoryAlignment = "threadgroupMemoryAlignment";
        private static readonly Selector sel_threadgroupMemoryDataSize = "threadgroupMemoryDataSize";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLArrayType : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLArrayType obj) => obj.NativePtr;
        public MTLArrayType(IntPtr ptr) => NativePtr = ptr;

        public MTLArrayType()
        {
            var cls = new ObjectiveCClass("MTLArrayType");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong ArgumentIndexStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndexStride);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        public MTLArrayType ElementArrayType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementArrayType));

        public MTLPointerType ElementPointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementPointerType));

        public MTLStructType ElementStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementStructType));

        public MTLTensorReferenceType ElementTensorReferenceType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementTensorReferenceType));

        public MTLTextureReferenceType ElementTextureReferenceType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementTextureReferenceType));

        public MTLDataType ElementType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_elementType);

        public ulong Stride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stride);

        private static readonly Selector sel_argumentIndexStride = "argumentIndexStride";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_elementArrayType = "elementArrayType";
        private static readonly Selector sel_elementPointerType = "elementPointerType";
        private static readonly Selector sel_elementStructType = "elementStructType";
        private static readonly Selector sel_elementTensorReferenceType = "elementTensorReferenceType";
        private static readonly Selector sel_elementTextureReferenceType = "elementTextureReferenceType";
        private static readonly Selector sel_elementType = "elementType";
        private static readonly Selector sel_stride = "stride";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLBinding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBinding obj) => obj.NativePtr;
        public MTLBinding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool IsArgument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public bool IsUsed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        [System.Obsolete]
        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isArgument = "isArgument";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLBufferBinding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBufferBinding obj) => obj.NativePtr;
        public static implicit operator MTLBinding(MTLBufferBinding obj) => new(obj.NativePtr);
        public MTLBufferBinding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public ulong BufferAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferAlignment);

        public ulong BufferDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataSize);

        public MTLDataType BufferDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferDataType);

        public MTLPointerType BufferPointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferPointerType));

        public MTLStructType BufferStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bufferStructType));

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool IsArgument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public bool IsUsed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        [System.Obsolete]
        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_bufferAlignment = "bufferAlignment";
        private static readonly Selector sel_bufferDataSize = "bufferDataSize";
        private static readonly Selector sel_bufferDataType = "bufferDataType";
        private static readonly Selector sel_bufferPointerType = "bufferPointerType";
        private static readonly Selector sel_bufferStructType = "bufferStructType";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isArgument = "isArgument";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLObjectPayloadBinding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLObjectPayloadBinding obj) => obj.NativePtr;
        public static implicit operator MTLBinding(MTLObjectPayloadBinding obj) => new(obj.NativePtr);
        public MTLObjectPayloadBinding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool IsArgument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public bool IsUsed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public ulong ObjectPayloadAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_objectPayloadAlignment);

        public ulong ObjectPayloadDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_objectPayloadDataSize);

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        [System.Obsolete]
        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isArgument = "isArgument";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_objectPayloadAlignment = "objectPayloadAlignment";
        private static readonly Selector sel_objectPayloadDataSize = "objectPayloadDataSize";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLPointerType : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPointerType obj) => obj.NativePtr;
        public MTLPointerType(IntPtr ptr) => NativePtr = ptr;

        public MTLPointerType()
        {
            var cls = new ObjectiveCClass("MTLPointerType");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public ulong Alignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alignment);

        public ulong DataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataSize);

        public MTLArrayType ElementArrayType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementArrayType));

        public bool ElementIsArgumentBuffer => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_elementIsArgumentBuffer);

        public MTLStructType ElementStructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_elementStructType));

        public MTLDataType ElementType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_elementType);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_alignment = "alignment";
        private static readonly Selector sel_dataSize = "dataSize";
        private static readonly Selector sel_elementArrayType = "elementArrayType";
        private static readonly Selector sel_elementIsArgumentBuffer = "elementIsArgumentBuffer";
        private static readonly Selector sel_elementStructType = "elementStructType";
        private static readonly Selector sel_elementType = "elementType";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLStructMember : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStructMember obj) => obj.NativePtr;
        public MTLStructMember(IntPtr ptr) => NativePtr = ptr;

        public MTLStructMember()
        {
            var cls = new ObjectiveCClass("MTLStructMember");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong ArgumentIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndex);

        public MTLArrayType ArrayType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arrayType));

        public MTLDataType DataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataType);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public ulong Offset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_offset);

        public MTLPointerType PointerType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_pointerType));

        public MTLStructType StructType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_structType));

        public MTLTensorReferenceType TensorReferenceType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tensorReferenceType));

        public MTLTextureReferenceType TextureReferenceType => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_textureReferenceType));

        private static readonly Selector sel_argumentIndex = "argumentIndex";
        private static readonly Selector sel_arrayType = "arrayType";
        private static readonly Selector sel_dataType = "dataType";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_pointerType = "pointerType";
        private static readonly Selector sel_structType = "structType";
        private static readonly Selector sel_tensorReferenceType = "tensorReferenceType";
        private static readonly Selector sel_textureReferenceType = "textureReferenceType";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLStructType : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStructType obj) => obj.NativePtr;
        public MTLStructType(IntPtr ptr) => NativePtr = ptr;

        public MTLStructType()
        {
            var cls = new ObjectiveCClass("MTLStructType");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray Members => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_members));

        public MTLStructMember MemberByName(NSString name)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_memberByName, name));
        }

        private static readonly Selector sel_memberByName = "memberByName:";
        private static readonly Selector sel_members = "members";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTensorBinding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTensorBinding obj) => obj.NativePtr;
        public static implicit operator MTLBinding(MTLTensorBinding obj) => new(obj.NativePtr);
        public MTLTensorBinding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public MTLTensorExtents Dimensions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_dimensions));

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public MTLDataType IndexType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);

        public bool IsArgument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public bool IsUsed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLTensorDataType TensorDataType => (MTLTensorDataType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_tensorDataType);

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        [System.Obsolete]
        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_dimensions = "dimensions";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_isArgument = "isArgument";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_tensorDataType = "tensorDataType";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTensorReferenceType : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTensorReferenceType obj) => obj.NativePtr;
        public MTLTensorReferenceType(IntPtr ptr) => NativePtr = ptr;

        public MTLTensorReferenceType()
        {
            var cls = new ObjectiveCClass("MTLTensorReferenceType");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public MTLTensorExtents Dimensions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_dimensions));

        public MTLDataType IndexType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);

        public MTLTensorDataType TensorDataType => (MTLTensorDataType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_tensorDataType);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_dimensions = "dimensions";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_tensorDataType = "tensorDataType";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTextureBinding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureBinding obj) => obj.NativePtr;
        public static implicit operator MTLBinding(MTLTextureBinding obj) => new(obj.NativePtr);
        public MTLTextureBinding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        [System.Obsolete]
        public bool DepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool IsArgument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public bool IsDepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        public bool IsUsed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public MTLDataType TextureDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureDataType);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        [System.Obsolete]
        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isArgument = "isArgument";
        private static readonly Selector sel_isDepthTexture = "isDepthTexture";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_textureDataType = "textureDataType";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTextureReferenceType : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureReferenceType obj) => obj.NativePtr;
        public MTLTextureReferenceType(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureReferenceType()
        {
            var cls = new ObjectiveCClass("MTLTextureReferenceType");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        public bool IsDepthTexture => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthTexture);

        public MTLDataType TextureDataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureDataType);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_isDepthTexture = "isDepthTexture";
        private static readonly Selector sel_textureDataType = "textureDataType";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLThreadgroupBinding : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLThreadgroupBinding obj) => obj.NativePtr;
        public static implicit operator MTLBinding(MTLThreadgroupBinding obj) => new(obj.NativePtr);
        public MTLThreadgroupBinding(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBindingAccess Access => (MTLBindingAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);

        [System.Obsolete]
        public bool Argument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);

        public bool IsArgument => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isArgument);

        public bool IsUsed => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public ulong ThreadgroupMemoryAlignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryAlignment);

        public ulong ThreadgroupMemoryDataSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryDataSize);

        public MTLBindingType Type => (MTLBindingType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        [System.Obsolete]
        public bool Used => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isUsed);

        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_isArgument = "isArgument";
        private static readonly Selector sel_isUsed = "isUsed";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_threadgroupMemoryAlignment = "threadgroupMemoryAlignment";
        private static readonly Selector sel_threadgroupMemoryDataSize = "threadgroupMemoryDataSize";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLType : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLType obj) => obj.NativePtr;
        public MTLType(IntPtr ptr) => NativePtr = ptr;

        public MTLType()
        {
            var cls = new ObjectiveCClass("MTLType");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDataType DataType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataType);

        private static readonly Selector sel_dataType = "dataType";
        private static readonly Selector sel_release = "release";
    }
}
