using System.Runtime.Versioning;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public class CAMetalDrawable : MTLDrawable
    {
        public new IntPtr NativePtr;

        public CAMetalDrawable(IntPtr ptr) : base(ptr)
        {
            NativePtr = ptr;
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveC.IntPtr_objc_msgSend(NativePtr, "texture"));
        }
    }
}
