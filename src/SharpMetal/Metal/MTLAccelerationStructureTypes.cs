using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4BufferRange
    {
        public ulong bufferAddress;
        public ulong length;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAxisAlignedBoundingBox
    {
        public MTLPackedFloat3 min;
        public MTLPackedFloat3 max;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLComponentTransform
    {
        public MTLPackedFloat3 scale;
        public MTLPackedFloat3 shear;
        public MTLPackedFloat3 pivot;
        public MTLPackedFloatQuaternion rotation;
        public MTLPackedFloat3 translation;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPackedFloat3
    {
        public float x;
        public float y;
        public float z;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPackedFloat4x3
    {
        public MTLPackedFloat3 columns;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPackedFloatQuaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }
}
