namespace SharpMetal
{
    public enum MTLCommandBufferStatus: ulong
    {
        MTLCommandBufferStatusNotEnqueued = 0,
        MTLCommandBufferStatusEnqueued = 1,
        MTLCommandBufferStatusCommitted = 2,
        MTLCommandBufferStatusScheduled = 3,
        MTLCommandBufferStatusCompleted = 4,
        MTLCommandBufferStatusError = 5
    }
}