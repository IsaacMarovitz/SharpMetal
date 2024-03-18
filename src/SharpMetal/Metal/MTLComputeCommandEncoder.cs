using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLDispatchThreadgroupsIndirectArguments
    {
        public uint threadgroupsPerGrid;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLStageInRegionIndirectArguments
    {
        public uint stageInOrigin;
        public uint stageInSize;
    }

    [SupportedOSPlatform("macos")]
    public class MTLComputeCommandEncoder : MTLCommandEncoder
    {
        public static implicit operator IntPtr(MTLComputeCommandEncoder obj) => obj.NativePtr;
        public MTLComputeCommandEncoder(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        public MTLDispatchType DispatchType => (MTLDispatchType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dispatchType);

        public void SetComputePipelineState(MTLComputePipelineState state)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setComputePipelineState, state);
        }

        public void SetBytes(IntPtr bytes, ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setByteslengthatIndex, bytes, length, index);
        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetBufferOffset(ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferOffsetatIndex, offset, index);
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong stride, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferoffsetattributeStrideatIndex, buffer, offset, stride, index);
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong offsets, ulong strides, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetBufferOffset(ulong offset, ulong stride, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferOffsetattributeStrideatIndex, offset, stride, index);
        }

        public void SetBytes(IntPtr bytes, ulong length, ulong stride, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setByteslengthattributeStrideatIndex, bytes, length, stride, index);
        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibleFunctionTableatBufferIndex, visibleFunctionTable, bufferIndex);
        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIntersectionFunctionTableatBufferIndex, intersectionFunctionTable, bufferIndex);
        }

        public void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAccelerationStructureatBufferIndex, accelerationStructure, bufferIndex);
        }

        public void SetTexture(MTLTexture texture, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTextureatIndex, texture, index);
        }

        public void SetTextures(MTLTexture[] textures, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetSamplerState(MTLSamplerState sampler, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSamplerStateatIndex, sampler, index);
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSamplerStatelodMinClamplodMaxClampatIndex, sampler, lodMinClamp, lodMaxClamp, index);
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLengthatIndex, length, index);
        }

        public void SetImageblockWidth(ulong width, ulong height)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setImageblockWidthheight, width, height);
        }

        public void SetStageInRegion(MTLRegion region)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStageInRegion, region);
        }

        public void SetStageInRegion(MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStageInRegionWithIndirectBufferindirectBufferOffset, indirectBuffer, indirectBufferOffset);
        }

        public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadgroupsthreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
        }

        public void DispatchThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadgroupsWithIndirectBufferindirectBufferOffsetthreadsPerThreadgroup, indirectBuffer, indirectBufferOffset, threadsPerThreadgroup);
        }

        public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadsthreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
        }

        public void UpdateFence(MTLFence fence)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFence, fence);
        }

        public void WaitForFence(MTLFence fence)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFence, fence);
        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResourceusage, resource, (ulong)usage);
        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage)
        {
            throw new NotImplementedException();
        }

        public void UseHeap(MTLHeap heap)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useHeap, heap);
        }

        public void UseHeaps(MTLHeap[] heaps, ulong count)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferwithRange, indirectCommandBuffer, executionRange);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferindirectBufferindirectBufferOffset, indirectCommandbuffer, indirectRangeBuffer, indirectBufferOffset);
        }

        public void MemoryBarrier(MTLBarrierScope scope)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_memoryBarrierWithScope, (ulong)scope);
        }

        public void MemoryBarrier(MTLResource[] resources, ulong count)
        {
            throw new NotImplementedException();
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_sampleCountersInBufferatSampleIndexwithBarrier, sampleBuffer, sampleIndex, barrier);
        }

        private static readonly Selector sel_dispatchType = "dispatchType";
        private static readonly Selector sel_setComputePipelineState = "setComputePipelineState:";
        private static readonly Selector sel_setByteslengthatIndex = "setBytes:length:atIndex:";
        private static readonly Selector sel_setBufferoffsetatIndex = "setBuffer:offset:atIndex:";
        private static readonly Selector sel_setBufferOffsetatIndex = "setBufferOffset:atIndex:";
        private static readonly Selector sel_setBuffersoffsetswithRange = "setBuffers:offsets:withRange:";
        private static readonly Selector sel_setBufferoffsetattributeStrideatIndex = "setBuffer:offset:attributeStride:atIndex:";
        private static readonly Selector sel_setBuffersoffsetsattributeStrideswithRange = "setBuffers:offsets:attributeStrides:withRange:";
        private static readonly Selector sel_setBufferOffsetattributeStrideatIndex = "setBufferOffset:attributeStride:atIndex:";
        private static readonly Selector sel_setByteslengthattributeStrideatIndex = "setBytes:length:attributeStride:atIndex:";
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
