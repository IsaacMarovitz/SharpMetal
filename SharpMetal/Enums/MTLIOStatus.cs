namespace SharpMetal
{
    public enum MTLIOStatus: long
    {
        Pending = 0,
        Complete = 3,
        Cancelled = 1,
        Error = 2
    }
}