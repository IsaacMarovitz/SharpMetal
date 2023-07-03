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
    public struct MTLComputeCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputeCommandEncoder obj) => obj.NativePtr;
        public MTLComputeCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public MTLDispatchType DispatchType => (MTLDispatchType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dispatchType);

        public void SetComputePipelineState(MTLComputePipelineState state) {

        }

        public void SetBytes(IntPtr bytes, ulong length, ulong index) {

        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index) {

        }

        public void SetBufferOffset(ulong offset, ulong index) {

        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range) {

        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, ulong bufferIndex) {

        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range) {

        }

        public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong bufferIndex) {

        }

        public void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range) {

        }

        public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong bufferIndex) {

        }

        public void SetTexture(MTLTexture texture, ulong index) {

        }

        public void SetTextures(MTLTexture[] textures, NSRange range) {

        }

        public void SetSamplerState(MTLSamplerState sampler, ulong index) {

        }

        public void SetSamplerStates(MTLSamplerState[] samplers, NSRange range) {

        }

        public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, ulong index) {

        }

        public void SetSamplerStates(MTLSamplerState[] samplers, float[] lodMinClamps, float[] lodMaxClamps, NSRange range) {

        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index) {

        }

        public void SetImageblockWidth(ulong width, ulong height) {

        }

        public void SetStageInRegion(MTLRegion region) {

        }

        public void SetStageInRegion(MTLBuffer indirectBuffer, ulong indirectBufferOffset) {

        }

        public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup) {

        }

        public void DispatchThreadgroups(MTLBuffer indirectBuffer, ulong indirectBufferOffset, MTLSize threadsPerThreadgroup) {

        }

        public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup) {

        }

        public void UpdateFence(MTLFence fence) {

        }

        public void WaitForFence(MTLFence fence) {

        }

        public void UseResource(MTLResource resource, MTLResourceUsage usage) {

        }

        public void UseResources(MTLResource[] resources, ulong count, MTLResourceUsage usage) {

        }

        public void UseHeap(MTLHeap heap) {

        }

        public void UseHeaps(MTLHeap[] heaps, ulong count) {

        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange) {

        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, ulong indirectBufferOffset) {

        }

        public void MemoryBarrier(MTLBarrierScope scope) {

        }

        public void MemoryBarrier(MTLResource[] resources, ulong count) {

        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier) {

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
