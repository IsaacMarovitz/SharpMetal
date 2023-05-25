namespace SharpMetal
{
    public enum MTLDeviceLocation: ulong
    {
        BuiltIn = 0,
        Slot = 1,
        External = 2,
        Unspecified = ulong.MaxValue
    }
}