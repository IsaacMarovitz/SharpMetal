using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLComputePassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLComputePassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLComputePassSampleBufferAttachmentDescriptor");
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
            throw new NotImplementedException();
        }

        public void SetStartOfEncoderSampleIndex(ulong startOfEncoderSampleIndex)
        {
            throw new NotImplementedException();
        }

        public void SetEndOfEncoderSampleIndex(ulong endOfEncoderSampleIndex)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer:";
        private static readonly Selector sel_startOfEncoderSampleIndex = "startOfEncoderSampleIndex";
        private static readonly Selector sel_setStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";
        private static readonly Selector sel_endOfEncoderSampleIndex = "endOfEncoderSampleIndex";
        private static readonly Selector sel_setEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLComputePassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLComputePassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLComputePassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLComputePassSampleBufferAttachmentDescriptor Object(ulong attachmentIndex)
        {
            throw new NotImplementedException();
        }

        public void SetObject(MTLComputePassSampleBufferAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLComputePassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePassDescriptor obj) => obj.NativePtr;
        public MTLComputePassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLComputePassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLDispatchType DispatchType
        {
            get => (MTLDispatchType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dispatchType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDispatchType, (ulong)value);
        }

        public MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        public void SetDispatchType(MTLDispatchType dispatchType)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_computePassDescriptor = "computePassDescriptor";
        private static readonly Selector sel_dispatchType = "dispatchType";
        private static readonly Selector sel_setDispatchType = "setDispatchType:";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}
