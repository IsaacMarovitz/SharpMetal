using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public interface MTLRenderPassAttachmentDescriptor
    {
        IntPtr NativePtr { get; }

        public MTLTexture Texture { get; set; }

        public ulong Level { get; set; }

        public ulong Slice { get; set; }

        public ulong DepthPlane { get; set; }

        public MTLLoadAction LoadAction { get; set; }

        public MTLStoreAction StoreAction { get; set; }

        public MTLStoreActionOptions StoreActionOptions { get; set; }

        public IntPtr ResolveTexture { get; set; }

        public ulong ResolveLevel { get; set; }

        public ulong ResolveSlice { get; set; }

        public ulong ResolveDepthPlane { get; set; }
    }
}