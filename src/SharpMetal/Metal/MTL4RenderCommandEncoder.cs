using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4RenderEncoderOptions : ulong
    {
        None = 0,
        Suspending = 1,
        Resuming = 1 << 1,
    }

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

        public MTL4CommandBuffer CommandBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBuffer));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong TileHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileHeight);

        public ulong TileWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileWidth);

        public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterEncoderStagesbeforeEncoderStagesvisibilityOptions, (ulong)afterEncoderStages, (ulong)beforeEncoderStages, (ulong)visibilityOptions);
        }

        public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterQueueStagesbeforeStagesvisibilityOptions, (ulong)afterQueueStages, (ulong)beforeStages, (ulong)visibilityOptions);
        }

        public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterStagesbeforeQueueStagesvisibilityOptions, (ulong)afterStages, (ulong)beforeQueueStages, (ulong)visibilityOptions);
        }

        public void DispatchThreadsPerTile(MTLSize threadsPerTile)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadsPerTile, threadsPerTile);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, ulong indexBuffer, ulong indexBufferLength, ulong indirectBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexTypeindexBufferindexBufferLengthindirectBuffer, (ulong)primitiveType, (ulong)indexType, indexBuffer, indexBufferLength, indirectBuffer);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, ulong indexBuffer, ulong indexBufferLength, ulong instanceCount, long baseVertex, ulong baseInstance)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCountbaseVertexbaseInstance, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferLength, instanceCount, baseVertex, baseInstance);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, ulong indexBuffer, ulong indexBufferLength, ulong instanceCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCount, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferLength, instanceCount);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, ulong indexBuffer, ulong indexBufferLength)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLength, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferLength);
        }

        public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawMeshThreadgroups(ulong indirectBuffer, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawMeshThreadgroupsWithIndirectBufferthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, indirectBuffer, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawMeshThreadsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesvertexStartvertexCount, (ulong)primitiveType, vertexStart, vertexCount);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesvertexStartvertexCountinstanceCount, (ulong)primitiveType, vertexStart, vertexCount, instanceCount);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount, ulong baseInstance)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesvertexStartvertexCountinstanceCountbaseInstance, (ulong)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong indirectBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesindirectBuffer, (ulong)primitiveType, indirectBuffer);
        }

        public void EndEncoding()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endEncoding);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferwithRange, indirectCommandBuffer, executionRange);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, ulong indirectRangeBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferindirectBuffer, indirectCommandBuffer, indirectRangeBuffer);
        }

        public void InsertDebugSignpost(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_insertDebugSignpost, nsString);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void SetArgumentTable(MTL4ArgumentTable argumentTable, MTLRenderStages stages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArgumentTableatStages, argumentTable, (ulong)stages);
        }

        public void SetBlendColor(float red, float green, float blue, float alpha)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBlendColorRedgreenbluealpha, red, green, blue, alpha);
        }

        public void SetColorAttachmentMap(MTLLogicalToPhysicalColorAttachmentMap mapping)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorAttachmentMap, mapping);
        }

        public void SetColorStoreAction(MTLStoreAction storeAction, ulong colorAttachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorStoreActionatIndex, (ulong)storeAction, colorAttachmentIndex);
        }

        public void SetCullMode(MTLCullMode cullMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCullMode, (ulong)cullMode);
        }

        public void SetDepthBias(float depthBias, float slopeScale, float clamp)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthBiasslopeScaleclamp, depthBias, slopeScale, clamp);
        }

        public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthClipMode, (ulong)depthClipMode);
        }

        public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStencilState, depthStencilState);
        }

        public void SetDepthStoreAction(MTLStoreAction storeAction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStoreAction, (ulong)storeAction);
        }

        public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFrontFacingWinding, (ulong)frontFacingWinding);
        }

        public void SetObjectThreadgroupMemoryLength(ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectThreadgroupMemoryLengthatIndex, length, index);
        }

        public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderPipelineState, pipelineState);
        }

        public void SetScissorRect(MTLScissorRect rect)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScissorRect, rect);
        }

        public void SetScissorRects(MTLScissorRect scissorRects, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScissorRectscount, scissorRects, count);
        }

        public void SetStencilReferenceValue(uint referenceValue)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilReferenceValue, referenceValue);
        }

        public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilFrontReferenceValuebackReferenceValue, frontReferenceValue, backReferenceValue);
        }

        public void SetStencilStoreAction(MTLStoreAction storeAction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilStoreAction, (ulong)storeAction);
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLengthoffsetatIndex, length, offset, index);
        }

        public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleFillMode, (ulong)fillMode);
        }

        public void SetVertexAmplificationCount(ulong count, MTLVertexAmplificationViewMapping viewMappings)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexAmplificationCountviewMappings, count, viewMappings);
        }

        public void SetViewport(MTLViewport viewport)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setViewport, viewport);
        }

        public void SetViewports(MTLViewport viewports, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setViewportscount, viewports, count);
        }

        public void SetVisibilityResultMode(MTLVisibilityResultMode mode, ulong offset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibilityResultModeoffset, (ulong)mode, offset);
        }

        public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFenceafterEncoderStages, fence, (ulong)afterEncoderStages);
        }

        public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFencebeforeEncoderStages, fence, (ulong)beforeEncoderStages);
        }

        public void WriteTimestamp(MTL4TimestampGranularity granularity, MTLRenderStages stage, MTL4CounterHeap counterHeap, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_writeTimestampWithGranularityafterStageintoHeapatIndex, (long)granularity, (ulong)stage, counterHeap, index);
        }

        private static readonly Selector sel_barrierAfterEncoderStagesbeforeEncoderStagesvisibilityOptions = "barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:";
        private static readonly Selector sel_barrierAfterQueueStagesbeforeStagesvisibilityOptions = "barrierAfterQueueStages:beforeStages:visibilityOptions:";
        private static readonly Selector sel_barrierAfterStagesbeforeQueueStagesvisibilityOptions = "barrierAfterStages:beforeQueueStages:visibilityOptions:";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_dispatchThreadsPerTile = "dispatchThreadsPerTile:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLength = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferLengthinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferLength:instanceCount:baseVertex:baseInstance:";
        private static readonly Selector sel_drawIndexedPrimitivesindexTypeindexBufferindexBufferLengthindirectBuffer = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferLength:indirectBuffer:";
        private static readonly Selector sel_drawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawMeshThreadgroupsWithIndirectBufferthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawMeshThreadsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawPrimitivesindirectBuffer = "drawPrimitives:indirectBuffer:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCount = "drawPrimitives:vertexStart:vertexCount:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCount = "drawPrimitives:vertexStart:vertexCount:instanceCount:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCountbaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_executeCommandsInBufferindirectBuffer = "executeCommandsInBuffer:indirectBuffer:";
        private static readonly Selector sel_executeCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";
        private static readonly Selector sel_insertDebugSignpost = "insertDebugSignpost:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_setArgumentTableatStages = "setArgumentTable:atStages:";
        private static readonly Selector sel_setBlendColorRedgreenbluealpha = "setBlendColorRed:green:blue:alpha:";
        private static readonly Selector sel_setColorAttachmentMap = "setColorAttachmentMap:";
        private static readonly Selector sel_setColorStoreActionatIndex = "setColorStoreAction:atIndex:";
        private static readonly Selector sel_setCullMode = "setCullMode:";
        private static readonly Selector sel_setDepthBiasslopeScaleclamp = "setDepthBias:slopeScale:clamp:";
        private static readonly Selector sel_setDepthClipMode = "setDepthClipMode:";
        private static readonly Selector sel_setDepthStencilState = "setDepthStencilState:";
        private static readonly Selector sel_setDepthStoreAction = "setDepthStoreAction:";
        private static readonly Selector sel_setFrontFacingWinding = "setFrontFacingWinding:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setObjectThreadgroupMemoryLengthatIndex = "setObjectThreadgroupMemoryLength:atIndex:";
        private static readonly Selector sel_setRenderPipelineState = "setRenderPipelineState:";
        private static readonly Selector sel_setScissorRect = "setScissorRect:";
        private static readonly Selector sel_setScissorRectscount = "setScissorRects:count:";
        private static readonly Selector sel_setStencilFrontReferenceValuebackReferenceValue = "setStencilFrontReferenceValue:backReferenceValue:";
        private static readonly Selector sel_setStencilReferenceValue = "setStencilReferenceValue:";
        private static readonly Selector sel_setStencilStoreAction = "setStencilStoreAction:";
        private static readonly Selector sel_setThreadgroupMemoryLengthoffsetatIndex = "setThreadgroupMemoryLength:offset:atIndex:";
        private static readonly Selector sel_setTriangleFillMode = "setTriangleFillMode:";
        private static readonly Selector sel_setVertexAmplificationCountviewMappings = "setVertexAmplificationCount:viewMappings:";
        private static readonly Selector sel_setViewport = "setViewport:";
        private static readonly Selector sel_setViewportscount = "setViewports:count:";
        private static readonly Selector sel_setVisibilityResultModeoffset = "setVisibilityResultMode:offset:";
        private static readonly Selector sel_tileHeight = "tileHeight";
        private static readonly Selector sel_tileWidth = "tileWidth";
        private static readonly Selector sel_updateFenceafterEncoderStages = "updateFence:afterEncoderStages:";
        private static readonly Selector sel_waitForFencebeforeEncoderStages = "waitForFence:beforeEncoderStages:";
        private static readonly Selector sel_writeTimestampWithGranularityafterStageintoHeapatIndex = "writeTimestampWithGranularity:afterStage:intoHeap:atIndex:";
        private static readonly Selector sel_release = "release";
    }
}
