namespace SharpMetal.Enums
{
    public enum MTLRenderStages: ulong
    {
        MTLRenderStageVertex = (1UL << 0),
        MTLRenderStageFragment = (1UL << 1),
        MTLRenderStageTile = (1UL << 2),
        MTLRenderStageMesh = (1UL << 4),
        MTLRenderStageObject = (1UL << 3)
    }
}