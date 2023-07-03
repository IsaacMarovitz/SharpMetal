using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLBlitOption: ulong
    {
        None = 0,
        DepthFromDepthStencil = 1,
        StencilFromDepthStencil = 2,
        RowLinearPVRTC = 4,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLBlitCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitCommandEncoder obj) => obj.NativePtr;
        public MTLBlitCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void SynchronizeResource(MTLResource resource) {

        }

        public void SynchronizeTexture(MTLTexture texture, ulong slice, ulong level) {

        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin) {

        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin) {

        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options) {

        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, ulong destinationOffset, ulong destinationBytesPerRow, ulong destinationBytesPerImage) {

        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, ulong destinationOffset, ulong destinationBytesPerRow, ulong destinationBytesPerImage, MTLBlitOption options) {

        }

        public void GenerateMipmaps(MTLTexture texture) {

        }

        public void FillBuffer(MTLBuffer buffer, NSRange range, byte value) {

        }

        public void CopyFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, ulong sliceCount, ulong levelCount) {

        }

        public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture) {

        }

        public void CopyFromBuffer(MTLBuffer sourceBuffer, ulong sourceOffset, MTLBuffer destinationBuffer, ulong destinationOffset, ulong size) {

        }

        public void UpdateFence(MTLFence fence) {

        }

        public void WaitForFence(MTLFence fence) {

        }

        public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, ulong mipLevel, ulong slice, bool resetCounters, MTLBuffer countersBuffer, ulong countersBufferOffset) {

        }

        public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, ulong mipLevel, ulong slice) {

        }

        public void OptimizeContentsForGPUAccess(MTLTexture texture) {

        }

        public void OptimizeContentsForGPUAccess(MTLTexture texture, ulong slice, ulong level) {

        }

        public void OptimizeContentsForCPUAccess(MTLTexture texture) {

        }

        public void OptimizeContentsForCPUAccess(MTLTexture texture, ulong slice, ulong level) {

        }

        public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range) {

        }

        public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, ulong destinationIndex) {

        }

        public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range) {

        }

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier) {

        }

        public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, ulong destinationOffset) {

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
