namespace SharpMetal
{
    public enum MTLCommandBufferErrorOption: ulong
    {
        None = 0,
        EncoderExecutionStatus = 1 << 0
    }
}