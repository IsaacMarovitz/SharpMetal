namespace SharpMetal
{
    public enum MTLAccelerationStructureInstanceOptions: uint
    {
        None = 0,
        DisableTriangleCulling = (1 << 0),
        TriangleFrontFacingWindingCounterClockwise = (1 << 1),
        Opaque = (1 << 2),
        NonOpaque = (1 << 3)
    }
}