using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLIOCompressionMethod : long
    {
        Zlib = 0,
        LZFSE = 1,
        LZ4 = 2,
        LZMA = 3,
        LZBitmap = 4,
    }

    public enum MTLFeatureSet : ulong
    {
        iOSGPUFamily1v1 = 0,
        iOSGPUFamily2v1 = 1,
        iOSGPUFamily1v2 = 2,
        iOSGPUFamily2v2 = 3,
        iOSGPUFamily3v1 = 4,
        iOSGPUFamily1v3 = 5,
        iOSGPUFamily2v3 = 6,
        iOSGPUFamily3v2 = 7,
        iOSGPUFamily1v4 = 8,
        iOSGPUFamily2v4 = 9,
        iOSGPUFamily3v3 = 10,
        iOSGPUFamily4v1 = 11,
        iOSGPUFamily1v5 = 12,
        iOSGPUFamily2v5 = 13,
        iOSGPUFamily3v4 = 14,
        iOSGPUFamily4v2 = 15,
        iOSGPUFamily5v1 = 16,
        macOSGPUFamily1v1 = 10000,
        OSXGPUFamily1v1 = 10000,
        macOSGPUFamily1v2 = 10001,
        OSXGPUFamily1v2 = 10001,
        OSXReadWriteTextureTier2 = 10002,
        macOSReadWriteTextureTier2 = 10002,
        macOSGPUFamily1v3 = 10003,
        macOSGPUFamily1v4 = 10004,
        macOSGPUFamily2v1 = 10005,
        watchOSGPUFamily1v1 = 20000,
        WatchOSGPUFamily1v1 = 20000,
        watchOSGPUFamily2v1 = 20001,
        WatchOSGPUFamily2v1 = 20001,
        tvOSGPUFamily1v1 = 30000,
        TVOSGPUFamily1v1 = 30000,
        tvOSGPUFamily1v2 = 30001,
        tvOSGPUFamily1v3 = 30002,
        tvOSGPUFamily2v1 = 30003,
        tvOSGPUFamily1v4 = 30004,
        tvOSGPUFamily2v2 = 30005,
    }

    public enum MTLGPUFamily : long
    {
        Apple1 = 1001,
        Apple2 = 1002,
        Apple3 = 1003,
        Apple4 = 1004,
        Apple5 = 1005,
        Apple6 = 1006,
        Apple7 = 1007,
        Apple8 = 1008,
        Mac1 = 2001,
        Mac2 = 2002,
        Common1 = 3001,
        Common2 = 3002,
        Common3 = 3003,
        MacCatalyst1 = 4001,
        MacCatalyst2 = 4002,
        Metal3 = 5001,
    }

    public enum MTLDeviceLocation : ulong
    {
        BuiltIn = 0,
        Slot = 1,
        External = 2,
        Unspecified = UInt64.MaxValue,
    }

    public enum MTLPipelineOption : ulong
    {
        None = 0,
        ArgumentInfo = 1,
        BufferTypeInfo = 2,
        FailOnBinaryArchiveMiss = 4,
    }

    public enum MTLReadWriteTextureTier : ulong
    {
        None = 0,
        Tier1 = 1,
        Tier2 = 2,
    }

    public enum MTLArgumentBuffersTier : ulong
    {
        Tier1 = 0,
        Tier2 = 1,
    }

    public enum MTLSparseTextureRegionAlignmentMode : ulong
    {
        Outward = 0,
        Inward = 1,
    }

    public enum MTLSparsePageSize : long
    {
        Size16 = 101,
        Size64 = 102,
        Size256 = 103,
    }

    public enum MTLCounterSamplingPoint : ulong
    {
        AtStageBoundary = 0,
        AtDrawBoundary = 1,
        AtDispatchBoundary = 2,
        AtTileDispatchBoundary = 3,
        AtBlitBoundary = 4,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLAccelerationStructureSizes
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAccelerationStructureSizes obj) => obj.NativePtr;
        public MTLAccelerationStructureSizes(IntPtr ptr) => NativePtr = ptr;

        public ulong accelerationStructureSize;

        public ulong buildScratchBufferSize;

        public ulong refitScratchBufferSize;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSizeAndAlign
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSizeAndAlign obj) => obj.NativePtr;
        public MTLSizeAndAlign(IntPtr ptr) => NativePtr = ptr;

        public ulong size;

        public ulong align;
    }

    [SupportedOSPlatform("macos")]
    public class MTLArgumentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLArgumentDescriptor obj) => obj.NativePtr;
        public MTLArgumentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLArgumentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLArgumentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLDataType DataType
        {
            get => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_dataType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDataType, (ulong)value);
        }

        public ulong Index
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setIndex, value);
        }

        public ulong ArrayLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArrayLength, value);
        }

        public MTLArgumentAccess Access
        {
            get => (MTLArgumentAccess)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_access);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAccess, (ulong)value);
        }

        public MTLTextureType TextureType
        {
            get => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTextureType, (ulong)value);
        }

        public ulong ConstantBlockAlignment
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_constantBlockAlignment);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantBlockAlignment, value);
        }

        public void SetDataType(MTLDataType dataType)
        {
            objc_msgSend(NativePtr, , dataType);
        }

        public void SetIndex(ulong index)
        {
            objc_msgSend(NativePtr, , index);
        }

        public void SetArrayLength(ulong arrayLength)
        {
            objc_msgSend(NativePtr, , arrayLength);
        }

        public void SetAccess(MTLArgumentAccess access)
        {
            objc_msgSend(NativePtr, , access);
        }

        public void SetTextureType(MTLTextureType textureType)
        {
            objc_msgSend(NativePtr, , textureType);
        }

        public void SetConstantBlockAlignment(ulong constantBlockAlignment)
        {
            objc_msgSend(NativePtr, , constantBlockAlignment);
        }

        private static readonly Selector sel_argumentDescriptor = "argumentDescriptor";
        private static readonly Selector sel_dataType = "dataType";
        private static readonly Selector sel_setDataType = "setDataType:";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_setIndex = "setIndex:";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_setArrayLength = "setArrayLength:";
        private static readonly Selector sel_access = "access";
        private static readonly Selector sel_setAccess = "setAccess:";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_setTextureType = "setTextureType:";
        private static readonly Selector sel_constantBlockAlignment = "constantBlockAlignment";
        private static readonly Selector sel_setConstantBlockAlignment = "setConstantBlockAlignment:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLDevice
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDevice obj) => obj.NativePtr;
        public MTLDevice(IntPtr ptr) => NativePtr = ptr;

        public bool IsHeadless => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isHeadless);

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public ulong RegistryID => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_registryID);

        public MTLSize MaxThreadsPerThreadgroup => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_maxThreadsPerThreadgroup));

        public bool LowPower => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isLowPower);

        public bool Headless => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isHeadless);

        public bool Removable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRemovable);

        public bool HasUnifiedMemory => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_hasUnifiedMemory);

        public ulong RecommendedMaxWorkingSetSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_recommendedMaxWorkingSetSize);

        public MTLDeviceLocation Location => (MTLDeviceLocation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_location);

        public ulong LocationNumber => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_locationNumber);

        public ulong MaxTransferRate => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTransferRate);

        public bool Depth24Stencil8PixelFormatSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepth24Stencil8PixelFormatSupported);

        public MTLReadWriteTextureTier ReadWriteTextureSupport => (MTLReadWriteTextureTier)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_readWriteTextureSupport);

        public MTLArgumentBuffersTier ArgumentBuffersSupport => (MTLArgumentBuffersTier)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentBuffersSupport);

        public bool RasterOrderGroupsSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_areRasterOrderGroupsSupported);

        public bool Supports32BitFloatFiltering => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supports32BitFloatFiltering);

        public bool Supports32BitMSAA => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supports32BitMSAA);

        public bool SupportsQueryTextureLOD => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsQueryTextureLOD);

        public bool SupportsBCTextureCompression => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsBCTextureCompression);

        public bool SupportsPullModelInterpolation => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsPullModelInterpolation);

        public bool BarycentricCoordsSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_areBarycentricCoordsSupported);

        public bool SupportsShaderBarycentricCoordinates => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsShaderBarycentricCoordinates);

        public ulong CurrentAllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_currentAllocatedSize);

        public MTLFence NewFence => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newFence));

        public ulong MaxThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxThreadgroupMemoryLength);

        public ulong MaxArgumentBufferSamplerCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxArgumentBufferSamplerCount);

        public bool ProgrammableSamplePositionsSupported => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_areProgrammableSamplePositionsSupported);

        public MTLEvent NewEvent => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newEvent));

        public ulong PeerGroupID => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_peerGroupID);

        public uint PeerIndex => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_peerIndex);

        public uint PeerCount => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_peerCount);

        public ulong MaxBufferLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxBufferLength);

        public NSArray CounterSets => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_counterSets));

        public bool SupportsDynamicLibraries => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsDynamicLibraries);

        public bool SupportsRenderDynamicLibraries => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsRenderDynamicLibraries);

        public bool SupportsRaytracing => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsRaytracing);

        public bool SupportsFunctionPointers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsFunctionPointers);

        public bool SupportsFunctionPointersFromRender => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsFunctionPointersFromRender);

        public bool SupportsRaytracingFromRender => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsRaytracingFromRender);

        public bool SupportsPrimitiveMotionBlur => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportsPrimitiveMotionBlur);

        public bool ShouldMaximizeConcurrentCompilation
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_shouldMaximizeConcurrentCompilation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShouldMaximizeConcurrentCompilation, value);
        }

        public ulong MaximumConcurrentCompilationTaskCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maximumConcurrentCompilationTaskCount);

        public static MTLDevice CreateSystemDefaultDevice()
        {
            throw new NotImplementedException();
        }

        public static NSArray CopyAllDevices()
        {
            throw new NotImplementedException();
        }

        public MTLCommandQueue NewCommandQueue(ulong maxCommandBufferCount)
        {
            throw new NotImplementedException();
        }

        public MTLCommandQueue NewCommandQueue()
        {
            throw new NotImplementedException();
        }

        public MTLSizeAndAlign HeapTextureSizeAndAlign(MTLTextureDescriptor desc)
        {
            throw new NotImplementedException();
        }

        public MTLSizeAndAlign HeapBufferSizeAndAlign(ulong length, MTLResourceOptions options)
        {
            throw new NotImplementedException();
        }

        public MTLHeap NewHeap(MTLHeapDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLBuffer NewBuffer(ulong length, MTLResourceOptions options)
        {
            throw new NotImplementedException();
        }

        public MTLBuffer NewBuffer(IntPtr pointer, ulong length, MTLResourceOptions options)
        {
            throw new NotImplementedException();
        }

        public MTLDepthStencilState NewDepthStencilState(MTLDepthStencilDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTexture(MTLTextureDescriptor descriptor, IntPtr iosurface, ulong plane)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewSharedTexture(MTLTextureDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewSharedTexture(MTLSharedTextureHandle sharedHandle)
        {
            throw new NotImplementedException();
        }

        public MTLSamplerState NewSamplerState(MTLSamplerDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewDefaultLibrary(NSBundle bundle, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewDefaultLibrary()
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewLibrary(NSString filepath, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewLibrary(NSURL url, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewLibrary(IntPtr data, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewLibrary(NSString source, MTLCompileOptions options, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLLibrary NewLibrary(MTLStitchedLibraryDescriptor descriptor, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, IntPtr reflection, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLComputePipelineState NewComputePipelineState(MTLFunction computeFunction, MTLPipelineOption options, IntPtr reflection, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLComputePipelineState NewComputePipelineState(MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, IntPtr reflection, NSError error)
        {
            throw new NotImplementedException();
        }

        public bool SupportsFeatureSet(MTLFeatureSet featureSet)
        {
            throw new NotImplementedException();
        }

        public bool SupportsFamily(MTLGPUFamily gpuFamily)
        {
            throw new NotImplementedException();
        }

        public bool SupportsTextureSampleCount(ulong sampleCount)
        {
            throw new NotImplementedException();
        }

        public ulong MinimumLinearTextureAlignmentForPixelFormat(MTLPixelFormat format)
        {
            throw new NotImplementedException();
        }

        public ulong MinimumTextureBufferAlignmentForPixelFormat(MTLPixelFormat format)
        {
            throw new NotImplementedException();
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, IntPtr reflection, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, IntPtr reflection, NSError error)
        {
            throw new NotImplementedException();
        }

        public void GetDefaultSamplePositions(MTLSamplePosition positions, ulong count)
        {
            objc_msgSend(NativePtr, , positions, count);
        }

        public MTLArgumentEncoder NewArgumentEncoder(NSArray arguments)
        {
            throw new NotImplementedException();
        }

        public bool SupportsRasterizationRateMap(ulong layerCount)
        {
            throw new NotImplementedException();
        }

        public MTLRasterizationRateMap NewRasterizationRateMap(MTLRasterizationRateMapDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLIndirectCommandBuffer NewIndirectCommandBuffer(MTLIndirectCommandBufferDescriptor descriptor, ulong maxCount, MTLResourceOptions options)
        {
            throw new NotImplementedException();
        }

        public MTLSharedEvent NewSharedEvent(MTLSharedEventHandle sharedEventHandle)
        {
            throw new NotImplementedException();
        }

        public MTLSharedEvent NewSharedEvent()
        {
            throw new NotImplementedException();
        }

        public IntPtr NewIOHandle(NSURL url, NSError error)
        {
            throw new NotImplementedException();
        }

        public IntPtr NewIOCommandQueue(IntPtr descriptor, NSError error)
        {
            throw new NotImplementedException();
        }

        public IntPtr NewIOHandle(NSURL url, MTLIOCompressionMethod compressionMethod, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, ulong sampleCount)
        {
            throw new NotImplementedException();
        }

        public void ConvertSparsePixelRegions(MTLRegion pixelRegions, MTLRegion tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, ulong numRegions)
        {
            objc_msgSend(NativePtr, , pixelRegions, tileRegions, tileSize, mode, numRegions);
        }

        public void ConvertSparseTileRegions(MTLRegion tileRegions, MTLRegion pixelRegions, MTLSize tileSize, ulong numRegions)
        {
            objc_msgSend(NativePtr, , tileRegions, pixelRegions, tileSize, numRegions);
        }

        public ulong SparseTileSizeInBytes(MTLSparsePageSize sparsePageSize)
        {
            throw new NotImplementedException();
        }

        public ulong SparseTileSizeInBytes()
        {
            throw new NotImplementedException();
        }

        public MTLSize SparseTileSize(MTLTextureType textureType, MTLPixelFormat pixelFormat, ulong sampleCount, MTLSparsePageSize sparsePageSize)
        {
            throw new NotImplementedException();
        }

        public MTLCounterSampleBuffer NewCounterSampleBuffer(MTLCounterSampleBufferDescriptor descriptor, NSError error)
        {
            throw new NotImplementedException();
        }

        public void SampleTimestamps(ulong cpuTimestamp, ulong gpuTimestamp)
        {
            objc_msgSend(NativePtr, , cpuTimestamp, gpuTimestamp);
        }

        public MTLArgumentEncoder NewArgumentEncoder(MTLBufferBinding bufferBinding)
        {
            throw new NotImplementedException();
        }

        public bool SupportsCounterSampling(MTLCounterSamplingPoint samplingPoint)
        {
            throw new NotImplementedException();
        }

        public bool SupportsVertexAmplificationCount(ulong count)
        {
            throw new NotImplementedException();
        }

        public MTLDynamicLibrary NewDynamicLibrary(MTLLibrary library, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLDynamicLibrary NewDynamicLibrary(NSURL url, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLBinaryArchive NewBinaryArchive(MTLBinaryArchiveDescriptor descriptor, NSError error)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructureSizes AccelerationStructureSizes(MTLAccelerationStructureDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructure NewAccelerationStructure(ulong size)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(ulong size)
        {
            throw new NotImplementedException();
        }

        public MTLSizeAndAlign HeapAccelerationStructureSizeAndAlign(MTLAccelerationStructureDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public void SetShouldMaximizeConcurrentCompilation(bool shouldMaximizeConcurrentCompilation)
        {
            objc_msgSend(NativePtr, , shouldMaximizeConcurrentCompilation);
        }

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_registryID = "registryID";
        private static readonly Selector sel_maxThreadsPerThreadgroup = "maxThreadsPerThreadgroup";
        private static readonly Selector sel_isLowPower = "isLowPower";
        private static readonly Selector sel_isHeadless = "isHeadless";
        private static readonly Selector sel_isRemovable = "isRemovable";
        private static readonly Selector sel_hasUnifiedMemory = "hasUnifiedMemory";
        private static readonly Selector sel_recommendedMaxWorkingSetSize = "recommendedMaxWorkingSetSize";
        private static readonly Selector sel_location = "location";
        private static readonly Selector sel_locationNumber = "locationNumber";
        private static readonly Selector sel_maxTransferRate = "maxTransferRate";
        private static readonly Selector sel_isDepth24Stencil8PixelFormatSupported = "isDepth24Stencil8PixelFormatSupported";
        private static readonly Selector sel_readWriteTextureSupport = "readWriteTextureSupport";
        private static readonly Selector sel_argumentBuffersSupport = "argumentBuffersSupport";
        private static readonly Selector sel_areRasterOrderGroupsSupported = "areRasterOrderGroupsSupported";
        private static readonly Selector sel_supports32BitFloatFiltering = "supports32BitFloatFiltering";
        private static readonly Selector sel_supports32BitMSAA = "supports32BitMSAA";
        private static readonly Selector sel_supportsQueryTextureLOD = "supportsQueryTextureLOD";
        private static readonly Selector sel_supportsBCTextureCompression = "supportsBCTextureCompression";
        private static readonly Selector sel_supportsPullModelInterpolation = "supportsPullModelInterpolation";
        private static readonly Selector sel_areBarycentricCoordsSupported = "areBarycentricCoordsSupported";
        private static readonly Selector sel_supportsShaderBarycentricCoordinates = "supportsShaderBarycentricCoordinates";
        private static readonly Selector sel_currentAllocatedSize = "currentAllocatedSize";
        private static readonly Selector sel_newCommandQueue = "newCommandQueue";
        private static readonly Selector sel_newCommandQueueWithMaxCommandBufferCount = "newCommandQueueWithMaxCommandBufferCount:";
        private static readonly Selector sel_heapTextureSizeAndAlignWithDescriptor = "heapTextureSizeAndAlignWithDescriptor:";
        private static readonly Selector sel_heapBufferSizeAndAlignWithLengthoptions = "heapBufferSizeAndAlignWithLength:options:";
        private static readonly Selector sel_newHeapWithDescriptor = "newHeapWithDescriptor:";
        private static readonly Selector sel_newBufferWithLengthoptions = "newBufferWithLength:options:";
        private static readonly Selector sel_newBufferWithByteslengthoptions = "newBufferWithBytes:length:options:";
        private static readonly Selector sel_newBufferWithBytesNoCopylengthoptionsdeallocator = "newBufferWithBytesNoCopy:length:options:deallocator:";
        private static readonly Selector sel_newDepthStencilStateWithDescriptor = "newDepthStencilStateWithDescriptor:";
        private static readonly Selector sel_newTextureWithDescriptor = "newTextureWithDescriptor:";
        private static readonly Selector sel_newTextureWithDescriptoriosurfaceplane = "newTextureWithDescriptor:iosurface:plane:";
        private static readonly Selector sel_newSharedTextureWithDescriptor = "newSharedTextureWithDescriptor:";
        private static readonly Selector sel_newSharedTextureWithHandle = "newSharedTextureWithHandle:";
        private static readonly Selector sel_newSamplerStateWithDescriptor = "newSamplerStateWithDescriptor:";
        private static readonly Selector sel_newDefaultLibrary = "newDefaultLibrary";
        private static readonly Selector sel_newDefaultLibraryWithBundleerror = "newDefaultLibraryWithBundle:error:";
        private static readonly Selector sel_newLibraryWithFileerror = "newLibraryWithFile:error:";
        private static readonly Selector sel_newLibraryWithURLerror = "newLibraryWithURL:error:";
        private static readonly Selector sel_newLibraryWithDataerror = "newLibraryWithData:error:";
        private static readonly Selector sel_newLibraryWithSourceoptionserror = "newLibraryWithSource:options:error:";
        private static readonly Selector sel_newLibraryWithStitchedDescriptorerror = "newLibraryWithStitchedDescriptor:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptorerror = "newRenderPipelineStateWithDescriptor:error:";
        private static readonly Selector sel_newRenderPipelineStateWithDescriptoroptionsreflectionerror = "newRenderPipelineStateWithDescriptor:options:reflection:error:";
        private static readonly Selector sel_newComputePipelineStateWithFunctionerror = "newComputePipelineStateWithFunction:error:";
        private static readonly Selector sel_newComputePipelineStateWithFunctionoptionsreflectionerror = "newComputePipelineStateWithFunction:options:reflection:error:";
        private static readonly Selector sel_newComputePipelineStateWithDescriptoroptionsreflectionerror = "newComputePipelineStateWithDescriptor:options:reflection:error:";
        private static readonly Selector sel_newFence = "newFence";
        private static readonly Selector sel_supportsFeatureSet = "supportsFeatureSet:";
        private static readonly Selector sel_supportsFamily = "supportsFamily:";
        private static readonly Selector sel_supportsTextureSampleCount = "supportsTextureSampleCount:";
        private static readonly Selector sel_minimumLinearTextureAlignmentForPixelFormat = "minimumLinearTextureAlignmentForPixelFormat:";
        private static readonly Selector sel_minimumTextureBufferAlignmentForPixelFormat = "minimumTextureBufferAlignmentForPixelFormat:";
        private static readonly Selector sel_newRenderPipelineStateWithTileDescriptoroptionsreflectionerror = "newRenderPipelineStateWithTileDescriptor:options:reflection:error:";
        private static readonly Selector sel_newRenderPipelineStateWithMeshDescriptoroptionsreflectionerror = "newRenderPipelineStateWithMeshDescriptor:options:reflection:error:";
        private static readonly Selector sel_maxThreadgroupMemoryLength = "maxThreadgroupMemoryLength";
        private static readonly Selector sel_maxArgumentBufferSamplerCount = "maxArgumentBufferSamplerCount";
        private static readonly Selector sel_areProgrammableSamplePositionsSupported = "areProgrammableSamplePositionsSupported";
        private static readonly Selector sel_getDefaultSamplePositionscount = "getDefaultSamplePositions:count:";
        private static readonly Selector sel_newArgumentEncoderWithArguments = "newArgumentEncoderWithArguments:";
        private static readonly Selector sel_supportsRasterizationRateMapWithLayerCount = "supportsRasterizationRateMapWithLayerCount:";
        private static readonly Selector sel_newRasterizationRateMapWithDescriptor = "newRasterizationRateMapWithDescriptor:";
        private static readonly Selector sel_newIndirectCommandBufferWithDescriptormaxCommandCountoptions = "newIndirectCommandBufferWithDescriptor:maxCommandCount:options:";
        private static readonly Selector sel_newEvent = "newEvent";
        private static readonly Selector sel_newSharedEvent = "newSharedEvent";
        private static readonly Selector sel_newSharedEventWithHandle = "newSharedEventWithHandle:";
        private static readonly Selector sel_peerGroupID = "peerGroupID";
        private static readonly Selector sel_peerIndex = "peerIndex";
        private static readonly Selector sel_peerCount = "peerCount";
        private static readonly Selector sel_newIOHandleWithURLerror = "newIOHandleWithURL:error:";
        private static readonly Selector sel_newIOCommandQueueWithDescriptorerror = "newIOCommandQueueWithDescriptor:error:";
        private static readonly Selector sel_newIOHandleWithURLcompressionMethoderror = "newIOHandleWithURL:compressionMethod:error:";
        private static readonly Selector sel_sparseTileSizeWithTextureTypepixelFormatsampleCount = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:";
        private static readonly Selector sel_sparseTileSizeInBytes = "sparseTileSizeInBytes";
        private static readonly Selector sel_convertSparsePixelRegionstoTileRegionswithTileSizealignmentModenumRegions = "convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:";
        private static readonly Selector sel_convertSparseTileRegionstoPixelRegionswithTileSizenumRegions = "convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:";
        private static readonly Selector sel_sparseTileSizeInBytesForSparsePageSize = "sparseTileSizeInBytesForSparsePageSize:";
        private static readonly Selector sel_sparseTileSizeWithTextureTypepixelFormatsampleCountsparsePageSize = "sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:";
        private static readonly Selector sel_maxBufferLength = "maxBufferLength";
        private static readonly Selector sel_counterSets = "counterSets";
        private static readonly Selector sel_newCounterSampleBufferWithDescriptorerror = "newCounterSampleBufferWithDescriptor:error:";
        private static readonly Selector sel_sampleTimestampsgpuTimestamp = "sampleTimestamps:gpuTimestamp:";
        private static readonly Selector sel_newArgumentEncoderWithBufferBinding = "newArgumentEncoderWithBufferBinding:";
        private static readonly Selector sel_supportsCounterSampling = "supportsCounterSampling:";
        private static readonly Selector sel_supportsVertexAmplificationCount = "supportsVertexAmplificationCount:";
        private static readonly Selector sel_supportsDynamicLibraries = "supportsDynamicLibraries";
        private static readonly Selector sel_supportsRenderDynamicLibraries = "supportsRenderDynamicLibraries";
        private static readonly Selector sel_newDynamicLibraryerror = "newDynamicLibrary:error:";
        private static readonly Selector sel_newDynamicLibraryWithURLerror = "newDynamicLibraryWithURL:error:";
        private static readonly Selector sel_newBinaryArchiveWithDescriptorerror = "newBinaryArchiveWithDescriptor:error:";
        private static readonly Selector sel_supportsRaytracing = "supportsRaytracing";
        private static readonly Selector sel_accelerationStructureSizesWithDescriptor = "accelerationStructureSizesWithDescriptor:";
        private static readonly Selector sel_newAccelerationStructureWithSize = "newAccelerationStructureWithSize:";
        private static readonly Selector sel_newAccelerationStructureWithDescriptor = "newAccelerationStructureWithDescriptor:";
        private static readonly Selector sel_heapAccelerationStructureSizeAndAlignWithSize = "heapAccelerationStructureSizeAndAlignWithSize:";
        private static readonly Selector sel_heapAccelerationStructureSizeAndAlignWithDescriptor = "heapAccelerationStructureSizeAndAlignWithDescriptor:";
        private static readonly Selector sel_supportsFunctionPointers = "supportsFunctionPointers";
        private static readonly Selector sel_supportsFunctionPointersFromRender = "supportsFunctionPointersFromRender";
        private static readonly Selector sel_supportsRaytracingFromRender = "supportsRaytracingFromRender";
        private static readonly Selector sel_supportsPrimitiveMotionBlur = "supportsPrimitiveMotionBlur";
        private static readonly Selector sel_shouldMaximizeConcurrentCompilation = "shouldMaximizeConcurrentCompilation";
        private static readonly Selector sel_setShouldMaximizeConcurrentCompilation = "setShouldMaximizeConcurrentCompilation:";
        private static readonly Selector sel_maximumConcurrentCompilationTaskCount = "maximumConcurrentCompilationTaskCount";
    }
}
