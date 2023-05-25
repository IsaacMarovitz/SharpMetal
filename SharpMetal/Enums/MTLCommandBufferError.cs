namespace SharpMetal
{
    public enum MTLCommandBufferError: ulong
    {
        None = 0,
        Timeout = 2,
        PageFault = 3,
        NotPermitted = 7,
        OutOfMemory = 8,
        InvalidResource = 9,
        Memoryless = 10,
        DeviceRemoved = 11,
        StackOverflow = 12,
        AccessRevoked = 4,
        Internal = 1
    }
}