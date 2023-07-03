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
            objc_msgSend(NativePtr, , pipelineState);
        }

        public void SetVertexBytes(IntPtr bytes, ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , bytes, length, index);
        }

        public void SetVertexBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetVertexBufferOffset(ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , offset, index);
        }

        public void SetVertexBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetVertexTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetVertexTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetVertexSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetVertexSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public void SetVertexSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetVertexSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, lodMinClamps, lodMaxClamps, range);
        }

        public void SetVertexVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , functionTable, bufferIndex);
        }

        public void SetVertexVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , functionTables, range);
        }

        public void SetVertexIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTable, bufferIndex);
        }

        public void SetVertexIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTables, range);
        }

        public void SetVertexAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , accelerationStructure, bufferIndex);
        }

        public void SetViewport(MTLViewport viewport)
        {
            objc_msgSend(NativePtr, , viewport);
        }

        public void SetViewports(MTLViewport viewports, ulong count)
        {
            objc_msgSend(NativePtr, , viewports, count);
        }

        public void SetFrontFacingWinding(MTLWinding frontFacingWinding)
        {
            objc_msgSend(NativePtr, , frontFacingWinding);
        }

        public void SetVertexAmplificationCount(ulong count, MTLVertexAmplificationViewMapping viewMappings)
        {
            objc_msgSend(NativePtr, , count, viewMappings);
        }

        public void SetCullMode(MTLCullMode cullMode)
        {
            objc_msgSend(NativePtr, , cullMode);
        }

        public void SetDepthClipMode(MTLDepthClipMode depthClipMode)
        {
            objc_msgSend(NativePtr, , depthClipMode);
        }

        public void SetDepthBias(float depthBias, float slopeScale, float clamp)
        {
            objc_msgSend(NativePtr, , depthBias, slopeScale, clamp);
        }

        public void SetScissorRect(MTLScissorRect rect)
        {
            objc_msgSend(NativePtr, , rect);
        }

        public void SetScissorRects(MTLScissorRect scissorRects, ulong count)
        {
            objc_msgSend(NativePtr, , scissorRects, count);
        }

        public void SetTriangleFillMode(MTLTriangleFillMode fillMode)
        {
            objc_msgSend(NativePtr, , fillMode);
        }

        public void SetFragmentBytes(IntPtr bytes, ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , bytes, length, index);
        }

        public void SetFragmentBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetFragmentBufferOffset(ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , offset, index);
        }

        public void SetFragmentBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetFragmentTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetFragmentTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetFragmentSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetFragmentSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public void SetFragmentSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetFragmentSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, lodMinClamps, lodMaxClamps, range);
        }

        public void SetFragmentVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , functionTable, bufferIndex);
        }

        public void SetFragmentVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , functionTables, range);
        }

        public void SetFragmentIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTable, bufferIndex);
        }

        public void SetFragmentIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTables, range);
        }

        public void SetFragmentAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , accelerationStructure, bufferIndex);
        }

        public void SetBlendColor(float red, float green, float blue, float alpha)
        {
            objc_msgSend(NativePtr, , red, green, blue, alpha);
        }

        public void SetDepthStencilState(MTLDepthStencilState depthStencilState)
        {
            objc_msgSend(NativePtr, , depthStencilState);
        }

        public void SetStencilReferenceValue(uint referenceValue)
        {
            objc_msgSend(NativePtr, , referenceValue);
        }

        public void SetStencilReferenceValues(uint frontReferenceValue, uint backReferenceValue)
        {
            objc_msgSend(NativePtr, , frontReferenceValue, backReferenceValue);
        }

        public void SetVisibilityResultMode(MTLVisibilityResultMode mode, ulong offset)
        {
            objc_msgSend(NativePtr, , mode, offset);
        }

        public void SetColorStoreAction(MTLStoreAction storeAction, ulong colorAttachmentIndex)
        {
            objc_msgSend(NativePtr, , storeAction, colorAttachmentIndex);
        }

        public void SetDepthStoreAction(MTLStoreAction storeAction)
        {
            objc_msgSend(NativePtr, , storeAction);
        }

        public void SetStencilStoreAction(MTLStoreAction storeAction)
        {
            objc_msgSend(NativePtr, , storeAction);
        }

        public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, ulong colorAttachmentIndex)
        {
            objc_msgSend(NativePtr, , storeActionOptions, colorAttachmentIndex);
        }

        public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            objc_msgSend(NativePtr, , storeActionOptions);
        }

        public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            objc_msgSend(NativePtr, , storeActionOptions);
        }

        public void SetObjectBytes(IntPtr bytes, ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , bytes, length, index);
        }

        public void SetObjectBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetObjectBufferOffset(ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , offset, index);
        }

        public void SetObjectBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetObjectTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetObjectTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetObjectSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetObjectSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public void SetObjectSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetObjectSamplerStates(MTLSamplerState[] samplers, float lodMinClamps, float lodMaxClamps, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, lodMinClamps, lodMaxClamps, range);
        }

        public void SetObjectThreadgroupMemoryLength(ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , length, index);
        }

        public void SetMeshBytes(IntPtr bytes, ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , bytes, length, index);
        }

        public void SetMeshBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetMeshBufferOffset(ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , offset, index);
        }

        public void SetMeshBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetMeshTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetMeshTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetMeshSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetMeshSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public void SetMeshSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetMeshSamplerStates(MTLSamplerState[] samplers, float lodMinClamps, float lodMaxClamps, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, lodMinClamps, lodMaxClamps, range);
        }

        public void DrawMeshThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            objc_msgSend(NativePtr, , threadgroupsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawMeshThreads(MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            objc_msgSend(NativePtr, , threadsPerGrid, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawMeshThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup)
        {
            objc_msgSend(NativePtr, , indirectBuffer, indirectBufferOffset, threadsPerObjectThreadgroup, threadsPerMeshThreadgroup);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount)
        {
            objc_msgSend(NativePtr, , primitiveType, vertexStart, vertexCount, instanceCount);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount)
        {
            objc_msgSend(NativePtr, , primitiveType, vertexStart, vertexCount);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount)
        {
            objc_msgSend(NativePtr, , primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset, instanceCount);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset)
        {
            objc_msgSend(NativePtr, , primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, ulong vertexStart, ulong vertexCount, ulong instanceCount, ulong baseInstance)
        {
            objc_msgSend(NativePtr, , primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, ulong indexCount, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, ulong instanceCount, long baseVertex, ulong baseInstance)
        {
            objc_msgSend(NativePtr, , primitiveType, indexCount, indexType, indexBuffer, indexBufferOffset, instanceCount, baseVertex, baseInstance);
        }

        public void DrawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , primitiveType, indirectBuffer, indirectBufferOffset);
        }

        public void DrawIndexedPrimitives(MTLPrimitiveType primitiveType, MTLIndexType indexType, MTLBuffer indexBuffer, ulong indexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , primitiveType, indexType, indexBuffer, indexBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void TextureBarrier()
        {
            objc_msgSend(NativePtr, , );
        }

        public void UpdateFence(MTLFence fence, MTLRenderStages stages)
        {
            objc_msgSend(NativePtr, , fence, stages);
        }

        public void WaitForFence(MTLFence fence, MTLRenderStages stages)
        {
            objc_msgSend(NativePtr, , fence, stages);
        }

        public void SetTessellationFactorBuffer(MTLBuffer buffer, ulong offset, ulong instanceStride)
        {
            objc_msgSend(NativePtr, , buffer, offset, instanceStride);
        }

        public void SetTessellationFactorScale(float scale)
        {
            objc_msgSend(NativePtr, , scale);
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, ulong instanceCount, ulong baseInstance)
        {
            objc_msgSend(NativePtr, , numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, instanceCount, baseInstance);
        }

        public void DrawPatches(ulong numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , numberOfPatchControlPoints, patchIndexBuffer, patchIndexBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, ulong patchStart, ulong patchCount, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, ulong instanceCount, ulong baseInstance)
        {
            objc_msgSend(NativePtr, , numberOfPatchControlPoints, patchStart, patchCount, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, instanceCount, baseInstance);
        }

        public void DrawIndexedPatches(ulong numberOfPatchControlPoints, MTLBuffer patchIndexBuffer, ulong patchIndexBufferOffset, MTLBuffer controlPointIndexBuffer, ulong controlPointIndexBufferOffset, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , numberOfPatchControlPoints, patchIndexBuffer, patchIndexBufferOffset, controlPointIndexBuffer, controlPointIndexBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void SetTileBytes(IntPtr bytes, ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , bytes, length, index);
        }

        public void SetTileBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetTileBufferOffset(ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , offset, index);
        }

        public void SetTileBuffers(MTLBuffer[] buffers, ulong offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetTileTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetTileTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetTileSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetTileSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public void SetTileSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetTileSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, lodMinClamps, lodMaxClamps, range);
        }

        public void SetTileVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , functionTable, bufferIndex);
        }

        public void SetTileVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , functionTables, range);
        }

        public void SetTileIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTable, bufferIndex);
        }

        public void SetTileIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTables, range);
        }

        public void SetTileAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , accelerationStructure, bufferIndex);
        }

        public void DispatchThreadsPerTile(MTLSize threadsPerTile)
        {
            objc_msgSend(NativePtr, , threadsPerTile);
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , length, offset, index);
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage)
        {
            objc_msgSend(NativePtr, , resource, usage);
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage)
        {
            objc_msgSend(NativePtr, , resources, count, usage);
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage, MTLRenderStages stages)
        {
            objc_msgSend(NativePtr, , resource, usage, stages);
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage, MTLRenderStages stages)
        {
            objc_msgSend(NativePtr, , resources, count, usage, stages);
        }

        public void UseHeap(MTLHeap heap)
        {
            objc_msgSend(NativePtr, , heap);
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count)
        {
            objc_msgSend(NativePtr, , heaps, count);
        }

        public void UseHeap(MTLHeap heap, MTLRenderStages stages)
        {
            objc_msgSend(NativePtr, , heap, stages);
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count, MTLRenderStages stages)
        {
            objc_msgSend(NativePtr, , heaps, count, stages);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            objc_msgSend(NativePtr, , indirectCommandBuffer, executionRange);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , indirectCommandbuffer, indirectRangeBuffer, indirectBufferOffset);
        }

        public void MemoryBarrier(MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before)
        {
            objc_msgSend(NativePtr, , scope, after, before);
        }

        public void MemoryBarrier(MTLResource[] resources, ulong count, MTLRenderStages after, MTLRenderStages before)
        {
            objc_msgSend(NativePtr, , resources, count, after, before);
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            objc_msgSend(NativePtr, , sampleBuffer, sampleIndex, barrier);
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
