namespace SharpMetal
{
    public enum MTLCounterSamplingPoint: ulong
    {
        AtBlitBoundary,
        AtDispatchBoundary,
        AtDrawBoundary,
        AtStageBoundary,
        AtTileDispatchBoundary
    }
}