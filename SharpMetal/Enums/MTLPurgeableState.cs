namespace SharpMetal
{
    public enum MTLPurgeableState: ulong
    {
        KeepCurrent = 1,
        NonVolatile = 2,
        Volatile = 3,
        Empty = 4
    }
}