using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4Archive : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4Archive obj) => obj.NativePtr;
        public MTL4Archive(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBinaryFunctionWithDescriptorerror, descriptor, ref error.NativePtr));
        }

        public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithDescriptorerror, descriptor, ref error.NativePtr));
        }

        public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithDescriptordynamicLinkingDescriptorerror, descriptor, dynamicLinkingDescriptor, ref error.NativePtr));
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateWithDescriptorerror, descriptor, ref error.NativePtr));
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateWithDescriptordynamicLinkingDescriptorerror, descriptor, dynamicLinkingDescriptor, ref error.NativePtr));
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_newBinaryFunctionWithDescriptorerror = "newBinaryFunctionWithDescriptor:error:";
        private static readonly Selector sel_newComputePipelineStateWithDescriptordynamicLinkingDescriptorerror = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";
        private static readonly Selector sel_newComputePipelineStateWithDescriptorerror = "newComputePipelineStateWithDescriptor:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptordynamicLinkingDescriptorerror = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptorerror = "newRenderPipelineStateWithDescriptor:error:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_release = "release";
    }
}
