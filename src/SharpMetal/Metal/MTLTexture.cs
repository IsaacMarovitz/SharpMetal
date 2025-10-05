using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLTextureCompressionType : long
    {
        Lossless = 0,
        Lossy = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTextureSwizzle : byte
    {
        Zero = 0,
        One = 1,
        Red = 2,
        Green = 3,
        Blue = 4,
        Alpha = 5,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTextureType : ulong
    {
        Type1D = 0,
        Type1DArray = 1,
        Type2D = 2,
        Type2DArray = 3,
        Type2DMultisample = 4,
        Cube = 5,
        CubeArray = 6,
        Type3D = 7,
        Type2DMultisampleArray = 8,
        TextureBuffer = 9,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLTextureUsage : ulong
    {
        Unknown = 0,
        ShaderRead = 1,
        ShaderWrite = 1 << 1,
        RenderTarget = 1 << 2,
        PixelFormatView = 1 << 4,
        ShaderAtomic = 1 << 5,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLTextureSwizzleChannels
    {
        public MTLTextureSwizzle red;
        public MTLTextureSwizzle green;
        public MTLTextureSwizzle blue;
        public MTLTextureSwizzle alpha;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLSharedTextureHandle : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSharedTextureHandle obj) => obj.NativePtr;
        public MTLSharedTextureHandle(IntPtr ptr) => NativePtr = ptr;

        public MTLSharedTextureHandle()
        {
            var cls = new ObjectiveCClass("MTLSharedTextureHandle");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTexture : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTexture obj) => obj.NativePtr;
        public static implicit operator MTLResource(MTLTexture obj) => new(obj.NativePtr);
        public MTLTexture(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public bool AllowGPUOptimizedContents => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowGPUOptimizedContents);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        public MTLBuffer Buffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));

        public ulong BufferBytesPerRow => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferBytesPerRow);

        public ulong BufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferOffset);

        public MTLTextureCompressionType CompressionType => (MTLTextureCompressionType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compressionType);

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public ulong Depth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depth);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public ulong FirstMipmapInTail => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_firstMipmapInTail);

        [System.Obsolete]
        public bool FramebufferOnly => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isFramebufferOnly);

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);

        public MTLHeap Heap => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_heap));

        public ulong HeapOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_heapOffset);

        public ulong Height => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_height);

        public IntPtr Iosurface => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_iosurface));

        public ulong IosurfacePlane => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_iosurfacePlane);

        public bool IsAliasable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAliasable);

        public bool IsFramebufferOnly => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isFramebufferOnly);

        public bool IsShareable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isShareable);

        public bool IsSparse => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isSparse);

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong MipmapLevelCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipmapLevelCount);

        public MTLSharedTextureHandle NewSharedTextureHandle => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newSharedTextureHandle));

        public ulong ParentRelativeLevel => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_parentRelativeLevel);

        public ulong ParentRelativeSlice => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_parentRelativeSlice);

        public MTLTexture ParentTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parentTexture));

        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);

        public MTLTexture RemoteStorageTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_remoteStorageTexture));

        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);

        public MTLResource RootResource => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_rootResource));

        public ulong SampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);

        [System.Obsolete]
        public bool Shareable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isShareable);

        public MTLTextureSparseTier SparseTextureTier => (MTLTextureSparseTier)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_sparseTextureTier);

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public MTLTextureSwizzleChannels Swizzle => ObjectiveCRuntime.MTLTextureSwizzleChannels_objc_msgSend(NativePtr, sel_swizzle);

        public ulong TailSizeInBytes => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tailSizeInBytes);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLTextureUsage Usage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);

        public ulong Width => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_width);

        public void GetBytes(IntPtr pixelBytes, ulong bytesPerRow, ulong bytesPerImage, MTLRegion region, ulong level, ulong slice)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_getBytesbytesPerRowbytesPerImagefromRegionmipmapLevelslice, pixelBytes, bytesPerRow, bytesPerImage, region, level, slice);
        }

        public void GetBytes(IntPtr pixelBytes, ulong bytesPerRow, MTLRegion region, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_getBytesbytesPerRowfromRegionmipmapLevel, pixelBytes, bytesPerRow, region, level);
        }

        public void MakeAliasable()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_makeAliasable);
        }

        public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRemoteTextureViewForDevice, device));
        }

        public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureViewWithPixelFormat, (ulong)pixelFormat));
        }

        public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureViewWithPixelFormattextureTypelevelsslices, (ulong)pixelFormat, (ulong)textureType, levelRange, sliceRange));
        }

        public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureViewWithDescriptor, descriptor));
        }

        public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureViewWithPixelFormattextureTypelevelsslicesswizzle, (ulong)pixelFormat, (ulong)textureType, levelRange, sliceRange, swizzle));
        }

        public void ReplaceRegion(MTLRegion region, ulong level, ulong slice, IntPtr pixelBytes, ulong bytesPerRow, ulong bytesPerImage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_replaceRegionmipmapLevelslicewithBytesbytesPerRowbytesPerImage, region, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
        }

        public void ReplaceRegion(MTLRegion region, ulong level, IntPtr pixelBytes, ulong bytesPerRow)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_replaceRegionmipmapLevelwithBytesbytesPerRow, region, level, pixelBytes, bytesPerRow);
        }

        public int SetOwner(IntPtr task_id_token)
        {
            return ObjectiveCRuntime.int_objc_msgSend(NativePtr, sel_setOwnerWithIdentity, task_id_token);
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_allowGPUOptimizedContents = "allowGPUOptimizedContents";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_buffer = "buffer";
        private static readonly Selector sel_bufferBytesPerRow = "bufferBytesPerRow";
        private static readonly Selector sel_bufferOffset = "bufferOffset";
        private static readonly Selector sel_compressionType = "compressionType";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_depth = "depth";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_firstMipmapInTail = "firstMipmapInTail";
        private static readonly Selector sel_getBytesbytesPerRowbytesPerImagefromRegionmipmapLevelslice = "getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:";
        private static readonly Selector sel_getBytesbytesPerRowfromRegionmipmapLevel = "getBytes:bytesPerRow:fromRegion:mipmapLevel:";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_heap = "heap";
        private static readonly Selector sel_heapOffset = "heapOffset";
        private static readonly Selector sel_height = "height";
        private static readonly Selector sel_iosurface = "iosurface";
        private static readonly Selector sel_iosurfacePlane = "iosurfacePlane";
        private static readonly Selector sel_isAliasable = "isAliasable";
        private static readonly Selector sel_isFramebufferOnly = "isFramebufferOnly";
        private static readonly Selector sel_isShareable = "isShareable";
        private static readonly Selector sel_isSparse = "isSparse";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_makeAliasable = "makeAliasable";
        private static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        private static readonly Selector sel_newRemoteTextureViewForDevice = "newRemoteTextureViewForDevice:";
        private static readonly Selector sel_newSharedTextureHandle = "newSharedTextureHandle";
        private static readonly Selector sel_newTextureViewWithDescriptor = "newTextureViewWithDescriptor:";
        private static readonly Selector sel_newTextureViewWithPixelFormat = "newTextureViewWithPixelFormat:";
        private static readonly Selector sel_newTextureViewWithPixelFormattextureTypelevelsslices = "newTextureViewWithPixelFormat:textureType:levels:slices:";
        private static readonly Selector sel_newTextureViewWithPixelFormattextureTypelevelsslicesswizzle = "newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:";
        private static readonly Selector sel_parentRelativeLevel = "parentRelativeLevel";
        private static readonly Selector sel_parentRelativeSlice = "parentRelativeSlice";
        private static readonly Selector sel_parentTexture = "parentTexture";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_remoteStorageTexture = "remoteStorageTexture";
        private static readonly Selector sel_replaceRegionmipmapLevelslicewithBytesbytesPerRowbytesPerImage = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";
        private static readonly Selector sel_replaceRegionmipmapLevelwithBytesbytesPerRow = "replaceRegion:mipmapLevel:withBytes:bytesPerRow:";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_rootResource = "rootResource";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOwnerWithIdentity = "setOwnerWithIdentity:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_sparseTextureTier = "sparseTextureTier";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_tailSizeInBytes = "tailSizeInBytes";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_width = "width";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTextureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureDescriptor obj) => obj.NativePtr;
        public MTLTextureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTextureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool AllowGPUOptimizedContents
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowGPUOptimizedContents);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowGPUOptimizedContents, value);
        }

        public ulong ArrayLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArrayLength, value);
        }

        public MTLTextureCompressionType CompressionType
        {
            get => (MTLTextureCompressionType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compressionType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompressionType, (long)value);
        }

        public MTLCPUCacheMode CpuCacheMode
        {
            get => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCpuCacheMode, (ulong)value);
        }

        public ulong Depth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepth, value);
        }

        public MTLHazardTrackingMode HazardTrackingMode
        {
            get => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setHazardTrackingMode, (ulong)value);
        }

        public ulong Height
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_height);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setHeight, value);
        }

        public ulong MipmapLevelCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipmapLevelCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMipmapLevelCount, value);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
        }

        public MTLSparsePageSize PlacementSparsePageSize
        {
            get => (MTLSparsePageSize)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_placementSparsePageSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPlacementSparsePageSize, (long)value);
        }

        public MTLResourceOptions ResourceOptions
        {
            get => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResourceOptions, (ulong)value);
        }

        public ulong SampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public MTLStorageMode StorageMode
        {
            get => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)value);
        }

        public MTLTextureSwizzleChannels Swizzle
        {
            get => ObjectiveCRuntime.MTLTextureSwizzleChannels_objc_msgSend(NativePtr, sel_swizzle);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSwizzle, value);
        }

        public MTLTextureType TextureType
        {
            get => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTextureType, (ulong)value);
        }

        public MTLTextureUsage Usage
        {
            get => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        public ulong Width
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_width);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWidth, value);
        }

        public static MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, ulong width, ulong height, bool mipmapped)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("MTLTextureDescriptor"), sel_texture2DDescriptorWithPixelFormatwidthheightmipmapped, (ulong)pixelFormat, width, height, mipmapped));
        }

        public static MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, ulong width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("MTLTextureDescriptor"), sel_textureBufferDescriptorWithPixelFormatwidthresourceOptionsusage, (ulong)pixelFormat, width, (ulong)resourceOptions, (ulong)usage));
        }

        public static MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, ulong size, bool mipmapped)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("MTLTextureDescriptor"), sel_textureCubeDescriptorWithPixelFormatsizemipmapped, (ulong)pixelFormat, size, mipmapped));
        }

        private static readonly Selector sel_allowGPUOptimizedContents = "allowGPUOptimizedContents";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_compressionType = "compressionType";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_depth = "depth";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_height = "height";
        private static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_placementSparsePageSize = "placementSparsePageSize";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setAllowGPUOptimizedContents = "setAllowGPUOptimizedContents:";
        private static readonly Selector sel_setArrayLength = "setArrayLength:";
        private static readonly Selector sel_setCompressionType = "setCompressionType:";
        private static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        private static readonly Selector sel_setDepth = "setDepth:";
        private static readonly Selector sel_setHazardTrackingMode = "setHazardTrackingMode:";
        private static readonly Selector sel_setHeight = "setHeight:";
        private static readonly Selector sel_setMipmapLevelCount = "setMipmapLevelCount:";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_setPlacementSparsePageSize = "setPlacementSparsePageSize:";
        private static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        private static readonly Selector sel_setSwizzle = "setSwizzle:";
        private static readonly Selector sel_setTextureType = "setTextureType:";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_setWidth = "setWidth:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_texture2DDescriptorWithPixelFormatwidthheightmipmapped = "texture2DDescriptorWithPixelFormat:width:height:mipmapped:";
        private static readonly Selector sel_textureBufferDescriptorWithPixelFormatwidthresourceOptionsusage = "textureBufferDescriptorWithPixelFormat:width:resourceOptions:usage:";
        private static readonly Selector sel_textureCubeDescriptorWithPixelFormatsizemipmapped = "textureCubeDescriptorWithPixelFormat:size:mipmapped:";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_width = "width";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTextureViewDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureViewDescriptor obj) => obj.NativePtr;
        public MTLTextureViewDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureViewDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTextureViewDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSRange LevelRange
        {
            get => ObjectiveCRuntime.NSRange_objc_msgSend(NativePtr, sel_levelRange);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevelRange, value);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
        }

        public NSRange SliceRange
        {
            get => ObjectiveCRuntime.NSRange_objc_msgSend(NativePtr, sel_sliceRange);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSliceRange, value);
        }

        public MTLTextureSwizzleChannels Swizzle
        {
            get => ObjectiveCRuntime.MTLTextureSwizzleChannels_objc_msgSend(NativePtr, sel_swizzle);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSwizzle, value);
        }

        public MTLTextureType TextureType
        {
            get => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTextureType, (ulong)value);
        }

        private static readonly Selector sel_levelRange = "levelRange";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setLevelRange = "setLevelRange:";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_setSliceRange = "setSliceRange:";
        private static readonly Selector sel_setSwizzle = "setSwizzle:";
        private static readonly Selector sel_setTextureType = "setTextureType:";
        private static readonly Selector sel_sliceRange = "sliceRange";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_release = "release";
    }
}
