namespace SharpMetal
{
    public enum MTLAccelerationStructureRefitOptions: ulong
    {
        PerPrimitiveData = (1 << 1),
        VertexData = (1 << 0)
    }
}