using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLCullMode : ulong
    {
        None = 0,
        Front = 1,
        Back = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLDepthClipMode : ulong
    {
        Clip = 0,
        Clamp = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLPrimitiveType : ulong
    {
        Point = 0,
        Line = 1,
        LineStrip = 2,
        Triangle = 3,
        TriangleStrip = 4,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLRenderStages : ulong
    {
        RenderStageVertex = 1,
        RenderStageFragment = 1 << 1,
        RenderStageTile = 1 << 2,
        RenderStageObject = 1 << 3,
        RenderStageMesh = 1 << 4,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTriangleFillMode : ulong
    {
        Fill = 0,
        Lines = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLVisibilityResultMode : ulong
    {
        Disabled = 0,
        Boolean = 1,
        Counting = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLWinding : ulong
    {
        Clockwise = 0,
        CounterClockwise = 1,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDrawIndexedPrimitivesIndirectArguments
    {
        public uint indexCount;
        public uint instanceCount;
        public uint indexStart;
        public int baseVertex;
        public uint baseInstance;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDrawPatchIndirectArguments
    {
        public uint patchCount;
        public uint instanceCount;
        public uint patchStart;
        public uint baseInstance;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDrawPrimitivesIndirectArguments
    {
        public uint vertexCount;
        public uint instanceCount;
        public uint vertexStart;
        public uint baseInstance;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLQuadTessellationFactorsHalf
    {
        public ushort edgeTessellationFactor;
        public ushort insideTessellationFactor;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLScissorRect
    {
        public ulong x;
        public ulong y;
        public ulong width;
        public ulong height;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLTriangleTessellationFactorsHalf
    {
        public ushort edgeTessellationFactor;
        public ushort insideTessellationFactor;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLVertexAmplificationViewMapping
    {
        public uint viewportArrayIndexOffset;
        public uint renderTargetArrayIndexOffset;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLViewport
    {
        public double originX;
        public double originY;
        public double width;
        public double height;
        public double znear;
        public double zfar;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderCommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderCommandEncoder obj) => obj.NativePtr;
        public static implicit operator MTLCommandEncoder(MTLRenderCommandEncoder obj) => new(obj.NativePtr);
        public MTLRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong TileHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileHeight);

        public ulong TileWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileWidth);

        public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterQueueStagesbeforeStages, (ulong)afterQueueStages, (ulong)beforeStages);
        }

        public void DispatchThreadsPerTile(MTLSize threadsPerTile)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadsPerTile, threadsPerTile);
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPatchespatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetindirectBufferindirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, ulong instanceCount, ulong baseInstance)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetinstanceCountbaseInstance, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, instanceCount, baseInstance);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCount, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferOffset, instanceCount);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffset, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferOffset);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount, long baseVertex, ulong baseInstance)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCountbaseVertexbaseInstance, (ulong)primitiveType, indexCount, (ulong)indexType, indexBuffer, indexBufferOffset, instanceCount, baseVertex, baseInstance);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitivesindexTypeindexBufferindexBufferOffsetindirectBufferindirectBufferOffset, (ulong)primitiveType, (ulong)indexType, indexBuffer, indexBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawMeshThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, indirectBuffer, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawMeshThreadsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup, threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPatchespatchIndexBufferpatchIndexBufferOffsetindirectBufferindirectBufferOffset, numberOfPatchControlPoints, patchIndexBuffer, patchIndexBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, ulong instanceCount, ulong baseInstance)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetinstanceCountbaseInstance, numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, instanceCount, baseInstance);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesvertexStartvertexCount, (ulong)primitiveType, vertexStart, vertexCount);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount, ulong baseInstance)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesvertexStartvertexCountinstanceCountbaseInstance, (ulong)primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesindirectBufferindirectBufferOffset, (ulong)primitiveType, indirectBuffer, indirectBufferOffset);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitivesvertexStartvertexCountinstanceCount, (ulong)primitiveType, vertexStart, vertexCount, instanceCount);
        }

        public void EndEncoding()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endEncoding);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferwithRange, indirectCommandBuffer, executionRange);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferindirectBufferindirectBufferOffset, indirectCommandbuffer, indirectRangeBuffer, indirectBufferOffset);
        }

        public void InsertDebugSignpost(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_insertDebugSignpost, nsString);
        }

        public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_memoryBarrierWithScopeafterStagesbeforeStages, (ulong)scope, (ulong)after, (ulong)before);
        }

        public void MemoryBarrier(MTLResource[] resources, ulong count, MTLRenderStages after, MTLRenderStages before)
        {
            throw new NotImplementedException();
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_sampleCountersInBufferatSampleIndexwithBarrier, sampleBuffer, sampleIndex, barrier);
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

        public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, ulong colorAttachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorStoreActionOptionsatIndex, (ulong)storeActionOptions, colorAttachmentIndex);
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

        public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStoreActionOptions, (ulong)storeActionOptions);
        }

        public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentAccelerationStructureatBufferIndex, accelerationStructure, bufferIndex);
        }

        public void SetFragmentBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetFragmentBufferOffset(ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentBufferOffsetatIndex, offset, index);
        }

        public void SetFragmentBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentBytes(IntPtr bytes, ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentByteslengthatIndex, bytes, length, index);
        }

        public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentIntersectionFunctionTableatBufferIndex, intersectionFunctionTable, bufferIndex);
        }

        public void SetFragmentIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentSamplerState(MTLSamplerState sampler, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentSamplerStateatIndex, sampler, index);
        }

        public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentSamplerStatelodMinClamplodMaxClampatIndex, sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetFragmentSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentTexture(MTLTexture texture, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentTextureatIndex, texture, index);
        }

        public void SetFragmentTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentVisibleFunctionTableatBufferIndex, functionTable, bufferIndex);
        }

        public void SetFragmentVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFrontFacingWinding, (ulong)frontFacingWinding);
        }

        public void SetMeshBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetMeshBufferOffset(ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshBufferOffsetatIndex, offset, index);
        }

        public void SetMeshBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMeshBytes(IntPtr bytes, ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshByteslengthatIndex, bytes, length, index);
        }

        public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshSamplerStatelodMinClamplodMaxClampatIndex, sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetMeshSamplerState(MTLSamplerState sampler, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshSamplerStateatIndex, sampler, index);
        }

        public void SetMeshSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMeshSamplerStates(MTLSamplerState[] samplers, float lodMinClamps, float lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMeshTexture(MTLTexture texture, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshTextureatIndex, texture, index);
        }

        public void SetMeshTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetObjectBufferOffset(ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectBufferOffsetatIndex, offset, index);
        }

        public void SetObjectBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectBytes(IntPtr bytes, ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectByteslengthatIndex, bytes, length, index);
        }

        public void SetObjectSamplerState(MTLSamplerState sampler, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectSamplerStateatIndex, sampler, index);
        }

        public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectSamplerStatelodMinClamplodMaxClampatIndex, sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetObjectSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectSamplerStates(MTLSamplerState[] samplers, float lodMinClamps, float lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectTexture(MTLTexture texture, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectTextureatIndex, texture, index);
        }

        public void SetObjectTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
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

        public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilStoreActionOptions, (ulong)storeActionOptions);
        }

        public void SetTessellationFactorBuffer(MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationFactorBufferoffsetinstanceStride, buffer, offset, instanceStride);
        }

        public void SetTessellationFactorScale(float scale)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationFactorScale, scale);
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLengthoffsetatIndex, length, offset, index);
        }

        public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileAccelerationStructureatBufferIndex, accelerationStructure, bufferIndex);
        }

        public void SetTileBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetTileBufferOffset(ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileBufferOffsetatIndex, offset, index);
        }

        public void SetTileBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileBytes(IntPtr bytes, ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileByteslengthatIndex, bytes, length, index);
        }

        public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileIntersectionFunctionTableatBufferIndex, intersectionFunctionTable, bufferIndex);
        }

        public void SetTileIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileSamplerState(MTLSamplerState sampler, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileSamplerStateatIndex, sampler, index);
        }

        public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileSamplerStatelodMinClamplodMaxClampatIndex, sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetTileSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileTexture(MTLTexture texture, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileTextureatIndex, texture, index);
        }

        public void SetTileTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileVisibleFunctionTableatBufferIndex, functionTable, bufferIndex);
        }

        public void SetTileVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleFillMode, (ulong)fillMode);
        }

        public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexAccelerationStructureatBufferIndex, accelerationStructure, bufferIndex);
        }

        public void SetVertexAmplificationCount(ulong count, MTLVertexAmplificationViewMapping viewMappings)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexAmplificationCountviewMappings, count, viewMappings);
        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong stride, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBufferoffsetattributeStrideatIndex, buffer, offset, stride, index);
        }

        public void SetVertexBufferOffset(ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBufferOffsetatIndex, offset, index);
        }

        public void SetVertexBufferOffset(ulong offset, ulong stride, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBufferOffsetattributeStrideatIndex, offset, stride, index);
        }

        public void SetVertexBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBuffers(MTLBuffer[] buffers, ulong offsets, ulong strides, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBytes(IntPtr bytes, ulong length, ulong stride, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexByteslengthattributeStrideatIndex, bytes, length, stride, index);
        }

        public void SetVertexBytes(IntPtr bytes, ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexByteslengthatIndex, bytes, length, index);
        }

        public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexIntersectionFunctionTableatBufferIndex, intersectionFunctionTable, bufferIndex);
        }

        public void SetVertexIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexSamplerStatelodMinClamplodMaxClampatIndex, sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetVertexSamplerState(MTLSamplerState sampler, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexSamplerStateatIndex, sampler, index);
        }

        public void SetVertexSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexTexture(MTLTexture texture, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexTextureatIndex, texture, index);
        }

        public void SetVertexTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexVisibleFunctionTableatBufferIndex, functionTable, bufferIndex);
        }

        public void SetVertexVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            throw new NotImplementedException();
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

        public void TextureBarrier()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_textureBarrier);
        }

        public void UpdateFence(MTLFence fence, MTLRenderStages stages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFenceafterStages, fence, (ulong)stages);
        }

        public void UseHeap(MTLHeap heap, MTLRenderStages stages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useHeapstages, heap, (ulong)stages);
        }

        public void UseHeap(MTLHeap heap)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useHeap, heap);
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count)
        {
            throw new NotImplementedException();
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResourceusage, resource, (ulong)usage);
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResourceusagestages, resource, (ulong)usage, (ulong)stages);
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage)
        {
            throw new NotImplementedException();
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void WaitForFence(MTLFence fence, MTLRenderStages stages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFencebeforeStages, fence, (ulong)stages);
        }

        private static readonly Selector sel_barrierAfterQueueStagesbeforeStages = "barrierAfterQueueStages:beforeStages:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_dispatchThreadsPerTile = "dispatchThreadsPerTile:";
        private static readonly Selector sel_drawIndexedPatchespatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetindirectBufferindirectBufferOffset = "drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawIndexedPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetinstanceCountbaseInstance = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffset = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";
        private static readonly Selector sel_drawIndexedPrimitivesindexTypeindexBufferindexBufferOffsetindirectBufferindirectBufferOffset = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawMeshThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawMeshThreadsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawPatchespatchIndexBufferpatchIndexBufferOffsetindirectBufferindirectBufferOffset = "drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetinstanceCountbaseInstance = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";
        private static readonly Selector sel_drawPrimitivesindirectBufferindirectBufferOffset = "drawPrimitives:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCount = "drawPrimitives:vertexStart:vertexCount:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCount = "drawPrimitives:vertexStart:vertexCount:instanceCount:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCountbaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_executeCommandsInBufferindirectBufferindirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_executeCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";
        private static readonly Selector sel_insertDebugSignpost = "insertDebugSignpost:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_memoryBarrierWithResourcescountafterStagesbeforeStages = "memoryBarrierWithResources:count:afterStages:beforeStages:";
        private static readonly Selector sel_memoryBarrierWithScopeafterStagesbeforeStages = "memoryBarrierWithScope:afterStages:beforeStages:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_sampleCountersInBufferatSampleIndexwithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";
        private static readonly Selector sel_setBlendColorRedgreenbluealpha = "setBlendColorRed:green:blue:alpha:";
        private static readonly Selector sel_setColorAttachmentMap = "setColorAttachmentMap:";
        private static readonly Selector sel_setColorStoreActionatIndex = "setColorStoreAction:atIndex:";
        private static readonly Selector sel_setColorStoreActionOptionsatIndex = "setColorStoreActionOptions:atIndex:";
        private static readonly Selector sel_setCullMode = "setCullMode:";
        private static readonly Selector sel_setDepthBiasslopeScaleclamp = "setDepthBias:slopeScale:clamp:";
        private static readonly Selector sel_setDepthClipMode = "setDepthClipMode:";
        private static readonly Selector sel_setDepthStencilState = "setDepthStencilState:";
        private static readonly Selector sel_setDepthStoreAction = "setDepthStoreAction:";
        private static readonly Selector sel_setDepthStoreActionOptions = "setDepthStoreActionOptions:";
        private static readonly Selector sel_setFragmentAccelerationStructureatBufferIndex = "setFragmentAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_setFragmentBufferOffsetatIndex = "setFragmentBufferOffset:atIndex:";
        private static readonly Selector sel_setFragmentBufferoffsetatIndex = "setFragmentBuffer:offset:atIndex:";
        private static readonly Selector sel_setFragmentBuffersoffsetswithRange = "setFragmentBuffers:offsets:withRange:";
        private static readonly Selector sel_setFragmentByteslengthatIndex = "setFragmentBytes:length:atIndex:";
        private static readonly Selector sel_setFragmentIntersectionFunctionTableatBufferIndex = "setFragmentIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setFragmentIntersectionFunctionTableswithBufferRange = "setFragmentIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setFragmentSamplerStateatIndex = "setFragmentSamplerState:atIndex:";
        private static readonly Selector sel_setFragmentSamplerStatelodMinClamplodMaxClampatIndex = "setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setFragmentSamplerStateslodMinClampslodMaxClampswithRange = "setFragmentSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setFragmentSamplerStateswithRange = "setFragmentSamplerStates:withRange:";
        private static readonly Selector sel_setFragmentTextureatIndex = "setFragmentTexture:atIndex:";
        private static readonly Selector sel_setFragmentTextureswithRange = "setFragmentTextures:withRange:";
        private static readonly Selector sel_setFragmentVisibleFunctionTableatBufferIndex = "setFragmentVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setFragmentVisibleFunctionTableswithBufferRange = "setFragmentVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setFrontFacingWinding = "setFrontFacingWinding:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMeshBufferOffsetatIndex = "setMeshBufferOffset:atIndex:";
        private static readonly Selector sel_setMeshBufferoffsetatIndex = "setMeshBuffer:offset:atIndex:";
        private static readonly Selector sel_setMeshBuffersoffsetswithRange = "setMeshBuffers:offsets:withRange:";
        private static readonly Selector sel_setMeshByteslengthatIndex = "setMeshBytes:length:atIndex:";
        private static readonly Selector sel_setMeshSamplerStateatIndex = "setMeshSamplerState:atIndex:";
        private static readonly Selector sel_setMeshSamplerStatelodMinClamplodMaxClampatIndex = "setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setMeshSamplerStateslodMinClampslodMaxClampswithRange = "setMeshSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setMeshSamplerStateswithRange = "setMeshSamplerStates:withRange:";
        private static readonly Selector sel_setMeshTextureatIndex = "setMeshTexture:atIndex:";
        private static readonly Selector sel_setMeshTextureswithRange = "setMeshTextures:withRange:";
        private static readonly Selector sel_setObjectBufferOffsetatIndex = "setObjectBufferOffset:atIndex:";
        private static readonly Selector sel_setObjectBufferoffsetatIndex = "setObjectBuffer:offset:atIndex:";
        private static readonly Selector sel_setObjectBuffersoffsetswithRange = "setObjectBuffers:offsets:withRange:";
        private static readonly Selector sel_setObjectByteslengthatIndex = "setObjectBytes:length:atIndex:";
        private static readonly Selector sel_setObjectSamplerStateatIndex = "setObjectSamplerState:atIndex:";
        private static readonly Selector sel_setObjectSamplerStatelodMinClamplodMaxClampatIndex = "setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setObjectSamplerStateslodMinClampslodMaxClampswithRange = "setObjectSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setObjectSamplerStateswithRange = "setObjectSamplerStates:withRange:";
        private static readonly Selector sel_setObjectTextureatIndex = "setObjectTexture:atIndex:";
        private static readonly Selector sel_setObjectTextureswithRange = "setObjectTextures:withRange:";
        private static readonly Selector sel_setObjectThreadgroupMemoryLengthatIndex = "setObjectThreadgroupMemoryLength:atIndex:";
        private static readonly Selector sel_setRenderPipelineState = "setRenderPipelineState:";
        private static readonly Selector sel_setScissorRect = "setScissorRect:";
        private static readonly Selector sel_setScissorRectscount = "setScissorRects:count:";
        private static readonly Selector sel_setStencilFrontReferenceValuebackReferenceValue = "setStencilFrontReferenceValue:backReferenceValue:";
        private static readonly Selector sel_setStencilReferenceValue = "setStencilReferenceValue:";
        private static readonly Selector sel_setStencilStoreAction = "setStencilStoreAction:";
        private static readonly Selector sel_setStencilStoreActionOptions = "setStencilStoreActionOptions:";
        private static readonly Selector sel_setTessellationFactorBufferoffsetinstanceStride = "setTessellationFactorBuffer:offset:instanceStride:";
        private static readonly Selector sel_setTessellationFactorScale = "setTessellationFactorScale:";
        private static readonly Selector sel_setThreadgroupMemoryLengthoffsetatIndex = "setThreadgroupMemoryLength:offset:atIndex:";
        private static readonly Selector sel_setTileAccelerationStructureatBufferIndex = "setTileAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_setTileBufferoffsetatIndex = "setTileBuffer:offset:atIndex:";
        private static readonly Selector sel_setTileBufferOffsetatIndex = "setTileBufferOffset:atIndex:";
        private static readonly Selector sel_setTileBuffersoffsetswithRange = "setTileBuffers:offsets:withRange:";
        private static readonly Selector sel_setTileByteslengthatIndex = "setTileBytes:length:atIndex:";
        private static readonly Selector sel_setTileIntersectionFunctionTableatBufferIndex = "setTileIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setTileIntersectionFunctionTableswithBufferRange = "setTileIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setTileSamplerStateatIndex = "setTileSamplerState:atIndex:";
        private static readonly Selector sel_setTileSamplerStatelodMinClamplodMaxClampatIndex = "setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setTileSamplerStateslodMinClampslodMaxClampswithRange = "setTileSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setTileSamplerStateswithRange = "setTileSamplerStates:withRange:";
        private static readonly Selector sel_setTileTextureatIndex = "setTileTexture:atIndex:";
        private static readonly Selector sel_setTileTextureswithRange = "setTileTextures:withRange:";
        private static readonly Selector sel_setTileVisibleFunctionTableatBufferIndex = "setTileVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setTileVisibleFunctionTableswithBufferRange = "setTileVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setTriangleFillMode = "setTriangleFillMode:";
        private static readonly Selector sel_setVertexAccelerationStructureatBufferIndex = "setVertexAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_setVertexAmplificationCountviewMappings = "setVertexAmplificationCount:viewMappings:";
        private static readonly Selector sel_setVertexBufferoffsetatIndex = "setVertexBuffer:offset:atIndex:";
        private static readonly Selector sel_setVertexBufferOffsetatIndex = "setVertexBufferOffset:atIndex:";
        private static readonly Selector sel_setVertexBufferoffsetattributeStrideatIndex = "setVertexBuffer:offset:attributeStride:atIndex:";
        private static readonly Selector sel_setVertexBufferOffsetattributeStrideatIndex = "setVertexBufferOffset:attributeStride:atIndex:";
        private static readonly Selector sel_setVertexBuffersoffsetsattributeStrideswithRange = "setVertexBuffers:offsets:attributeStrides:withRange:";
        private static readonly Selector sel_setVertexBuffersoffsetswithRange = "setVertexBuffers:offsets:withRange:";
        private static readonly Selector sel_setVertexByteslengthatIndex = "setVertexBytes:length:atIndex:";
        private static readonly Selector sel_setVertexByteslengthattributeStrideatIndex = "setVertexBytes:length:attributeStride:atIndex:";
        private static readonly Selector sel_setVertexIntersectionFunctionTableatBufferIndex = "setVertexIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVertexIntersectionFunctionTableswithBufferRange = "setVertexIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setVertexSamplerStateatIndex = "setVertexSamplerState:atIndex:";
        private static readonly Selector sel_setVertexSamplerStatelodMinClamplodMaxClampatIndex = "setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setVertexSamplerStateslodMinClampslodMaxClampswithRange = "setVertexSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setVertexSamplerStateswithRange = "setVertexSamplerStates:withRange:";
        private static readonly Selector sel_setVertexTextureatIndex = "setVertexTexture:atIndex:";
        private static readonly Selector sel_setVertexTextureswithRange = "setVertexTextures:withRange:";
        private static readonly Selector sel_setVertexVisibleFunctionTableatBufferIndex = "setVertexVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVertexVisibleFunctionTableswithBufferRange = "setVertexVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setViewport = "setViewport:";
        private static readonly Selector sel_setViewportscount = "setViewports:count:";
        private static readonly Selector sel_setVisibilityResultModeoffset = "setVisibilityResultMode:offset:";
        private static readonly Selector sel_textureBarrier = "textureBarrier";
        private static readonly Selector sel_tileHeight = "tileHeight";
        private static readonly Selector sel_tileWidth = "tileWidth";
        private static readonly Selector sel_updateFenceafterStages = "updateFence:afterStages:";
        private static readonly Selector sel_useHeap = "useHeap:";
        private static readonly Selector sel_useHeapscount = "useHeaps:count:";
        private static readonly Selector sel_useHeapscountstages = "useHeaps:count:stages:";
        private static readonly Selector sel_useHeapstages = "useHeap:stages:";
        private static readonly Selector sel_useResourcescountusage = "useResources:count:usage:";
        private static readonly Selector sel_useResourcescountusagestages = "useResources:count:usage:stages:";
        private static readonly Selector sel_useResourceusage = "useResource:usage:";
        private static readonly Selector sel_useResourceusagestages = "useResource:usage:stages:";
        private static readonly Selector sel_waitForFencebeforeStages = "waitForFence:beforeStages:";
        private static readonly Selector sel_release = "release";
    }
}
