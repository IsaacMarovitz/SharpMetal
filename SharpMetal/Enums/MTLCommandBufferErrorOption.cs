namespace SharpMetal
{
    public enum MTLCommandBufferErrorOption: ulong
    {
        MTLCommandBufferErrorOptionNone = 0,
        MTLCommandBufferErrorOptionEncoderExecutionStatus = 1 << 0
    }
}