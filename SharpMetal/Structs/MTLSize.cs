using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MTLSize
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSize mtlSize) => mtlSize.NativePtr;
        public MTLSize(IntPtr ptr) => NativePtr = ptr;

        [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal")]
        public static partial MTLSize MTLSizeMake(ulong width, ulong height, ulong depth);

        public ulong Width => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_width);
        public ulong Height => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_height);
        public ulong Depth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depth);

        private static readonly Selector sel_width = "width";
        private static readonly Selector sel_height = "height";
        private static readonly Selector sel_depth = "depth";
    }
}