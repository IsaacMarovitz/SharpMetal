namespace SharpMetal
{
    public enum MTLBarrierScope: ulong
    {
        MTLBarrierScopeBuffers = 1 << 0,
        MTLBarrierScopeRenderTargets = 1 << 2,
        MTLBarrierScopeTextures = 1 << 1
    }
}