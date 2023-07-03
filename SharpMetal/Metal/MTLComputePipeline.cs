using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLComputePipelineReflection
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
    public class MTLComputePipelineDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineDescriptor obj) => obj.NativePtr;
        public MTLComputePipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLComputePipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLComputePipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLFunction ComputeFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setComputeFunction, value);
        }

        public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadGroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public ulong MaxTotalThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerThreadgroup, value);
        }

        public MTLStageInputOutputDescriptor StageInputDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stageInputDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStageInputDescriptor, value);
        }

        public MTLPipelineBufferDescriptorArray Buffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffers));

        public bool SupportIndirectCommandBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, value);
        }

        public NSArray InsertLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_insertLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInsertLibraries, value);
        }

        public NSArray PreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreloadedLibraries, value);
        }

        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
        }

        public MTLLinkedFunctions LinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_linkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLinkedFunctions, value);
        }

        public bool SupportAddingBinaryFunctions
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingBinaryFunctions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAddingBinaryFunctions, value);
        }

        public ulong MaxCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCallStackDepth, value);
        }

        public void SetLabel(NSString label)
        {
            objc_msgSend(NativePtr, , label);
        }

        public void SetComputeFunction(MTLFunction computeFunction)
        {
            objc_msgSend(NativePtr, , computeFunction);
        }

        public void SetThreadGroupSizeIsMultipleOfThreadExecutionWidth(bool threadGroupSizeIsMultipleOfThreadExecutionWidth)
        {
            objc_msgSend(NativePtr, , threadGroupSizeIsMultipleOfThreadExecutionWidth);
        }

        public void SetMaxTotalThreadsPerThreadgroup(ulong maxTotalThreadsPerThreadgroup)
        {
            objc_msgSend(NativePtr, , maxTotalThreadsPerThreadgroup);
        }

        public void SetStageInputDescriptor(MTLStageInputOutputDescriptor stageInputDescriptor)
        {
            objc_msgSend(NativePtr, , stageInputDescriptor);
        }

        public void SetSupportIndirectCommandBuffers(bool supportIndirectCommandBuffers)
        {
            objc_msgSend(NativePtr, , supportIndirectCommandBuffers);
        }

        public void SetInsertLibraries(NSArray insertLibraries)
        {
            objc_msgSend(NativePtr, , insertLibraries);
        }

        public void SetPreloadedLibraries(NSArray preloadedLibraries)
        {
            objc_msgSend(NativePtr, , preloadedLibraries);
        }

        public void SetBinaryArchives(NSArray binaryArchives)
        {
            objc_msgSend(NativePtr, , binaryArchives);
        }

        public void Reset()
        {
            objc_msgSend(NativePtr, , );
        }

        public void SetLinkedFunctions(MTLLinkedFunctions linkedFunctions)
        {
            objc_msgSend(NativePtr, , linkedFunctions);
        }

        public void SetSupportAddingBinaryFunctions(bool supportAddingBinaryFunctions)
        {
            objc_msgSend(NativePtr, , supportAddingBinaryFunctions);
        }

        public void SetMaxCallStackDepth(ulong maxCallStackDepth)
        {
            objc_msgSend(NativePtr, , maxCallStackDepth);
        }

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
    public class MTLComputePipelineState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLComputePipelineState obj) => obj.NativePtr;
        public MTLComputePipelineState(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);

        public ulong ThreadExecutionWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadExecutionWidth);

        public ulong StaticThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_staticThreadgroupMemoryLength);

        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        public ulong ImageblockMemoryLength(MTLSize imageblockDimensions)
        {
            throw new NotImplementedException();
        }

        public MTLFunctionHandle FunctionHandle(MTLFunction function)
        {
            throw new NotImplementedException();
        }

        public MTLComputePipelineState NewComputePipelineState(NSArray functions, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

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
