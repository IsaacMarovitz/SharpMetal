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

        public ulong Size
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSize, value);
        }

        public MTLStorageMode StorageMode
        {
            get => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)value);
        }

        public MTLCPUCacheMode CpuCacheMode
        {
            get => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCpuCacheMode, (ulong)value);
        }

        public MTLSparsePageSize SparsePageSize
        {
            get => (MTLSparsePageSize)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_sparsePageSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSparsePageSize, (long)value);
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

        public MTLHeapType Type
        {
            get => (MTLHeapType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setType, (long)value);
        }

        public void SetSize(ulong size)
        {
            throw new NotImplementedException();
        }

        public void SetStorageMode(MTLStorageMode storageMode)
        {
            throw new NotImplementedException();
        }

        public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
        {
            throw new NotImplementedException();
        }

        public void SetSparsePageSize(MTLSparsePageSize sparsePageSize)
        {
            throw new NotImplementedException();
        }

        public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
        {
            throw new NotImplementedException();
        }

        public void SetResourceOptions(MTLResourceOptions resourceOptions)
        {
            throw new NotImplementedException();
        }

        public void SetType(MTLHeapType type)
        {
            throw new NotImplementedException();
        }

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

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);

        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);

        public ulong UsedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usedSize);

        public ulong CurrentAllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_currentAllocatedSize);

        public MTLHeapType Type => (MTLHeapType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        public void SetLabel(NSString label)
        {
            throw new NotImplementedException();
        }

        public ulong MaxAvailableSize(ulong alignment)
        {
            throw new NotImplementedException();
        }

        public MTLBuffer NewBuffer(ulong length, MTLResourceOptions options)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTexture(MTLTextureDescriptor desc)
        {
            throw new NotImplementedException();
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            throw new NotImplementedException();
        }

        public MTLBuffer NewBuffer(ulong length, MTLResourceOptions options, ulong offset)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTexture(MTLTextureDescriptor descriptor, ulong offset)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructure NewAccelerationStructure(ulong size)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructure NewAccelerationStructure(ulong size, ulong offset)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, ulong offset)
        {
            throw new NotImplementedException();
        }

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
