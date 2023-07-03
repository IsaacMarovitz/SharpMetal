using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDispatchThreadgroupsIndirectArguments
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDispatchThreadgroupsIndirectArguments obj) => obj.NativePtr;
        public MTLDispatchThreadgroupsIndirectArguments(IntPtr ptr) => NativePtr = ptr;

        public uint threadgroupsPerGrid;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLStageInRegionIndirectArguments
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStageInRegionIndirectArguments obj) => obj.NativePtr;
        public MTLStageInRegionIndirectArguments(IntPtr ptr) => NativePtr = ptr;

        public uint stageInOrigin;

        public uint stageInSize;
    }

    [SupportedOSPlatform("macos")]
    public class MTLComputeCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputeCommandEncoder obj) => obj.NativePtr;
        public MTLComputeCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public MTLDispatchType DispatchType => (MTLDispatchType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dispatchType);

        public void SetComputePipelineState(MTLComputePipelineState state)
        {
            objc_msgSend(NativePtr, , state);
        }

        public void SetBytes(IntPtr bytes, ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , bytes, length, index);
        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetBufferOffset(ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , offset, index);
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , visibleFunctionTable, bufferIndex);
        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , visibleFunctionTables, range);
        }

        public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTable, bufferIndex);
        }

        public void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTables, range);
        }

        public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            objc_msgSend(NativePtr, , accelerationStructure, bufferIndex);
        }

        public void SetTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, lodMinClamps, lodMaxClamps, range);
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index)
        {
            objc_msgSend(NativePtr, , length, index);
        }

        public void SetImageblockWidth(ulong width, ulong height)
        {
            objc_msgSend(NativePtr, , width, height);
        }

        public void SetStageInRegion(MTLRegion region)
        {
            objc_msgSend(NativePtr, , region);
        }

        public void SetStageInRegion(MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , indirectBuffer, indirectBufferOffset);
        }

        public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
        {
            objc_msgSend(NativePtr, , threadgroupsPerGrid, threadsPerThreadgroup);
        }

        public void DispatchThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerThreadgroup)
        {
            objc_msgSend(NativePtr, , indirectBuffer, indirectBufferOffset, threadsPerThreadgroup);
        }

        public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
        {
            objc_msgSend(NativePtr, , threadsPerGrid, threadsPerThreadgroup);
        }

        public void UpdateFence(MTLFence fence)
        {
            objc_msgSend(NativePtr, , fence);
        }

        public void WaitForFence(MTLFence fence)
        {
            objc_msgSend(NativePtr, , fence);
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage)
        {
            objc_msgSend(NativePtr, , resource, usage);
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage)
        {
            objc_msgSend(NativePtr, , resources, count, usage);
        }

        public void UseHeap(MTLHeap heap)
        {
            objc_msgSend(NativePtr, , heap);
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count)
        {
            objc_msgSend(NativePtr, , heaps, count);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            objc_msgSend(NativePtr, , indirectCommandBuffer, executionRange);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, ulong indirectBufferOffset)
        {
            objc_msgSend(NativePtr, , indirectCommandbuffer, indirectRangeBuffer, indirectBufferOffset);
        }

        public void MemoryBarrier(MTLBarrierScope scope)
        {
            objc_msgSend(NativePtr, , scope);
        }

        public void MemoryBarrier(MTLResource[] resources, ulong count)
        {
            objc_msgSend(NativePtr, , resources, count);
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            objc_msgSend(NativePtr, , sampleBuffer, sampleIndex, barrier);
        }

        private static readonly Selector sel_dispatchType = "dispatchType";
        private static readonly Selector sel_setComputePipelineState = "setComputePipelineState:";
        private static readonly Selector sel_setByteslengthatIndex = "setBytes:length:atIndex:";
        private static readonly Selector sel_setBufferoffsetatIndex = "setBuffer:offset:atIndex:";
        private static readonly Selector sel_setBufferOffsetatIndex = "setBufferOffset:atIndex:";
        private static readonly Selector sel_setBuffersoffsetswithRange = "setBuffers:offsets:withRange:";
        private static readonly Selector sel_setVisibleFunctionTableatBufferIndex = "setVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVisibleFunctionTableswithBufferRange = "setVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_setIntersectionFunctionTableatBufferIndex = "setIntersectionFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setIntersectionFunctionTableswithBufferRange = "setIntersectionFunctionTables:withBufferRange:";
        private static readonly Selector sel_setAccelerationStructureatBufferIndex = "setAccelerationStructure:atBufferIndex:";
        private static readonly Selector sel_setTextureatIndex = "setTexture:atIndex:";
        private static readonly Selector sel_setTextureswithRange = "setTextures:withRange:";
        private static readonly Selector sel_setSamplerStateatIndex = "setSamplerState:atIndex:";
        private static readonly Selector sel_setSamplerStateswithRange = "setSamplerStates:withRange:";
        private static readonly Selector sel_setSamplerStatelodMinClamplodMaxClampatIndex = "setSamplerState:lodMinClamp:lodMaxClamp:atIndex:";
        private static readonly Selector sel_setSamplerStateslodMinClampslodMaxClampswithRange = "setSamplerStates:lodMinClamps:lodMaxClamps:withRange:";
        private static readonly Selector sel_setThreadgroupMemoryLengthatIndex = "setThreadgroupMemoryLength:atIndex:";
        private static readonly Selector sel_setImageblockWidthheight = "setImageblockWidth:height:";
        private static readonly Selector sel_setStageInRegion = "setStageInRegion:";
        private static readonly Selector sel_setStageInRegionWithIndirectBufferindirectBufferOffset = "setStageInRegionWithIndirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_dispatchThreadgroupsthreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";
        private static readonly Selector sel_dispatchThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:";
        private static readonly Selector sel_dispatchThreadsthreadsPerThreadgroup = "dispatchThreads:threadsPerThreadgroup:";
        private static readonly Selector sel_updateFence = "updateFence:";
        private static readonly Selector sel_waitForFence = "waitForFence:";
        private static readonly Selector sel_useResourceusage = "useResource:usage:";
        private static readonly Selector sel_useResourcescountusage = "useResources:count:usage:";
        private static readonly Selector sel_useHeap = "useHeap:";
        private static readonly Selector sel_useHeapscount = "useHeaps:count:";
        private static readonly Selector sel_executeCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";
        private static readonly Selector sel_executeCommandsInBufferindirectBufferindirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_memoryBarrierWithScope = "memoryBarrierWithScope:";
        private static readonly Selector sel_memoryBarrierWithResourcescount = "memoryBarrierWithResources:count:";
        private static readonly Selector sel_sampleCountersInBufferatSampleIndexwithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";
    }
}
