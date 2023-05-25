namespace SharpMetal
{
    public enum MTLDynamicLibraryError: ulong
    {
        None = 0,
        InvalidFile = 1,
        CompilationFailure = 2,
        UnresolvedInstallName = 3,
        DependencyLoadFailure = 4,
        Unsupported = 5
    }
}