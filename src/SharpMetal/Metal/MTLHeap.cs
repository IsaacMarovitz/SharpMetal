using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLHeapType : long
    {
        Automatic = 0,
        Placement = 1,
        Sparse = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLHeap : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLHeap obj) => obj.NativePtr;
        public static implicit operator MTLAllocation(MTLHeap obj) => new(obj.NativePtr);
        public MTLHeap(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public ulong CurrentAllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_currentAllocatedSize);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public MTLHeapType Type => (MTLHeapType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        public ulong UsedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usedSize);

        public ulong MaxAvailableSize(ulong alignment)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxAvailableSizeWithAlignment, alignment);
        }

        public MTLAccelerationStructure NewAccelerationStructure(ulong size)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newAccelerationStructureWithSize, size));
        }

        public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newAccelerationStructureWithDescriptor, descriptor));
        }

        public MTLAccelerationStructure NewAccelerationStructure(ulong size, ulong offset)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newAccelerationStructureWithSizeoffset, size, offset));
        }

        public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, ulong offset)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newAccelerationStructureWithDescriptoroffset, descriptor, offset));
        }

        public MTLBuffer NewBuffer(ulong length, MTLResourceOptions options)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBufferWithLengthoptions, length, (ulong)options));
        }

        public MTLBuffer NewBuffer(ulong length, MTLResourceOptions options, ulong offset)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBufferWithLengthoptionsoffset, length, (ulong)options, offset));
        }

        public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureWithDescriptor, descriptor));
        }

        public MTLTexture NewTexture(MTLTextureDescriptor descriptor, ulong offset)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureWithDescriptoroffset, descriptor, offset));
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_currentAllocatedSize = "currentAllocatedSize";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxAvailableSizeWithAlignment = "maxAvailableSizeWithAlignment:";
        private static readonly Selector sel_newAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";
        private static readonly Selector sel_newAccelerationStructureWithDescriptoroffset = "newAccelerationStructureWithDescriptor:offset:";
        private static readonly Selector sel_newAccelerationStructureWithSize = "newAccelerationStructureWithSize:";
        private static readonly Selector sel_newAccelerationStructureWithSizeoffset = "newAccelerationStructureWithSize:offset:";
        private static readonly Selector sel_newBufferWithLengthoptions = "newBufferWithLength:options:";
        private static readonly Selector sel_newBufferWithLengthoptionsoffset = "newBufferWithLength:options:offset:";
        private static readonly Selector sel_newTextureWithDescriptor = "newTextureWithDescriptor:";
        private static readonly Selector sel_newTextureWithDescriptoroffset = "newTextureWithDescriptor:offset:";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_usedSize = "usedSize";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLHeapDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLHeapDescriptor obj) => obj.NativePtr;
        public MTLHeapDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLHeapDescriptor()
        {
            var cls = new ObjectiveCClass("MTLHeapDescriptor");
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

        public MTLHazardTrackingMode HazardTrackingMode
        {
            get => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setHazardTrackingMode, (ulong)value);
        }

        public MTLSparsePageSize MaxCompatiblePlacementSparsePageSize
        {
            get => (MTLSparsePageSize)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_maxCompatiblePlacementSparsePageSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCompatiblePlacementSparsePageSize, (long)value);
        }

        public MTLResourceOptions ResourceOptions
        {
            get => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResourceOptions, (ulong)value);
        }

        public ulong Size
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSize, value);
        }

        public MTLSparsePageSize SparsePageSize
        {
            get => (MTLSparsePageSize)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_sparsePageSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSparsePageSize, (long)value);
        }

        public MTLStorageMode StorageMode
        {
            get => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)value);
        }

        public MTLHeapType Type
        {
            get => (MTLHeapType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setType, (long)value);
        }

        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_maxCompatiblePlacementSparsePageSize = "maxCompatiblePlacementSparsePageSize";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        private static readonly Selector sel_setHazardTrackingMode = "setHazardTrackingMode:";
        private static readonly Selector sel_setMaxCompatiblePlacementSparsePageSize = "setMaxCompatiblePlacementSparsePageSize:";
        private static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        private static readonly Selector sel_setSize = "setSize:";
        private static readonly Selector sel_setSparsePageSize = "setSparsePageSize:";
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        private static readonly Selector sel_setType = "setType:";
        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_sparsePageSize = "sparsePageSize";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_release = "release";
    }
}
