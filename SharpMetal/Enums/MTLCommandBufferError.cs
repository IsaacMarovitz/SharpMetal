namespace SharpMetal.Enums
{
    public enum MTLCommandBufferError: long
    {
        MTLCommandBufferErrorNone = 0,
        MTLCommandBufferErrorTimeout = 2,
        MTLCommandBufferErrorPageFault = 3,
        MTLCommandBufferErrorNotPermitted = 7,
        MTLCommandBufferErrorOutOfMemory = 8,
        MTLCommandBufferErrorInvalidResource = 9,
        MTLCommandBufferErrorMemoryless = 10,
        MTLCommandBufferErrorDeviceRemoved = 11,
        MTLCommandBufferErrorStackOverflow = 12,
        MTLCommandBufferErrorAccessRevoked = 4,
        MTLCommandBufferErrorInternal = 1
    }
}