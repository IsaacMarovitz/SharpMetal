using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MTLOrigin
    {
        public readonly IntPtr NativePtr;
        public MTLOrigin(IntPtr ptr) => NativePtr = ptr;

        [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal")]
        public static partial MTLOrigin MTLOriginMake(ulong x, ulong y, ulong z);

        public ulong X => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_x);
        public ulong Y => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_y);
        public ulong Z => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_z);

        private static readonly Selector sel_x = "x";
        private static readonly Selector sel_y = "y";
        private static readonly Selector sel_z = "z";
    }
}