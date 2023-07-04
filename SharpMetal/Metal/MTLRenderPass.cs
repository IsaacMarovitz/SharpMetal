using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLLoadAction : ulong
    {
        DontCare = 0,
        Load = 1,
        Clear = 2,
    }

    public enum MTLStoreAction : ulong
    {
        DontCare = 0,
        Store = 1,
        MultisampleResolve = 2,
        StoreAndMultisampleResolve = 3,
        Unknown = 4,
        CustomSampleDepthStore = 5,
    }

    public enum MTLStoreActionOptions : ulong
    {
        StoreActionOptionNone = 0,
        StoreActionOptionValidMask = 1,
        StoreActionOptionCustomSamplePositions = 1,
    }

    public enum MTLMultisampleDepthResolveFilter : ulong
    {
        Sample0 = 0,
        Min = 1,
        Max = 2,
    }

    public enum MTLMultisampleStencilResolveFilter : ulong
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
    public partial class MTLRenderPassAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, value);
        }

        public ulong Level
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, value);
        }

        public ulong Slice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, value);
        }

        public ulong DepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, value);
        }

        public MTLTexture ResolveTexture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, value);
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

        public ulong ResolveDepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, value);
        }

        public MTLLoadAction LoadAction
        {
            get => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)value);
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

        public void SetTexture(MTLTexture texture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, texture);
        }

        public void SetLevel(ulong level)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, level);
        }

        public void SetSlice(ulong slice)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, slice);
        }

        public void SetDepthPlane(ulong depthPlane)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, depthPlane);
        }

        public void SetResolveTexture(MTLTexture resolveTexture)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, resolveTexture);
        }

        public void SetResolveLevel(ulong resolveLevel)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveLevel, resolveLevel);
        }

        public void SetResolveSlice(ulong resolveSlice)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveSlice, resolveSlice);
        }

        public void SetResolveDepthPlane(ulong resolveDepthPlane)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, resolveDepthPlane);
        }

        public void SetLoadAction(MTLLoadAction loadAction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)loadAction);
        }

        public void SetStoreAction(MTLStoreAction storeAction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreAction, (ulong)storeAction);
        }

        public void SetStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreActionOptions, (ulong)storeActionOptions);
        }

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
    public partial class MTLRenderPassColorAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLClearColor ClearColor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_clearColor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearColor, value);
        }

        public void SetClearColor(MTLClearColor clearColor)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearColor, clearColor);
        }

        private static readonly Selector sel_clearColor = "clearColor";
        private static readonly Selector sel_setClearColor = "setClearColor:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLRenderPassDepthAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassDepthAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassDepthAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassDepthAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDepthAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public double ClearDepth
        {
            get => ObjectiveCRuntime.double_objc_msgSend(NativePtr, sel_clearDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearDepth, value);
        }

        public MTLMultisampleDepthResolveFilter DepthResolveFilter
        {
            get => (MTLMultisampleDepthResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthResolveFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthResolveFilter, (ulong)value);
        }

        public void SetClearDepth(double clearDepth)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearDepth, clearDepth);
        }

        public void SetDepthResolveFilter(MTLMultisampleDepthResolveFilter depthResolveFilter)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthResolveFilter, (ulong)depthResolveFilter);
        }

        private static readonly Selector sel_clearDepth = "clearDepth";
        private static readonly Selector sel_setClearDepth = "setClearDepth:";
        private static readonly Selector sel_depthResolveFilter = "depthResolveFilter";
        private static readonly Selector sel_setDepthResolveFilter = "setDepthResolveFilter:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLRenderPassStencilAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassStencilAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassStencilAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassStencilAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassStencilAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public uint ClearStencil
        {
            get => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_clearStencil);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearStencil, value);
        }

        public MTLMultisampleStencilResolveFilter StencilResolveFilter
        {
            get => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilResolveFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilResolveFilter, (ulong)value);
        }

        public void SetClearStencil(uint clearStencil)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearStencil, clearStencil);
        }

        public void SetStencilResolveFilter(MTLMultisampleStencilResolveFilter stencilResolveFilter)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilResolveFilter, (ulong)stencilResolveFilter);
        }

        private static readonly Selector sel_clearStencil = "clearStencil";
        private static readonly Selector sel_setClearStencil = "setClearStencil:";
        private static readonly Selector sel_stencilResolveFilter = "stencilResolveFilter";
        private static readonly Selector sel_setStencilResolveFilter = "setStencilResolveFilter:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLRenderPassColorAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPassColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
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
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLRenderPassSampleBufferAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassSampleBufferAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPassSampleBufferAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassSampleBufferAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassSampleBufferAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCounterSampleBuffer SampleBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleBuffer, value);
        }

        public ulong StartOfVertexSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfVertexSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfVertexSampleIndex, value);
        }

        public ulong EndOfVertexSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfVertexSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfVertexSampleIndex, value);
        }

        public ulong StartOfFragmentSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_startOfFragmentSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfFragmentSampleIndex, value);
        }

        public ulong EndOfFragmentSampleIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_endOfFragmentSampleIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfFragmentSampleIndex, value);
        }

        public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleBuffer, sampleBuffer);
        }

        public void SetStartOfVertexSampleIndex(ulong startOfVertexSampleIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfVertexSampleIndex, startOfVertexSampleIndex);
        }

        public void SetEndOfVertexSampleIndex(ulong endOfVertexSampleIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfVertexSampleIndex, endOfVertexSampleIndex);
        }

        public void SetStartOfFragmentSampleIndex(ulong startOfFragmentSampleIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStartOfFragmentSampleIndex, startOfFragmentSampleIndex);
        }

        public void SetEndOfFragmentSampleIndex(ulong endOfFragmentSampleIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setEndOfFragmentSampleIndex, endOfFragmentSampleIndex);
        }

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
    public partial class MTLRenderPassSampleBufferAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassSampleBufferAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPassSampleBufferAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassSampleBufferAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPassSampleBufferAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
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
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLRenderPassDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPassDescriptor obj) => obj.NativePtr;
        public MTLRenderPassDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPassDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLRenderPassColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public MTLRenderPassDepthAttachmentDescriptor DepthAttachment
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_depthAttachment));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthAttachment, value);
        }

        public MTLRenderPassStencilAttachmentDescriptor StencilAttachment
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stencilAttachment));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilAttachment, value);
        }

        public MTLBuffer VisibilityResultBuffer
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_visibilityResultBuffer));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibilityResultBuffer, value);
        }

        public ulong RenderTargetArrayLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetArrayLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetArrayLength, value);
        }

        public ulong ImageblockSampleLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockSampleLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setImageblockSampleLength, value);
        }

        public ulong ThreadgroupMemoryLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadgroupMemoryLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLength, value);
        }

        public ulong TileWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileWidth, value);
        }

        public ulong TileHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tileHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileHeight, value);
        }

        public ulong DefaultRasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_defaultRasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDefaultRasterSampleCount, value);
        }

        public ulong RenderTargetWidth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetWidth, value);
        }

        public ulong RenderTargetHeight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_renderTargetHeight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetHeight, value);
        }

        public MTLRasterizationRateMap RasterizationRateMap
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_rasterizationRateMap));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationRateMap, value);
        }

        public MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleBufferAttachments));

        public void SetDepthAttachment(MTLRenderPassDepthAttachmentDescriptor depthAttachment)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthAttachment, depthAttachment);
        }

        public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilAttachment, stencilAttachment);
        }

        public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibilityResultBuffer, visibilityResultBuffer);
        }

        public void SetRenderTargetArrayLength(ulong renderTargetArrayLength)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetArrayLength, renderTargetArrayLength);
        }

        public void SetImageblockSampleLength(ulong imageblockSampleLength)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setImageblockSampleLength, imageblockSampleLength);
        }

        public void SetThreadgroupMemoryLength(ulong threadgroupMemoryLength)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupMemoryLength, threadgroupMemoryLength);
        }

        public void SetTileWidth(ulong tileWidth)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileWidth, tileWidth);
        }

        public void SetTileHeight(ulong tileHeight)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileHeight, tileHeight);
        }

        public void SetDefaultRasterSampleCount(ulong defaultRasterSampleCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDefaultRasterSampleCount, defaultRasterSampleCount);
        }

        public void SetRenderTargetWidth(ulong renderTargetWidth)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetWidth, renderTargetWidth);
        }

        public void SetRenderTargetHeight(ulong renderTargetHeight)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderTargetHeight, renderTargetHeight);
        }

        public void SetSamplePositions(MTLSamplePosition positions, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSamplePositionscount, positions, count);
        }

        public ulong GetSamplePositions(MTLSamplePosition positions, ulong count)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_getSamplePositionscount, positions, count);
        }

        public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationRateMap, rasterizationRateMap);
        }

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
