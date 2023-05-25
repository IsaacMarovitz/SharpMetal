namespace SharpMetal.Enums
{
    public enum MTLDeviceLocation: long
    {
        MTLDeviceLocationBuiltIn = 0,
        MTLDeviceLocationSlot = 1,
        MTLDeviceLocationExternal = 2,
        MTLDeviceLocationUnspecified = long.MaxValue
    }
}