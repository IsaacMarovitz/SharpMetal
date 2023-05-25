namespace SharpMetal
{
    public enum MTLCounterSamplingPoint: ulong
    {
        MTLCounterSamplingPointAtBlitBoundary,
        MTLCounterSamplingPointAtDispatchBoundary,
        MTLCounterSamplingPointAtDrawBoundary,
        MTLCounterSamplingPointAtStageBoundary,
        MTLCounterSamplingPointAtTileDispatchBoundary
    }
}