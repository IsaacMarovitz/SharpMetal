using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPackedFloat3
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPackedFloat3 obj) => obj.NativePtr;
        public MTLPackedFloat3(IntPtr ptr) => NativePtr = ptr;

        public float x;
        public float y;
        public float z;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPackedFloat4x3
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPackedFloat4x3 obj) => obj.NativePtr;
        public MTLPackedFloat4x3(IntPtr ptr) => NativePtr = ptr;

        public MTLPackedFloat3 columns;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAxisAlignedBoundingBox
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAxisAlignedBoundingBox obj) => obj.NativePtr;
        public MTLAxisAlignedBoundingBox(IntPtr ptr) => NativePtr = ptr;

        public MTLPackedFloat3 min;
        public MTLPackedFloat3 max;
    }
}
