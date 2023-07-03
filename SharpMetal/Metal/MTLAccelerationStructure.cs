using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLAccelerationStructureUsage : ulong
    {
        None = 0,
        Refit = 1,
        PreferFastBuild = 2,
        ExtendedLimits = 4,
    }

    public enum MTLAccelerationStructureInstanceOptions : uint
    {
        AccelerationStructureInstanceOptionNone = 0,
        AccelerationStructureInstanceOptionDisableTriangleCulling = 1,
        AccelerationStructureInstanceOptionTriangleFrontFacingWindingCounterClockwise = 2,
        AccelerationStructureInstanceOptionOpaque = 4,
        AccelerationStructureInstanceOptionNonOpaque = 8,
    }

    public enum MTLMotionBorderMode : uint
    {
        Clamp = 0,
        Vanish = 1,
    }

    public enum MTLAccelerationStructureInstanceDescriptorType : ulong
    {
        Default = 0,
        UserID = 1,
        Motion = 2,
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
    public class MTLAccelerationStructureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        public void SetUsage(MTLAccelerationStructureUsage usage)
        {
            objc_msgSend(NativePtr, , usage);
        }

        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_setUsage = "setUsage:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLAccelerationStructureGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLBuffer PrimitiveDataBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_primitiveDataBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBufferOffset, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public void SetIntersectionFunctionTableOffset(ulong intersectionFunctionTableOffset)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTableOffset);
        }

        public void SetOpaque(bool opaque)
        {
            objc_msgSend(NativePtr, , opaque);
        }

        public void SetAllowDuplicateIntersectionFunctionInvocation(bool allowDuplicateIntersectionFunctionInvocation)
        {
            objc_msgSend(NativePtr, , allowDuplicateIntersectionFunctionInvocation);
        }

        public void SetLabel(NSString label)
        {
            objc_msgSend(NativePtr, , label);
        }

        public void SetPrimitiveDataBuffer(MTLBuffer primitiveDataBuffer)
        {
            objc_msgSend(NativePtr, , primitiveDataBuffer);
        }

        public void SetPrimitiveDataBufferOffset(ulong primitiveDataBufferOffset)
        {
            objc_msgSend(NativePtr, , primitiveDataBufferOffset);
        }

        public void SetPrimitiveDataStride(ulong primitiveDataStride)
        {
            objc_msgSend(NativePtr, , primitiveDataStride);
        }

        public void SetPrimitiveDataElementSize(ulong primitiveDataElementSize)
        {
            objc_msgSend(NativePtr, , primitiveDataElementSize);
        }

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
    public class MTLPrimitiveAccelerationStructureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPrimitiveAccelerationStructureDescriptor obj) => obj.NativePtr;
        public MTLPrimitiveAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPrimitiveAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLPrimitiveAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray GeometryDescriptors
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_geometryDescriptors));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setGeometryDescriptors, value);
        }

        public MTLMotionBorderMode MotionStartBorderMode
        {
            get => (MTLMotionBorderMode)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_motionStartBorderMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionStartBorderMode, (uint)value);
        }

        public MTLMotionBorderMode MotionEndBorderMode
        {
            get => (MTLMotionBorderMode)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_motionEndBorderMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionEndBorderMode, (uint)value);
        }

        public float MotionStartTime
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionStartTime);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionStartTime, value);
        }

        public float MotionEndTime
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionEndTime);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionEndTime, value);
        }

        public ulong MotionKeyframeCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionKeyframeCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionKeyframeCount, value);
        }

        public void SetGeometryDescriptors(NSArray geometryDescriptors)
        {
            objc_msgSend(NativePtr, , geometryDescriptors);
        }

        public void SetMotionStartBorderMode(MTLMotionBorderMode motionStartBorderMode)
        {
            objc_msgSend(NativePtr, , motionStartBorderMode);
        }

        public void SetMotionEndBorderMode(MTLMotionBorderMode motionEndBorderMode)
        {
            objc_msgSend(NativePtr, , motionEndBorderMode);
        }

        public void SetMotionStartTime(float motionStartTime)
        {
            objc_msgSend(NativePtr, , motionStartTime);
        }

        public void SetMotionEndTime(float motionEndTime)
        {
            objc_msgSend(NativePtr, , motionEndTime);
        }

        public void SetMotionKeyframeCount(ulong motionKeyframeCount)
        {
            objc_msgSend(NativePtr, , motionKeyframeCount);
        }

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
    public class MTLAccelerationStructureTriangleGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureTriangleGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer VertexBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBuffer, value);
        }

        public ulong VertexBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBufferOffset, value);
        }

        public MTLAttributeFormat VertexFormat
        {
            get => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexFormat, (ulong)value);
        }

        public ulong VertexStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexStride, value);
        }

        public MTLBuffer IndexBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indexBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBuffer, value);
        }

        public ulong IndexBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBufferOffset, value);
        }

        public MTLIndexType IndexType
        {
            get => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexType, (ulong)value);
        }

        public ulong TriangleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_triangleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleCount, value);
        }

        public MTLBuffer TransformationMatrixBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_transformationMatrixBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixBuffer, value);
        }

        public ulong TransformationMatrixBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_transformationMatrixBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixBufferOffset, value);
        }

        public void SetVertexBuffer(MTLBuffer vertexBuffer)
        {
            objc_msgSend(NativePtr, , vertexBuffer);
        }

        public void SetVertexBufferOffset(ulong vertexBufferOffset)
        {
            objc_msgSend(NativePtr, , vertexBufferOffset);
        }

        public void SetVertexFormat(MTLAttributeFormat vertexFormat)
        {
            objc_msgSend(NativePtr, , vertexFormat);
        }

        public void SetVertexStride(ulong vertexStride)
        {
            objc_msgSend(NativePtr, , vertexStride);
        }

        public void SetIndexBuffer(MTLBuffer indexBuffer)
        {
            objc_msgSend(NativePtr, , indexBuffer);
        }

        public void SetIndexBufferOffset(ulong indexBufferOffset)
        {
            objc_msgSend(NativePtr, , indexBufferOffset);
        }

        public void SetIndexType(MTLIndexType indexType)
        {
            objc_msgSend(NativePtr, , indexType);
        }

        public void SetTriangleCount(ulong triangleCount)
        {
            objc_msgSend(NativePtr, , triangleCount);
        }

        public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
        {
            objc_msgSend(NativePtr, , transformationMatrixBuffer);
        }

        public void SetTransformationMatrixBufferOffset(ulong transformationMatrixBufferOffset)
        {
            objc_msgSend(NativePtr, , transformationMatrixBufferOffset);
        }

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
    public class MTLAccelerationStructureBoundingBoxGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer BoundingBoxBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_boundingBoxBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxBuffer, value);
        }

        public ulong BoundingBoxBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxBufferOffset, value);
        }

        public ulong BoundingBoxStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxStride, value);
        }

        public ulong BoundingBoxCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxCount, value);
        }

        public void SetBoundingBoxBuffer(MTLBuffer boundingBoxBuffer)
        {
            objc_msgSend(NativePtr, , boundingBoxBuffer);
        }

        public void SetBoundingBoxBufferOffset(ulong boundingBoxBufferOffset)
        {
            objc_msgSend(NativePtr, , boundingBoxBufferOffset);
        }

        public void SetBoundingBoxStride(ulong boundingBoxStride)
        {
            objc_msgSend(NativePtr, , boundingBoxStride);
        }

        public void SetBoundingBoxCount(ulong boundingBoxCount)
        {
            objc_msgSend(NativePtr, , boundingBoxCount);
        }

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
    public class MTLMotionKeyframeData
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLMotionKeyframeData obj) => obj.NativePtr;
        public MTLMotionKeyframeData(IntPtr ptr) => NativePtr = ptr;

        public MTLMotionKeyframeData()
        {
            var cls = new ObjectiveCClass("MTLMotionKeyframeData");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer Buffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBuffer, value);
        }

        public ulong Offset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_offset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOffset, value);
        }

        public void SetBuffer(MTLBuffer buffer)
        {
            objc_msgSend(NativePtr, , buffer);
        }

        public void SetOffset(ulong offset)
        {
            objc_msgSend(NativePtr, , offset);
        }

        private static readonly Selector sel_buffer = "buffer";
        private static readonly Selector sel_setBuffer = "setBuffer:";
        private static readonly Selector sel_offset = "offset";
        private static readonly Selector sel_setOffset = "setOffset:";
        private static readonly Selector sel_data = "data";
    }

    [SupportedOSPlatform("macos")]
    public class MTLAccelerationStructureMotionTriangleGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureMotionTriangleGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureMotionTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureMotionTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureMotionTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray VertexBuffers
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffers));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBuffers, value);
        }

        public MTLAttributeFormat VertexFormat
        {
            get => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexFormat, (ulong)value);
        }

        public ulong VertexStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_vertexStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexStride, value);
        }

        public MTLBuffer IndexBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indexBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBuffer, value);
        }

        public ulong IndexBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBufferOffset, value);
        }

        public MTLIndexType IndexType
        {
            get => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexType, (ulong)value);
        }

        public ulong TriangleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_triangleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleCount, value);
        }

        public MTLBuffer TransformationMatrixBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_transformationMatrixBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixBuffer, value);
        }

        public ulong TransformationMatrixBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_transformationMatrixBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixBufferOffset, value);
        }

        public void SetVertexBuffers(NSArray vertexBuffers)
        {
            objc_msgSend(NativePtr, , vertexBuffers);
        }

        public void SetVertexFormat(MTLAttributeFormat vertexFormat)
        {
            objc_msgSend(NativePtr, , vertexFormat);
        }

        public void SetVertexStride(ulong vertexStride)
        {
            objc_msgSend(NativePtr, , vertexStride);
        }

        public void SetIndexBuffer(MTLBuffer indexBuffer)
        {
            objc_msgSend(NativePtr, , indexBuffer);
        }

        public void SetIndexBufferOffset(ulong indexBufferOffset)
        {
            objc_msgSend(NativePtr, , indexBufferOffset);
        }

        public void SetIndexType(MTLIndexType indexType)
        {
            objc_msgSend(NativePtr, , indexType);
        }

        public void SetTriangleCount(ulong triangleCount)
        {
            objc_msgSend(NativePtr, , triangleCount);
        }

        public void SetTransformationMatrixBuffer(MTLBuffer transformationMatrixBuffer)
        {
            objc_msgSend(NativePtr, , transformationMatrixBuffer);
        }

        public void SetTransformationMatrixBufferOffset(ulong transformationMatrixBufferOffset)
        {
            objc_msgSend(NativePtr, , transformationMatrixBufferOffset);
        }

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
    public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray BoundingBoxBuffers
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_boundingBoxBuffers));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxBuffers, value);
        }

        public ulong BoundingBoxStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxStride, value);
        }

        public ulong BoundingBoxCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxCount, value);
        }

        public void SetBoundingBoxBuffers(NSArray boundingBoxBuffers)
        {
            objc_msgSend(NativePtr, , boundingBoxBuffers);
        }

        public void SetBoundingBoxStride(ulong boundingBoxStride)
        {
            objc_msgSend(NativePtr, , boundingBoxStride);
        }

        public void SetBoundingBoxCount(ulong boundingBoxCount)
        {
            objc_msgSend(NativePtr, , boundingBoxCount);
        }

        private static readonly Selector sel_boundingBoxBuffers = "boundingBoxBuffers";
        private static readonly Selector sel_setBoundingBoxBuffers = "setBoundingBoxBuffers:";
        private static readonly Selector sel_boundingBoxStride = "boundingBoxStride";
        private static readonly Selector sel_setBoundingBoxStride = "setBoundingBoxStride:";
        private static readonly Selector sel_boundingBoxCount = "boundingBoxCount";
        private static readonly Selector sel_setBoundingBoxCount = "setBoundingBoxCount:";
        private static readonly Selector sel_descriptor = "descriptor";
    }

    [SupportedOSPlatform("macos")]
    public class MTLInstanceAccelerationStructureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLInstanceAccelerationStructureDescriptor obj) => obj.NativePtr;
        public MTLInstanceAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLInstanceAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLInstanceAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBuffer InstanceDescriptorBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_instanceDescriptorBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorBuffer, value);
        }

        public ulong InstanceDescriptorBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorBufferOffset, value);
        }

        public ulong InstanceDescriptorStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorStride, value);
        }

        public ulong InstanceCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceCount, value);
        }

        public NSArray InstancedAccelerationStructures
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_instancedAccelerationStructures));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstancedAccelerationStructures, value);
        }

        public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
        {
            get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorType, (ulong)value);
        }

        public MTLBuffer MotionTransformBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_motionTransformBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformBuffer, value);
        }

        public ulong MotionTransformBufferOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformBufferOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformBufferOffset, value);
        }

        public ulong MotionTransformCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformCount, value);
        }

        public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
        {
            objc_msgSend(NativePtr, , instanceDescriptorBuffer);
        }

        public void SetInstanceDescriptorBufferOffset(ulong instanceDescriptorBufferOffset)
        {
            objc_msgSend(NativePtr, , instanceDescriptorBufferOffset);
        }

        public void SetInstanceDescriptorStride(ulong instanceDescriptorStride)
        {
            objc_msgSend(NativePtr, , instanceDescriptorStride);
        }

        public void SetInstanceCount(ulong instanceCount)
        {
            objc_msgSend(NativePtr, , instanceCount);
        }

        public void SetInstancedAccelerationStructures(NSArray instancedAccelerationStructures)
        {
            objc_msgSend(NativePtr, , instancedAccelerationStructures);
        }

        public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
        {
            objc_msgSend(NativePtr, , instanceDescriptorType);
        }

        public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
        {
            objc_msgSend(NativePtr, , motionTransformBuffer);
        }

        public void SetMotionTransformBufferOffset(ulong motionTransformBufferOffset)
        {
            objc_msgSend(NativePtr, , motionTransformBufferOffset);
        }

        public void SetMotionTransformCount(ulong motionTransformCount)
        {
            objc_msgSend(NativePtr, , motionTransformCount);
        }

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
    public class MTLAccelerationStructure
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
