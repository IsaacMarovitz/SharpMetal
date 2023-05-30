using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLAccelerationStructureUsage: ulong
    {
        None = 0,
        Refit = 1,
        PreferFastBuild = 2,
        ExtendedLimits = 4,
    }

    public enum MTLAccelerationStructureInstanceOptions: uint
    {
        AccelerationStructureInstanceOptionNone = 0,
        AccelerationStructureInstanceOptionDisableTriangleCulling = 1,
        AccelerationStructureInstanceOptionTriangleFrontFacingWindingCounterClockwise = 2,
        AccelerationStructureInstanceOptionOpaque = 4,
        AccelerationStructureInstanceOptionNonOpaque = 8,
    }

    public enum MTLMotionBorderMode: uint
    {
        Clamp = 0,
        Vanish = 1,
    }

    public enum MTLAccelerationStructureInstanceDescriptorType: ulong
    {
        Default = 0,
        UserID = 1,
        Motion = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLAccelerationStructureUsage Usage => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);

        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_setUsage = "setUsage:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong IntersectionFunctionTableOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
        public bool Opaque => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
        public bool AllowDuplicateIntersectionFunctionInvocation => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLBuffer PrimitiveDataBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_primitiveDataBuffer));
        public ulong PrimitiveDataBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataBufferOffset);
        public ulong PrimitiveDataStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
        public ulong PrimitiveDataElementSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);

        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_primitiveDataBufferOffset = "primitiveDataBufferOffset";
        private static readonly Selector sel_setPrimitiveDataBufferOffset = "setPrimitiveDataBufferOffset:";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLPrimitiveAccelerationStructureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPrimitiveAccelerationStructureDescriptor obj) => obj.NativePtr;
        public MTLPrimitiveAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPrimitiveAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLPrimitiveAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray GeometryDescriptors => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_geometryDescriptors));
        public MTLMotionBorderMode MotionStartBorderMode => (MTLMotionBorderMode)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_motionStartBorderMode);
        public MTLMotionBorderMode MotionEndBorderMode => (MTLMotionBorderMode)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_motionEndBorderMode);
        public float MotionStartTime => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionStartTime);
        public float MotionEndTime => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionEndTime);
        public ulong MotionKeyframeCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionKeyframeCount);
        public MTLPrimitiveAccelerationStructureDescriptor Descriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_descriptor));

        private static readonly Selector sel_geometryDescriptors = "geometryDescriptors";
        private static readonly Selector sel_setGeometryDescriptors = "setGeometryDescriptors:";
        private static readonly Selector sel_motionStartBorderMode = "motionStartBorderMode";
        private static readonly Selector sel_setMotionStartBorderMode = "setMotionStartBorderMode:";
        private static readonly Selector sel_motionEndBorderMode = "motionEndBorderMode";
        private static readonly Selector sel_setMotionEndBorderMode = "setMotionEndBorderMode:";
        private static readonly Selector sel_motionStartTime = "motionStartTime";
        private static readonly Selector sel_setMotionStartTime = "setMotionStartTime:";
        private static readonly Selector sel_motionEndTime = "motionEndTime";
        private static readonly Selector sel_setMotionEndTime = "setMotionEndTime:";
        private static readonly Selector sel_motionKeyframeCount = "motionKeyframeCount";
        private static readonly Selector sel_setMotionKeyframeCount = "setMotionKeyframeCount:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureTriangleGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureTriangleGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer VertexBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffer));
        public ulong VertexBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexBufferOffset);
        public MTLAttributeFormat VertexFormat => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexFormat);
        public ulong VertexStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexStride);
        public MTLBuffer IndexBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indexBuffer));
        public ulong IndexBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexBufferOffset);
        public MTLIndexType IndexType => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
        public ulong TriangleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_triangleCount);
        public MTLBuffer TransformationMatrixBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_transformationMatrixBuffer));
        public ulong TransformationMatrixBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_transformationMatrixBufferOffset);
        public MTLAccelerationStructureTriangleGeometryDescriptor Descriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_descriptor));

        private static readonly Selector sel_vertexBuffer = "vertexBuffer";
        private static readonly Selector sel_setVertexBuffer = "setVertexBuffer:";
        private static readonly Selector sel_vertexBufferOffset = "vertexBufferOffset";
        private static readonly Selector sel_setVertexBufferOffset = "setVertexBufferOffset:";
        private static readonly Selector sel_vertexFormat = "vertexFormat";
        private static readonly Selector sel_setVertexFormat = "setVertexFormat:";
        private static readonly Selector sel_vertexStride = "vertexStride";
        private static readonly Selector sel_setVertexStride = "setVertexStride:";
        private static readonly Selector sel_indexBuffer = "indexBuffer";
        private static readonly Selector sel_setIndexBuffer = "setIndexBuffer:";
        private static readonly Selector sel_indexBufferOffset = "indexBufferOffset";
        private static readonly Selector sel_setIndexBufferOffset = "setIndexBufferOffset:";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_setIndexType = "setIndexType:";
        private static readonly Selector sel_triangleCount = "triangleCount";
        private static readonly Selector sel_setTriangleCount = "setTriangleCount:";
        private static readonly Selector sel_transformationMatrixBuffer = "transformationMatrixBuffer";
        private static readonly Selector sel_setTransformationMatrixBuffer = "setTransformationMatrixBuffer:";
        private static readonly Selector sel_transformationMatrixBufferOffset = "transformationMatrixBufferOffset";
        private static readonly Selector sel_setTransformationMatrixBufferOffset = "setTransformationMatrixBufferOffset:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureBoundingBoxGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer BoundingBoxBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_boundingBoxBuffer));
        public ulong BoundingBoxBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxBufferOffset);
        public ulong BoundingBoxStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxStride);
        public ulong BoundingBoxCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxCount);
        public MTLAccelerationStructureBoundingBoxGeometryDescriptor Descriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_descriptor));

        private static readonly Selector sel_boundingBoxBuffer = "boundingBoxBuffer";
        private static readonly Selector sel_setBoundingBoxBuffer = "setBoundingBoxBuffer:";
        private static readonly Selector sel_boundingBoxBufferOffset = "boundingBoxBufferOffset";
        private static readonly Selector sel_setBoundingBoxBufferOffset = "setBoundingBoxBufferOffset:";
        private static readonly Selector sel_boundingBoxStride = "boundingBoxStride";
        private static readonly Selector sel_setBoundingBoxStride = "setBoundingBoxStride:";
        private static readonly Selector sel_boundingBoxCount = "boundingBoxCount";
        private static readonly Selector sel_setBoundingBoxCount = "setBoundingBoxCount:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLMotionKeyframeData
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLMotionKeyframeData obj) => obj.NativePtr;
        public MTLMotionKeyframeData(IntPtr ptr) => NativePtr = ptr;

        public MTLMotionKeyframeData()
        {
            var cls = new ObjectiveCClass("MTLMotionKeyframeData");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer Buffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));
        public ulong Offset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_offset);
        public MTLMotionKeyframeData Data => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_data));

        private static readonly Selector sel_buffer = "buffer";
        private static readonly Selector sel_setBuffer = "setBuffer:";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_setOffset = "setOffset:";
        private static readonly Selector sel_data = "data";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureMotionTriangleGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureMotionTriangleGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureMotionTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureMotionTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray VertexBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffers));
        public MTLAttributeFormat VertexFormat => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexFormat);
        public ulong VertexStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexStride);
        public MTLBuffer IndexBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indexBuffer));
        public ulong IndexBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexBufferOffset);
        public MTLIndexType IndexType => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
        public ulong TriangleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_triangleCount);
        public MTLBuffer TransformationMatrixBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_transformationMatrixBuffer));
        public ulong TransformationMatrixBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_transformationMatrixBufferOffset);
        public MTLAccelerationStructureMotionTriangleGeometryDescriptor Descriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_descriptor));

        private static readonly Selector sel_vertexBuffers = "vertexBuffers";
        private static readonly Selector sel_setVertexBuffers = "setVertexBuffers:";
        private static readonly Selector sel_vertexFormat = "vertexFormat";
        private static readonly Selector sel_setVertexFormat = "setVertexFormat:";
        private static readonly Selector sel_vertexStride = "vertexStride";
        private static readonly Selector sel_setVertexStride = "setVertexStride:";
        private static readonly Selector sel_indexBuffer = "indexBuffer";
        private static readonly Selector sel_setIndexBuffer = "setIndexBuffer:";
        private static readonly Selector sel_indexBufferOffset = "indexBufferOffset";
        private static readonly Selector sel_setIndexBufferOffset = "setIndexBufferOffset:";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_setIndexType = "setIndexType:";
        private static readonly Selector sel_triangleCount = "triangleCount";
        private static readonly Selector sel_setTriangleCount = "setTriangleCount:";
        private static readonly Selector sel_transformationMatrixBuffer = "transformationMatrixBuffer";
        private static readonly Selector sel_setTransformationMatrixBuffer = "setTransformationMatrixBuffer:";
        private static readonly Selector sel_transformationMatrixBufferOffset = "transformationMatrixBufferOffset";
        private static readonly Selector sel_setTransformationMatrixBufferOffset = "setTransformationMatrixBufferOffset:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray BoundingBoxBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_boundingBoxBuffers));
        public ulong BoundingBoxStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxStride);
        public ulong BoundingBoxCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxCount);
        public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_descriptor));

        private static readonly Selector sel_boundingBoxBuffers = "boundingBoxBuffers";
        private static readonly Selector sel_setBoundingBoxBuffers = "setBoundingBoxBuffers:";
        private static readonly Selector sel_boundingBoxStride = "boundingBoxStride";
        private static readonly Selector sel_setBoundingBoxStride = "setBoundingBoxStride:";
        private static readonly Selector sel_boundingBoxCount = "boundingBoxCount";
        private static readonly Selector sel_setBoundingBoxCount = "setBoundingBoxCount:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructureInstanceDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureInstanceDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureInstanceDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPackedFloat4x3 transformationMatrix;
        public MTLAccelerationStructureInstanceOptions options;
        public uint mask;
        public uint intersectionFunctionTableOffset;
        public uint accelerationStructureIndex;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructureUserIDInstanceDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureUserIDInstanceDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureUserIDInstanceDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPackedFloat4x3 transformationMatrix;
        public MTLAccelerationStructureInstanceOptions options;
        public uint mask;
        public uint intersectionFunctionTableOffset;
        public uint accelerationStructureIndex;
        public uint userID;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructureMotionInstanceDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureMotionInstanceDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureMotionInstanceDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureInstanceOptions options;
        public uint mask;
        public uint intersectionFunctionTableOffset;
        public uint accelerationStructureIndex;
        public uint userID;
        public uint motionTransformsStartIndex;
        public uint motionTransformsCount;
        public MTLMotionBorderMode motionStartBorderMode;
        public MTLMotionBorderMode motionEndBorderMode;
        public float motionStartTime;
        public float motionEndTime;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLInstanceAccelerationStructureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLInstanceAccelerationStructureDescriptor obj) => obj.NativePtr;
        public MTLInstanceAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLInstanceAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLInstanceAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer InstanceDescriptorBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_instanceDescriptorBuffer));
        public ulong InstanceDescriptorBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorBufferOffset);
        public ulong InstanceDescriptorStride => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorStride);
        public ulong InstanceCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceCount);
        public NSArray InstancedAccelerationStructures => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_instancedAccelerationStructures));
        public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorType);
        public MTLBuffer MotionTransformBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_motionTransformBuffer));
        public ulong MotionTransformBufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformBufferOffset);
        public ulong MotionTransformCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformCount);
        public MTLInstanceAccelerationStructureDescriptor Descriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_descriptor));

        private static readonly Selector sel_instanceDescriptorBuffer = "instanceDescriptorBuffer";
        private static readonly Selector sel_setInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";
        private static readonly Selector sel_instanceDescriptorBufferOffset = "instanceDescriptorBufferOffset";
        private static readonly Selector sel_setInstanceDescriptorBufferOffset = "setInstanceDescriptorBufferOffset:";
        private static readonly Selector sel_instanceDescriptorStride = "instanceDescriptorStride";
        private static readonly Selector sel_setInstanceDescriptorStride = "setInstanceDescriptorStride:";
        private static readonly Selector sel_instanceCount = "instanceCount";
        private static readonly Selector sel_setInstanceCount = "setInstanceCount:";
        private static readonly Selector sel_instancedAccelerationStructures = "instancedAccelerationStructures";
        private static readonly Selector sel_setInstancedAccelerationStructures = "setInstancedAccelerationStructures:";
        private static readonly Selector sel_instanceDescriptorType = "instanceDescriptorType";
        private static readonly Selector sel_setInstanceDescriptorType = "setInstanceDescriptorType:";
        private static readonly Selector sel_motionTransformBuffer = "motionTransformBuffer";
        private static readonly Selector sel_setMotionTransformBuffer = "setMotionTransformBuffer:";
        private static readonly Selector sel_motionTransformBufferOffset = "motionTransformBufferOffset";
        private static readonly Selector sel_setMotionTransformBufferOffset = "setMotionTransformBufferOffset:";
        private static readonly Selector sel_motionTransformCount = "motionTransformCount";
        private static readonly Selector sel_setMotionTransformCount = "setMotionTransformCount:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAccelerationStructure
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructure obj) => obj.NativePtr;
        public MTLAccelerationStructure(IntPtr ptr) => NativePtr = ptr;

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);
        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
    }
}
