using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
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

    public enum MTLTextureSwizzle : byte
    {
        Zero = 0,
        One = 1,
        Red = 2,
        Green = 3,
        Blue = 4,
        Alpha = 5,
    }

    public enum MTLTextureUsage : ulong
    {
        Unknown = 0,
        ShaderRead = 1,
        ShaderWrite = 2,
        RenderTarget = 4,
        PixelFormatView = 16,
    }

    public enum MTLTextureCompressionType : long
    {
        Lossless = 0,
        Lossy = 1,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLTextureSwizzleChannels
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureSwizzleChannels obj) => obj.NativePtr;
        public MTLTextureSwizzleChannels(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureSwizzle red;

        public MTLTextureSwizzle green;

        public MTLTextureSwizzle blue;

        public MTLTextureSwizzle alpha;
    }

    [SupportedOSPlatform("macos")]
    public class MTLSharedTextureHandle
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSharedTextureHandle obj) => obj.NativePtr;
        public MTLSharedTextureHandle(IntPtr ptr) => NativePtr = ptr;

        public MTLSharedTextureHandle()
        {
            var cls = new ObjectiveCClass("MTLSharedTextureHandle");
            NativePtr = cls.AllocInit();
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
    }

    [SupportedOSPlatform("macos")]
    public class MTLTextureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureDescriptor obj) => obj.NativePtr;
        public MTLTextureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTextureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTextureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLTextureType TextureType
        {
            get => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTextureType, (ulong)value);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
        }

        public ulong Width
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_width);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWidth, value);
        }

        public ulong Height
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_height);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setHeight, value);
        }

        public ulong Depth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepth, value);
        }

        public ulong MipmapLevelCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipmapLevelCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMipmapLevelCount, value);
        }

        public ulong SampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public ulong ArrayLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArrayLength, value);
        }

        public MTLResourceOptions ResourceOptions
        {
            get => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResourceOptions, (ulong)value);
        }

        public MTLCPUCacheMode CpuCacheMode
        {
            get => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCpuCacheMode, (ulong)value);
        }

        public MTLStorageMode StorageMode
        {
            get => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)value);
        }

        public MTLHazardTrackingMode HazardTrackingMode
        {
            get => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setHazardTrackingMode, (ulong)value);
        }

        public MTLTextureUsage Usage
        {
            get => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        public bool AllowGPUOptimizedContents
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowGPUOptimizedContents);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowGPUOptimizedContents, value);
        }

        public MTLTextureCompressionType CompressionType
        {
            get => (MTLTextureCompressionType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compressionType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompressionType, (long)value);
        }

        public MTLTextureSwizzleChannels Swizzle
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_swizzle));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSwizzle, value);
        }

        public MTLTextureDescriptor Texture2DDescriptor(MTLPixelFormat pixelFormat, ulong width, ulong height, bool mipmapped)
        {
            throw new NotImplementedException();
        }

        public MTLTextureDescriptor TextureCubeDescriptor(MTLPixelFormat pixelFormat, ulong size, bool mipmapped)
        {
            throw new NotImplementedException();
        }

        public MTLTextureDescriptor TextureBufferDescriptor(MTLPixelFormat pixelFormat, ulong width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
        {
            throw new NotImplementedException();
        }

        public void SetTextureType(MTLTextureType textureType)
        {
            throw new NotImplementedException();
        }

        public void SetPixelFormat(MTLPixelFormat pixelFormat)
        {
            throw new NotImplementedException();
        }

        public void SetWidth(ulong width)
        {
            throw new NotImplementedException();
        }

        public void SetHeight(ulong height)
        {
            throw new NotImplementedException();
        }

        public void SetDepth(ulong depth)
        {
            throw new NotImplementedException();
        }

        public void SetMipmapLevelCount(ulong mipmapLevelCount)
        {
            throw new NotImplementedException();
        }

        public void SetSampleCount(ulong sampleCount)
        {
            throw new NotImplementedException();
        }

        public void SetArrayLength(ulong arrayLength)
        {
            throw new NotImplementedException();
        }

        public void SetResourceOptions(MTLResourceOptions resourceOptions)
        {
            throw new NotImplementedException();
        }

        public void SetCpuCacheMode(MTLCPUCacheMode cpuCacheMode)
        {
            throw new NotImplementedException();
        }

        public void SetStorageMode(MTLStorageMode storageMode)
        {
            throw new NotImplementedException();
        }

        public void SetHazardTrackingMode(MTLHazardTrackingMode hazardTrackingMode)
        {
            throw new NotImplementedException();
        }

        public void SetUsage(MTLTextureUsage usage)
        {
            throw new NotImplementedException();
        }

        public void SetAllowGPUOptimizedContents(bool allowGPUOptimizedContents)
        {
            throw new NotImplementedException();
        }

        public void SetCompressionType(MTLTextureCompressionType compressionType)
        {
            throw new NotImplementedException();
        }

        public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_texture2DDescriptorWithPixelFormatwidthheightmipmapped = "texture2DDescriptorWithPixelFormat:width:height:mipmapped:";
        private static readonly Selector sel_textureCubeDescriptorWithPixelFormatsizemipmapped = "textureCubeDescriptorWithPixelFormat:size:mipmapped:";
        private static readonly Selector sel_textureBufferDescriptorWithPixelFormatwidthresourceOptionsusage = "textureBufferDescriptorWithPixelFormat:width:resourceOptions:usage:";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_setTextureType = "setTextureType:";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_width = "width";
        private static readonly Selector sel_setWidth = "setWidth:";
        private static readonly Selector sel_height = "height";
        private static readonly Selector sel_setHeight = "setHeight:";
        private static readonly Selector sel_depth = "depth";
        private static readonly Selector sel_setDepth = "setDepth:";
        private static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        private static readonly Selector sel_setMipmapLevelCount = "setMipmapLevelCount:";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_setArrayLength = "setArrayLength:";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_setHazardTrackingMode = "setHazardTrackingMode:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_allowGPUOptimizedContents = "allowGPUOptimizedContents";
        private static readonly Selector sel_setAllowGPUOptimizedContents = "setAllowGPUOptimizedContents:";
        private static readonly Selector sel_compressionType = "compressionType";
        private static readonly Selector sel_setCompressionType = "setCompressionType:";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_setSwizzle = "setSwizzle:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLTexture
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTexture obj) => obj.NativePtr;
        public MTLTexture(IntPtr ptr) => NativePtr = ptr;

        public MTLResource RootResource => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_rootResource));

        public MTLTexture ParentTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parentTexture));

        public ulong ParentRelativeLevel => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_parentRelativeLevel);

        public ulong ParentRelativeSlice => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_parentRelativeSlice);

        public MTLBuffer Buffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));

        public ulong BufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferOffset);

        public ulong BufferBytesPerRow => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferBytesPerRow);

        public IntPtr Iosurface => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_iosurface));

        public ulong IosurfacePlane => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_iosurfacePlane);

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);

        public ulong Width => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_width);

        public ulong Height => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_height);

        public ulong Depth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depth);

        public ulong MipmapLevelCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipmapLevelCount);

        public ulong SampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        public MTLTextureUsage Usage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);

        public bool Shareable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isShareable);

        public bool FramebufferOnly => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isFramebufferOnly);

        public ulong FirstMipmapInTail => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_firstMipmapInTail);

        public ulong TailSizeInBytes => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tailSizeInBytes);

        public bool IsSparse => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isSparse);

        public bool AllowGPUOptimizedContents => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowGPUOptimizedContents);

        public MTLTextureCompressionType CompressionType => (MTLTextureCompressionType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compressionType);

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        public MTLSharedTextureHandle NewSharedTextureHandle => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newSharedTextureHandle));

        public MTLTexture RemoteStorageTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_remoteStorageTexture));

        public MTLTextureSwizzleChannels Swizzle => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_swizzle));

        public void GetBytes(IntPtr pixelBytes, ulong bytesPerRow, ulong bytesPerImage, MTLRegion region, ulong level, ulong slice)
        {
            throw new NotImplementedException();
        }

        public void ReplaceRegion(MTLRegion region, ulong level, ulong slice, IntPtr pixelBytes, ulong bytesPerRow, ulong bytesPerImage)
        {
            throw new NotImplementedException();
        }

        public void GetBytes(IntPtr pixelBytes, ulong bytesPerRow, MTLRegion region, ulong level)
        {
            throw new NotImplementedException();
        }

        public void ReplaceRegion(MTLRegion region, ulong level, IntPtr pixelBytes, ulong bytesPerRow)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
        {
            throw new NotImplementedException();
        }

        public MTLTexture NewTextureView(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_rootResource = "rootResource";
        private static readonly Selector sel_parentTexture = "parentTexture";
        private static readonly Selector sel_parentRelativeLevel = "parentRelativeLevel";
        private static readonly Selector sel_parentRelativeSlice = "parentRelativeSlice";
        private static readonly Selector sel_buffer = "buffer";
        private static readonly Selector sel_bufferOffset = "bufferOffset";
        private static readonly Selector sel_bufferBytesPerRow = "bufferBytesPerRow";
        private static readonly Selector sel_iosurface = "iosurface";
        private static readonly Selector sel_iosurfacePlane = "iosurfacePlane";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_width = "width";
        private static readonly Selector sel_height = "height";
        private static readonly Selector sel_depth = "depth";
        private static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_isShareable = "isShareable";
        private static readonly Selector sel_isFramebufferOnly = "isFramebufferOnly";
        private static readonly Selector sel_firstMipmapInTail = "firstMipmapInTail";
        private static readonly Selector sel_tailSizeInBytes = "tailSizeInBytes";
        private static readonly Selector sel_isSparse = "isSparse";
        private static readonly Selector sel_allowGPUOptimizedContents = "allowGPUOptimizedContents";
        private static readonly Selector sel_compressionType = "compressionType";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_getBytesbytesPerRowbytesPerImagefromRegionmipmapLevelslice = "getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:";
        private static readonly Selector sel_replaceRegionmipmapLevelslicewithBytesbytesPerRowbytesPerImage = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";
        private static readonly Selector sel_getBytesbytesPerRowfromRegionmipmapLevel = "getBytes:bytesPerRow:fromRegion:mipmapLevel:";
        private static readonly Selector sel_replaceRegionmipmapLevelwithBytesbytesPerRow = "replaceRegion:mipmapLevel:withBytes:bytesPerRow:";
        private static readonly Selector sel_newTextureViewWithPixelFormat = "newTextureViewWithPixelFormat:";
        private static readonly Selector sel_newTextureViewWithPixelFormattextureTypelevelsslices = "newTextureViewWithPixelFormat:textureType:levels:slices:";
        private static readonly Selector sel_newSharedTextureHandle = "newSharedTextureHandle";
        private static readonly Selector sel_remoteStorageTexture = "remoteStorageTexture";
        private static readonly Selector sel_newRemoteTextureViewForDevice = "newRemoteTextureViewForDevice:";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_newTextureViewWithPixelFormattextureTypelevelsslicesswizzle = "newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:";
    }
}
