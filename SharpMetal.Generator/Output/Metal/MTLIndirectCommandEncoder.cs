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

        public void SetRenderPipelineState(MTLRenderPipelineState pipelineState) {

        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong index) {

        }

        public void SetFragmentBuffer(MTLBuffer buffer, ulong offset, ulong index) {

        }

        public void DrawPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, ulong instanceCount, ulong baseInstance, MTLBuffer buffer, ulong offset, ulong instanceStride) {

        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, ulong instanceCount, ulong baseInstance, MTLBuffer buffer, ulong offset, ulong instanceStride) {

        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount, ulong baseInstance) {

        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount, long baseVertex, ulong baseInstance) {

        }

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

        public void SetComputePipelineState(MTLComputePipelineState pipelineState) {

        }

        public void SetKernelBuffer(MTLBuffer buffer, ulong offset, ulong index) {

        }

        public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup) {

        }

        public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup) {

        }

        public void SetImageblockWidth(ulong width, ulong height) {

        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index) {

        }

        public void SetStageInRegion(MTLRegion region) {

        }

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
