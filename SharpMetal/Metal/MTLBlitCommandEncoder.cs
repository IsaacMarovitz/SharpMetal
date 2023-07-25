using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLBlitOption : ulong
    {
        None = 0,
        DepthFromDepthStencil = 1,
        StencilFromDepthStencil = 2,
        RowLinearPVRTC = 4,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLBlitCommandEncoder : MTLCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitCommandEncoder obj) => obj.NativePtr;
        public MTLBlitCommandEncoder(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLBlitCommandEncoder()
        {
            throw new NotImplementedException();
        }

        public void SynchronizeResource(MTLResource resource)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_synchronizeResource, resource);
        }

        public void SynchronizeTexture(MTLTexture texture, ulong slice, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_synchronizeTextureslicelevel, texture, slice, level);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceBuffer, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions, sourceBuffer, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin, (ulong)options);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, ulong destinationOffset, ulong destinationBytesPerRow, ulong destinationBytesPerImage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, ulong destinationOffset, ulong destinationBytesPerRow, ulong destinationBytesPerImage, MTLBlitOption options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (ulong)options);
        }

        public void GenerateMipmaps(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_generateMipmapsForTexture, texture);
        }

        public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_fillBufferrangevalue, buffer, range, value);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, ulong sliceCount, ulong levelCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount, sourceTexture, sourceSlice, sourceLevel, destinationTexture, destinationSlice, destinationLevel, sliceCount, levelCount);
        }

        public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromTexturetoTexture, sourceTexture, destinationTexture);
        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, MTLBuffer destinationBuffer, ulong destinationOffset, ulong size)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyFromBuffersourceOffsettoBufferdestinationOffsetsize, sourceBuffer, sourceOffset, destinationBuffer, destinationOffset, size);
        }

        public void UpdateFence(MTLFence fence)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFence, fence);
        }

        public void WaitForFence(MTLFence fence)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFence, fence);
        }

        public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, ulong mipLevel, ulong slice, bool resetCounters, MTLBuffer countersBuffer, ulong countersBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_getTextureAccessCountersregionmipLevelsliceresetCounterscountersBuffercountersBufferOffset, texture, region, mipLevel, slice, resetCounters, countersBuffer, countersBufferOffset);
        }

        public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, ulong mipLevel, ulong slice)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resetTextureAccessCountersregionmipLevelslice, texture, region, mipLevel, slice);
        }

        public void OptimizeContentsForGPUAccess(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForGPUAccess, texture);
        }

        public void OptimizeContentsForGPUAccess(MTLTexture texture, ulong slice, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForGPUAccessslicelevel, texture, slice, level);
        }

        public void OptimizeContentsForCPUAccess(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForCPUAccess, texture);
        }

        public void OptimizeContentsForCPUAccess(MTLTexture texture, ulong slice, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeContentsForCPUAccessslicelevel, texture, slice, level);
        }

        public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resetCommandsInBufferwithRange, buffer, range);
        }

        public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, ulong destinationIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyIndirectCommandBuffersourceRangedestinationdestinationIndex, source, sourceRange, destination, destinationIndex);
        }

        public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_optimizeIndirectCommandBufferwithRange, indirectCommandBuffer, range);
        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_sampleCountersInBufferatSampleIndexwithBarrier, sampleBuffer, sampleIndex, barrier);
        }

        public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, ulong destinationOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resolveCountersinRangedestinationBufferdestinationOffset, sampleBuffer, range, destinationBuffer, destinationOffset);
        }

        private static readonly Selector sel_synchronizeResource = "synchronizeResource:";
        private static readonly Selector sel_synchronizeTextureslicelevel = "synchronizeTexture:slice:level:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
        private static readonly Selector sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
        private static readonly Selector sel_copyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";
        private static readonly Selector sel_generateMipmapsForTexture = "generateMipmapsForTexture:";
        private static readonly Selector sel_fillBufferrangevalue = "fillBuffer:range:value:";
        private static readonly Selector sel_copyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";
        private static readonly Selector sel_copyFromTexturetoTexture = "copyFromTexture:toTexture:";
        private static readonly Selector sel_copyFromBuffersourceOffsettoBufferdestinationOffsetsize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";
        private static readonly Selector sel_updateFence = "updateFence:";
        private static readonly Selector sel_waitForFence = "waitForFence:";
        private static readonly Selector sel_getTextureAccessCountersregionmipLevelsliceresetCounterscountersBuffercountersBufferOffset = "getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:";
        private static readonly Selector sel_resetTextureAccessCountersregionmipLevelslice = "resetTextureAccessCounters:region:mipLevel:slice:";
        private static readonly Selector sel_optimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";
        private static readonly Selector sel_optimizeContentsForGPUAccessslicelevel = "optimizeContentsForGPUAccess:slice:level:";
        private static readonly Selector sel_optimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";
        private static readonly Selector sel_optimizeContentsForCPUAccessslicelevel = "optimizeContentsForCPUAccess:slice:level:";
        private static readonly Selector sel_resetCommandsInBufferwithRange = "resetCommandsInBuffer:withRange:";
        private static readonly Selector sel_copyIndirectCommandBuffersourceRangedestinationdestinationIndex = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";
        private static readonly Selector sel_optimizeIndirectCommandBufferwithRange = "optimizeIndirectCommandBuffer:withRange:";
        private static readonly Selector sel_sampleCountersInBufferatSampleIndexwithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";
        private static readonly Selector sel_resolveCountersinRangedestinationBufferdestinationOffset = "resolveCounters:inRange:destinationBuffer:destinationOffset:";
    }
}
