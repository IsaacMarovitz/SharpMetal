namespace SharpMetal
{
    public unsafe class MTLDevice
    {
        private const string MetalFramework = "/System/Library/Frameworks/Metal.framework/Metal";

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
    }
}