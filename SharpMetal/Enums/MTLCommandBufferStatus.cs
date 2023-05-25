namespace SharpMetal.Enums
{
    public enum MTLCommandBufferStatus: long
    {
        MTLCommandBufferStatusNotEnqueued = 0,
        MTLCommandBufferStatusEnqueued = 1,
        MTLCommandBufferStatusCommitted = 2,
        MTLCommandBufferStatusScheduled = 3,
        MTLCommandBufferStatusCompleted = 4,
        MTLCommandBufferStatusError = 5
    }
}