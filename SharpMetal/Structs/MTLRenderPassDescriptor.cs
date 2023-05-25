using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Structs
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassDescriptor
    {
        private static readonly ObjectiveCClass s_class = new ObjectiveCClass(nameof(MTLRenderPassDescriptor));
        public readonly IntPtr NativePtr;
        public static MTLRenderPassDescriptor New() => s_class.AllocInit<MTLRenderPassDescriptor>();
    }
}