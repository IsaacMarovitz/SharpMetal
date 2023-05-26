using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MTLTextureSwizzleChannels
    {
        public readonly IntPtr NativePtr;
        public MTLTextureSwizzleChannels(IntPtr ptr) => NativePtr = ptr;

        [LibraryImport("/System/Library/Frameworks/Metal.framework/Metal")]
        public static partial MTLTextureSwizzleChannels MTLTextureSwizzleChannelsMake(MTLTextureSwizzle r, MTLTextureSwizzle g, MTLTextureSwizzle b, MTLTextureSwizzle a);

        public MTLTextureSwizzle Red => (MTLTextureSwizzle)ObjectiveCRuntime.byte_objc_msgSend(NativePtr, sel_red);
        public MTLTextureSwizzle Green => (MTLTextureSwizzle)ObjectiveCRuntime.byte_objc_msgSend(NativePtr, sel_green);
        public MTLTextureSwizzle Blue => (MTLTextureSwizzle)ObjectiveCRuntime.byte_objc_msgSend(NativePtr, sel_blue);
        public MTLTextureSwizzle Alpha => (MTLTextureSwizzle)ObjectiveCRuntime.byte_objc_msgSend(NativePtr, sel_alpha);

        private static readonly Selector sel_red = "red";
        private static readonly Selector sel_green = "green";
        private static readonly Selector sel_blue = "blue";
        private static readonly Selector sel_alpha = "alpha";
    }
}