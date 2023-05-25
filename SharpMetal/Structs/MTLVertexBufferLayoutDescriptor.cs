using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLVertexBufferLayoutDescriptor
    {
        public readonly IntPtr NativePtr { get; }
        public MTLVertexBufferLayoutDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexBufferLayoutDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVertexBufferLayoutDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLVertexStepFunction StepFunction
        {
            get => (MTLVertexStepFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stepFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStepFunction, (ulong)value);
        }

        public ulong StepRate
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stepRate);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStepRate);
        }

        public ulong Stride
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stride);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStride);
        }

        private static readonly Selector sel_stepFunction = "stepFunction";
        private static readonly Selector sel_setStepFunction = "setStepFunction:";
        private static readonly Selector sel_stepRate = "stepRate";
        private static readonly Selector sel_setStepRate = "setStepRate:";
        private static readonly Selector sel_stride = "stride";
        private static readonly Selector sel_setStride = "setStride:";
    }
}