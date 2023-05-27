using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLTexture
    {
        public readonly IntPtr NativePtr;
        public MTLTexture(IntPtr ptr) => NativePtr = ptr;

        public void ReplaceRegionMipmapLevelSliceWithBytesBytesPerRowBytesPerImage(MTLRegion region, ulong level, ulong slice, IntPtr pixelBytes, ulong bytesPerRow, ulong bytesPerImage)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_replaceRegionMipmapLevelSliceWithBytesBytesPerRowBytesPerImage, region.NativePtr, level, slice, pixelBytes, bytesPerRow, bytesPerImage);
        }

        public void ReplaceRegionMipmapLevelWithBytesBytesPerRow(MTLRegion region, ulong level, IntPtr pixelBytes, ulong bytesPerRow)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_replaceRegionMipmapLevelWithBytesBytesPerRow, region.NativePtr, level, pixelBytes, bytesPerRow);
        }

        public void GetBytesBytesPerRowBytesPerImageFromRegionMipmapLevelSlice(IntPtr pixelBytes, ulong bytesPerRow, ulong bytesPerImage, MTLRegion region, ulong level, ulong slice)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_getBytesBytesPerRowBytesPerImageFromRegionMipmapLevelSlice, pixelBytes, bytesPerRow, bytesPerImage, region.NativePtr, level, slice);
        }

        public void GetBytesBytesPerRowFromRegionMipmapLevel(IntPtr pixelBytes, ulong bytesPerRow, MTLRegion region, ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_getBytesBytesPerRowFromRegionMipmapLevel, pixelBytes, bytesPerRow, region.NativePtr, level);
        }

        public MTLTexture NewTextureViewWithPixelFormat(MTLPixelFormat pixelFormat)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newTextureViewWithPixelFormat, (ulong)pixelFormat));
        }

        // TODO: Needs NSRange
        /*public MTLTexture NewTextureViewWithPixelFormatTextureTypeLevelsSlices(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange)
        {

        }*/

        // TODO: Needs NSRange
        /*public MTLTexture NewTextureViewWithPixelFormatTextureTypeLevelsSlicesSwizzle(MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle)
        {

        }*/

        public MTLTextureType TextureType => (MTLTextureType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_textureType);

        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);

        public ulong Width => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_width);

        public ulong Height => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_height);

        public ulong Depth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depth);

        public ulong MipmapLevelCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipmapLevelCount);

        public ulong ArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_arrayLength);

        public ulong SampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);

        public bool FramebufferOnly => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_framebufferOnly);

        public MTLTextureUsage Usage => (MTLTextureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);

        public bool AllowGPUOptimizedContents => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowGPUOptimizedContents);

        public bool Shareable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_shareable);

        public MTLTextureSwizzleChannels Swizzle => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_swizzle));

        // TODO: Needs IOSurfaceRef
        // public IOSurfaceRef IOSurface => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_iosurface);

        public ulong IOSurfacePlane => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_iosurfacePlane);

        public MTLTexture ParentTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parentTexture));

        public ulong ParentRelativeLevel => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_parentRelativeLevel);

        public ulong ParentRelativeSlice => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_parentRelativeSlice);

        public MTLBuffer Buffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));

        public ulong BufferOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferOffset);

        public ulong BufferBytesPerRow => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_bufferBytesPerRow);

        // TODO: Needs MTLSharedTextureHandle
        /*public MTLSharedTextureHandle NewSharedTextureHandle()
        {

        }*/

        public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRemoteTextureViewForDevice, device));
        }

        public MTLTexture RemoteStorageTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_remoteStorageTexture));

        public bool IsSparse => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isSparse);

        public ulong FirstMipmapInTail => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_firstMipmapInTail);

        public ulong TailSizeInBytes => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tailSizeInBytes);

        public MTLTextureCompressionType CompressionType => (MTLTextureCompressionType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compressionType);

        // TODO: Needs MTLResourceID
        // public MTLResourceID GPUResourceID;

        private static readonly Selector sel_replaceRegionMipmapLevelSliceWithBytesBytesPerRowBytesPerImage = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";
        private static readonly Selector sel_replaceRegionMipmapLevelWithBytesBytesPerRow = "replaceRegion:mipmapLevel:withBytes:bytesPerRow:";
        private static readonly Selector sel_getBytesBytesPerRowBytesPerImageFromRegionMipmapLevelSlice = "getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:";
        private static readonly Selector sel_getBytesBytesPerRowFromRegionMipmapLevel = "getBytes:bytesPerRow:fromRegion:mipmapLevel:";
        private static readonly Selector sel_newTextureViewWithPixelFormat = "newTextureViewWithPixelFormat:";
        private static readonly Selector sel_newTextureViewWithPixelFormatTextureTypeLevelsSlices = "newTextureViewWithPixelFormat:textureType:levels:slices:";
        private static readonly Selector sel_newTextureViewWithPixelFormatTextureTypeLevelsSlicesSwizzle = "newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:";
        private static readonly Selector sel_textureType = "textureType";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_width = "width";
        private static readonly Selector sel_height = "height";
        private static readonly Selector sel_depth = "depth";
        private static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        private static readonly Selector sel_arrayLength = "arrayLength";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_framebufferOnly = "isFramebufferOnly";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_allowGPUOptimizedContents = "allowGPUOptimizedContents";
        private static readonly Selector sel_shareable = "isShareable";
        private static readonly Selector sel_swizzle = "swizzle";
        private static readonly Selector sel_iosurface = "iosurface";
        private static readonly Selector sel_iosurfacePlane = "iosurfacePlane";
        private static readonly Selector sel_parentTexture = "parentTexture";
        private static readonly Selector sel_parentRelativeLevel = "parentRelativeLevel";
        private static readonly Selector sel_parentRelativeSlice = "parentRelativeSlice";
        private static readonly Selector sel_buffer = "buffer";
        private static readonly Selector sel_bufferOffset = "bufferOffset";
        private static readonly Selector sel_bufferBytesPerRow = "bufferBytesPerRow";
        private static readonly Selector sel_newSharedTextureHandle = "newSharedTextureHandle";
        private static readonly Selector sel_newRemoteTextureViewForDevice = "newRemoteTextureViewForDevice:";
        private static readonly Selector sel_remoteStorageTexture = "remoteStorageTexture";
        private static readonly Selector sel_isSparse = "isSparse";
        private static readonly Selector sel_firstMipmapInTail = "firstMipmapInTail";
        private static readonly Selector sel_tailSizeInBytes = "tailSizeInBytes";
        private static readonly Selector sel_compressionType = "compressionType";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
    }
}