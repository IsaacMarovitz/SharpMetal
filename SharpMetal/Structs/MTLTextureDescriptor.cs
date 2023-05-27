using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLTextureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureDescriptor mtlTextureDescriptor) => mtlTextureDescriptor.NativePtr;
        public MTLTextureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public static MTLTextureDescriptor Texture2DDescriptorWithPixelFormat(MTLPixelFormat pixelFormat, ulong width, ulong height, bool mipmapped)
        {
            var cls = new ObjectiveCClass("MTLTextureDescriptor");
            return new MTLTextureDescriptor(ObjectiveCRuntime.IntPtr_objc_msgSend(cls, sel_texture2DDescriptorWithPixelFormatWidthHeightMipmapped, pixelFormat, width, height, mipmapped));
        }

        public static MTLTextureDescriptor TextureCubeDescriptorWithPixelFormat(MTLPixelFormat pixelFormat, ulong size, bool mipmapped)
        {
            var cls = new ObjectiveCClass("MTLTextureDescriptor");
            return new MTLTextureDescriptor(ObjectiveCRuntime.IntPtr_objc_msgSend(cls, sel_textureCubeDescriptorWithPixelFormatSizeMipmapped, pixelFormat, size, mipmapped));
        }

        public static MTLTextureDescriptor TextureBufferDescriptorWithPixelFormat(MTLPixelFormat pixelFormat, ulong width, MTLResourceOptions resourceOptions, MTLTextureUsage usage)
        {
            var cls = new ObjectiveCClass("MTLTextureDescriptor");
            return new MTLTextureDescriptor(ObjectiveCRuntime.IntPtr_objc_msgSend(cls, sel_textureBufferDescriptorWithPixelFormatWidthResourceOptionsUsage, pixelFormat, width, resourceOptions, usage));
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

        public MTLCPUCacheMode CPUCacheMode
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

        public bool AllowGPUOptimizedContents
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowGPUOptimizedContents);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowGPUOptimizedContents, value);
        }

        public MTLTextureUsage Usage
        {
            get => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        public MTLTextureSwizzleChannels Swizzle
        {
            get => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_swizzle));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSwizzle, value);
        }

        public MTLTextureCompressionType CompressionType
        {
            get => (MTLTextureCompressionType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compressionType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompressionType, (long)value);
        }

        private static readonly Selector sel_texture2DDescriptorWithPixelFormatWidthHeightMipmapped = "texture2DDescriptorWithPixelFormat:width:height:mipmapped:";
        private static readonly Selector sel_textureCubeDescriptorWithPixelFormatSizeMipmapped = "textureCubeDescriptorWithPixelFormat:size:mipmapped:";
        private static readonly Selector sel_textureBufferDescriptorWithPixelFormatWidthResourceOptionsUsage = "textureBufferDescriptorWithPixelFormat:width:resourceOptions:usage:";

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
        private static readonly Selector sel_allowGPUOptimizedContents = "allowGPUOptimizedContents";
        private static readonly Selector sel_setAllowGPUOptimizedContents = "setAllowedGPUOptimizedContents:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_setSwizzle = "setSwizzle:";
        private static readonly Selector sel_compressionType = "compressionType";
        private static readonly Selector sel_setCompressionType = "setCompressionType:";
    }
}