using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLTensorDataType : long
    {
        None = 0,
        Float32 = 3,
        Float16 = 16,
        BFloat16 = 121,
        Int8 = 45,
        UInt8 = 49,
        Int16 = 37,
        UInt16 = 41,
        Int32 = 29,
        UInt32 = 33,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTensorError : long
    {
        None = 0,
        InternalError = 1,
        InvalidDescriptor = 2,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLTensorUsage : ulong
    {
        Compute = 1,
        Render = 1 << 1,
        MachineLearning = 1 << 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTensor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTensor obj) => obj.NativePtr;
        public static implicit operator MTLResource(MTLTensor obj) => new(obj.NativePtr);
        public MTLTensor(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public MTLBuffer Buffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));

        public ulong BufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferOffset);

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public MTLTensorDataType DataType => (MTLTensorDataType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_dataType);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLTensorExtents Dimensions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_dimensions));

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);

        public MTLHeap Heap => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_heap));

        public ulong HeapOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_heapOffset);

        public bool IsAliasable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAliasable);

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public MTLTensorExtents Strides => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_strides));

        public MTLTensorUsage Usage => (MTLTensorUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);

        public void GetBytes(IntPtr bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_getBytesstridesfromSliceOriginsliceDimensions, bytes, strides, sliceOrigin, sliceDimensions);
        }

        public void MakeAliasable()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_makeAliasable);
        }

        public void ReplaceSliceOrigin(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, IntPtr bytes, MTLTensorExtents strides)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_replaceSliceOriginsliceDimensionswithBytesstrides, sliceOrigin, sliceDimensions, bytes, strides);
        }

        public int SetOwner(IntPtr task_id_token)
        {
            return ObjectiveCRuntime.int_objc_msgSend(NativePtr, sel_setOwnerWithIdentity, task_id_token);
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_buffer = "buffer";
        private static readonly Selector sel_bufferOffset = "bufferOffset";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_dataType = "dataType";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_dimensions = "dimensions";
        private static readonly Selector sel_getBytesstridesfromSliceOriginsliceDimensions = "getBytes:strides:fromSliceOrigin:sliceDimensions:";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_heap = "heap";
        private static readonly Selector sel_heapOffset = "heapOffset";
        private static readonly Selector sel_isAliasable = "isAliasable";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_makeAliasable = "makeAliasable";
        private static readonly Selector sel_replaceSliceOriginsliceDimensionswithBytesstrides = "replaceSliceOrigin:sliceDimensions:withBytes:strides:";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOwnerWithIdentity = "setOwnerWithIdentity:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_strides = "strides";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTensorDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTensorDescriptor obj) => obj.NativePtr;
        public MTLTensorDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTensorDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTensorDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLCPUCacheMode CpuCacheMode
        {
            get => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCpuCacheMode, (ulong)value);
        }

        public MTLTensorDataType DataType
        {
            get => (MTLTensorDataType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_dataType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDataType, (long)value);
        }

        public MTLTensorExtents Dimensions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_dimensions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDimensions, value);
        }

        public MTLHazardTrackingMode HazardTrackingMode
        {
            get => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setHazardTrackingMode, (ulong)value);
        }

        public MTLResourceOptions ResourceOptions
        {
            get => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResourceOptions, (ulong)value);
        }

        public MTLStorageMode StorageMode
        {
            get => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)value);
        }

        public MTLTensorExtents Strides
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_strides));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStrides, value);
        }

        public MTLTensorUsage Usage
        {
            get => (MTLTensorUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_dataType = "dataType";
        private static readonly Selector sel_dimensions = "dimensions";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        private static readonly Selector sel_setDataType = "setDataType:";
        private static readonly Selector sel_setDimensions = "setDimensions:";
        private static readonly Selector sel_setHazardTrackingMode = "setHazardTrackingMode:";
        private static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        private static readonly Selector sel_setStrides = "setStrides:";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_strides = "strides";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTensorExtents : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTensorExtents obj) => obj.NativePtr;
        public MTLTensorExtents(IntPtr ptr) => NativePtr = ptr;

        public MTLTensorExtents()
        {
            var cls = new ObjectiveCClass("MTLTensorExtents");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong Rank => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rank);

        public long ExtentAtDimensionIndex(ulong dimensionIndex)
        {
            return ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_extentAtDimensionIndex, dimensionIndex);
        }

        public MTLTensorExtents Init(ulong rank, long values)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithRankvalues, rank, values));
        }

        private static readonly Selector sel_extentAtDimensionIndex = "extentAtDimensionIndex:";
        private static readonly Selector sel_initWithRankvalues = "initWithRank:values:";
        private static readonly Selector sel_rank = "rank";
        private static readonly Selector sel_release = "release";
    }
}
