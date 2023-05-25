namespace SharpMetal.Enums
{
    public enum MTLCommandBufferErrorOption: long
    {
        MTLCommandBufferErrorOptionNone = 0,
        MTLCommandBufferErrorOptionEncoderExecutionStatus = 1 << 0
    }
}