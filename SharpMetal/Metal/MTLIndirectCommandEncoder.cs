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
            objc_msgSend(NativePtr, , pipelineState);
        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetFragmentBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, ulong instanceCount, ulong baseInstance, MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            objc_msgSend(NativePtr, , numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, instanceCount, baseInstance, buffer, offset, instanceStride);
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, ulong instanceCount, ulong baseInstance, MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            objc_msgSend(NativePtr, , numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, instanceCount, baseInstance, buffer, offset, instanceStride);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount, ulong baseInstance)
        {
            objc_msgSend(NativePtr, , primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount, long baseVertex, ulong baseInstance)
        {
            objc_msgSend(NativePtr, , primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset, instanceCount, baseVertex, baseInstance);
        }

        public void Reset()
        {
            objc_msgSend(NativePtr, , );
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
            objc_msgSend(NativePtr, , pipelineState);
        }

        public void SetKernelBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
        {
            objc_msgSend(NativePtr, , threadgroupsPerGrid, threadsPerThreadgroup);
        }

        public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
        {
            objc_msgSend(NativePtr, , threadsPerGrid, threadsPerThreadgroup);
        }

        public void SetBarrier()
        {
            objc_msgSend(NativePtr, , );
        }

        public void ClearBarrier()
        {
            objc_msgSend(NativePtr, , );
        }

        public void SetImageblockWidth(ulong width, ulong height)
        {
            objc_msgSend(NativePtr, , width, height);
        }

        public void Reset()
        {
            objc_msgSend(NativePtr, , );
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , length, index);
        }

        public void SetStageInRegion(MTLRegion region)
        {
            objc_msgSend(NativePtr, , region);
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
