using System.Runtime.InteropServices;

namespace SharpMetal.Examples.Common
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

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

    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 64)]
    public struct Matrix4x4
    {
        public Vector4 a;
        public Vector4 b;
        public Vector4 c;
        public Vector4 d;

        public Matrix4x4(Vector4 a, Vector4 b, Vector4 c, Vector4 d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 48)]
    public struct Matrix3x3
    {
        public Vector3 a;
        public Vector3 b;
        public Vector3 c;

        public Matrix3x3(Vector3 a, Vector3 b, Vector3 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public static class Math
    {
        public static Vector3 Add(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Matrix4x4 MakeIdentity()
        {
            return new Matrix4x4
            (
                new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );
        }

        public static Matrix4x4 MakePerspective(float fovRadians, float aspect, float zNear, float zFar)
        {
            var ys = 1.0f / float.Tan(fovRadians * 0.5f);
            var xs = ys / aspect;
            var zs = zFar / (zNear - zFar);
            return new Matrix4x4
            (
                new Vector4(xs, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, ys, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, zs, zNear * zs),
                new Vector4(0.0f, 0.0f, -1.0f, 0.0f)
            );
        }

        public static Matrix4x4 MakeXRotate(float angleRadians)
        {
            var a = angleRadians;
            return new Matrix4x4
            (
                new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, float.Cos(a), float.Sin(a), 0.0f),
                new Vector4(0.0f, -float.Sin(a), float.Cos(a), 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );
        }

        public static Matrix4x4 MakeYRotate(float angleRadians)
        {
            var a = angleRadians;
            return new Matrix4x4
            (
                new Vector4(float.Cos(a), 0.0f, float.Sin(a), 0.0f),
                new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
                new Vector4(-float.Sin(a), 0.0f, float.Cos(a), 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );
        }

        public static Matrix4x4 MakeZRotate(float angleRadians)
        {
            var a = angleRadians;
            return new Matrix4x4
            (
                new Vector4(float.Cos(a), float.Sin(a), 0.0f, 0.0f),
                new Vector4(-float.Sin(a), float.Cos(a), 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );
        }
    }
}
