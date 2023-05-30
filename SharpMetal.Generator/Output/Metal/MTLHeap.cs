using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLHeapType: long
    {
        Automatic = 0,
        Placement = 1,
        Sparse = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLHeapDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLHeapDescriptor obj) => obj.NativePtr;
        public MTLHeapDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLHeapDescriptor()
        {
            var cls = new ObjectiveCClass("MTLHeapDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);
        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);
        public MTLSparsePageSize SparsePageSize => (MTLSparsePageSize)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_sparsePageSize);
        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);
        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);
        public MTLHeapType Type => (MTLHeapType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_setSize = "setSize:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        private static readonly Selector sel_sparsePageSize = "sparsePageSize";
        private static readonly Selector sel_setSparsePageSize = "setSparsePageSize:";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_setHazardTrackingMode = "setHazardTrackingMode:";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_setType = "setType:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLHeap
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLHeap obj) => obj.NativePtr;
        public MTLHeap(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);
        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);
        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);
        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);
        public ulong UsedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usedSize);
        public ulong CurrentAllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_currentAllocatedSize);
        public MTLHeapType Type => (MTLHeapType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_usedSize = "usedSize";
        private static readonly Selector sel_currentAllocatedSize = "currentAllocatedSize";
        private static readonly Selector sel_maxAvailableSizeWithAlignment = "maxAvailableSizeWithAlignment:";
        private static readonly Selector sel_newBufferWithLengthoptions = "newBufferWithLength:options:";
        private static readonly Selector sel_newTextureWithDescriptor = "newTextureWithDescriptor:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_newBufferWithLengthoptionsoffset = "newBufferWithLength:options:offset:";
        private static readonly Selector sel_newTextureWithDescriptoroffset = "newTextureWithDescriptor:offset:";
        private static readonly Selector sel_newAccelerationStructureWithSize = "newAccelerationStructureWithSize:";
        private static readonly Selector sel_newAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";
        private static readonly Selector sel_newAccelerationStructureWithSizeoffset = "newAccelerationStructureWithSize:offset:";
        private static readonly Selector sel_newAccelerationStructureWithDescriptoroffset = "newAccelerationStructureWithDescriptor:offset:";
    }
}
