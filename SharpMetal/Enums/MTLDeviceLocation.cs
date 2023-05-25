namespace SharpMetal
{
    public enum MTLDeviceLocation: ulong
    {
        MTLDeviceLocationBuiltIn = 0,
        MTLDeviceLocationSlot = 1,
        MTLDeviceLocationExternal = 2,
        MTLDeviceLocationUnspecified = ulong.MaxValue
    }
}