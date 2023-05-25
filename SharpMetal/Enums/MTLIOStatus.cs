namespace SharpMetal.Enums
{
    public enum MTLIOStatus: long
    {
        MTLIOStatusPending = 0,
        MTLIOStatusComplete = 3,
        MTLIOStatusCancelled = 1,
        MTLIOStatusError = 2
    }
}