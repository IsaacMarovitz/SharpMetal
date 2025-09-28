using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4RenderCommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderCommandEncoder obj) => obj.NativePtr;
        public static implicit operator MTL4CommandEncoder(MTL4RenderCommandEncoder obj) => new(obj.NativePtr);
        public MTL4RenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTL4CommandBuffer CommandBuffer

        // missing NSString Label

        // missing ulong TileHeight

        // missing ulong TileWidth
        private static readonly Selector sel_release = "release";
    }
}
