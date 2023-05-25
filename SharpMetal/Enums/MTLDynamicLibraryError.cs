namespace SharpMetal.Enums
{
    public enum MTLDynamicLibraryError: long
    {
        MTLDynamicLibraryErrorNone = 0,
        MTLDynamicLibraryErrorInvalidFile = 1,
        MTLDynamicLibraryErrorCompilationFailure = 2,
        MTLDynamicLibraryErrorUnresolvedInstallName = 3,
        MTLDynamicLibraryErrorDependencyLoadFailure = 4,
        MTLDynamicLibraryErrorUnsupported = 5
    }
}