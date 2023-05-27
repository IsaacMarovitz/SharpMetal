using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLBlitPassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr { get; }
        public static implicit operator IntPtr(MTLBlitPassSampleBufferAttachmentDescriptor descriptor) => descriptor.NativePtr;
        public MTLBlitPassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        // TODO: Needs MTLCounterSampleBuffer
        /*public MTLCounterSampleBuffer SampleBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBuffer));
            set => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_setSampleBuffer, value);
        }*/

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

        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer";
        private static readonly Selector sel_startOfEncoderSampleIndex = "startOfEncoderSampleIndex";
        private static readonly Selector sel_setStartOfEncoderSampleIndex = "setStartOfEncoderSampleIndex";
        private static readonly Selector sel_endOfEncoderSampleIndex = "endOfEncoderSampleIndex";
        private static readonly Selector sel_setEndOfEncoderSampleIndex = "setEndOfEncoderSampleIndex";
    }
}