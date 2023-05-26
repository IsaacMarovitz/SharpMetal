using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public partial struct MTLDevice
    {
        private const string MetalFramework = "/System/Library/Frameworks/Metal.framework/Metal";

        [LibraryImport(MetalFramework)]
        public static partial MTLDevice MTLCreateSystemDefaultDevice();

        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDevice device) => device.NativePtr;
        public MTLDevice(IntPtr nativePtr) => NativePtr = nativePtr;

        public bool SupportsFamily(MTLGPUFamily gpuFamily)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsFamily, (long)gpuFamily);
        }

        public ulong MaxThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxThreadgroupMemoryLength);

        public MTLSize MaxThreadsPerThreadgroup => ObjectiveCRuntime.mtlSize_objc_msgSend(NativePtr, sel_maxThreadsPerThreadgroup);

        public bool SupportsRaytracing => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsRaytracing);

        public bool SupportsPrimitiveMotionBlur => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsPrimitiveMotionBlur);

        public bool SupportsRaytracingFromRender => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsRaytracingFromRender);

        public bool Supports32BitMSAA => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supports32BitMSAA);

        public bool SupportsPullModelInterpolation => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsPullModelInterpolation);

        public bool SupportsShaderBarycentricCoordinates => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsShaderBarycentricCoordinates);

        public bool SupportsVertexAmplificationCount(ulong count)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsVertexAmplificationCount, count);
        }

        public bool ProgrammableSamplePositionsSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_programmableSamplePositionsSupported);

        public bool RasterOrderGroupsSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_rasterOrderGroupsSupported);

        public bool Supports32BitFloatFiltering => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supports32BitFloatFiltering);

        public bool SupportsBCTextureCompression => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsBCTextureCompression);

        public bool Depth24Stencil8PixelFormatSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_depth24Stencil8PixelFormatSupported);

        public bool SupportsQueryTextureLOD => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsQueryTextureLOD);

        public MTLReadWriteTextureTier ReadWriteTextureSupport => (MTLReadWriteTextureTier)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_readWriteTextureSupport);

        public bool SupportsFunctionPointers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsFunctionPointers);

        public bool SupportsFunctionPointersFromRender => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsFunctionPointersFromRender);

        public ulong CurrentAllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_currentAllocatedSize);

        public ulong recommendedMaxWorkingSetSize => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_recommendedMaxWorkingSetSize);

        public bool HasUnifiedMemory => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_hasUnifiedMemory);

        public ulong MaxTransferRate => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_maxTransferRate);

        // TODO: Needs NSArray
        // public NSArray CounterSets

        public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsCounterSampling, (ulong)samplingPoint);
        }

        // TODO: Needs MTLCounterSampleBuffer, MTLCounterSampleBufferDescriptor, and NSError
        /* public MTLCounterSampleBuffer NewCounterSampleBufferWithDescriptorError(MTLCounterSampleBufferDescriptor descriptor, out NSError error)
        {

        }*/

        // TODO: Needs MTLTimestamp
        /*public void SampleTimestampsGPUTimestamp(MTLTimestamp cpuTimestamp, MTLTimestamp gpuTimestamp)
        {

        }*/

        public NSString Name => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_name);

        public ulong RegistryID => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_registryID);

        public MTLDeviceLocation Location => (MTLDeviceLocation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_location);

        public ulong LocationNumber => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_locationNumber);

        public bool LowPower => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_lowPower);

        public bool Removable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_removable);

        public bool Headless => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_headless);

        public ulong PeerGroupId => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_peerGroupID);

        public uint PeerCount => ObjectiveCRuntime.uint32_objc_msgSend(NativePtr, sel_peerCount);

        public uint PeerIndex => ObjectiveCRuntime.uint32_objc_msgSend(NativePtr, sel_peerIndex);

        #region Device Inspection Selectors

        private static readonly Selector sel_supportsFamily = "supportsFamily:";
        private static readonly Selector sel_maxThreadgroupMemoryLength = "maxThreadgroupMemoryLength";
        private static readonly Selector sel_maxThreadsPerThreadgroup = "maxThreadsPerThreadgroup";
        private static readonly Selector sel_supportsRaytracing = "supportsRaytracing";
        private static readonly Selector sel_supportsPrimitiveMotionBlur = "supportsPrimitiveMotionBlur";
        private static readonly Selector sel_supportsRaytracingFromRender = "supportsRaytracingFromRender";
        private static readonly Selector sel_supports32BitMSAA = "supports32BitMSAA";
        private static readonly Selector sel_supportsPullModelInterpolation = "supportsPullModelInterpolation";
        private static readonly Selector sel_supportsShaderBarycentricCoordinates = "supportsShaderBarycentricCoordinates";
        private static readonly Selector sel_supportsVertexAmplificationCount = "supportsVertexAmplificationCount:";
        private static readonly Selector sel_programmableSamplePositionsSupported = "programmableSamplePositionsSupported";
        private static readonly Selector sel_rasterOrderGroupsSupported = "rasterOrderGroupsSupported";
        private static readonly Selector sel_supports32BitFloatFiltering = "supports32BitFloatFiltering";
        private static readonly Selector sel_supportsBCTextureCompression = "supportsBCTextureCompression";
        private static readonly Selector sel_depth24Stencil8PixelFormatSupported = "depth24Stencil8PixelFormatSupported";
        private static readonly Selector sel_supportsQueryTextureLOD = "supportsQueryTextureLOD";
        private static readonly Selector sel_readWriteTextureSupport = "readWriteTextureSupport";
        private static readonly Selector sel_supportsFunctionPointers = "supportsFunctionPointers";
        private static readonly Selector sel_supportsFunctionPointersFromRender = "supportsFunctionPointersFromRender";
        private static readonly Selector sel_currentAllocatedSize = "currentAllocatedSize";
        private static readonly Selector sel_recommendedMaxWorkingSetSize = "recommendedMaxWorkingSetSize";
        private static readonly Selector sel_hasUnifiedMemory = "hasUnifiedMemory";
        private static readonly Selector sel_maxTransferRate = "maxTransferRate";
        private static readonly Selector sel_counterSets = "counterSets";
        private static readonly Selector sel_supportsCounterSampling = "supportsCounterSampling:";
        private static readonly Selector sel_newCounterSampleBufferWithDescriptorError = "newCounterSampleBufferWithDescriptor:error:";
        private static readonly Selector sel_sampleTimestampsGpuTimestamp = "sampleTimestamps:gpuTimestamp:";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_registryID = "registryID";
        private static readonly Selector sel_location = "location";
        private static readonly Selector sel_locationNumber = "locationNumber";
        private static readonly Selector sel_lowPower = "lowPower";
        private static readonly Selector sel_removable = "removable";
        private static readonly Selector sel_headless = "headless";
        private static readonly Selector sel_peerGroupID = "peerGroupID";
        private static readonly Selector sel_peerCount = "peerCount";
        private static readonly Selector sel_peerIndex = "peerIndex";

        #endregion

        #region Work Submission Selectors

        private static readonly Selector sel_newCommandQueue = "newCommandQueue";
        private static readonly Selector sel_newCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";
        private static readonly Selector sel_newIOCommandQueueWithDescriptorError = "newIOCommandQueueWithDescriptor:error:";
        private static readonly Selector sel_newIOHandleWithURLError = "newIOHandleWithURL:error:";
        private static readonly Selector sel_newIOHandleWithURLCompressionMethodError = "newIOHandleWithURL:compressionMethod:error:";
        private static readonly Selector sel_newIndirectCommandBufferWithDescriptorMaxCommandCountOptions = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";

        #endregion

        #region Pipeline State Creation Selectors

        private static readonly Selector sel_newComputePipelineStateWithDescriptorOptionsReflectionError = "newComputePipelineStateWithDescriptor:options:reflection:error:";
        private static readonly Selector sel_newComputePipelineStateWithDescriptorOptionsCompletionHandler = "newComputePipelineStateWithDescriptor:options:completionHandler:";
        private static readonly Selector sel_newComputePipelineStateWithFunctionError = "newComputePipelineStateWithFunction:error:";
        private static readonly Selector sel_newComputePipelineStateWithFunctionCompletionHandler = "newComputePipelineStateWithFunction:completionHandler:";
        private static readonly Selector sel_newComputePipelineStateWithFunctionOptionsReflectionError = "newComputePipelineStateWithFunction:options:reflection:error:";
        private static readonly Selector sel_newComputePipelineStateWithFunctionOptionsCompletionHandler = "newComputePipelineStateWithFunction:options:completionHandler:";

        private static readonly Selector sel_newRenderPipelineStateWithDescriptorError = "newRenderPipelineStateWithDescriptor:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptorCompletionHandler = "newRenderPipelineStateWithDescriptor:completionHandler:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptorOptionsReflectionError = "newRenderPipelineStateWithDescriptor:options:reflection:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithDescriptor:options:completionHandler:";
        private static readonly Selector sel_newRenderPipelineStateWithMeshDescriptorOptionsReflectionError = "newRenderPipelineStateWithMeshDescriptor:options:reflection:error:";
        private static readonly Selector sel_newRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithMeshDescriptor:options:completionHandler:";
        private static readonly Selector sel_newRenderPipelineStateWithTileDescriptorOptionsReflectionError = "newRenderPipelineStateWithTileDescriptor:options:reflection:error:";
        private static readonly Selector sel_newRenderPipelineStateWithTileDescriptorOptionsCompletionHandler = "newRenderPipelineStateWithTileDescriptor:options:completionHandler:";

        private static readonly Selector sel_newDepthStencilStateWithDescriptor = "newDepthStencilStateWithDescriptor:";

        private static readonly Selector sel_supportsRasterizationRateMapWithLayerCount = "supportsRasterizationRateMapWithLayerCount:";
        private static readonly Selector sel_newRasterizationRateMapWithDescriptor = "newRasterizationRateMapWithDescriptor:";

        #endregion

        #region Resource Creation Selectors

        private static readonly Selector sel_newHeapWithDescriptor = "newHeapWithDescriptor:";
        private static readonly Selector sel_heapBufferSizeAndAlignWithLengthOptions = "heapBufferSizeAndAlignWithLength:options:";
        private static readonly Selector sel_heapTextureSizeAndAlignWithDescriptor = "heapTextureSizeAndAlignWithDescriptor:";
        private static readonly Selector sel_heapAccelerationStructureSizeAndAlignWithSize = "heapAccelerationStructureSizeAndAlignWithSize:";
        private static readonly Selector sel_heapAccelerationStructureSizeAndAlignWithDescriptor = "heapAccelerationStructureSizeAndAlignWithDescriptor:";
        private static readonly Selector sel_maxBufferLength = "maxBufferLength";
        private static readonly Selector sel_newBufferWithLengthOptions = "newBufferWithLength:options:";
        private static readonly Selector sel_newBufferWithBytesLengthOptions = "newBufferWithBytes:length:options:";

        #endregion
    }
}