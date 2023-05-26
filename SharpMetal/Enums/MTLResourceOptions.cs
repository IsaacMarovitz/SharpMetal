namespace SharpMetal
{
    public enum MTLResourceOptions: ulong
    {
        CPUCacheModeDefaultCache = MTLCPUCacheMode.DefaultCache << 0,
        CPUCacheModeWriteCombined = MTLCPUCacheMode.WriteCombined << 0,

        StorageModeShared = MTLStorageMode.Shared << 0,
        StorageModeManaged = MTLStorageMode.Managed << 0,
        StorageModePrivate = MTLStorageMode.Private << 0,
        StorageModeMemoryless = MTLStorageMode.Memoryless << 0,

        HazardTrackingModeDefault = MTLHazardTrackingMode.Default << 0,
        HazardTrackingModeTracked = MTLHazardTrackingMode.Tracked << 0,
        HazardTrackingModeUntracked = MTLHazardTrackingMode.Untracked << 0
    }
}