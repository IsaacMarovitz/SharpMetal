using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLIndirectRenderCommand
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectRenderCommand obj) => obj.NativePtr;
        public MTLIndirectRenderCommand(IntPtr ptr) => NativePtr = ptr;

        public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, ulong instanceCount, ulong baseInstance, MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, ulong instanceCount, ulong baseInstance, MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            throw new NotImplementedException();
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount, ulong baseInstance)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount, long baseVertex, ulong baseInstance)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
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
    public class MTLIndirectComputeCommand
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectComputeCommand obj) => obj.NativePtr;
        public MTLIndirectComputeCommand(IntPtr ptr) => NativePtr = ptr;

        public void SetComputePipelineState(MTLComputePipelineState pipelineState)
        {
            throw new NotImplementedException();
        }

        public void SetKernelBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void SetBarrier()
        {
            throw new NotImplementedException();
        }

        public void ClearBarrier()
        {
            throw new NotImplementedException();
        }

        public void SetImageblockWidth(ulong width, ulong height)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetStageInRegion(MTLRegion region)
        {
            throw new NotImplementedException();
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
