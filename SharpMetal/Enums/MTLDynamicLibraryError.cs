namespace SharpMetal
{
    public enum MTLDynamicLibraryError: ulong
    {
        MTLDynamicLibraryErrorNone = 0,
        MTLDynamicLibraryErrorInvalidFile = 1,
        MTLDynamicLibraryErrorCompilationFailure = 2,
        MTLDynamicLibraryErrorUnresolvedInstallName = 3,
        MTLDynamicLibraryErrorDependencyLoadFailure = 4,
        MTLDynamicLibraryErrorUnsupported = 5
    }
}