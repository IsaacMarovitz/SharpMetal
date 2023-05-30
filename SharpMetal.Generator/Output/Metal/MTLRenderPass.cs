using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLLoadAction: ulong
    {
        DontCare = 0,
        Load = 1,
        Clear = 2,
    }

    public enum MTLStoreAction: ulong
    {
        DontCare = 0,
        Store = 1,
        MultisampleResolve = 2,
        StoreAndMultisampleResolve = 3,
        Unknown = 4,
        CustomSampleDepthStore = 5,
    }

    public enum MTLStoreActionOptions: ulong
    {
        StoreActionOptionNone = 0,
        StoreActionOptionValidMask = 1,
        StoreActionOptionCustomSamplePositions = 1,
    }

    public enum MTLMultisampleDepthResolveFilter: ulong
    {
        Sample0 = 0,
        Min = 1,
        Max = 2,
    }

    public enum MTLMultisampleStencilResolveFilter: ulong
    {
        Sample0 = 0,
        DepthResolvedSample = 1,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLClearColor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLClearColor obj) => obj.NativePtr;
        public MTLClearColor(IntPtr ptr) => NativePtr = ptr;

        public double red;
        public double green;
        public double blue;
        public double alpha;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLTexture Texture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
        public ulong Level => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
        public ulong Slice => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
        public ulong DepthPlane => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
        public MTLTexture ResolveTexture => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture));
        public ulong ResolveLevel => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveLevel);
        public ulong ResolveSlice => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveSlice);
        public ulong ResolveDepthPlane => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
        public MTLLoadAction LoadAction => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
        public MTLStoreAction StoreAction => (MTLStoreAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeAction);
        public MTLStoreActionOptions StoreActionOptions => (MTLStoreActionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeActionOptions);

        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_setTexture = "setTexture:";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_slice = "slice";
        private static readonly Selector sel_setSlice = "setSlice:";
        private static readonly Selector sel_depthPlane = "depthPlane";
        private static readonly Selector sel_setDepthPlane = "setDepthPlane:";
        private static readonly Selector sel_resolveTexture = "resolveTexture";
        private static readonly Selector sel_setResolveTexture = "setResolveTexture:";
        private static readonly Selector sel_resolveLevel = "resolveLevel";
        private static readonly Selector sel_setResolveLevel = "setResolveLevel:";
        private static readonly Selector sel_resolveSlice = "resolveSlice";
        private static readonly Selector sel_setResolveSlice = "setResolveSlice:";
        private static readonly Selector sel_resolveDepthPlane = "resolveDepthPlane";
        private static readonly Selector sel_setResolveDepthPlane = "setResolveDepthPlane:";
        private static readonly Selector sel_loadAction = "loadAction";
        private static readonly Selector sel_setLoadAction = "setLoadAction:";
        private static readonly Selector sel_storeAction = "storeAction";
        private static readonly Selector sel_setStoreAction = "setStoreAction:";
        private static readonly Selector sel_storeActionOptions = "storeActionOptions";
        private static readonly Selector sel_setStoreActionOptions = "setStoreActionOptions:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassColorAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLClearColor ClearColor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_clearColor));

        private static readonly Selector sel_clearColor = "clearColor";
        private static readonly Selector sel_setClearColor = "setClearColor:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassDepthAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassDepthAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassDepthAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassDepthAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDepthAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public double ClearDepth => ObjectiveCRuntime.double_objc_msgSend(NativePtr, sel_clearDepth);
        public MTLMultisampleDepthResolveFilter DepthResolveFilter => (MTLMultisampleDepthResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthResolveFilter);

        private static readonly Selector sel_clearDepth = "clearDepth";
        private static readonly Selector sel_setClearDepth = "setClearDepth:";
        private static readonly Selector sel_depthResolveFilter = "depthResolveFilter";
        private static readonly Selector sel_setDepthResolveFilter = "setDepthResolveFilter:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassStencilAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassStencilAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassStencilAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassStencilAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassStencilAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public uint ClearStencil => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_clearStencil);
        public MTLMultisampleStencilResolveFilter StencilResolveFilter => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilResolveFilter);

        private static readonly Selector sel_clearStencil = "clearStencil";
        private static readonly Selector sel_setClearStencil = "setClearStencil:";
        private static readonly Selector sel_stencilResolveFilter = "stencilResolveFilter";
        private static readonly Selector sel_setStencilResolveFilter = "setStencilResolveFilter:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassColorAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPassColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassSampleBufferAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCounterSampleBuffer SampleBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBuffer));
        public ulong StartOfVertexSampleIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfVertexSampleIndex);
        public ulong EndOfVertexSampleIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfVertexSampleIndex);
        public ulong StartOfFragmentSampleIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfFragmentSampleIndex);
        public ulong EndOfFragmentSampleIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfFragmentSampleIndex);

        private static readonly Selector sel_sampleBuffer = "sampleBuffer";
        private static readonly Selector sel_setSampleBuffer = "setSampleBuffer:";
        private static readonly Selector sel_startOfVertexSampleIndex = "startOfVertexSampleIndex";
        private static readonly Selector sel_setStartOfVertexSampleIndex = "setStartOfVertexSampleIndex:";
        private static readonly Selector sel_endOfVertexSampleIndex = "endOfVertexSampleIndex";
        private static readonly Selector sel_setEndOfVertexSampleIndex = "setEndOfVertexSampleIndex:";
        private static readonly Selector sel_startOfFragmentSampleIndex = "startOfFragmentSampleIndex";
        private static readonly Selector sel_setStartOfFragmentSampleIndex = "setStartOfFragmentSampleIndex:";
        private static readonly Selector sel_endOfFragmentSampleIndex = "endOfFragmentSampleIndex";
        private static readonly Selector sel_setEndOfFragmentSampleIndex = "setEndOfFragmentSampleIndex:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassDescriptor obj) => obj.NativePtr;
        public MTLRenderPassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLRenderPassDescriptor RenderPassDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderPassDescriptor));
        public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));
        public MTLRenderPassDepthAttachmentDescriptor DepthAttachment => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthAttachment));
        public MTLRenderPassStencilAttachmentDescriptor StencilAttachment => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stencilAttachment));
        public MTLBuffer VisibilityResultBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_visibilityResultBuffer));
        public ulong RenderTargetArrayLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetArrayLength);
        public ulong ImageblockSampleLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockSampleLength);
        public ulong ThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryLength);
        public ulong TileWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileWidth);
        public ulong TileHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileHeight);
        public ulong DefaultRasterSampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_defaultRasterSampleCount);
        public ulong RenderTargetWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetWidth);
        public ulong RenderTargetHeight => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetHeight);
        public MTLRasterizationRateMap RasterizationRateMap => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_rasterizationRateMap));
        public MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        private static readonly Selector sel_renderPassDescriptor = "renderPassDescriptor";
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_depthAttachment = "depthAttachment";
        private static readonly Selector sel_setDepthAttachment = "setDepthAttachment:";
        private static readonly Selector sel_stencilAttachment = "stencilAttachment";
        private static readonly Selector sel_setStencilAttachment = "setStencilAttachment:";
        private static readonly Selector sel_visibilityResultBuffer = "visibilityResultBuffer";
        private static readonly Selector sel_setVisibilityResultBuffer = "setVisibilityResultBuffer:";
        private static readonly Selector sel_renderTargetArrayLength = "renderTargetArrayLength";
        private static readonly Selector sel_setRenderTargetArrayLength = "setRenderTargetArrayLength:";
        private static readonly Selector sel_imageblockSampleLength = "imageblockSampleLength";
        private static readonly Selector sel_setImageblockSampleLength = "setImageblockSampleLength:";
        private static readonly Selector sel_threadgroupMemoryLength = "threadgroupMemoryLength";
        private static readonly Selector sel_setThreadgroupMemoryLength = "setThreadgroupMemoryLength:";
        private static readonly Selector sel_tileWidth = "tileWidth";
        private static readonly Selector sel_setTileWidth = "setTileWidth:";
        private static readonly Selector sel_tileHeight = "tileHeight";
        private static readonly Selector sel_setTileHeight = "setTileHeight:";
        private static readonly Selector sel_defaultRasterSampleCount = "defaultRasterSampleCount";
        private static readonly Selector sel_setDefaultRasterSampleCount = "setDefaultRasterSampleCount:";
        private static readonly Selector sel_renderTargetWidth = "renderTargetWidth";
        private static readonly Selector sel_setRenderTargetWidth = "setRenderTargetWidth:";
        private static readonly Selector sel_renderTargetHeight = "renderTargetHeight";
        private static readonly Selector sel_setRenderTargetHeight = "setRenderTargetHeight:";
        private static readonly Selector sel_setSamplePositionscount = "setSamplePositions:count:";
        private static readonly Selector sel_getSamplePositionscount = "getSamplePositions:count:";
        private static readonly Selector sel_rasterizationRateMap = "rasterizationRateMap";
        private static readonly Selector sel_setRasterizationRateMap = "setRasterizationRateMap:";
        private static readonly Selector sel_sampleBufferAttachments = "sampleBufferAttachments";
    }
}
