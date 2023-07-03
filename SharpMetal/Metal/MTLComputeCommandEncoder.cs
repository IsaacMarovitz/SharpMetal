using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
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
            throw new NotImplementedException();
        }

        public void SetBytes(IntPtr bytes, ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetBufferOffset(ulong offset, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            throw new NotImplementedException();
        }

        public void SetTexture(MTLTexture texture, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetSamplerState(MTLSamplerState sampler, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetImageblockWidth(ulong width, ulong height)
        {
            throw new NotImplementedException();
        }

        public void SetStageInRegion(MTLRegion region)
        {
            throw new NotImplementedException();
        }

        public void SetStageInRegion(MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            throw new NotImplementedException();
        }

        public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void DispatchThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
        {
            throw new NotImplementedException();
        }

        public void UpdateFence(MTLFence fence)
        {
            throw new NotImplementedException();
        }

        public void WaitForFence(MTLFence fence)
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

        public void UseHeap(MTLHeap heap)
        {
            throw new NotImplementedException();
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count)
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

        public void MemoryBarrier(MTLBarrierScope scope)
        {
            throw new NotImplementedException();
        }

        public void MemoryBarrier(MTLResource[] resources, ulong count)
        {
            throw new NotImplementedException();
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            throw new NotImplementedException();
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
