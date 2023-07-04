using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLAccelerationStructureRefitOptions : ulong
    {
        AccelerationStructureRefitOptionVertexData = 1,
        AccelerationStructureRefitOptionPerPrimitiveData = 2,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLAccelerationStructureCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureCommandEncoder obj) => obj.NativePtr;
        public MTLAccelerationStructureCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, ulong scratchBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_buildAccelerationStructuredescriptorscratchBufferscratchBufferOffset, accelerationStructure, descriptor, scratchBuffer, scratchBufferOffset);
        }

        public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, ulong scratchBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_refitAccelerationStructuredescriptordestinationscratchBufferscratchBufferOffset, sourceAccelerationStructure, descriptor, destinationAccelerationStructure, scratchBuffer, scratchBufferOffset);
        }

        public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, ulong scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_refitAccelerationStructuredescriptordestinationscratchBufferscratchBufferOffsetoptions, sourceAccelerationStructure, descriptor, destinationAccelerationStructure, scratchBuffer, scratchBufferOffset, (ulong)options);
        }

        public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyAccelerationStructuretoAccelerationStructure, sourceAccelerationStructure, destinationAccelerationStructure);
        }

        public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, ulong offset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_writeCompactedAccelerationStructureSizetoBufferoffset, accelerationStructure, buffer, offset);
        }

        public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, ulong offset, MTLDataType sizeDataType)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_writeCompactedAccelerationStructureSizetoBufferoffsetsizeDataType, accelerationStructure, buffer, offset, (ulong)sizeDataType);
        }

        public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyAndCompactAccelerationStructuretoAccelerationStructure, sourceAccelerationStructure, destinationAccelerationStructure);
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

        public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, ulong sampleIndex, bool barrier)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_sampleCountersInBufferatSampleIndexwithBarrier, sampleBuffer, sampleIndex, barrier);
        }

        private static readonly Selector sel_buildAccelerationStructuredescriptorscratchBufferscratchBufferOffset = "buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:";
        private static readonly Selector sel_refitAccelerationStructuredescriptordestinationscratchBufferscratchBufferOffset = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:";
        private static readonly Selector sel_refitAccelerationStructuredescriptordestinationscratchBufferscratchBufferOffsetoptions = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:options:";
        private static readonly Selector sel_copyAccelerationStructuretoAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";
        private static readonly Selector sel_writeCompactedAccelerationStructureSizetoBufferoffset = "writeCompactedAccelerationStructureSize:toBuffer:offset:";
        private static readonly Selector sel_writeCompactedAccelerationStructureSizetoBufferoffsetsizeDataType = "writeCompactedAccelerationStructureSize:toBuffer:offset:sizeDataType:";
        private static readonly Selector sel_copyAndCompactAccelerationStructuretoAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";
        private static readonly Selector sel_updateFence = "updateFence:";
        private static readonly Selector sel_waitForFence = "waitForFence:";
        private static readonly Selector sel_useResourceusage = "useResource:usage:";
        private static readonly Selector sel_useResourcescountusage = "useResources:count:usage:";
        private static readonly Selector sel_useHeap = "useHeap:";
        private static readonly Selector sel_useHeapscount = "useHeaps:count:";
        private static readonly Selector sel_sampleCountersInBufferatSampleIndexwithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCounterSampleBuffer SampleBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleBuffer, value);
        }

        public ulong StartOfEncoderSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfEncoderSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfEncoderSampleIndex, value);
        }

        public ulong EndOfEncoderSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfEncoderSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfEncoderSampleIndex, value);
        }

        public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleBuffer, sampleBuffer);
        }

        public void SetStartOfEncoderSampleIndex(ulong startOfEncoderSampleIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfEncoderSampleIndex, startOfEncoderSampleIndex);
        }

        public void SetEndOfEncoderSampleIndex(ulong endOfEncoderSampleIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfEncoderSampleIndex, endOfEncoderSampleIndex);
        }

        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer:";
        private static readonly Selector sel_startOfEncoderSampleIndex = "startOfEncoderSampleIndex";
        private static readonly Selector sel_setStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";
        private static readonly Selector sel_endOfEncoderSampleIndex = "endOfEncoderSampleIndex";
        private static readonly Selector sel_setEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor Object(ulong attachmentIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, attachmentIndex));
        }

        public void SetObject(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLAccelerationStructurePassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructurePassDescriptor obj) => obj.NativePtr;
        public MTLAccelerationStructurePassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLAccelerationStructurePassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLAccelerationStructurePassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        private static readonly Selector sel_accelerationStructurePassDescriptor = "accelerationStructurePassDescriptor";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}
