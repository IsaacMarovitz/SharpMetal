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

        #region Device Inspection

        public bool SupportsFamily(MTLGPUFamily gpuFamily)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsFamily, (long)gpuFamily);
        }

        public ulong MaxThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxThreadgroupMemoryLength);

        // TODO: Fix me
        // public MTLSize MaxThreadsPerThreadgroup => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_maxThreadsPerThreadgroup));

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

        public ulong RecommendedMaxWorkingSetSize => ObjectiveCRuntime.uint64_objc_msgSend(NativePtr, sel_recommendedMaxWorkingSetSize);

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

        #endregion

        #region Work Submission

        public MTLCommandQueue NewCommandQueue()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newCommandQueue));
        }

        public MTLCommandQueue NewCommandQueueWithMaxCommandBufferCount(ulong maxCommandBufferCount)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newCommandQueueWithMaxCommandBufferCount, maxCommandBufferCount));
        }

        // TODO: Needs MTLIOCommandQueue, MTLIOCommandQueueDescriptor, NSError
        /*public MTLIOCommandQueue NewIOCommandQueueWithDescriptorError(MTLIOCommandQueueDescriptor descriptor, out NSError error)
        {

        }*/

        // TODO: Needs MTLIOFileHandle, NSURL, NSError
        /*public MTLIOFileHandle NewIOHandleWithURLError(NSURL url, out NSError error)
        {

        }*/

        // TODO: Needs MTLIOFileHandle, NSURL, NSError
        /*public MTLIOFileHandle NewIOHandleWithURLCompressionMethodError(NSURL url, MTLIOCompressionMethod compressionMethod, out NSError error)
        {

        }*/

        // TODO: Needs MTLIndirectCommandBuffer, MTLIndirectCommandBufferDescriptor
        /*public MTLIndirectCommandBuffer NewIndirectCommandBufferWithDescriptorMaxCommandCountOptions(MTLIndirectCommandBufferDescriptor descriptor, ulong maxCount, MTLResourceOptions options)
        {

        }*/

        #endregion

        #region Pipeline State Creation

        // TODO: Needs MTLComputePipelineState, MTLComputePipelineDescriptor, MTLPipelineOption, MTLAutoreleasedComputePipelineReflection, NSError
        /*public MTLComputePipelineState NewComputePipelineStateWithDescriptorOptionsReflectionError(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLAutoreleasedComputePipelineReflection reflection, out NSError error)
        {

        }*/

        // TODO: Needs MTLComputePipelineDescriptor, MTLPipelineOption, MTLNewComputePipelineStateWithReflectionCompletionHandler
        /*public void NewComputePipelineStateWithDescriptorOptionsCompletionHandler(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLComputePipelineState and NSError
        /*public MTLComputePipelineState NewComputePipelineStateWithFunctionError(MTLFunction computeFunction, out NSError error)
        {

        }*/

        // TODO: Needs MTLNewComputePipelineStateCompletionHandler
        /*public void NewComputePipelineStateWithFunctionCompletionHandler(MTLFunction computeFunction, MTLNewComputePipelineStateCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLComputePipelineState, MTLPipelineOption, MTLAutoreleasedComputePipelineReflection, NSError
        /*public MTLComputePipelineState NewComputePipelineStateWithFunctionOptionsReflectionError(MTLFunction computeFunction, MTLPipelineOption options, MTLAutoreleasedComputePipelineReflection reflection, out NSError error)
        {

        }*/

        // TODO: Needs MTLPipelineOption, MTLNewComputePipelineStateWithReflectionCompletionHandler
        /*public void NewComputePipelineStateWithFunctionIptionsCompletionHandler(MTLFunction computeFunction, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLRenderPipelineState, NSError
        /*public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorError(MTLRenderPipelineDescriptor descriptor, out NSError error)
        {

        }*/

        // TODO: Needs MTLNewRenderPipelineStateCompletionHandler
        /*public void NewRenderPipelineStateWithDescriptorCompletionHandler(MTLRenderPipelineDescriptor descriptor, MTLNewRenderPipelineStateCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLRenderPipelineState, MTLPipelineOption,MTLAutoreleasedRenderPipelineReflection, NSError
        /*public MTLRenderPipelineState NewRenderPipelineStateWithDescriptorOptionsReflectionError(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLAutoreleasedRenderPipelineReflection reflection, out NSError error)
        {

        }*/

        // TODO: Needs MTLPipelineOption, MTLNewRenderPipelineStateWithReflectionCompletionHandler
        /*public void NewRenderPipelineStateWithDescriptorOptionsCompletionHandler(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLRenderPipelineState, MTLMeshRenderPipelineDescriptor, MTLPipelineOption, MTLAutoreleasedRenderPipelineReflection, NSError
        /*public MTLRenderPipelineState NewRenderPipelineStateWithMeshDescriptorOptionsReflectionError(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLAutoreleasedRenderPipelineReflection reflection, out NSError error)
        {

        }*/

        // TODO: Needs MTLMeshRenderPipelineDescriptor, MTLPipelineOption, MTLNewRenderPipelineStateWithReflectionCompletionHandler
        /*public void NewRenderPipelineStateWithMeshDescriptorOptionsCompletionHandler(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLRenderPipelineState, MTLTileRenderPipelineDescriptor, MTLPipelineOption, MTLAutoreleasedRenderPipelineReflection, NSError
        /*public MTLRenderPipelineState NewRenderPipelineStateWithTileDescriptorOptionsReflectionError(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLAutoreleasedRenderPipelineReflection reflection, out NSError error)
        {

        }*/

        // TODO: Needs MTLTileRenderPipelineDescriptor, MTLPipelineOption, MTLNewRenderPipelineStateWithReflectionCompletionHandler
        /*public void NewRenderPipelineStateWithTileDescriptorOptionsCompletionHandler(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLDepthStencilState, MTLDepthStencilDescriptor
        /*public MTLDepthStencilState NewDepthStencilStateWithDescriptor(MTLDepthStencilDescriptor descriptor)
        {

        }*/

        public bool SupportsRasterizationRateMapWithLayerCount(ulong layerCount)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsRasterizationRateMapWithLayerCount, layerCount);
        }

        // TODO: Needs MTLRasterizationRateMap, MTLRasterizationRateMapDescriptor
        /*public MTLRasterizationRateMap NewRasterizationRateMapWithDescriptor(MTLRasterizationRateMapDescriptor descriptor)
        {

        }*/

        #endregion

        #region Resource Creation

        // TODO: Needs MTLHeap, MTLHeapDescriptor
        /*public MTLHeap NewHeapWithDescriptor(MTLHeapDescriptor descriptor)
        {

        }*/

        // TODO: Needs MTLSizeAndAlign
        /*public MTLSizeAndAlign HeapBufferSizeAndAlignWithLengthOptions(ulong length, MTLResourceOptions options)
        {

        }*/

        // TODO: Needs MTLSizeAndAlign
        /*public MTLSizeAndAlign HeapTextureSizeAndAlignWithDescriptor(MTLTextureDescriptor desc)
        {

        }*/

        // TODO: Needs MTLSizeAndAlign
        /*public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlignWithSize(ulong size)
        {

        }*/

        // TODO: Needs MTLSizeAndAlign, MTLAccelerationStructureDescriptor
        /*public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlignWithDescriptor(MTLAccelerationStructureDescriptor descriptor)
        {

        }*/

        public ulong MaxBufferLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxBufferLength);

        public MTLBuffer NewBufferWithLengthOptions(ulong length, MTLResourceOptions options)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBufferWithLengthOptions, length, (ulong)options));
        }

        public MTLBuffer NewBufferWithBytesLengthOptions(IntPtr pointer, ulong length, MTLResourceOptions options)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBufferWithBytesLengthOptions, pointer, length, (ulong)options));
        }

        public MTLBuffer NewBufferWithBytesNoCopyLengthOptionsDeallocator(IntPtr pointer, ulong length, MTLResourceOptions options, IntPtr deallocator)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newBufferWithBytesNoCopyLengthOptionsDeallocator, pointer, length, (ulong)options, deallocator));
        }

        // TODO: Needs MTLTexture
        /*public MTLTexture NewTextureWithDescriptor(MTLTextureDescriptor descriptor)
        {

        }*/

        // TODO: Needs MTLTexture, IOSurfaceRef
        /*public MTLTexture NewTextureWithDescriptorIosurfacePlane(MTLTextureDescriptor descriptor, IOSurfaceRef iosurface, ulong plane)
        {

        }*/

        // TODO: Needs MTLTexture
        /*public MTLTexture NewSharedTextureWithDescriptor(MTLTextureDescriptor descriptor)
        {

        }*/

        // TODO: Needs MTLTexture, MTLSharedTextureHandle
        /*public MTLTexture NewSharedTextureWithHandle(MTLSharedTextureHandle sharedHandle)
        {

        }*/

        public ulong MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_minimumLinearTextureAlignmentForPixelFormat, (ulong)format);
        }

        public ulong MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_minimumTextureBufferAlignmentForPixelFormat, (ulong)format);
        }

        public bool SupportsTextureSampleCount(ulong sampleCount)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsTextureSampleCount, sampleCount);
        }

        // TODO: Needs MTLSamplerState
        /*public MTLSamplerState NewSamplerStateWithDescriptor(MTLSamplerDescriptor descriptor)
        {

        }*/

        // TODO: Needs MTLSamplePosition
        /*public void GetDefaultSamplePositionsCount(MTLSamplePosition position, ulong count)
        {

        }*/

        public MTLSize SparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, ulong sampleCount, MTLSparsePageSize sparsePageSize)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize, (ulong)textureType, (ulong)pixelFormat, sampleCount, (long)sparsePageSize));
        }

        public MTLSize SparseTileSizeWithTextureTypePixelFormatSampleCount(MTLTextureType textureType, MTLPixelFormat pixelFormat, ulong sampleCount)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sparseTileSizeWithTextureTypePixelFormatSampleCount, (ulong)textureType, (ulong)pixelFormat, sampleCount));
        }

        public ulong SparseTileSizeInBytesForSparsePageSize(MTLSparsePageSize sparsePageSize)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sparseTileSizeInBytesForSparsePageSize, (ulong)sparsePageSize);
        }

        public ulong SparseTileSizeInBytes => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sparseTileSizeInBytes);

        public void ConvertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, ulong numRegions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_convertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions, pixelRegions.NativePtr, tileRegions.NativePtr, tileSize.NativePtr, (ulong)mode, numRegions);
        }

        public void ConvertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, ulong numRegions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_convertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions, tileRegions.NativePtr, pixelRegions.NativePtr, tileSize.NativePtr, numRegions);
        }

        // TODO: Needs MTLAccelerationStructure, MTLAccelerationStructureDescriptor
        /*public MTLAccelerationStructure NewAccelerationStructureWithDescriptor(MTLAccelerationStructureDescriptor descriptor)
        {

        }*/

        // TODO: Needs MTLAccelerationStructure
        /*public MTLAccelerationStructure NewAccelerationStructureWithSize(ulong size)
        {

        }*/

        // TODO: Needs MTLAccelerationStructureSizes, MTLAccelerationStructureDescriptor
        /*public MTLAccelerationStructureSizes AccelerationStructureSizesWithDescriptor(MTLAccelerationStructureDescriptor descriptor)
        {

        }*/

        // TODO: Needs MTLArgumentBuffersTier
        // public MTLArgumentBuffersTier ArgumentBuffersSupport;

        public ulong MaxArgumentBufferSamplerCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxArgumentBufferSamplerCount);

        // TODO: Needs MTLArgumentEncoder, NSArray
        /*public MTLArgumentEncoder NewArgumentEncoderWithArguments(NSArray of MTLArgumentDescriptor arguments)
        {

        }*/

        // TODO: Needs MTLArgumentEncoder, MTLBufferBinding
        /*public MTLArgumentEncoder NewArgumentEncoderWithBufferBinding(MTLBufferBinding bufferBinding)
        {

        }*/

        // TODO: Needs MTLFence
        /*public MTLFence NewFence()
        {

        }*/

        // TODO: Needs MTLEvent
        /*public MTLEvent NewEvent()
        {

        }*/

        // TODO: Needs MTLSharedEvent
        /*public MTLSharedEvent NewSharedEvent()
        {

        }*/

        // TODO: Needs MTLSharedEvent, MTLSharedEventHandle
        /*public MTLSharedEvent NewSharedEventWithHandle(MTLSharedEventHandle sharedEventHandle)
        {

        }*/

        #endregion

        #region Shader Library and Archive Creation

        // TODO: Needs MTLLibrary
        /*public MTLLibrary NewDefaultLibrary()
        {

        }*/

        // TODO: Needs MTLLibrary, NSBundle, NSError
        /*public MTLLibrary NewDefaultLibraryWithBundleError(NSBundle bundle, out NSError error)
        {

        }*/

        // TODO: Needs MTLLibrary, NSURL, NSError
        /*public MTLLibrary NewLibraryWithURLError(NSURL url, out NSError error)
        {

        }*/

        // TODO: Needs MTLLibrary, NSError
        /*public MTLLibrary NewLibraryWithSourceOptionsError(NSString source, MTLCompileOptions options, out NSError error)
        {

        }*/

        // TODO: Needs MTLNewLibraryCompletionHandler
        /*public void NewLibraryWithSourceOptionsCompletionHandler(NSString source, MTLCompileOptions options, MTLNewLibraryCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLLibrary, MTLStitchedLibraryDescriptor, NSError
        /*public MTLLibrary NewLibraryWithStitchedDescriptorError(MTLStitchedLibraryDescriptor descriptor, out NSError error)
        {

        }*/

        // TODO: Needs MTLLibrary, MTLStitchedLibraryDescriptor, NSError
        /*public void NewLibraryWithStitchedDescriptorCompletionHandler(MTLStitchedLibraryDescriptor descriptor, MTLNewLibraryCompletionHandler completionHandler)
        {

        }*/

        // TODO: Needs MTLLibrary, dispatch_data_t, NSError
        /*public MTLLibrary NewLibraryWithDataError(dispatch_data_t data, out NSError error)
        {

        }*/

        // TODO: Needs MTLDynamicLibrary, MTLLibrary, NSError
        /*public MTLDynamicLibrary NewDynamicLibraryError(MTLLibrary library, out NSError error)
        {

        }*/

        // TODO: Needs MTLDynamicLibrary, NSURL, NSError
        /*public MTLDynamicLibrary NewDynamicLibraryWithURLError(NSURL url, out NSError error)
        {

        }*/

        public bool SupportsDynamicLibraries => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsDynamicLibraries);

        public bool SupportsRenderDynamicLibraries => ObjectiveCRuntime.bool_objc_msgSend(Name, sel_supportsRenderDynamicLibraries);

        // TODO: Needs MTLBinaryArchive, MTLBinaryArchiveDescriptor, NSError
        /*public MTLBinaryArchive NewBinaryArchiveWithDescriptorError(MTLBinaryArchiveDescriptor descriptor, out NSError error)
        {

        }*/

        #endregion

        public ulong MaximumConcurrentCompilationTaskCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maximumConcurrentCompilationTaskCount);

        public bool ShouldMaximizeConcurrentCompilation => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_shouldMaximizeConcurrentCompilation);

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
        private static readonly Selector sel_programmableSamplePositionsSupported = "areProgrammableSamplePositionsSupported";
        private static readonly Selector sel_rasterOrderGroupsSupported = "areRasterOrderGroupsSupported";
        private static readonly Selector sel_supports32BitFloatFiltering = "supports32BitFloatFiltering";
        private static readonly Selector sel_supportsBCTextureCompression = "supportsBCTextureCompression";
        private static readonly Selector sel_depth24Stencil8PixelFormatSupported = "isDepth24Stencil8PixelFormatSupported";
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
        private static readonly Selector sel_lowPower = "isLowPower";
        private static readonly Selector sel_removable = "isRemovable";
        private static readonly Selector sel_headless = "isHeadless";
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
        private static readonly Selector sel_newBufferWithBytesNoCopyLengthOptionsDeallocator = "newBufferWithBytesNoCopy:length:options:deallocator:";
        private static readonly Selector sel_newTextureWithDescriptor = "newTextureWithDescriptor:";
        private static readonly Selector sel_newTextureWithDescriptorIosurfacePlane = "newTextureWithDescriptor:iosurface:plane:";
        private static readonly Selector sel_newSharedTextureWithDescriptor = "newSharedTextureWithDescriptor:";
        private static readonly Selector sel_newSharedTextureWithHandle = "newSharedTextureWithHandle:";
        private static readonly Selector sel_minimumLinearTextureAlignmentForPixelFormat = "minimumLinearTextureAlignmentForPixelFormat:";
        private static readonly Selector sel_minimumTextureBufferAlignmentForPixelFormat = "minimumTextureBufferAlignmentForPixelFormat:";
        private static readonly Selector sel_supportsTextureSampleCount = "supportsTextureSampleCount:";
        private static readonly Selector sel_newSamplerStateWithDescriptor = "newSamplerStateWithDescriptor:";
        private static readonly Selector sel_getDefaultSamplePositionsCount = "getDefaultSamplePositions:count:";
        private static readonly Selector sel_sparseTileSizeWithTextureTypePixelFormatSampleCountSparsePageSize = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:";
        private static readonly Selector sel_sparseTileSizeWithTextureTypePixelFormatSampleCount = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:";
        private static readonly Selector sel_sparseTileSizeInBytesForSparsePageSize = "sparseTileSizeInBytesForSparsePageSize:";
        private static readonly Selector sel_sparseTileSizeInBytes = "sparseTileSizeInBytes";
        private static readonly Selector sel_convertSparsePixelRegionsToTileRegionsWithTileSizeAlignmentModeNumRegions = "convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:";
        private static readonly Selector sel_convertSparseTileRegionsToPixelRegionsWithTileSizeNumRegions = "convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:";
        private static readonly Selector sel_newAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";
        private static readonly Selector sel_newAccelerationStructureWithSize = "newAccelerationStructureWithSize:";
        private static readonly Selector sel_accelerationStructureSizesWithDescriptor = "accelerationStructureSizesWithDescriptor:";
        private static readonly Selector sel_argumentBuffersSupport = "argumentBuffersSupport";
        private static readonly Selector sel_maxArgumentBufferSamplerCount = "maxArgumentBufferSamplerCount";
        private static readonly Selector sel_newArgumentEncoderWithArguments = "newArgumentEncoderWithArguments:";
        private static readonly Selector sel_newArgumentEncoderWithBufferBinding = "newArgumentEncoderWithBufferBinding:";
        private static readonly Selector sel_newFence = "newFence";
        private static readonly Selector sel_newEvent = "newEvent";
        private static readonly Selector sel_newSharedEvent = "newSharedEvent";
        private static readonly Selector sel_newSharedEventWithHandle = "newSharedEventWithHandle:";

        #endregion

        #region Shader Library and Archive Creation Selectors

        private static readonly Selector sel_newDefaultLibrary = "newDefaultLibrary";
        private static readonly Selector sel_newDefaultLibraryWithBundleError = "newDefaultLibraryWithBundle:error:";
        private static readonly Selector sel_newLibraryWithURLError = "newLibraryWithURL:error:";
        private static readonly Selector sel_newLibraryWithSourceOptionsError = "newLibraryWithSource:options:error:";
        private static readonly Selector sel_newLibraryWithSourceOptionsCompletionHandler = "newLibraryWithSource:options:completionHandler:";
        private static readonly Selector sel_newLibraryWithStitchedDescriptorError = "newLibraryWithStitchedDescriptor:error:";
        private static readonly Selector sel_newLibraryWithStitchedDescriptorCompletionHandler = "newLibraryWithStitchedDescriptor:completionHandler:";
        private static readonly Selector sel_newLibraryWithDataError = "newLibraryWithData:error:";
        private static readonly Selector sel_supportsDynamicLibraries = "supportsDynamicLibraries";
        private static readonly Selector sel_supportsRenderDynamicLibraries = "supportsRenderDynamicLibraries";
        private static readonly Selector sel_newDynamicLibraryError = "newDynamicLibrary:error:";
        private static readonly Selector sel_newDynamicLibraryWithURLError = "newDynamicLibraryWithURL:error:";
        private static readonly Selector sel_newBinaryArchiveWithDescriptorError = "newBinaryArchiveWithDescriptor:error:";

        #endregion

        private static readonly Selector sel_maximumConcurrentCompilationTaskCount = "maximumConcurrentCompilationTaskCount";
        private static readonly Selector sel_shouldMaximizeConcurrentCompilation = "shouldMaximizeConcurrentCompilation";
    }
}