using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLComputePipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineDescriptor obj) => obj.NativePtr;
        public MTLComputePipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLComputePipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
        }

        public MTLPipelineBufferDescriptorArray Buffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffers));

        public MTLFunction ComputeFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setComputeFunction, value);
        }

        public NSArray InsertLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_insertLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInsertLibraries, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLLinkedFunctions LinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_linkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLinkedFunctions, value);
        }

        public ulong MaxCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCallStackDepth, value);
        }

        public ulong MaxTotalThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerThreadgroup, value);
        }

        public NSArray PreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreloadedLibraries, value);
        }

        public MTLSize RequiredThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_requiredThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRequiredThreadsPerThreadgroup, value);
        }

        public MTLShaderValidation ShaderValidation
        {
            get => (MTLShaderValidation)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_shaderValidation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShaderValidation, (long)value);
        }

        public MTLStageInputOutputDescriptor StageInputDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stageInputDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStageInputDescriptor, value);
        }

        public bool SupportAddingBinaryFunctions
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingBinaryFunctions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAddingBinaryFunctions, value);
        }

        public bool SupportIndirectCommandBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, value);
        }

        public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadGroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_buffers = "buffers";
        private static readonly Selector sel_computeFunction = "computeFunction";
        private static readonly Selector sel_insertLibraries = "insertLibraries";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_linkedFunctions = "linkedFunctions";
        private static readonly Selector sel_maxCallStackDepth = "maxCallStackDepth";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_preloadedLibraries = "preloadedLibraries";
        private static readonly Selector sel_requiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
        private static readonly Selector sel_setComputeFunction = "setComputeFunction:";
        private static readonly Selector sel_setInsertLibraries = "setInsertLibraries:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setLinkedFunctions = "setLinkedFunctions:";
        private static readonly Selector sel_setMaxCallStackDepth = "setMaxCallStackDepth:";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
        private static readonly Selector sel_setPreloadedLibraries = "setPreloadedLibraries:";
        private static readonly Selector sel_setRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";
        private static readonly Selector sel_setShaderValidation = "setShaderValidation:";
        private static readonly Selector sel_setStageInputDescriptor = "setStageInputDescriptor:";
        private static readonly Selector sel_setSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth = "setThreadGroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_shaderValidation = "shaderValidation";
        private static readonly Selector sel_stageInputDescriptor = "stageInputDescriptor";
        private static readonly Selector sel_supportAddingBinaryFunctions = "supportAddingBinaryFunctions";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_threadGroupSizeIsMultipleOfThreadExecutionWidth = "threadGroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLComputePipelineReflection : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineReflection obj) => obj.NativePtr;
        public MTLComputePipelineReflection(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePipelineReflection()
        {
            var cls = new ObjectiveCClass("MTLComputePipelineReflection");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray Arguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arguments));

        public NSArray Bindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bindings));

        private static readonly Selector sel_arguments = "arguments";
        private static readonly Selector sel_bindings = "bindings";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLComputePipelineState : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineState obj) => obj.NativePtr;
        public static implicit operator MTLAllocation(MTLComputePipelineState obj) => new(obj.NativePtr);
        public MTLComputePipelineState(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);

        public MTLComputePipelineReflection Reflection => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_reflection));

        public MTLSize RequiredThreadsPerThreadgroup => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_requiredThreadsPerThreadgroup);

        public MTLShaderValidation ShaderValidation => (MTLShaderValidation)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_shaderValidation);

        public ulong StaticThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_staticThreadgroupMemoryLength);

        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);

        public ulong ThreadExecutionWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadExecutionWidth);

        public MTLFunctionHandle FunctionHandle(NSString name)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionHandleWithName, name));
        }

        public MTLFunctionHandle FunctionHandle(MTL4BinaryFunction function)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionHandleWithBinaryFunction, function));
        }

        public MTLFunctionHandle FunctionHandle(MTLFunction function)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionHandleWithFunction, function));
        }

        public ulong ImageblockMemoryLength(MTLSize imageblockDimensions)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockMemoryLengthForDimensions, imageblockDimensions);
        }

        public MTLComputePipelineState NewComputePipelineState(NSArray functions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithAdditionalBinaryFunctionserror, functions, ref error.NativePtr));
        }

        public MTLComputePipelineState NewComputePipelineStateWithBinaryFunctions(NSArray additionalBinaryFunctions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithBinaryFunctionserror, additionalBinaryFunctions, ref error.NativePtr));
        }

        public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newIntersectionFunctionTableWithDescriptor, descriptor));
        }

        public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newVisibleFunctionTableWithDescriptor, descriptor));
        }

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_functionHandleWithBinaryFunction = "functionHandleWithBinaryFunction:";
        private static readonly Selector sel_functionHandleWithFunction = "functionHandleWithFunction:";
        private static readonly Selector sel_functionHandleWithName = "functionHandleWithName:";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_imageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_newComputePipelineStateWithAdditionalBinaryFunctionserror = "newComputePipelineStateWithAdditionalBinaryFunctions:error:";
        private static readonly Selector sel_newComputePipelineStateWithBinaryFunctionserror = "newComputePipelineStateWithBinaryFunctions:error:";
        private static readonly Selector sel_newIntersectionFunctionTableWithDescriptor = "newIntersectionFunctionTableWithDescriptor:";
        private static readonly Selector sel_newVisibleFunctionTableWithDescriptor = "newVisibleFunctionTableWithDescriptor:";
        private static readonly Selector sel_reflection = "reflection";
        private static readonly Selector sel_requiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";
        private static readonly Selector sel_shaderValidation = "shaderValidation";
        private static readonly Selector sel_staticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_threadExecutionWidth = "threadExecutionWidth";
        private static readonly Selector sel_release = "release";
    }
}
