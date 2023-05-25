namespace SharpMetal
{
    [Flags]
    public enum MTLColorWriteMask: ulong
    {
        None = 0,
        Red = 0x1 << 3,
        Green = 0x1 << 2,
        Blue = 0x1 << 1,
        Alpha = 0x1 << 0,
        All = 0xf
    }
}