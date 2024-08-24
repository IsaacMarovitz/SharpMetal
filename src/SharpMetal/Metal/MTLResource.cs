using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLPurgeableState : ulong
    {
        KeepCurrent = 1,
        NonVolatile = 2,
        Volatile = 3,
        Empty = 4,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLCPUCacheMode : ulong
    {
        DefaultCache = 0,
        WriteCombined = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLStorageMode : ulong
    {
        Shared = 0,
        Managed = 1,
        Private = 2,
        Memoryless = 3,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLHazardTrackingMode : ulong
    {
        Default = 0,
        Untracked = 1,
        Tracked = 2,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLResourceOptions : ulong
    {
        ResourceCPUCacheModeDefaultCache = 0,
        ResourceCPUCacheModeWriteCombined = 1,
        ResourceStorageModeShared = 0,
        ResourceStorageModeManaged = 16,
        ResourceStorageModePrivate = 32,
        ResourceStorageModeMemoryless = 48,
        ResourceHazardTrackingModeDefault = 0,
        ResourceHazardTrackingModeUntracked = 256,
        ResourceHazardTrackingModeTracked = 512,
        CPUCacheModeDefault = 0,
        CPUCacheModeWriteCombined = 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLResource : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResource obj) => obj.NativePtr;
        public MTLResource(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);

        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);

        public MTLHeap Heap => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_heap));

        public ulong HeapOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_heapOffset);

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public bool IsAliasable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAliasable);

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        public void MakeAliasable()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_makeAliasable);
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_heap = "heap";
        private static readonly Selector sel_heapOffset = "heapOffset";
        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_makeAliasable = "makeAliasable";
        private static readonly Selector sel_isAliasable = "isAliasable";
        private static readonly Selector sel_release = "release";
    }
}
