namespace SharpMetal
{
    public enum MTLCommandBufferStatus: ulong
    {
        NotEnqueued = 0,
        Enqueued = 1,
        Committed = 2,
        Scheduled = 3,
        Completed = 4,
        Error = 5
    }
}