namespace SharpMetal
{
    public enum MTLPipelineOption: ulong
    {
        None = 0,
        ArgumentInfo = 1 << 0,
        BufferTypeInfo = 1 << 1,
        FailOnBinaryArchiveMiss = 1 << 2
    }
}