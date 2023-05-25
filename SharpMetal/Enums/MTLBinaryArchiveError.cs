namespace SharpMetal.Enums
{
    public enum MTLBinaryArchiveError: ulong
    {
        MTLBinaryArchiveErrorNone = 0,
        MTLBinaryArchiveErrorInvalidFile = 1,
        MTLBinaryArchiveErrorCompilationFailure = 3,
        MTLBinaryArchiveErrorUnexpectedElement = 2,
        MTLBinaryArchiveErrorInternalError = 4
    }
}