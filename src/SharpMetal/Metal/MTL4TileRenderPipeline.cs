using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4TileRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4TileRenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4TileRenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4TileRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4TileRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4TileRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments

        // missing NSString Label

        // missing ulong MaxTotalThreadsPerThreadgroup

        // missing MTL4PipelineOptions Options

        // missing ulong RasterSampleCount

        // missing MTLSize RequiredThreadsPerThreadgroup

        // missing MTL4StaticLinkingDescriptor StaticLinkingDescriptor

        // missing bool SupportBinaryLinking

        // missing bool ThreadgroupSizeMatchesTileSize

        // missing MTL4FunctionDescriptor TileFunctionDescriptor
        private static readonly Selector sel_release = "release";
    }
}
