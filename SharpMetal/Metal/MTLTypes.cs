using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLOrigin
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLOrigin obj) => obj.NativePtr;
        public MTLOrigin(IntPtr ptr) => NativePtr = ptr;

        public ulong x;

        public ulong y;

        public ulong z;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSize
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSize obj) => obj.NativePtr;
        public MTLSize(IntPtr ptr) => NativePtr = ptr;

        public ulong width;

        public ulong height;

        public ulong depth;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRegion
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRegion obj) => obj.NativePtr;
        public MTLRegion(IntPtr ptr) => NativePtr = ptr;

        public MTLOrigin origin;

        public MTLSize size;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSamplePosition
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplePosition obj) => obj.NativePtr;
        public MTLSamplePosition(IntPtr ptr) => NativePtr = ptr;

        public float x;

        public float y;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLResourceID
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceID obj) => obj.NativePtr;
        public MTLResourceID(IntPtr ptr) => NativePtr = ptr;

        public ulong _impl;
    }
}
