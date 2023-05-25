namespace SharpMetal
{
    public enum MTLVertexStepFunction: ulong
    {
        MTLVertexStepFunctionConstant = 0,
        MTLVertexStepFunctionPerVertex = 1,
        MTLVertexStepFunctionPerInstance = 2,
        MTLVertexStepFunctionPerPatch = 3,
        MTLVertexStepFunctionPerPatchControlPoint = 4
    }
}