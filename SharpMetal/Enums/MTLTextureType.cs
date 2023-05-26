namespace SharpMetal
{
    public enum MTLTextureType: ulong
    {
        Type1D = 0,
        Type1DArray = 1,
        Type2D = 2,
        Type2DArray = 3,
        Type2DMultisample = 4,
        TypeCube = 5,
        TypeCubeArray = 6,
        Type3D = 7,
        Type2DMultisampleArray = 8,
        TypeTextureBuffer = 9
    }
}