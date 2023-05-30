using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLResourceStatePassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStatePassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLResourceStatePassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceStatePassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLResourceStatePassSampleBufferAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCounterSampleBuffer SampleBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBuffer));
        public ulong StartOfEncoderSampleIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfEncoderSampleIndex);
        public ulong EndOfEncoderSampleIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfEncoderSampleIndex);

        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer:";
        private static readonly Selector sel_startOfEncoderSampleIndex = "startOfEncoderSampleIndex";
        private static readonly Selector sel_setStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex:";
        private static readonly Selector sel_endOfEncoderSampleIndex = "endOfEncoderSampleIndex";
        private static readonly Selector sel_setEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLResourceStatePassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStatePassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLResourceStatePassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceStatePassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLResourceStatePassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLResourceStatePassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStatePassDescriptor obj) => obj.NativePtr;
        public MTLResourceStatePassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceStatePassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLResourceStatePassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLResourceStatePassDescriptor ResourceStatePassDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceStatePassDescriptor));
        public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        private static readonly Selector sel_resourceStatePassDescriptor = "resourceStatePassDescriptor";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}
