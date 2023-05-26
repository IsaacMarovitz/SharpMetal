namespace SharpMetal
{
    public enum MTLAccelerationStructureUsage: ulong
    {
        None = 0,
        Refit = (1 << 0),
        PreferFastBuild = (1 << 1),
        ExtendedLimits = (1 << 2)
    }
}