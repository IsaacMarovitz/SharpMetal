using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLBlitPassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitPassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLBlitPassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLBlitPassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLBlitPassSampleBufferAttachmentDescriptor");
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
            objc_msgSend(NativePtr, , sampleBuffer);
        }

        public void SetStartOfEncoderSampleIndex(ulong startOfEncoderSampleIndex)
        {
            objc_msgSend(NativePtr, , startOfEncoderSampleIndex);
        }

        public void SetEndOfEncoderSampleIndex(ulong endOfEncoderSampleIndex)
        {
            objc_msgSend(NativePtr, , endOfEncoderSampleIndex);
        }

        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer:";
        private static readonly Selector sel_startOfEncoderSampleIndex = "startOfEncoderSampleIndex";
        private static readonly Selector sel_setStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";
        private static readonly Selector sel_endOfEncoderSampleIndex = "endOfEncoderSampleIndex";
        private static readonly Selector sel_setEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLBlitPassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitPassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLBlitPassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLBlitPassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLBlitPassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLBlitPassSampleBufferAttachmentDescriptor Object(ulong attachmentIndex)
        {
            throw new NotImplementedException();
        }

        public void SetObject(MTLBlitPassSampleBufferAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            objc_msgSend(NativePtr, , attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLBlitPassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBlitPassDescriptor obj) => obj.NativePtr;
        public MTLBlitPassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLBlitPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLBlitPassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        private static readonly Selector sel_blitPassDescriptor = "blitPassDescriptor";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}
