using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4ComputePipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ComputePipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4ComputePipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4ComputePipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4ComputePipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4ComputePipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTL4FunctionDescriptor ComputeFunctionDescriptor

        // missing NSString Label

        // missing ulong MaxTotalThreadsPerThreadgroup

        // missing MTL4PipelineOptions Options

        // missing MTLSize RequiredThreadsPerThreadgroup

        // missing MTL4StaticLinkingDescriptor StaticLinkingDescriptor

        // missing bool SupportBinaryLinking

        // missing MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers

        // missing bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
        private static readonly Selector sel_release = "release";
    }
}
