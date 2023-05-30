using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLIndirectRenderCommand
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectRenderCommand obj) => obj.NativePtr;
        public MTLIndirectRenderCommand(IntPtr ptr) => NativePtr = ptr;

        private static readonly Selector sel_setRenderPipelineState = "setRenderPipelineState:";
        private static readonly Selector sel_setVertexBufferoffsetatIndex = "setVertexBuffer:offset:atIndex:";
        private static readonly Selector sel_setFragmentBufferoffsetatIndex = "setFragmentBuffer:offset:atIndex:";
        private static readonly Selector sel_drawPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetinstanceCountbaseInstancetessellationFactorBuffertessellationFactorBufferOffsettessellationFactorBufferInstanceStride = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:";
        private static readonly Selector sel_drawIndexedPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetinstanceCountbaseInstancetessellationFactorBuffertessellationFactorBufferOffsettessellationFactorBufferInstanceStride = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCountbaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";
        private static readonly Selector sel_reset = "reset";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIndirectComputeCommand
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectComputeCommand obj) => obj.NativePtr;
        public MTLIndirectComputeCommand(IntPtr ptr) => NativePtr = ptr;

        private static readonly Selector sel_setComputePipelineState = "setComputePipelineState:";
        private static readonly Selector sel_setKernelBufferoffsetatIndex = "setKernelBuffer:offset:atIndex:";
        private static readonly Selector sel_concurrentDispatchThreadgroupsthreadsPerThreadgroup = "concurrentDispatchThreadgroups:threadsPerThreadgroup:";
        private static readonly Selector sel_concurrentDispatchThreadsthreadsPerThreadgroup = "concurrentDispatchThreads:threadsPerThreadgroup:";
        private static readonly Selector sel_setBarrier = "setBarrier";
        private static readonly Selector sel_clearBarrier = "clearBarrier";
        private static readonly Selector sel_setImageblockWidthheight = "setImageblockWidth:height:";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setThreadgroupMemoryLengthatIndex = "setThreadgroupMemoryLength:atIndex:";
        private static readonly Selector sel_setStageInRegion = "setStageInRegion:";
    }
}
