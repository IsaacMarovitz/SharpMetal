using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4MeshRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MeshRenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4MeshRenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4MeshRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4MeshRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4MeshRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTL4AlphaToCoverageState AlphaToCoverageState

        // missing MTL4AlphaToOneState AlphaToOneState

        // missing MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState

        // missing MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments

        // missing MTL4FunctionDescriptor FragmentFunctionDescriptor

        // missing MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor

        // missing bool IsRasterizationEnabled

        // missing NSString Label

        // missing ulong MaxTotalThreadgroupsPerMeshGrid

        // missing ulong MaxTotalThreadsPerMeshThreadgroup

        // missing ulong MaxTotalThreadsPerObjectThreadgroup

        // missing ulong MaxVertexAmplificationCount

        // missing MTL4FunctionDescriptor MeshFunctionDescriptor

        // missing MTL4StaticLinkingDescriptor MeshStaticLinkingDescriptor

        // missing bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth

        // missing MTL4FunctionDescriptor ObjectFunctionDescriptor

        // missing MTL4StaticLinkingDescriptor ObjectStaticLinkingDescriptor

        // missing bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth

        // missing MTL4PipelineOptions Options

        // missing ulong PayloadMemoryLength

        // missing bool RasterizationEnabled

        // missing ulong RasterSampleCount

        // missing MTLSize RequiredThreadsPerMeshThreadgroup

        // missing MTLSize RequiredThreadsPerObjectThreadgroup

        // missing bool SupportFragmentBinaryLinking

        // missing MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers

        // missing bool SupportMeshBinaryLinking

        // missing bool SupportObjectBinaryLinking
        private static readonly Selector sel_release = "release";
    }
}
