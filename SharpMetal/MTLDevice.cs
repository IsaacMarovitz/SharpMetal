using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public unsafe struct MTLDevice
    {
        private const string MetalFramework = "/System/Library/Frameworks/Metal.framework/Metal";

        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDevice device) => device.NativePtr;
        public MTLDevice(IntPtr nativePtr) => NativePtr = nativePtr;

        public string Name => ObjectiveCRuntime.string_objc_msgSend(NativePtr, sel_name);

        public ulong RegistryID => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_registryID);

        // public MTLDeviceLocation Location => mtlDeviceLocation_objc_msgSend(NativePtr, sel_location);

        public long LocationNumber => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_locationNumber);

        public bool LowPower => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_lowPower);

        public bool Removable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_removable);

        public bool Headless => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_headless);

        public ulong PeerGroupId => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_peerGroupID);

        public uint PeerCount => ObjectiveCRuntime.uint32_objc_msgSend(NativePtr, sel_peerCount);

        public uint PeerIndex => ObjectiveCRuntime.uint32_objc_msgSend(NativePtr, sel_peerIndex);

        #region Device Inspection Selectors

        private static readonly ObjectiveCRuntime.Selector sel_supportsFamily = "supportsFamily:";
        private static readonly ObjectiveCRuntime.Selector sel_maxThreadgroupMemoryLength = "maxThreadgroupMemoryLength";
        private static readonly ObjectiveCRuntime.Selector sel_maxThreadsPerThreadgroup = "maxThreadsPerThreadgroup";
        private static readonly ObjectiveCRuntime.Selector sel_supportsRaytracing = "supportsRaytracing";
        private static readonly ObjectiveCRuntime.Selector sel_supportsPrimitiveMotionBlur = "supportsPrimitiveMotionBlur";
        private static readonly ObjectiveCRuntime.Selector sel_supportsRaytracingFromRender = "supportsRaytracingFromRender";
        private static readonly ObjectiveCRuntime.Selector sel_supports32BitMSAA = "supports32BitMSAA";
        private static readonly ObjectiveCRuntime.Selector sel_supportsPullModelInterpolation = "supportsPullModelInterpolation";
        private static readonly ObjectiveCRuntime.Selector sel_supportsShaderBarycentricCoordinates = "supportsShaderBarycentricCoordinates";
        private static readonly ObjectiveCRuntime.Selector sel_supportsVertexAmplificationCount = "supportsVertexAmplificationCount:";
        private static readonly ObjectiveCRuntime.Selector sel_programmableSamplePositionsSupported = "programmableSamplePositionsSupported";
        private static readonly ObjectiveCRuntime.Selector sel_rasterOrderGroupsSupported = "rasterOrderGroupsSupported";
        private static readonly ObjectiveCRuntime.Selector sel_supports32BitFloatFiltering = "supports32BitFloatFiltering";
        private static readonly ObjectiveCRuntime.Selector sel_supportsBCTextureCompression = "supportsBCTextureCompression";
        private static readonly ObjectiveCRuntime.Selector sel_depth24Stencil8PixelFormatSupported = "depth24Stencil8PixelFormatSupported";
        private static readonly ObjectiveCRuntime.Selector sel_supportsQueryTextureLOD = "supportsQueryTextureLOD";
        private static readonly ObjectiveCRuntime.Selector sel_supportsFunctionPointers = "supportsFunctionPointers";
        private static readonly ObjectiveCRuntime.Selector sel_supportsFunctionPointersFromRender = "supportsFunctionPointersFromRender";
        private static readonly ObjectiveCRuntime.Selector sel_currentAllocatedSize = "currentAllocatedSize";
        private static readonly ObjectiveCRuntime.Selector sel_recommendedMaxWorkingSetSize = "recommendedMaxWorkingSetSize";
        private static readonly ObjectiveCRuntime.Selector sel_hasUnifiedMemory = "hasUnifiedMemory";
        private static readonly ObjectiveCRuntime.Selector sel_maxTransferRate = "maxTransferRate";
        private static readonly ObjectiveCRuntime.Selector sel_counterSets = "counterSets";
        private static readonly ObjectiveCRuntime.Selector sel_supportsCounterSampling = "supportsCounterSampling:";
        private static readonly ObjectiveCRuntime.Selector sel_newCounterSampleBufferWithDescriptorError = "newCounterSampleBufferWithDescriptor:error:";
        private static readonly ObjectiveCRuntime.Selector sel_sampleTimestampsGpuTimestamp = "sampleTimestamps:gpuTimestamp:";
        private static readonly ObjectiveCRuntime.Selector sel_name = "name";
        private static readonly ObjectiveCRuntime.Selector sel_registryID = "registryID";
        private static readonly ObjectiveCRuntime.Selector sel_location = "location";
        private static readonly ObjectiveCRuntime.Selector sel_locationNumber = "locationNumber";
        private static readonly ObjectiveCRuntime.Selector sel_lowPower = "lowPower";
        private static readonly ObjectiveCRuntime.Selector sel_removable = "removable";
        private static readonly ObjectiveCRuntime.Selector sel_headless = "headless";
        private static readonly ObjectiveCRuntime.Selector sel_peerGroupID = "peerGroupID";
        private static readonly ObjectiveCRuntime.Selector sel_peerCount = "peerCount";
        private static readonly ObjectiveCRuntime.Selector sel_peerIndex = "peerIndex";

        #endregion

        #region Work Submission Selectors

        private static readonly ObjectiveCRuntime.Selector sel_newCommandQueue = "newCommandQueue";
        private static readonly ObjectiveCRuntime.Selector sel_newCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";
        private static readonly ObjectiveCRuntime.Selector sel_newIOCommandQueueWithDescriptorError = "newIOCommandQueueWithDescriptor:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newIOHandleWithURLError = "newIOHandleWithURL:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newIOHandleWithURLCompressionMethodError = "newIOHandleWithURL:compressionMethod:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newIndirectCommandBufferWithDescriptorMaxCommandCountOptions = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";

        #endregion

        #region Pipeline State Creation Selectors

        private static readonly ObjectiveCRuntime.Selector sel_newComputePipelineStateWithDescriptorOptionsReflectionError = "newComputePipelineStateWithDescriptor:options:reflection:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newComputePipelineStateWithDescriptorOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:options:completionHandler:";
        private static readonly ObjectiveCRuntime.Selector sel_newComputePipelineStateWithFunctionError = "newComputePipelineStateWithFunction:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newComputePipelineStateWithFunctionCompletionHandler = "newComputePipelineStateWithFunction:completionHandler:";
        private static readonly ObjectiveCRuntime.Selector sel_newComputePipelineStateWithFunctionOptionsReflectionError = "newComputePipelineStateWithFunction:options:reflection:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newComputePipelineStateWithFunctionOptionsCompletionHandler = "newComputePipelineStateWithFunction:options:completionHandler:";

        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithDescriptorError = "newRenderPipelineStateWithDescriptor:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithDescriptorCompletionHandler = "newRenderPipelineStateWithDescriptor:completionHandler:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithDescriptorOptionsReflectionError = "newRenderPipelineStateWithDescriptor:options:reflection:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:options:completionHandler:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithMeshDescriptorOptionsReflectionError = "newRenderPipelineStateWithMeshDescriptor:options:reflection:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithMeshDescriptor:options:completionHandler:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithTileDescriptorOptionsReflectionError = "newRenderPipelineStateWithTileDescriptor:options:reflection:error:";
        private static readonly ObjectiveCRuntime.Selector sel_newRenderPipelineStateWithTileDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithTileDescriptor:options:completionHandler:";

        private static readonly ObjectiveCRuntime.Selector sel_newDepthStencilStateWithDescriptor = "newDepthStencilStateWithDescriptor:";

        private static readonly ObjectiveCRuntime.Selector sel_supportsRasterizationRateMapWithLayerCount = "supportsRasterizationRateMapWithLayerCount:";
        private static readonly ObjectiveCRuntime.Selector sel_newRasterizationRateMapWithDescriptor = "newRasterizationRateMapWithDescriptor:";

        #endregion

        #region Resource Creation Selectors

        private static readonly ObjectiveCRuntime.Selector sel_newHeapWithDescriptor = "newHeapWithDescriptor:";
        private static readonly ObjectiveCRuntime.Selector sel_heapBufferSizeAndAlignWithLengthOptions = "heapBufferSizeAndAlignWithLength:options:";
        private static readonly ObjectiveCRuntime.Selector sel_heapTextureSizeAndAlignWithDescriptor = "heapTextureSizeAndAlignWithDescriptor:";
        private static readonly ObjectiveCRuntime.Selector sel_heapAccelerationStructureSizeAndAlignWithSize = "heapAccelerationStructureSizeAndAlignWithSize:";
        private static readonly ObjectiveCRuntime.Selector sel_heapAccelerationStructureSizeAndAlignWithDescriptor = "heapAccelerationStructureSizeAndAlignWithDescriptor:";
        private static readonly ObjectiveCRuntime.Selector sel_maxBufferLength = "maxBufferLength";
        private static readonly ObjectiveCRuntime.Selector sel_newBufferWithLengthOptions = "newBufferWithLength:options:";
        private static readonly ObjectiveCRuntime.Selector sel_newBufferWithBytesLengthOptions = "newBufferWithBytes:length:options:";

        #endregion
    }
}