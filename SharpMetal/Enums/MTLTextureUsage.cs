namespace SharpMetal
{
    public enum MTLTextureUsage: ulong
    {
        Unknown = 0x0000,
        ShaderRead = 0x0001,
        ShaderWrite = 0x0002,
        RenderTarget = 0x0004,
        PixelFormatView = 0x0010
    }
}