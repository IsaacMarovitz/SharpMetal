using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MTLRegion
    {
        public readonly IntPtr NativePtr;
        public MTLRegion(IntPtr ptr) => NativePtr = ptr;

        [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal")]
        public static partial MTLRegion MTLRegionMake1D(ulong x, ulong width);

        [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal")]
        public static partial MTLRegion MTLRegionMake2D(ulong x, ulong y, ulong width, ulong height);

        [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal")]
        public static partial MTLRegion MTLRegionMake3D(ulong x, ulong y, ulong z, ulong width, ulong height, ulong depth);

        public MTLOrigin Origin => ObjectiveCRuntime.mtlOrigin_objc_msgSend(NativePtr, sel_origin);
        public MTLSize Size => ObjectiveCRuntime.mtlSize_objc_msgSend(NativePtr, sel_origin);

        private static readonly Selector sel_origin = "origin";
        private static readonly Selector sel_size = "size";
    }
}