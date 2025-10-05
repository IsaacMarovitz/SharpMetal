using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4ComputeCommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ComputeCommandEncoder obj) => obj.NativePtr;
        public static implicit operator MTL4CommandEncoder(MTL4ComputeCommandEncoder obj) => new(obj.NativePtr);
        public MTL4ComputeCommandEncoder(IntPtr ptr) => NativePtr = ptr;

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

        public MTLStages Stages => (MTLStages)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stages);

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

        public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTL4BufferRange scratchBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_buildAccelerationStructuredescriptorscratchBuffer, accelerationStructure, descriptor, scratchBuffer);
        }

        public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyAccelerationStructuretoAccelerationStructure, sourceAccelerationStructure, destinationAccelerationStructure);
        }

        public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyAndCompactAccelerationStructuretoAccelerationStructure, sourceAccelerationStructure, destinationAccelerationStructure);
        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceBuffer, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions, sourceBuffer, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin, (ulong)options);
        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, MTLBuffer destinationBuffer, ulong destinationOffset, ulong size)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromBuffersourceOffsettoBufferdestinationOffsetsize, sourceBuffer, sourceOffset, destinationBuffer, destinationOffset, size);
        }

        public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTensorsourceOriginsourceDimensionstoTensordestinationOrigindestinationDimensions, sourceTensor, sourceOrigin, sourceDimensions, destinationTensor, destinationOrigin, destinationDimensions);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturetoTexture, sourceTexture, destinationTexture);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, ulong sliceCount, ulong levelCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount, sourceTexture, sourceSlice, sourceLevel, destinationTexture, destinationSlice, destinationLevel, sliceCount, levelCount);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, ulong destinationOffset, ulong destinationBytesPerRow, ulong destinationBytesPerImage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, ulong destinationOffset, ulong destinationBytesPerRow, ulong destinationBytesPerImage, MTLBlitOption options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (ulong)options);
        }

        public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, ulong destinationIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyIndirectCommandBuffersourceRangedestinationdestinationIndex, source, sourceRange, destination, destinationIndex);
        }

        public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadgroupsthreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
        }

        public void DispatchThreadgroups(ulong indirectBuffer, MTLSize threadsPerThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadgroupsWithIndirectBufferthreadsPerThreadgroup, indirectBuffer, threadsPerThreadgroup);
        }

        public void DispatchThreads(ulong indirectBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadsWithIndirectBuffer, indirectBuffer);
        }

        public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_dispatchThreadsthreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
        }

        public void EndEncoding()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endEncoding);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferwithRange, indirectCommandBuffer, executionRange);
        }

        public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, ulong indirectRangeBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_executeCommandsInBufferindirectBuffer, indirectCommandbuffer, indirectRangeBuffer);
        }

        public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_fillBufferrangevalue, buffer, range, value);
        }

        public void GenerateMipmaps(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_generateMipmapsForTexture, texture);
        }

        public void InsertDebugSignpost(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_insertDebugSignpost, nsString);
        }

        public void OptimizeContentsForCPUAccess(MTLTexture texture, ulong slice, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForCPUAccessslicelevel, texture, slice, level);
        }

        public void OptimizeContentsForCPUAccess(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForCPUAccess, texture);
        }

        public void OptimizeContentsForGPUAccess(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForGPUAccess, texture);
        }

        public void OptimizeContentsForGPUAccess(MTLTexture texture, ulong slice, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForGPUAccessslicelevel, texture, slice, level);
        }

        public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeIndirectCommandBufferwithRange, indirectCommandBuffer, range);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_refitAccelerationStructuredescriptordestinationscratchBuffer, sourceAccelerationStructure, descriptor, destinationAccelerationStructure, scratchBuffer);
        }

        public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTL4AccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTL4BufferRange scratchBuffer, MTLAccelerationStructureRefitOptions options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_refitAccelerationStructuredescriptordestinationscratchBufferoptions, sourceAccelerationStructure, descriptor, destinationAccelerationStructure, scratchBuffer, (ulong)options);
        }

        public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resetCommandsInBufferwithRange, buffer, range);
        }

        public void SetArgumentTable(MTL4ArgumentTable argumentTable)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArgumentTable, argumentTable);
        }

        public void SetComputePipelineState(MTLComputePipelineState state)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setComputePipelineState, state);
        }

        public void SetImageblockWidth(ulong width, ulong height)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setImageblockWidthheight, width, height);
        }

        public void SetThreadgroupMemoryLength(ulong length, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLengthatIndex, length, index);
        }

        public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFenceafterEncoderStages, fence, (ulong)afterEncoderStages);
        }

        public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFencebeforeEncoderStages, fence, (ulong)beforeEncoderStages);
        }

        public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTL4BufferRange buffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_writeCompactedAccelerationStructureSizetoBuffer, accelerationStructure, buffer);
        }

        public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_writeTimestampWithGranularityintoHeapatIndex, (long)granularity, counterHeap, index);
        }

        private static readonly Selector sel_barrierAfterEncoderStagesbeforeEncoderStagesvisibilityOptions = "barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:";
        private static readonly Selector sel_barrierAfterQueueStagesbeforeStagesvisibilityOptions = "barrierAfterQueueStages:beforeStages:visibilityOptions:";
        private static readonly Selector sel_barrierAfterStagesbeforeQueueStagesvisibilityOptions = "barrierAfterStages:beforeQueueStages:visibilityOptions:";
        private static readonly Selector sel_buildAccelerationStructuredescriptorscratchBuffer = "buildAccelerationStructure:descriptor:scratchBuffer:";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_copyAccelerationStructuretoAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";
        private static readonly Selector sel_copyAndCompactAccelerationStructuretoAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";
        private static readonly Selector sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
        private static readonly Selector sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";
        private static readonly Selector sel_copyFromBuffersourceOffsettoBufferdestinationOffsetsize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";
        private static readonly Selector sel_copyFromTensorsourceOriginsourceDimensionstoTensordestinationOrigindestinationDimensions = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";
        private static readonly Selector sel_copyFromTexturetoTexture = "copyFromTexture:toTexture:";
        private static readonly Selector sel_copyIndirectCommandBuffersourceRangedestinationdestinationIndex = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";
        private static readonly Selector sel_dispatchThreadgroupsthreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";
        private static readonly Selector sel_dispatchThreadgroupsWithIndirectBufferthreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:threadsPerThreadgroup:";
        private static readonly Selector sel_dispatchThreadsthreadsPerThreadgroup = "dispatchThreads:threadsPerThreadgroup:";
        private static readonly Selector sel_dispatchThreadsWithIndirectBuffer = "dispatchThreadsWithIndirectBuffer:";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_executeCommandsInBufferindirectBuffer = "executeCommandsInBuffer:indirectBuffer:";
        private static readonly Selector sel_executeCommandsInBufferwithRange = "executeCommandsInBuffer:withRange:";
        private static readonly Selector sel_fillBufferrangevalue = "fillBuffer:range:value:";
        private static readonly Selector sel_generateMipmapsForTexture = "generateMipmapsForTexture:";
        private static readonly Selector sel_insertDebugSignpost = "insertDebugSignpost:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_optimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";
        private static readonly Selector sel_optimizeContentsForCPUAccessslicelevel = "optimizeContentsForCPUAccess:slice:level:";
        private static readonly Selector sel_optimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";
        private static readonly Selector sel_optimizeContentsForGPUAccessslicelevel = "optimizeContentsForGPUAccess:slice:level:";
        private static readonly Selector sel_optimizeIndirectCommandBufferwithRange = "optimizeIndirectCommandBuffer:withRange:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_refitAccelerationStructuredescriptordestinationscratchBuffer = "refitAccelerationStructure:descriptor:destination:scratchBuffer:";
        private static readonly Selector sel_refitAccelerationStructuredescriptordestinationscratchBufferoptions = "refitAccelerationStructure:descriptor:destination:scratchBuffer:options:";
        private static readonly Selector sel_resetCommandsInBufferwithRange = "resetCommandsInBuffer:withRange:";
        private static readonly Selector sel_setArgumentTable = "setArgumentTable:";
        private static readonly Selector sel_setComputePipelineState = "setComputePipelineState:";
        private static readonly Selector sel_setImageblockWidthheight = "setImageblockWidth:height:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setThreadgroupMemoryLengthatIndex = "setThreadgroupMemoryLength:atIndex:";
        private static readonly Selector sel_stages = "stages";
        private static readonly Selector sel_updateFenceafterEncoderStages = "updateFence:afterEncoderStages:";
        private static readonly Selector sel_waitForFencebeforeEncoderStages = "waitForFence:beforeEncoderStages:";
        private static readonly Selector sel_writeCompactedAccelerationStructureSizetoBuffer = "writeCompactedAccelerationStructureSize:toBuffer:";
        private static readonly Selector sel_writeTimestampWithGranularityintoHeapatIndex = "writeTimestampWithGranularity:intoHeap:atIndex:";
        private static readonly Selector sel_release = "release";
    }
}
