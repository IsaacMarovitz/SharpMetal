using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLPipelineBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPipelineBufferDescriptor descriptor) => descriptor.NativePtr;
        public MTLPipelineBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPipelineBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLPipelineBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLMutability Mutability
        {
            get => (MTLMutability)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mutability);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMutability, (ulong)value);
        }

        private static readonly Selector sel_mutability = "mutability";
        private static readonly Selector sel_setMutability = "setMutability";
    }
}