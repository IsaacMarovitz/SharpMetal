namespace SharpMetal
{
    public enum MTLStoreAction: ulong
    {
        MTLStoreActionDontCare = 0,
        MTLStoreActionStore = 1,
        MTLStoreActionMultisampleResolve = 2,
        MTLStoreActionStoreAndMultisampleResolve = 3,
        MTLStoreActionUnknown = 4,
        MTLStoreActionCustomSampleDepthStore = 5
    }
}