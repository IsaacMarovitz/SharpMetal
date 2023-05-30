using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLComputePipelineReflection
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineReflection obj) => obj.NativePtr;
        public MTLComputePipelineReflection(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePipelineReflection()
        {
            var cls = new ObjectiveCClass("MTLComputePipelineReflection");
            NativePtr = cls.AllocInit();
        }

        public NSArray Bindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bindings));
        public NSArray Arguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arguments));

        private static readonly Selector sel_bindings = "bindings";
        private static readonly Selector sel_arguments = "arguments";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLComputePipelineDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineDescriptor obj) => obj.NativePtr;
        public MTLComputePipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLComputePipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLFunction ComputeFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeFunction));
        public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadGroupSizeIsMultipleOfThreadExecutionWidth);
        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
        public MTLStageInputOutputDescriptor StageInputDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stageInputDescriptor));
        public MTLPipelineBufferDescriptorArray Buffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffers));
        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
        public NSArray InsertLibraries => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_insertLibraries));
        public NSArray PreloadedLibraries => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
        public NSArray BinaryArchives => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
        public MTLLinkedFunctions LinkedFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_linkedFunctions));
        public bool SupportAddingBinaryFunctions => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingBinaryFunctions);
        public ulong MaxCallStackDepth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_computeFunction = "computeFunction";
        private static readonly Selector sel_setComputeFunction = "setComputeFunction:";
        private static readonly Selector sel_threadGroupSizeIsMultipleOfThreadExecutionWidth = "threadGroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth = "setThreadGroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
        private static readonly Selector sel_stageInputDescriptor = "stageInputDescriptor";
        private static readonly Selector sel_setStageInputDescriptor = "setStageInputDescriptor:";
        private static readonly Selector sel_buffers = "buffers";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_insertLibraries = "insertLibraries";
        private static readonly Selector sel_setInsertLibraries = "setInsertLibraries:";
        private static readonly Selector sel_preloadedLibraries = "preloadedLibraries";
        private static readonly Selector sel_setPreloadedLibraries = "setPreloadedLibraries:";
        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_linkedFunctions = "linkedFunctions";
        private static readonly Selector sel_setLinkedFunctions = "setLinkedFunctions:";
        private static readonly Selector sel_supportAddingBinaryFunctions = "supportAddingBinaryFunctions";
        private static readonly Selector sel_setSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";
        private static readonly Selector sel_maxCallStackDepth = "maxCallStackDepth";
        private static readonly Selector sel_setMaxCallStackDepth = "setMaxCallStackDepth:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLComputePipelineState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineState obj) => obj.NativePtr;
        public MTLComputePipelineState(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
        public ulong ThreadExecutionWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadExecutionWidth);
        public ulong ThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_staticThreadgroupMemoryLength);
        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_threadExecutionWidth = "threadExecutionWidth";
        private static readonly Selector sel_staticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";
        private static readonly Selector sel_imageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_functionHandleWithFunction = "functionHandleWithFunction:";
        private static readonly Selector sel_newComputePipelineStateWithAdditionalBinaryFunctionserror = "newComputePipelineStateWithAdditionalBinaryFunctions:error:";
        private static readonly Selector sel_newVisibleFunctionTableWithDescriptor = "newVisibleFunctionTableWithDescriptor:";
        private static readonly Selector sel_newIntersectionFunctionTableWithDescriptor = "newIntersectionFunctionTableWithDescriptor:";
    }
}
