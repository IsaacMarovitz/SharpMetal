using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4Compiler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4Compiler obj) => obj.NativePtr;
        public MTL4Compiler(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public MTL4PipelineDataSetSerializer PipelineDataSetSerializer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_pipelineDataSetSerializer));

        public MTL4BinaryFunction NewBinaryFunction(MTL4BinaryFunctionDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBinaryFunctionWithDescriptorcompilerTaskOptionserror, descriptor, compilerTaskOptions, ref error.NativePtr));
        }

        public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithDescriptorcompilerTaskOptionserror, descriptor, compilerTaskOptions, ref error.NativePtr));
        }

        public MTLComputePipelineState NewComputePipelineState(MTL4ComputePipelineDescriptor descriptor, MTL4PipelineStageDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror, descriptor, dynamicLinkingDescriptor, compilerTaskOptions, ref error.NativePtr));
        }

        public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newDynamicLibraryerror, library, ref error.NativePtr));
        }

        public MTLDynamicLibrary NewDynamicLibrary(NSURL url, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newDynamicLibraryWithURLerror, url, ref error.NativePtr));
        }

        public MTLLibrary NewLibrary(MTL4LibraryDescriptor descriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newLibraryWithDescriptorerror, descriptor, ref error.NativePtr));
        }

        public MTL4MachineLearningPipelineState NewMachineLearningPipelineState(MTL4MachineLearningPipelineDescriptor descriptor, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newMachineLearningPipelineStateWithDescriptorerror, descriptor, ref error.NativePtr));
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4CompilerTaskOptions compilerTaskOptions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateWithDescriptorcompilerTaskOptionserror, descriptor, compilerTaskOptions, ref error.NativePtr));
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTL4PipelineDescriptor descriptor, MTL4RenderPipelineDynamicLinkingDescriptor dynamicLinkingDescriptor, MTL4CompilerTaskOptions compilerTaskOptions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror, descriptor, dynamicLinkingDescriptor, compilerTaskOptions, ref error.NativePtr));
        }

        public MTLRenderPipelineState NewRenderPipelineStateBySpecialization(MTL4PipelineDescriptor descriptor, MTLRenderPipelineState pipeline, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateBySpecializationWithDescriptorpipelineerror, descriptor, pipeline, ref error.NativePtr));
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_newBinaryFunctionWithDescriptorcompilerTaskOptionserror = "newBinaryFunctionWithDescriptor:compilerTaskOptions:error:";
        private static readonly Selector sel_newComputePipelineStateWithDescriptorcompilerTaskOptionserror = "newComputePipelineStateWithDescriptor:compilerTaskOptions:error:";
        private static readonly Selector sel_newComputePipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror = "newComputePipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";
        private static readonly Selector sel_newDynamicLibraryerror = "newDynamicLibrary:error:";
        private static readonly Selector sel_newDynamicLibraryWithURLerror = "newDynamicLibraryWithURL:error:";
        private static readonly Selector sel_newLibraryWithDescriptorerror = "newLibraryWithDescriptor:error:";
        private static readonly Selector sel_newMachineLearningPipelineStateWithDescriptorerror = "newMachineLearningPipelineStateWithDescriptor:error:";
        private static readonly Selector sel_newRenderPipelineStateBySpecializationWithDescriptorpipelineerror = "newRenderPipelineStateBySpecializationWithDescriptor:pipeline:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptorcompilerTaskOptionserror = "newRenderPipelineStateWithDescriptor:compilerTaskOptions:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptordynamicLinkingDescriptorcompilerTaskOptionserror = "newRenderPipelineStateWithDescriptor:dynamicLinkingDescriptor:compilerTaskOptions:error:";
        private static readonly Selector sel_pipelineDataSetSerializer = "pipelineDataSetSerializer";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CompilerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CompilerDescriptor obj) => obj.NativePtr;
        public MTL4CompilerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4CompilerDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4CompilerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_pipelineDataSetSerializer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPipelineDataSetSerializer, value);
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_pipelineDataSetSerializer = "pipelineDataSetSerializer";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setPipelineDataSetSerializer = "setPipelineDataSetSerializer:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CompilerTaskOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CompilerTaskOptions obj) => obj.NativePtr;
        public MTL4CompilerTaskOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4CompilerTaskOptions()
        {
            var cls = new ObjectiveCClass("MTL4CompilerTaskOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray LookupArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_lookupArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLookupArchives, value);
        }

        private static readonly Selector sel_lookupArchives = "lookupArchives";
        private static readonly Selector sel_setLookupArchives = "setLookupArchives:";
        private static readonly Selector sel_release = "release";
    }
}
