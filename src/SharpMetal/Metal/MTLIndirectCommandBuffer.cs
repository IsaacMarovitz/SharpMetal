using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLIndirectCommandType : ulong
    {
        Draw = 1,
        DrawIndexed = 2,
        DrawPatches = 4,
        DrawIndexedPatches = 8,
        ConcurrentDispatch = 32,
        ConcurrentDispatchThreads = 64,
        DrawMeshThreadgroups = 128,
        DrawMeshThreads = 256,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLIndirectCommandBufferExecutionRange
    {
        public uint location;
        public uint length;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIndirectCommandBuffer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBuffer obj) => obj.NativePtr;
        public static implicit operator MTLResource(MTLIndirectCommandBuffer obj) => new(obj.NativePtr);
        public MTLIndirectCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

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

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public MTLIndirectComputeCommand IndirectComputeCommand(ulong commandIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indirectComputeCommandAtIndex, commandIndex));
        }

        public MTLIndirectRenderCommand IndirectRenderCommand(ulong commandIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indirectRenderCommandAtIndex, commandIndex));
        }

        public void MakeAliasable()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_makeAliasable);
        }

        public void Reset(NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resetWithRange, range);
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_heap = "heap";
        private static readonly Selector sel_heapOffset = "heapOffset";
        private static readonly Selector sel_indirectComputeCommandAtIndex = "indirectComputeCommandAtIndex:";
        private static readonly Selector sel_indirectRenderCommandAtIndex = "indirectRenderCommandAtIndex:";
        private static readonly Selector sel_isAliasable = "isAliasable";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_makeAliasable = "makeAliasable";
        private static readonly Selector sel_resetWithRange = "resetWithRange:";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIndirectCommandBufferDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBufferDescriptor obj) => obj.NativePtr;
        public MTLIndirectCommandBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIndirectCommandBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIndirectCommandBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLIndirectCommandType CommandTypes
        {
            get => (MTLIndirectCommandType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_commandTypes);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCommandTypes, (ulong)value);
        }

        public bool InheritBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_inheritBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInheritBuffers, value);
        }

        public bool InheritPipelineState
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_inheritPipelineState);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInheritPipelineState, value);
        }

        public ulong MaxFragmentBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxFragmentBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxFragmentBufferBindCount, value);
        }

        public ulong MaxKernelBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxKernelBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxKernelBufferBindCount, value);
        }

        public ulong MaxKernelThreadgroupMemoryBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxKernelThreadgroupMemoryBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxKernelThreadgroupMemoryBindCount, value);
        }

        public ulong MaxMeshBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxMeshBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxMeshBufferBindCount, value);
        }

        public ulong MaxObjectBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxObjectBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxObjectBufferBindCount, value);
        }

        public ulong MaxObjectThreadgroupMemoryBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxObjectThreadgroupMemoryBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxObjectThreadgroupMemoryBindCount, value);
        }

        public ulong MaxVertexBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexBufferBindCount, value);
        }

        public bool SupportDynamicAttributeStride
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportDynamicAttributeStride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportDynamicAttributeStride, value);
        }

        public bool SupportRayTracing
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportRayTracing);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportRayTracing, value);
        }

        private static readonly Selector sel_commandTypes = "commandTypes";
        private static readonly Selector sel_inheritBuffers = "inheritBuffers";
        private static readonly Selector sel_inheritPipelineState = "inheritPipelineState";
        private static readonly Selector sel_maxFragmentBufferBindCount = "maxFragmentBufferBindCount";
        private static readonly Selector sel_maxKernelBufferBindCount = "maxKernelBufferBindCount";
        private static readonly Selector sel_maxKernelThreadgroupMemoryBindCount = "maxKernelThreadgroupMemoryBindCount";
        private static readonly Selector sel_maxMeshBufferBindCount = "maxMeshBufferBindCount";
        private static readonly Selector sel_maxObjectBufferBindCount = "maxObjectBufferBindCount";
        private static readonly Selector sel_maxObjectThreadgroupMemoryBindCount = "maxObjectThreadgroupMemoryBindCount";
        private static readonly Selector sel_maxVertexBufferBindCount = "maxVertexBufferBindCount";
        private static readonly Selector sel_setCommandTypes = "setCommandTypes:";
        private static readonly Selector sel_setInheritBuffers = "setInheritBuffers:";
        private static readonly Selector sel_setInheritPipelineState = "setInheritPipelineState:";
        private static readonly Selector sel_setMaxFragmentBufferBindCount = "setMaxFragmentBufferBindCount:";
        private static readonly Selector sel_setMaxKernelBufferBindCount = "setMaxKernelBufferBindCount:";
        private static readonly Selector sel_setMaxKernelThreadgroupMemoryBindCount = "setMaxKernelThreadgroupMemoryBindCount:";
        private static readonly Selector sel_setMaxMeshBufferBindCount = "setMaxMeshBufferBindCount:";
        private static readonly Selector sel_setMaxObjectBufferBindCount = "setMaxObjectBufferBindCount:";
        private static readonly Selector sel_setMaxObjectThreadgroupMemoryBindCount = "setMaxObjectThreadgroupMemoryBindCount:";
        private static readonly Selector sel_setMaxVertexBufferBindCount = "setMaxVertexBufferBindCount:";
        private static readonly Selector sel_setSupportDynamicAttributeStride = "setSupportDynamicAttributeStride:";
        private static readonly Selector sel_setSupportRayTracing = "setSupportRayTracing:";
        private static readonly Selector sel_supportDynamicAttributeStride = "supportDynamicAttributeStride";
        private static readonly Selector sel_supportRayTracing = "supportRayTracing";
        private static readonly Selector sel_release = "release";
    }
}
