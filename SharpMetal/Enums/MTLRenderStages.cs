namespace SharpMetal
{
    public enum MTLRenderStages: ulong
    {
        Vertex = (1UL << 0),
        Fragment = (1UL << 1),
        Tile = (1UL << 2),
        Mesh = (1UL << 4),
        Object = (1UL << 3)
    }
}