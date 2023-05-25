namespace SharpMetal.Enums
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