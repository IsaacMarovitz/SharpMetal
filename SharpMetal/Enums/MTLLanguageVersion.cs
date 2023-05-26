namespace SharpMetal
{
    public enum MTLLanguageVersion: ulong
    {
        Version1_1 = (1 << 16) + 1,
        Version1_2 = (1 << 16) + 2,
        Version2_0 = (2 << 16),
        Version2_1 = (2 << 16) + 1,
        Version2_2 = (2 << 16) + 2,
        Version2_3 = (2 << 16) + 3,
        Version2_4 = (2 << 16) + 4,
        Version3_0 = (3 << 16) + 0
    }
}