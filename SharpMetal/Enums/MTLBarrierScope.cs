namespace SharpMetal
{
    public enum MTLBarrierScope: ulong
    {
        Buffers = 1 << 0,
        RenderTargets = 1 << 2,
        Textures = 1 << 1
    }
}