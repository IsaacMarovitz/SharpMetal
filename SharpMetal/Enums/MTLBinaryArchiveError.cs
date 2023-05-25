namespace SharpMetal
{
    public enum MTLBinaryArchiveError: ulong
    {
        None = 0,
        InvalidFile = 1,
        CompilationFailure = 3,
        UnexpectedElement = 2,
        InternalError = 4
    }
}