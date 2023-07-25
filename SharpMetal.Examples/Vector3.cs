using System.Runtime.InteropServices;

namespace SharpMetal.Examples
{
    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
