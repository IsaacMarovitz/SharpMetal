using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureBoundingBoxGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureBoundingBoxGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public MTL4BufferRange BoundingBoxBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_boundingBoxBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxBuffer, value);
        }

        public ulong BoundingBoxCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxCount, value);
        }

        public ulong BoundingBoxStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxStride, value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_boundingBoxBuffer = "boundingBoxBuffer";
        private static readonly Selector sel_boundingBoxCount = "boundingBoxCount";
        private static readonly Selector sel_boundingBoxStride = "boundingBoxStride";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setBoundingBoxBuffer = "setBoundingBoxBuffer:";
        private static readonly Selector sel_setBoundingBoxCount = "setBoundingBoxCount:";
        private static readonly Selector sel_setBoundingBoxStride = "setBoundingBoxStride:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureCurveGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureCurveGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureCurveGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureCurveGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureCurveGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureCurveGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public MTL4BufferRange ControlPointBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_controlPointBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointBuffer, value);
        }

        public ulong ControlPointCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_controlPointCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointCount, value);
        }

        public MTLAttributeFormat ControlPointFormat
        {
            get => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_controlPointFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointFormat, (ulong)value);
        }

        public ulong ControlPointStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_controlPointStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointStride, value);
        }

        public MTLCurveBasis CurveBasis
        {
            get => (MTLCurveBasis)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_curveBasis);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCurveBasis, (long)value);
        }

        public MTLCurveEndCaps CurveEndCaps
        {
            get => (MTLCurveEndCaps)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_curveEndCaps);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCurveEndCaps, (long)value);
        }

        public MTLCurveType CurveType
        {
            get => (MTLCurveType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_curveType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCurveType, (long)value);
        }

        public MTL4BufferRange IndexBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_indexBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBuffer, value);
        }

        public MTLIndexType IndexType
        {
            get => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexType, (ulong)value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        public MTL4BufferRange RadiusBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_radiusBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRadiusBuffer, value);
        }

        public MTLAttributeFormat RadiusFormat
        {
            get => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_radiusFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRadiusFormat, (ulong)value);
        }

        public ulong RadiusStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_radiusStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRadiusStride, value);
        }

        public ulong SegmentControlPointCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_segmentControlPointCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSegmentControlPointCount, value);
        }

        public ulong SegmentCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_segmentCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSegmentCount, value);
        }

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_controlPointBuffer = "controlPointBuffer";
        private static readonly Selector sel_controlPointCount = "controlPointCount";
        private static readonly Selector sel_controlPointFormat = "controlPointFormat";
        private static readonly Selector sel_controlPointStride = "controlPointStride";
        private static readonly Selector sel_curveBasis = "curveBasis";
        private static readonly Selector sel_curveEndCaps = "curveEndCaps";
        private static readonly Selector sel_curveType = "curveType";
        private static readonly Selector sel_indexBuffer = "indexBuffer";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_radiusBuffer = "radiusBuffer";
        private static readonly Selector sel_radiusFormat = "radiusFormat";
        private static readonly Selector sel_radiusStride = "radiusStride";
        private static readonly Selector sel_segmentControlPointCount = "segmentControlPointCount";
        private static readonly Selector sel_segmentCount = "segmentCount";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setControlPointBuffer = "setControlPointBuffer:";
        private static readonly Selector sel_setControlPointCount = "setControlPointCount:";
        private static readonly Selector sel_setControlPointFormat = "setControlPointFormat:";
        private static readonly Selector sel_setControlPointStride = "setControlPointStride:";
        private static readonly Selector sel_setCurveBasis = "setCurveBasis:";
        private static readonly Selector sel_setCurveEndCaps = "setCurveEndCaps:";
        private static readonly Selector sel_setCurveType = "setCurveType:";
        private static readonly Selector sel_setIndexBuffer = "setIndexBuffer:";
        private static readonly Selector sel_setIndexType = "setIndexType:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_setRadiusBuffer = "setRadiusBuffer:";
        private static readonly Selector sel_setRadiusFormat = "setRadiusFormat:";
        private static readonly Selector sel_setRadiusStride = "setRadiusStride:";
        private static readonly Selector sel_setSegmentControlPointCount = "setSegmentControlPointCount:";
        private static readonly Selector sel_setSegmentCount = "setSegmentCount:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTLAccelerationStructureDescriptor(MTL4AccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureGeometryDescriptor obj) => obj.NativePtr;
        public MTL4AccelerationStructureGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public MTL4BufferRange BoundingBoxBuffers
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_boundingBoxBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxBuffers, value);
        }

        public ulong BoundingBoxCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxCount, value);
        }

        public ulong BoundingBoxStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_boundingBoxStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBoundingBoxStride, value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_boundingBoxBuffers = "boundingBoxBuffers";
        private static readonly Selector sel_boundingBoxCount = "boundingBoxCount";
        private static readonly Selector sel_boundingBoxStride = "boundingBoxStride";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setBoundingBoxBuffers = "setBoundingBoxBuffers:";
        private static readonly Selector sel_setBoundingBoxCount = "setBoundingBoxCount:";
        private static readonly Selector sel_setBoundingBoxStride = "setBoundingBoxStride:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureMotionCurveGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureMotionCurveGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionCurveGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureMotionCurveGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureMotionCurveGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureMotionCurveGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public MTL4BufferRange ControlPointBuffers
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_controlPointBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointBuffers, value);
        }

        public ulong ControlPointCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_controlPointCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointCount, value);
        }

        public MTLAttributeFormat ControlPointFormat
        {
            get => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_controlPointFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointFormat, (ulong)value);
        }

        public ulong ControlPointStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_controlPointStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlPointStride, value);
        }

        public MTLCurveBasis CurveBasis
        {
            get => (MTLCurveBasis)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_curveBasis);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCurveBasis, (long)value);
        }

        public MTLCurveEndCaps CurveEndCaps
        {
            get => (MTLCurveEndCaps)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_curveEndCaps);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCurveEndCaps, (long)value);
        }

        public MTLCurveType CurveType
        {
            get => (MTLCurveType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_curveType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCurveType, (long)value);
        }

        public MTL4BufferRange IndexBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_indexBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBuffer, value);
        }

        public MTLIndexType IndexType
        {
            get => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexType, (ulong)value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        public MTL4BufferRange RadiusBuffers
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_radiusBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRadiusBuffers, value);
        }

        public MTLAttributeFormat RadiusFormat
        {
            get => (MTLAttributeFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_radiusFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRadiusFormat, (ulong)value);
        }

        public ulong RadiusStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_radiusStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRadiusStride, value);
        }

        public ulong SegmentControlPointCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_segmentControlPointCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSegmentControlPointCount, value);
        }

        public ulong SegmentCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_segmentCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSegmentCount, value);
        }

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_controlPointBuffers = "controlPointBuffers";
        private static readonly Selector sel_controlPointCount = "controlPointCount";
        private static readonly Selector sel_controlPointFormat = "controlPointFormat";
        private static readonly Selector sel_controlPointStride = "controlPointStride";
        private static readonly Selector sel_curveBasis = "curveBasis";
        private static readonly Selector sel_curveEndCaps = "curveEndCaps";
        private static readonly Selector sel_curveType = "curveType";
        private static readonly Selector sel_indexBuffer = "indexBuffer";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_radiusBuffers = "radiusBuffers";
        private static readonly Selector sel_radiusFormat = "radiusFormat";
        private static readonly Selector sel_radiusStride = "radiusStride";
        private static readonly Selector sel_segmentControlPointCount = "segmentControlPointCount";
        private static readonly Selector sel_segmentCount = "segmentCount";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setControlPointBuffers = "setControlPointBuffers:";
        private static readonly Selector sel_setControlPointCount = "setControlPointCount:";
        private static readonly Selector sel_setControlPointFormat = "setControlPointFormat:";
        private static readonly Selector sel_setControlPointStride = "setControlPointStride:";
        private static readonly Selector sel_setCurveBasis = "setCurveBasis:";
        private static readonly Selector sel_setCurveEndCaps = "setCurveEndCaps:";
        private static readonly Selector sel_setCurveType = "setCurveType:";
        private static readonly Selector sel_setIndexBuffer = "setIndexBuffer:";
        private static readonly Selector sel_setIndexType = "setIndexType:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_setRadiusBuffers = "setRadiusBuffers:";
        private static readonly Selector sel_setRadiusFormat = "setRadiusFormat:";
        private static readonly Selector sel_setRadiusStride = "setRadiusStride:";
        private static readonly Selector sel_setSegmentControlPointCount = "setSegmentControlPointCount:";
        private static readonly Selector sel_setSegmentCount = "setSegmentCount:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureMotionTriangleGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureMotionTriangleGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionTriangleGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureMotionTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureMotionTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureMotionTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public MTL4BufferRange IndexBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_indexBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBuffer, value);
        }

        public MTLIndexType IndexType
        {
            get => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexType, (ulong)value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        public MTL4BufferRange TransformationMatrixBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_transformationMatrixBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixBuffer, value);
        }

        public MTLMatrixLayout TransformationMatrixLayout
        {
            get => (MTLMatrixLayout)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_transformationMatrixLayout);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixLayout, (long)value);
        }

        public ulong TriangleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_triangleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleCount, value);
        }

        public MTL4BufferRange VertexBuffers
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_vertexBuffers);
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

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_indexBuffer = "indexBuffer";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setIndexBuffer = "setIndexBuffer:";
        private static readonly Selector sel_setIndexType = "setIndexType:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_setTransformationMatrixBuffer = "setTransformationMatrixBuffer:";
        private static readonly Selector sel_setTransformationMatrixLayout = "setTransformationMatrixLayout:";
        private static readonly Selector sel_setTriangleCount = "setTriangleCount:";
        private static readonly Selector sel_setVertexBuffers = "setVertexBuffers:";
        private static readonly Selector sel_setVertexFormat = "setVertexFormat:";
        private static readonly Selector sel_setVertexStride = "setVertexStride:";
        private static readonly Selector sel_transformationMatrixBuffer = "transformationMatrixBuffer";
        private static readonly Selector sel_transformationMatrixLayout = "transformationMatrixLayout";
        private static readonly Selector sel_triangleCount = "triangleCount";
        private static readonly Selector sel_vertexBuffers = "vertexBuffers";
        private static readonly Selector sel_vertexFormat = "vertexFormat";
        private static readonly Selector sel_vertexStride = "vertexStride";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureTriangleGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureTriangleGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureTriangleGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowDuplicateIntersectionFunctionInvocation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowDuplicateIntersectionFunctionInvocation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowDuplicateIntersectionFunctionInvocation, value);
        }

        public MTL4BufferRange IndexBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_indexBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexBuffer, value);
        }

        public MTLIndexType IndexType
        {
            get => (MTLIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_indexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndexType, (ulong)value);
        }

        public ulong IntersectionFunctionTableOffset
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intersectionFunctionTableOffset);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableOffset, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool Opaque
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_opaque);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaque, value);
        }

        public MTL4BufferRange PrimitiveDataBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_primitiveDataBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataBuffer, value);
        }

        public ulong PrimitiveDataElementSize
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataElementSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataElementSize, value);
        }

        public ulong PrimitiveDataStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_primitiveDataStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrimitiveDataStride, value);
        }

        public MTL4BufferRange TransformationMatrixBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_transformationMatrixBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixBuffer, value);
        }

        public MTLMatrixLayout TransformationMatrixLayout
        {
            get => (MTLMatrixLayout)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_transformationMatrixLayout);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTransformationMatrixLayout, (long)value);
        }

        public ulong TriangleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_triangleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleCount, value);
        }

        public MTL4BufferRange VertexBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_vertexBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBuffer, value);
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

        private static readonly Selector sel_allowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";
        private static readonly Selector sel_indexBuffer = "indexBuffer";
        private static readonly Selector sel_indexType = "indexType";
        private static readonly Selector sel_intersectionFunctionTableOffset = "intersectionFunctionTableOffset";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_opaque = "opaque";
        private static readonly Selector sel_primitiveDataBuffer = "primitiveDataBuffer";
        private static readonly Selector sel_primitiveDataElementSize = "primitiveDataElementSize";
        private static readonly Selector sel_primitiveDataStride = "primitiveDataStride";
        private static readonly Selector sel_setAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";
        private static readonly Selector sel_setIndexBuffer = "setIndexBuffer:";
        private static readonly Selector sel_setIndexType = "setIndexType:";
        private static readonly Selector sel_setIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaque = "setOpaque:";
        private static readonly Selector sel_setPrimitiveDataBuffer = "setPrimitiveDataBuffer:";
        private static readonly Selector sel_setPrimitiveDataElementSize = "setPrimitiveDataElementSize:";
        private static readonly Selector sel_setPrimitiveDataStride = "setPrimitiveDataStride:";
        private static readonly Selector sel_setTransformationMatrixBuffer = "setTransformationMatrixBuffer:";
        private static readonly Selector sel_setTransformationMatrixLayout = "setTransformationMatrixLayout:";
        private static readonly Selector sel_setTriangleCount = "setTriangleCount:";
        private static readonly Selector sel_setVertexBuffer = "setVertexBuffer:";
        private static readonly Selector sel_setVertexFormat = "setVertexFormat:";
        private static readonly Selector sel_setVertexStride = "setVertexStride:";
        private static readonly Selector sel_transformationMatrixBuffer = "transformationMatrixBuffer";
        private static readonly Selector sel_transformationMatrixLayout = "transformationMatrixLayout";
        private static readonly Selector sel_triangleCount = "triangleCount";
        private static readonly Selector sel_vertexBuffer = "vertexBuffer";
        private static readonly Selector sel_vertexFormat = "vertexFormat";
        private static readonly Selector sel_vertexStride = "vertexStride";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4IndirectInstanceAccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4IndirectInstanceAccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureDescriptor(MTL4IndirectInstanceAccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4IndirectInstanceAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4IndirectInstanceAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4IndirectInstanceAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4BufferRange InstanceCountBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_instanceCountBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceCountBuffer, value);
        }

        public MTL4BufferRange InstanceDescriptorBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_instanceDescriptorBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorBuffer, value);
        }

        public ulong InstanceDescriptorStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorStride, value);
        }

        public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
        {
            get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorType, (ulong)value);
        }

        public MTLMatrixLayout InstanceTransformationMatrixLayout
        {
            get => (MTLMatrixLayout)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_instanceTransformationMatrixLayout);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceTransformationMatrixLayout, (long)value);
        }

        public ulong MaxInstanceCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxInstanceCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxInstanceCount, value);
        }

        public ulong MaxMotionTransformCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxMotionTransformCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxMotionTransformCount, value);
        }

        public MTL4BufferRange MotionTransformBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_motionTransformBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformBuffer, value);
        }

        public MTL4BufferRange MotionTransformCountBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_motionTransformCountBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformCountBuffer, value);
        }

        public ulong MotionTransformStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformStride, value);
        }

        public MTLTransformType MotionTransformType
        {
            get => (MTLTransformType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_motionTransformType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformType, (long)value);
        }

        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_instanceCountBuffer = "instanceCountBuffer";
        private static readonly Selector sel_instanceDescriptorBuffer = "instanceDescriptorBuffer";
        private static readonly Selector sel_instanceDescriptorStride = "instanceDescriptorStride";
        private static readonly Selector sel_instanceDescriptorType = "instanceDescriptorType";
        private static readonly Selector sel_instanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";
        private static readonly Selector sel_maxInstanceCount = "maxInstanceCount";
        private static readonly Selector sel_maxMotionTransformCount = "maxMotionTransformCount";
        private static readonly Selector sel_motionTransformBuffer = "motionTransformBuffer";
        private static readonly Selector sel_motionTransformCountBuffer = "motionTransformCountBuffer";
        private static readonly Selector sel_motionTransformStride = "motionTransformStride";
        private static readonly Selector sel_motionTransformType = "motionTransformType";
        private static readonly Selector sel_setInstanceCountBuffer = "setInstanceCountBuffer:";
        private static readonly Selector sel_setInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";
        private static readonly Selector sel_setInstanceDescriptorStride = "setInstanceDescriptorStride:";
        private static readonly Selector sel_setInstanceDescriptorType = "setInstanceDescriptorType:";
        private static readonly Selector sel_setInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";
        private static readonly Selector sel_setMaxInstanceCount = "setMaxInstanceCount:";
        private static readonly Selector sel_setMaxMotionTransformCount = "setMaxMotionTransformCount:";
        private static readonly Selector sel_setMotionTransformBuffer = "setMotionTransformBuffer:";
        private static readonly Selector sel_setMotionTransformCountBuffer = "setMotionTransformCountBuffer:";
        private static readonly Selector sel_setMotionTransformStride = "setMotionTransformStride:";
        private static readonly Selector sel_setMotionTransformType = "setMotionTransformType:";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4InstanceAccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4InstanceAccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureDescriptor(MTL4InstanceAccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4InstanceAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4InstanceAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4InstanceAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong InstanceCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceCount, value);
        }

        public MTL4BufferRange InstanceDescriptorBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_instanceDescriptorBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorBuffer, value);
        }

        public ulong InstanceDescriptorStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorStride, value);
        }

        public MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType
        {
            get => (MTLAccelerationStructureInstanceDescriptorType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_instanceDescriptorType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceDescriptorType, (ulong)value);
        }

        public MTLMatrixLayout InstanceTransformationMatrixLayout
        {
            get => (MTLMatrixLayout)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_instanceTransformationMatrixLayout);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstanceTransformationMatrixLayout, (long)value);
        }

        public MTL4BufferRange MotionTransformBuffer
        {
            get => ObjectiveCRuntime.MTL4BufferRange_objc_msgSend(NativePtr, sel_motionTransformBuffer);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformBuffer, value);
        }

        public ulong MotionTransformCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformCount, value);
        }

        public ulong MotionTransformStride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_motionTransformStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformStride, value);
        }

        public MTLTransformType MotionTransformType
        {
            get => (MTLTransformType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_motionTransformType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionTransformType, (long)value);
        }

        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_instanceCount = "instanceCount";
        private static readonly Selector sel_instanceDescriptorBuffer = "instanceDescriptorBuffer";
        private static readonly Selector sel_instanceDescriptorStride = "instanceDescriptorStride";
        private static readonly Selector sel_instanceDescriptorType = "instanceDescriptorType";
        private static readonly Selector sel_instanceTransformationMatrixLayout = "instanceTransformationMatrixLayout";
        private static readonly Selector sel_motionTransformBuffer = "motionTransformBuffer";
        private static readonly Selector sel_motionTransformCount = "motionTransformCount";
        private static readonly Selector sel_motionTransformStride = "motionTransformStride";
        private static readonly Selector sel_motionTransformType = "motionTransformType";
        private static readonly Selector sel_setInstanceCount = "setInstanceCount:";
        private static readonly Selector sel_setInstanceDescriptorBuffer = "setInstanceDescriptorBuffer:";
        private static readonly Selector sel_setInstanceDescriptorStride = "setInstanceDescriptorStride:";
        private static readonly Selector sel_setInstanceDescriptorType = "setInstanceDescriptorType:";
        private static readonly Selector sel_setInstanceTransformationMatrixLayout = "setInstanceTransformationMatrixLayout:";
        private static readonly Selector sel_setMotionTransformBuffer = "setMotionTransformBuffer:";
        private static readonly Selector sel_setMotionTransformCount = "setMotionTransformCount:";
        private static readonly Selector sel_setMotionTransformStride = "setMotionTransformStride:";
        private static readonly Selector sel_setMotionTransformType = "setMotionTransformType:";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4PrimitiveAccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PrimitiveAccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureDescriptor(MTL4PrimitiveAccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4PrimitiveAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4PrimitiveAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4PrimitiveAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray GeometryDescriptors
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_geometryDescriptors));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setGeometryDescriptors, value);
        }

        public MTLMotionBorderMode MotionEndBorderMode
        {
            get => (MTLMotionBorderMode)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_motionEndBorderMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionEndBorderMode, (uint)value);
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

        public MTLMotionBorderMode MotionStartBorderMode
        {
            get => (MTLMotionBorderMode)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_motionStartBorderMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionStartBorderMode, (uint)value);
        }

        public float MotionStartTime
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_motionStartTime);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMotionStartTime, value);
        }

        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_geometryDescriptors = "geometryDescriptors";
        private static readonly Selector sel_motionEndBorderMode = "motionEndBorderMode";
        private static readonly Selector sel_motionEndTime = "motionEndTime";
        private static readonly Selector sel_motionKeyframeCount = "motionKeyframeCount";
        private static readonly Selector sel_motionStartBorderMode = "motionStartBorderMode";
        private static readonly Selector sel_motionStartTime = "motionStartTime";
        private static readonly Selector sel_setGeometryDescriptors = "setGeometryDescriptors:";
        private static readonly Selector sel_setMotionEndBorderMode = "setMotionEndBorderMode:";
        private static readonly Selector sel_setMotionEndTime = "setMotionEndTime:";
        private static readonly Selector sel_setMotionKeyframeCount = "setMotionKeyframeCount:";
        private static readonly Selector sel_setMotionStartBorderMode = "setMotionStartBorderMode:";
        private static readonly Selector sel_setMotionStartTime = "setMotionStartTime:";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }
}
