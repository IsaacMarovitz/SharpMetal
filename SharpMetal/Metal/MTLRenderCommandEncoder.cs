using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLPrimitiveType : ulong
    {
        Point = 0,
        Line = 1,
        LineStrip = 2,
        Triangle = 3,
        TriangleStrip = 4,
    }

    public enum MTLVisibilityResultMode : ulong
    {
        Disabled = 0,
        Boolean = 1,
        Counting = 2,
    }

    public enum MTLCullMode : ulong
    {
        None = 0,
        Front = 1,
        Back = 2,
    }

    public enum MTLWinding : ulong
    {
        Clockwise = 0,
        CounterClockwise = 1,
    }

    public enum MTLDepthClipMode : ulong
    {
        Clip = 0,
        Clamp = 1,
    }

    public enum MTLTriangleFillMode : ulong
    {
        Fill = 0,
        Lines = 1,
    }

    public enum MTLRenderStages : ulong
    {
        RenderStageVertex = 1,
        RenderStageFragment = 2,
        RenderStageTile = 4,
        RenderStageObject = 8,
        RenderStageMesh = 16,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLScissorRect
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLScissorRect obj) => obj.NativePtr;
        public MTLScissorRect(IntPtr ptr) => NativePtr = ptr;

        public ulong x;

        public ulong y;

        public ulong width;

        public ulong height;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLViewport
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLViewport obj) => obj.NativePtr;
        public MTLViewport(IntPtr ptr) => NativePtr = ptr;

        public double originX;

        public double originY;

        public double width;

        public double height;

        public double znear;

        public double zfar;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDrawPrimitivesIndirectArguments
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDrawPrimitivesIndirectArguments obj) => obj.NativePtr;
        public MTLDrawPrimitivesIndirectArguments(IntPtr ptr) => NativePtr = ptr;

        public uint vertexCount;

        public uint instanceCount;

        public uint vertexStart;

        public uint baseInstance;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDrawIndexedPrimitivesIndirectArguments
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDrawIndexedPrimitivesIndirectArguments obj) => obj.NativePtr;
        public MTLDrawIndexedPrimitivesIndirectArguments(IntPtr ptr) => NativePtr = ptr;

        public uint indexCount;

        public uint instanceCount;

        public uint indexStart;

        public int baseVertex;

        public uint baseInstance;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLVertexAmplificationViewMapping
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAmplificationViewMapping obj) => obj.NativePtr;
        public MTLVertexAmplificationViewMapping(IntPtr ptr) => NativePtr = ptr;

        public uint viewportArrayIndexOffset;

        public uint renderTargetArrayIndexOffset;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDrawPatchIndirectArguments
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDrawPatchIndirectArguments obj) => obj.NativePtr;
        public MTLDrawPatchIndirectArguments(IntPtr ptr) => NativePtr = ptr;

        public uint patchCount;

        public uint instanceCount;

        public uint patchStart;

        public uint baseInstance;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLQuadTessellationFactorsHalf
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLQuadTessellationFactorsHalf obj) => obj.NativePtr;
        public MTLQuadTessellationFactorsHalf(IntPtr ptr) => NativePtr = ptr;

        public ushort edgeTessellationFactor;

        public ushort insideTessellationFactor;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLTriangleTessellationFactorsHalf
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTriangleTessellationFactorsHalf obj) => obj.NativePtr;
        public MTLTriangleTessellationFactorsHalf(IntPtr ptr) => NativePtr = ptr;

        public ushort edgeTessellationFactor;

        public ushort insideTessellationFactor;
    }

    [SupportedOSPlatform("macos")]
    public class MTLRenderCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderCommandEncoder obj) => obj.NativePtr;
        public MTLRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public ulong TileWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileWidth);

        public ulong TileHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileHeight);

        public void SetRenderPipelineState(MTLRenderPipelineState pipelineState)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBytes(IntPtr bytes, ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBufferOffset(ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVertexBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexTexture(MTLTexture texture, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVertexTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexSamplerState(MTLSamplerState sampler, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVertexSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVertexSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetVertexVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetVertexIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetViewport(MTLViewport viewport)
        {
            throw new NotImplementedException();
        }

        public void SetViewports(MTLViewport viewports, ulong count)
        {
            throw new NotImplementedException();
        }

        public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
        {
            throw new NotImplementedException();
        }

        public void SetVertexAmplificationCount(ulong count, MTLVertexAmplificationViewMapping viewMappings)
        {
            throw new NotImplementedException();
        }

        public void SetCullMode(MTLCullMode cullMode)
        {
            throw new NotImplementedException();
        }

        public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
        {
            throw new NotImplementedException();
        }

        public void SetDepthBias(float depthBias, float slopeScale, float clamp)
        {
            throw new NotImplementedException();
        }

        public void SetScissorRect(MTLScissorRect rect)
        {
            throw new NotImplementedException();
        }

        public void SetScissorRects(MTLScissorRect scissorRects, ulong count)
        {
            throw new NotImplementedException();
        }

        public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentBytes(IntPtr bytes, ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentBufferOffset(ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentTexture(MTLTexture texture, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentSamplerState(MTLSamplerState sampler, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetBlendColor(float red, float green, float blue, float alpha)
        {
            throw new NotImplementedException();
        }

        public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
        {
            throw new NotImplementedException();
        }

        public void SetStencilReferenceValue(uint referenceValue)
        {
            throw new NotImplementedException();
        }

        public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
        {
            throw new NotImplementedException();
        }

        public void SetVisibilityResultMode(MTLVisibilityResultMode mode, ulong offset)
        {
            throw new NotImplementedException();
        }

        public void SetColorStoreAction(MTLStoreAction storeAction, ulong colorAttachmentIndex)
        {
            throw new NotImplementedException();
        }

        public void SetDepthStoreAction(MTLStoreAction storeAction)
        {
            throw new NotImplementedException();
        }

        public void SetStencilStoreAction(MTLStoreAction storeAction)
        {
            throw new NotImplementedException();
        }

        public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, ulong colorAttachmentIndex)
        {
            throw new NotImplementedException();
        }

        public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            throw new NotImplementedException();
        }

        public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            throw new NotImplementedException();
        }

        public void SetObjectBytes(IntPtr bytes, ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetObjectBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetObjectBufferOffset(ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetObjectBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectTexture(MTLTexture texture, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetObjectTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectSamplerState(MTLSamplerState sampler, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetObjectSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetObjectSamplerStates(MTLSamplerState[] samplers, float lodMinClamps, float lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetObjectThreadgroupMemoryLength(ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshBytes(IntPtr bytes, ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshBufferOffset(ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMeshTexture(MTLTexture texture, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMeshSamplerState(MTLSamplerState sampler, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetMeshSamplerStates(MTLSamplerState[] samplers, float lodMinClamps, float lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount)
        {
            throw new NotImplementedException();
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset)
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

        public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            throw new NotImplementedException();
        }

        public void UpdateFence(MTLFence fence, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void WaitForFence(MTLFence fence, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void SetTessellationFactorBuffer(MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            throw new NotImplementedException();
        }

        public void SetTessellationFactorScale(float scale)
        {
            throw new NotImplementedException();
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, ulong instanceCount, ulong baseInstance)
        {
            throw new NotImplementedException();
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, ulong instanceCount, ulong baseInstance)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            throw new NotImplementedException();
        }

        public void SetTileBytes(IntPtr bytes, ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTileBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTileBufferOffset(ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTileBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileTexture(MTLTexture texture, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTileTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileSamplerState(MTLSamplerState sampler, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTileSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTileSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetTileVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetTileIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void DispatchThreadsPerTile(MTLSize threadsPerTile)
        {
            throw new NotImplementedException();
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage)
        {
            throw new NotImplementedException();
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage)
        {
            throw new NotImplementedException();
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void UseHeap(MTLHeap heap)
        {
            throw new NotImplementedException();
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count)
        {
            throw new NotImplementedException();
        }

        public void UseHeap(MTLHeap heap, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count, MTLRenderStages stages)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, ulong indirectBufferOffset)
        {
            throw new NotImplementedException();
        }

        public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
        {
            throw new NotImplementedException();
        }

        public void MemoryBarrier(MTLResource[] resources, ulong count, MTLRenderStages after, MTLRenderStages before)
        {
            throw new NotImplementedException();
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_setRenderPipelineState = "setRenderPipelineState:";
        private static readonly Selector sel_setVertexByteslengthatIndex = "setVertexBytes:length:atIndex:";
        private static readonly Selector sel_setVertexBufferoffsetatIndex = "setVertexBuffer:offset:atIndex:";
        private static readonly Selector sel_setVertexBufferOffsetatIndex = "setVertexBufferOffset:atIndex:";
        private static readonly Selector sel_setVertexBuffersoffsetswithRange = "setVertexBuffers:offsets:withRange:";
        private static readonly Selector sel_setVertexTextureatIndex = "setVertexTexture:atIndex:";
        private static readonly Selector sel_setVertexTextureswithRange = "setVertexTextures:withRange:";
        private static readonly Selector sel_setVertexSamplerStateatIndex = "setVertexSamplerState:atIndex:";
        private static readonly Selector sel_setVertexSamplerStateswithRange = "setVertexSamplerStates:withRange:";
        private static readonly Selector sel_setVertexSamplerStatelodMinClamplodMaxClampatIndex = "setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setVertexSamplerStateslodMinClampslodMaxClampswithRange = "setVertexSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setVertexVisibleFunctionTableatBufferIndex = "setVertexVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVertexVisibleFunctionTableswithBufferRange = "setVertexVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setVertexIntersectionFunctionTableatBufferIndex = "setVertexIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVertexIntersectionFunctionTableswithBufferRange = "setVertexIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setVertexAccelerationStructureatBufferIndex = "setVertexAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_setViewport = "setViewport:";
        private static readonly Selector sel_setViewportscount = "setViewports:count:";
        private static readonly Selector sel_setFrontFacingWinding = "setFrontFacingWinding:";
        private static readonly Selector sel_setVertexAmplificationCountviewMappings = "setVertexAmplificationCount:viewMappings:";
        private static readonly Selector sel_setCullMode = "setCullMode:";
        private static readonly Selector sel_setDepthClipMode = "setDepthClipMode:";
        private static readonly Selector sel_setDepthBiasslopeScaleclamp = "setDepthBias:slopeScale:clamp:";
        private static readonly Selector sel_setScissorRect = "setScissorRect:";
        private static readonly Selector sel_setScissorRectscount = "setScissorRects:count:";
        private static readonly Selector sel_setTriangleFillMode = "setTriangleFillMode:";
        private static readonly Selector sel_setFragmentByteslengthatIndex = "setFragmentBytes:length:atIndex:";
        private static readonly Selector sel_setFragmentBufferoffsetatIndex = "setFragmentBuffer:offset:atIndex:";
        private static readonly Selector sel_setFragmentBufferOffsetatIndex = "setFragmentBufferOffset:atIndex:";
        private static readonly Selector sel_setFragmentBuffersoffsetswithRange = "setFragmentBuffers:offsets:withRange:";
        private static readonly Selector sel_setFragmentTextureatIndex = "setFragmentTexture:atIndex:";
        private static readonly Selector sel_setFragmentTextureswithRange = "setFragmentTextures:withRange:";
        private static readonly Selector sel_setFragmentSamplerStateatIndex = "setFragmentSamplerState:atIndex:";
        private static readonly Selector sel_setFragmentSamplerStateswithRange = "setFragmentSamplerStates:withRange:";
        private static readonly Selector sel_setFragmentSamplerStatelodMinClamplodMaxClampatIndex = "setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setFragmentSamplerStateslodMinClampslodMaxClampswithRange = "setFragmentSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setFragmentVisibleFunctionTableatBufferIndex = "setFragmentVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setFragmentVisibleFunctionTableswithBufferRange = "setFragmentVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setFragmentIntersectionFunctionTableatBufferIndex = "setFragmentIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setFragmentIntersectionFunctionTableswithBufferRange = "setFragmentIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setFragmentAccelerationStructureatBufferIndex = "setFragmentAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_setBlendColorRedgreenbluealpha = "setBlendColorRed:green:blue:alpha:";
        private static readonly Selector sel_setDepthStencilState = "setDepthStencilState:";
        private static readonly Selector sel_setStencilReferenceValue = "setStencilReferenceValue:";
        private static readonly Selector sel_setStencilFrontReferenceValuebackReferenceValue = "setStencilFrontReferenceValue:backReferenceValue:";
        private static readonly Selector sel_setVisibilityResultModeoffset = "setVisibilityResultMode:offset:";
        private static readonly Selector sel_setColorStoreActionatIndex = "setColorStoreAction:atIndex:";
        private static readonly Selector sel_setDepthStoreAction = "setDepthStoreAction:";
        private static readonly Selector sel_setStencilStoreAction = "setStencilStoreAction:";
        private static readonly Selector sel_setColorStoreActionOptionsatIndex = "setColorStoreActionOptions:atIndex:";
        private static readonly Selector sel_setDepthStoreActionOptions = "setDepthStoreActionOptions:";
        private static readonly Selector sel_setStencilStoreActionOptions = "setStencilStoreActionOptions:";
        private static readonly Selector sel_setObjectByteslengthatIndex = "setObjectBytes:length:atIndex:";
        private static readonly Selector sel_setObjectBufferoffsetatIndex = "setObjectBuffer:offset:atIndex:";
        private static readonly Selector sel_setObjectBufferOffsetatIndex = "setObjectBufferOffset:atIndex:";
        private static readonly Selector sel_setObjectBuffersoffsetswithRange = "setObjectBuffers:offsets:withRange:";
        private static readonly Selector sel_setObjectTextureatIndex = "setObjectTexture:atIndex:";
        private static readonly Selector sel_setObjectTextureswithRange = "setObjectTextures:withRange:";
        private static readonly Selector sel_setObjectSamplerStateatIndex = "setObjectSamplerState:atIndex:";
        private static readonly Selector sel_setObjectSamplerStateswithRange = "setObjectSamplerStates:withRange:";
        private static readonly Selector sel_setObjectSamplerStatelodMinClamplodMaxClampatIndex = "setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setObjectSamplerStateslodMinClampslodMaxClampswithRange = "setObjectSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setObjectThreadgroupMemoryLengthatIndex = "setObjectThreadgroupMemoryLength:atIndex:";
        private static readonly Selector sel_setMeshByteslengthatIndex = "setMeshBytes:length:atIndex:";
        private static readonly Selector sel_setMeshBufferoffsetatIndex = "setMeshBuffer:offset:atIndex:";
        private static readonly Selector sel_setMeshBufferOffsetatIndex = "setMeshBufferOffset:atIndex:";
        private static readonly Selector sel_setMeshBuffersoffsetswithRange = "setMeshBuffers:offsets:withRange:";
        private static readonly Selector sel_setMeshTextureatIndex = "setMeshTexture:atIndex:";
        private static readonly Selector sel_setMeshTextureswithRange = "setMeshTextures:withRange:";
        private static readonly Selector sel_setMeshSamplerStateatIndex = "setMeshSamplerState:atIndex:";
        private static readonly Selector sel_setMeshSamplerStateswithRange = "setMeshSamplerStates:withRange:";
        private static readonly Selector sel_setMeshSamplerStatelodMinClamplodMaxClampatIndex = "setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setMeshSamplerStateslodMinClampslodMaxClampswithRange = "setMeshSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_drawMeshThreadgroupsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawMeshThreadsthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawMeshThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerObjectThreadgroupthreadsPerMeshThreadgroup = "drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCount = "drawPrimitives:vertexStart:vertexCount:instanceCount:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCount = "drawPrimitives:vertexStart:vertexCount:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCount = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffset = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:";
        private static readonly Selector sel_drawPrimitivesvertexStartvertexCountinstanceCountbaseInstance = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";
        private static readonly Selector sel_drawIndexedPrimitivesindexCountindexTypeindexBufferindexBufferOffsetinstanceCountbaseVertexbaseInstance = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";
        private static readonly Selector sel_drawPrimitivesindirectBufferindirectBufferOffset = "drawPrimitives:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawIndexedPrimitivesindexTypeindexBufferindexBufferOffsetindirectBufferindirectBufferOffset = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_textureBarrier = "textureBarrier";
        private static readonly Selector sel_updateFenceafterStages = "updateFence:afterStages:";
        private static readonly Selector sel_waitForFencebeforeStages = "waitForFence:beforeStages:";
        private static readonly Selector sel_setTessellationFactorBufferoffsetinstanceStride = "setTessellationFactorBuffer:offset:instanceStride:";
        private static readonly Selector sel_setTessellationFactorScale = "setTessellationFactorScale:";
        private static readonly Selector sel_drawPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetinstanceCountbaseInstance = "drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:";
        private static readonly Selector sel_drawPatchespatchIndexBufferpatchIndexBufferOffsetindirectBufferindirectBufferOffset = "drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawIndexedPatchespatchStartpatchCountpatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetinstanceCountbaseInstance = "drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:";
        private static readonly Selector sel_drawIndexedPatchespatchIndexBufferpatchIndexBufferOffsetcontrolPointIndexBuffercontrolPointIndexBufferOffsetindirectBufferindirectBufferOffset = "drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_tileWidth = "tileWidth";
        private static readonly Selector sel_tileHeight = "tileHeight";
        private static readonly Selector sel_setTileByteslengthatIndex = "setTileBytes:length:atIndex:";
        private static readonly Selector sel_setTileBufferoffsetatIndex = "setTileBuffer:offset:atIndex:";
        private static readonly Selector sel_setTileBufferOffsetatIndex = "setTileBufferOffset:atIndex:";
        private static readonly Selector sel_setTileBuffersoffsetswithRange = "setTileBuffers:offsets:withRange:";
        private static readonly Selector sel_setTileTextureatIndex = "setTileTexture:atIndex:";
        private static readonly Selector sel_setTileTextureswithRange = "setTileTextures:withRange:";
        private static readonly Selector sel_setTileSamplerStateatIndex = "setTileSamplerState:atIndex:";
        private static readonly Selector sel_setTileSamplerStateswithRange = "setTileSamplerStates:withRange:";
        private static readonly Selector sel_setTileSamplerStatelodMinClamplodMaxClampatIndex = "setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setTileSamplerStateslodMinClampslodMaxClampswithRange = "setTileSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setTileVisibleFunctionTableatBufferIndex = "setTileVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setTileVisibleFunctionTableswithBufferRange = "setTileVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setTileIntersectionFunctionTableatBufferIndex = "setTileIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setTileIntersectionFunctionTableswithBufferRange = "setTileIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setTileAccelerationStructureatBufferIndex = "setTileAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_dispatchThreadsPerTile = "dispatchThreadsPerTile:";
        private static readonly Selector sel_setThreadgroupMemoryLengthoffsetatIndex = "setThreadgroupMemoryLength:offset:atIndex:";
        private static readonly Selector sel_useResourceusage = "useResource:usage:";
        private static readonly Selector sel_useResourcescountusage = "useResources:count:usage:";
        private static readonly Selector sel_useResourceusagestages = "useResource:usage:stages:";
        private static readonly Selector sel_useResourcescountusagestages = "useResources:count:usage:stages:";
        private static readonly Selector sel_useHeap = "useHeap:";
        private static readonly Selector sel_useHeapscount = "useHeaps:count:";
        private static readonly Selector sel_useHeapstages = "useHeap:stages:";
        private static readonly Selector sel_useHeapscountstages = "useHeaps:count:stages:";
        private static readonly Selector sel_executeCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";
        private static readonly Selector sel_executeCommandsInBufferindirectBufferindirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_memoryBarrierWithScopeafterStagesbeforeStages = "memoryBarrierWithScope:afterStages:beforeStages:";
        private static readonly Selector sel_memoryBarrierWithResourcescountafterStagesbeforeStages = "memoryBarrierWithResources:count:afterStages:beforeStages:";
        private static readonly Selector sel_sampleCountersInBufferatSampleIndexwithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";
    }
}
