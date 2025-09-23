using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLLoadAction : ulong
    {
        DontCare = 0,
        Load = 1,
        Clear = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLMultisampleDepthResolveFilter : ulong
    {
        Sample0 = 0,
        Min = 1,
        Max = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLMultisampleStencilResolveFilter : ulong
    {
        Sample0 = 0,
        DepthResolvedSample = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLStoreAction : ulong
    {
        DontCare = 0,
        Store = 1,
        MultisampleResolve = 2,
        StoreAndMultisampleResolve = 3,
        Unknown = 4,
        CustomSampleDepthStore = 5,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLStoreActionOptions : ulong
    {
        None = 0,
        CustomSamplePositions = 1,
        ValidMask = 1,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLClearColor
    {
        public double red;
        public double green;
        public double blue;
        public double alpha;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong DepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, value);
        }

        public ulong Level
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, value);
        }

        public MTLLoadAction LoadAction
        {
            get => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)value);
        }

        public ulong ResolveDepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, value);
        }

        public ulong ResolveLevel
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveLevel);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveLevel, value);
        }

        public ulong ResolveSlice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveSlice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveSlice, value);
        }

        public MTLTexture ResolveTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, value);
        }

        public ulong Slice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, value);
        }

        public MTLStoreAction StoreAction
        {
            get => (MTLStoreAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreAction, (ulong)value);
        }

        public MTLStoreActionOptions StoreActionOptions
        {
            get => (MTLStoreActionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeActionOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreActionOptions, (ulong)value);
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, value);
        }

        private static readonly Selector sel_depthPlane = "depthPlane";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_loadAction = "loadAction";
        private static readonly Selector sel_resolveDepthPlane = "resolveDepthPlane";
        private static readonly Selector sel_resolveLevel = "resolveLevel";
        private static readonly Selector sel_resolveSlice = "resolveSlice";
        private static readonly Selector sel_resolveTexture = "resolveTexture";
        private static readonly Selector sel_setDepthPlane = "setDepthPlane:";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_setLoadAction = "setLoadAction:";
        private static readonly Selector sel_setResolveDepthPlane = "setResolveDepthPlane:";
        private static readonly Selector sel_setResolveLevel = "setResolveLevel:";
        private static readonly Selector sel_setResolveSlice = "setResolveSlice:";
        private static readonly Selector sel_setResolveTexture = "setResolveTexture:";
        private static readonly Selector sel_setSlice = "setSlice:";
        private static readonly Selector sel_setStoreAction = "setStoreAction:";
        private static readonly Selector sel_setStoreActionOptions = "setStoreActionOptions:";
        private static readonly Selector sel_setTexture = "setTexture:";
        private static readonly Selector sel_slice = "slice";
        private static readonly Selector sel_storeAction = "storeAction";
        private static readonly Selector sel_storeActionOptions = "storeActionOptions";
        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassColorAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptor obj) => obj.NativePtr;
        public static implicit operator MTLRenderPassAttachmentDescriptor(MTLRenderPassColorAttachmentDescriptor obj) => new(obj.NativePtr);
        public MTLRenderPassColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLClearColor ClearColor
        {
            get => ObjectiveCRuntime.MTLClearColor_objc_msgSend(NativePtr, sel_clearColor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearColor, value);
        }

        public ulong DepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, value);
        }

        public ulong Level
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, value);
        }

        public MTLLoadAction LoadAction
        {
            get => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)value);
        }

        public ulong ResolveDepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, value);
        }

        public ulong ResolveLevel
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveLevel);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveLevel, value);
        }

        public ulong ResolveSlice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveSlice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveSlice, value);
        }

        public MTLTexture ResolveTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, value);
        }

        public ulong Slice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, value);
        }

        public MTLStoreAction StoreAction
        {
            get => (MTLStoreAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreAction, (ulong)value);
        }

        public MTLStoreActionOptions StoreActionOptions
        {
            get => (MTLStoreActionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeActionOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreActionOptions, (ulong)value);
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, value);
        }

        private static readonly Selector sel_clearColor = "clearColor";
        private static readonly Selector sel_depthPlane = "depthPlane";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_loadAction = "loadAction";
        private static readonly Selector sel_resolveDepthPlane = "resolveDepthPlane";
        private static readonly Selector sel_resolveLevel = "resolveLevel";
        private static readonly Selector sel_resolveSlice = "resolveSlice";
        private static readonly Selector sel_resolveTexture = "resolveTexture";
        private static readonly Selector sel_setClearColor = "setClearColor:";
        private static readonly Selector sel_setDepthPlane = "setDepthPlane:";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_setLoadAction = "setLoadAction:";
        private static readonly Selector sel_setResolveDepthPlane = "setResolveDepthPlane:";
        private static readonly Selector sel_setResolveLevel = "setResolveLevel:";
        private static readonly Selector sel_setResolveSlice = "setResolveSlice:";
        private static readonly Selector sel_setResolveTexture = "setResolveTexture:";
        private static readonly Selector sel_setSlice = "setSlice:";
        private static readonly Selector sel_setStoreAction = "setStoreAction:";
        private static readonly Selector sel_setStoreActionOptions = "setStoreActionOptions:";
        private static readonly Selector sel_setTexture = "setTexture:";
        private static readonly Selector sel_slice = "slice";
        private static readonly Selector sel_storeAction = "storeAction";
        private static readonly Selector sel_storeActionOptions = "storeActionOptions";
        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassColorAttachmentDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPassColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLRenderPassColorAttachmentDescriptor Object(ulong attachmentIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, attachmentIndex));
        }

        public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassDepthAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassDepthAttachmentDescriptor obj) => obj.NativePtr;
        public static implicit operator MTLRenderPassAttachmentDescriptor(MTLRenderPassDepthAttachmentDescriptor obj) => new(obj.NativePtr);
        public MTLRenderPassDepthAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassDepthAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDepthAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public double ClearDepth
        {
            get => ObjectiveCRuntime.double_objc_msgSend(NativePtr, sel_clearDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearDepth, value);
        }

        public ulong DepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, value);
        }

        public MTLMultisampleDepthResolveFilter DepthResolveFilter
        {
            get => (MTLMultisampleDepthResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthResolveFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthResolveFilter, (ulong)value);
        }

        public ulong Level
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, value);
        }

        public MTLLoadAction LoadAction
        {
            get => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)value);
        }

        public ulong ResolveDepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, value);
        }

        public ulong ResolveLevel
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveLevel);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveLevel, value);
        }

        public ulong ResolveSlice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveSlice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveSlice, value);
        }

        public MTLTexture ResolveTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, value);
        }

        public ulong Slice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, value);
        }

        public MTLStoreAction StoreAction
        {
            get => (MTLStoreAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreAction, (ulong)value);
        }

        public MTLStoreActionOptions StoreActionOptions
        {
            get => (MTLStoreActionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeActionOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreActionOptions, (ulong)value);
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, value);
        }

        private static readonly Selector sel_clearDepth = "clearDepth";
        private static readonly Selector sel_depthPlane = "depthPlane";
        private static readonly Selector sel_depthResolveFilter = "depthResolveFilter";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_loadAction = "loadAction";
        private static readonly Selector sel_resolveDepthPlane = "resolveDepthPlane";
        private static readonly Selector sel_resolveLevel = "resolveLevel";
        private static readonly Selector sel_resolveSlice = "resolveSlice";
        private static readonly Selector sel_resolveTexture = "resolveTexture";
        private static readonly Selector sel_setClearDepth = "setClearDepth:";
        private static readonly Selector sel_setDepthPlane = "setDepthPlane:";
        private static readonly Selector sel_setDepthResolveFilter = "setDepthResolveFilter:";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_setLoadAction = "setLoadAction:";
        private static readonly Selector sel_setResolveDepthPlane = "setResolveDepthPlane:";
        private static readonly Selector sel_setResolveLevel = "setResolveLevel:";
        private static readonly Selector sel_setResolveSlice = "setResolveSlice:";
        private static readonly Selector sel_setResolveTexture = "setResolveTexture:";
        private static readonly Selector sel_setSlice = "setSlice:";
        private static readonly Selector sel_setStoreAction = "setStoreAction:";
        private static readonly Selector sel_setStoreActionOptions = "setStoreActionOptions:";
        private static readonly Selector sel_setTexture = "setTexture:";
        private static readonly Selector sel_slice = "slice";
        private static readonly Selector sel_storeAction = "storeAction";
        private static readonly Selector sel_storeActionOptions = "storeActionOptions";
        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassDescriptor obj) => obj.NativePtr;
        public MTLRenderPassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public ulong DefaultRasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_defaultRasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDefaultRasterSampleCount, value);
        }

        public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthAttachment));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthAttachment, value);
        }

        public ulong ImageblockSampleLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockSampleLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setImageblockSampleLength, value);
        }

        public MTLRasterizationRateMap RasterizationRateMap
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_rasterizationRateMap));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationRateMap, value);
        }

        public ulong RenderTargetArrayLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetArrayLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetArrayLength, value);
        }

        public ulong RenderTargetHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetHeight, value);
        }

        public ulong RenderTargetWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetWidth, value);
        }

        public MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stencilAttachment));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilAttachment, value);
        }

        public ulong ThreadgroupMemoryLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLength, value);
        }

        public ulong TileHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileHeight, value);
        }

        public ulong TileWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileWidth, value);
        }

        public MTLBuffer VisibilityResultBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_visibilityResultBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibilityResultBuffer, value);
        }

        public ulong GetSamplePositions(MTLSamplePosition positions, ulong count)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_getSamplePositionscount, positions, count);
        }

        public void SetSamplePositions(MTLSamplePosition positions, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSamplePositionscount, positions, count);
        }

        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_defaultRasterSampleCount = "defaultRasterSampleCount";
        private static readonly Selector sel_depthAttachment = "depthAttachment";
        private static readonly Selector sel_getSamplePositionscount = "getSamplePositions:count:";
        private static readonly Selector sel_imageblockSampleLength = "imageblockSampleLength";
        private static readonly Selector sel_rasterizationRateMap = "rasterizationRateMap";
        private static readonly Selector sel_renderPassDescriptor = "renderPassDescriptor";
        private static readonly Selector sel_renderTargetArrayLength = "renderTargetArrayLength";
        private static readonly Selector sel_renderTargetHeight = "renderTargetHeight";
        private static readonly Selector sel_renderTargetWidth = "renderTargetWidth";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
        private static readonly Selector sel_setDefaultRasterSampleCount = "setDefaultRasterSampleCount:";
        private static readonly Selector sel_setDepthAttachment = "setDepthAttachment:";
        private static readonly Selector sel_setImageblockSampleLength = "setImageblockSampleLength:";
        private static readonly Selector sel_setRasterizationRateMap = "setRasterizationRateMap:";
        private static readonly Selector sel_setRenderTargetArrayLength = "setRenderTargetArrayLength:";
        private static readonly Selector sel_setRenderTargetHeight = "setRenderTargetHeight:";
        private static readonly Selector sel_setRenderTargetWidth = "setRenderTargetWidth:";
        private static readonly Selector sel_setSamplePositionscount = "setSamplePositions:count:";
        private static readonly Selector sel_setStencilAttachment = "setStencilAttachment:";
        private static readonly Selector sel_setThreadgroupMemoryLength = "setThreadgroupMemoryLength:";
        private static readonly Selector sel_setTileHeight = "setTileHeight:";
        private static readonly Selector sel_setTileWidth = "setTileWidth:";
        private static readonly Selector sel_setVisibilityResultBuffer = "setVisibilityResultBuffer:";
        private static readonly Selector sel_stencilAttachment = "stencilAttachment";
        private static readonly Selector sel_threadgroupMemoryLength = "threadgroupMemoryLength";
        private static readonly Selector sel_tileHeight = "tileHeight";
        private static readonly Selector sel_tileWidth = "tileWidth";
        private static readonly Selector sel_visibilityResultBuffer = "visibilityResultBuffer";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassSampleBufferAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassSampleBufferAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong EndOfFragmentSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfFragmentSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfFragmentSampleIndex, value);
        }

        public ulong EndOfVertexSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfVertexSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfVertexSampleIndex, value);
        }

        public MTLCounterSampleBuffer SampleBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleBuffer, value);
        }

        public ulong StartOfFragmentSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfFragmentSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfFragmentSampleIndex, value);
        }

        public ulong StartOfVertexSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfVertexSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfVertexSampleIndex, value);
        }

        private static readonly Selector sel_endOfFragmentSampleIndex = "endOfFragmentSampleIndex";
        private static readonly Selector sel_endOfVertexSampleIndex = "endOfVertexSampleIndex";
        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setEndOfFragmentSampleIndex = "setEndOfFragmentSampleIndex:";
        private static readonly Selector sel_setEndOfVertexSampleIndex = "setEndOfVertexSampleIndex:";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer:";
        private static readonly Selector sel_setStartOfFragmentSampleIndex = "setStartOfFragmentSampleIndex:";
        private static readonly Selector sel_setStartOfVertexSampleIndex = "setStartOfVertexSampleIndex:";
        private static readonly Selector sel_startOfFragmentSampleIndex = "startOfFragmentSampleIndex";
        private static readonly Selector sel_startOfVertexSampleIndex = "startOfVertexSampleIndex";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassSampleBufferAttachmentDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLRenderPassSampleBufferAttachmentDescriptor Object(ulong attachmentIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, attachmentIndex));
        }

        public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassStencilAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassStencilAttachmentDescriptor obj) => obj.NativePtr;
        public static implicit operator MTLRenderPassAttachmentDescriptor(MTLRenderPassStencilAttachmentDescriptor obj) => new(obj.NativePtr);
        public MTLRenderPassStencilAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassStencilAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassStencilAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public uint ClearStencil
        {
            get => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_clearStencil);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearStencil, value);
        }

        public ulong DepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, value);
        }

        public ulong Level
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, value);
        }

        public MTLLoadAction LoadAction
        {
            get => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)value);
        }

        public ulong ResolveDepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, value);
        }

        public ulong ResolveLevel
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveLevel);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveLevel, value);
        }

        public ulong ResolveSlice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveSlice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveSlice, value);
        }

        public MTLTexture ResolveTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, value);
        }

        public ulong Slice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, value);
        }

        public MTLMultisampleStencilResolveFilter StencilResolveFilter
        {
            get => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilResolveFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilResolveFilter, (ulong)value);
        }

        public MTLStoreAction StoreAction
        {
            get => (MTLStoreAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreAction, (ulong)value);
        }

        public MTLStoreActionOptions StoreActionOptions
        {
            get => (MTLStoreActionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeActionOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreActionOptions, (ulong)value);
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, value);
        }

        private static readonly Selector sel_clearStencil = "clearStencil";
        private static readonly Selector sel_depthPlane = "depthPlane";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_loadAction = "loadAction";
        private static readonly Selector sel_resolveDepthPlane = "resolveDepthPlane";
        private static readonly Selector sel_resolveLevel = "resolveLevel";
        private static readonly Selector sel_resolveSlice = "resolveSlice";
        private static readonly Selector sel_resolveTexture = "resolveTexture";
        private static readonly Selector sel_setClearStencil = "setClearStencil:";
        private static readonly Selector sel_setDepthPlane = "setDepthPlane:";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_setLoadAction = "setLoadAction:";
        private static readonly Selector sel_setResolveDepthPlane = "setResolveDepthPlane:";
        private static readonly Selector sel_setResolveLevel = "setResolveLevel:";
        private static readonly Selector sel_setResolveSlice = "setResolveSlice:";
        private static readonly Selector sel_setResolveTexture = "setResolveTexture:";
        private static readonly Selector sel_setSlice = "setSlice:";
        private static readonly Selector sel_setStencilResolveFilter = "setStencilResolveFilter:";
        private static readonly Selector sel_setStoreAction = "setStoreAction:";
        private static readonly Selector sel_setStoreActionOptions = "setStoreActionOptions:";
        private static readonly Selector sel_setTexture = "setTexture:";
        private static readonly Selector sel_slice = "slice";
        private static readonly Selector sel_stencilResolveFilter = "stencilResolveFilter";
        private static readonly Selector sel_storeAction = "storeAction";
        private static readonly Selector sel_storeActionOptions = "storeActionOptions";
        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_release = "release";
    }
}
