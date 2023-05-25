namespace SharpMetal
{
    [Flags]
    public enum MTLColorWriteMask: ulong
    {
        MTLColorWriteMaskNone = 0,
        MTLColorWriteMaskRed = 0x1 << 3,
        MTLColorWriteMaskGreen = 0x1 << 2,
        MTLColorWriteMaskBlue = 0x1 << 1,
        MTLColorWriteMaskAlpha = 0x1 << 0,
        MTLColorWriteMaskAll = 0xf
    }
}