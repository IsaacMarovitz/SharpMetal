using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.QuartzCore
{
    [SupportedOSPlatform("macos")]
    public class CAMetalDrawable : MTLDrawable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalDrawable obj) => obj.NativePtr;
        public CAMetalDrawable(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        public CAMetalLayer Layer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layer));

        public MTLTexture Texture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));

        private static readonly Selector sel_layer = "layer";
        private static readonly Selector sel_texture = "texture";
    }
}
