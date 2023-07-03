using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
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
    public class MTLRenderPassAttachmentDescriptor
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
            throw new NotImplementedException();
        }

        public void SetLevel(ulong level)
        {
            throw new NotImplementedException();
        }

        public void SetSlice(ulong slice)
        {
            throw new NotImplementedException();
        }

        public void SetDepthPlane(ulong depthPlane)
        {
            throw new NotImplementedException();
        }

        public void SetResolveTexture(MTLTexture resolveTexture)
        {
            throw new NotImplementedException();
        }

        public void SetResolveLevel(ulong resolveLevel)
        {
            throw new NotImplementedException();
        }

        public void SetResolveSlice(ulong resolveSlice)
        {
            throw new NotImplementedException();
        }

        public void SetResolveDepthPlane(ulong resolveDepthPlane)
        {
            throw new NotImplementedException();
        }

        public void SetLoadAction(MTLLoadAction loadAction)
        {
            throw new NotImplementedException();
        }

        public void SetStoreAction(MTLStoreAction storeAction)
        {
            throw new NotImplementedException();
        }

        public void SetStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            throw new NotImplementedException();
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
    public class MTLRenderPassColorAttachmentDescriptor
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
            throw new NotImplementedException();
        }

        private static readonly Selector sel_clearColor = "clearColor";
        private static readonly Selector sel_setClearColor = "setClearColor:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLRenderPassDepthAttachmentDescriptor
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
            throw new NotImplementedException();
        }

        public void SetDepthResolveFilter(MTLMultisampleDepthResolveFilter depthResolveFilter)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_clearDepth = "clearDepth";
        private static readonly Selector sel_setClearDepth = "setClearDepth:";
        private static readonly Selector sel_depthResolveFilter = "depthResolveFilter";
        private static readonly Selector sel_setDepthResolveFilter = "setDepthResolveFilter:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLRenderPassStencilAttachmentDescriptor
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
            throw new NotImplementedException();
        }

        public void SetStencilResolveFilter(MTLMultisampleStencilResolveFilter stencilResolveFilter)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_clearStencil = "clearStencil";
        private static readonly Selector sel_setClearStencil = "setClearStencil:";
        private static readonly Selector sel_stencilResolveFilter = "stencilResolveFilter";
        private static readonly Selector sel_setStencilResolveFilter = "setStencilResolveFilter:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLRenderPassColorAttachmentDescriptorArray
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
            throw new NotImplementedException();
        }

        public void SetObject(MTLRenderPassColorAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLRenderPassSampleBufferAttachmentDescriptor
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
            throw new NotImplementedException();
        }

        public void SetStartOfVertexSampleIndex(ulong startOfVertexSampleIndex)
        {
            throw new NotImplementedException();
        }

        public void SetEndOfVertexSampleIndex(ulong endOfVertexSampleIndex)
        {
            throw new NotImplementedException();
        }

        public void SetStartOfFragmentSampleIndex(ulong startOfFragmentSampleIndex)
        {
            throw new NotImplementedException();
        }

        public void SetEndOfFragmentSampleIndex(ulong endOfFragmentSampleIndex)
        {
            throw new NotImplementedException();
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
    public class MTLRenderPassSampleBufferAttachmentDescriptorArray
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
            throw new NotImplementedException();
        }

        public void SetObject(MTLRenderPassSampleBufferAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLRenderPassDescriptor
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
            throw new NotImplementedException();
        }

        public void SetStencilAttachment(MTLRenderPassStencilAttachmentDescriptor stencilAttachment)
        {
            throw new NotImplementedException();
        }

        public void SetVisibilityResultBuffer(MTLBuffer visibilityResultBuffer)
        {
            throw new NotImplementedException();
        }

        public void SetRenderTargetArrayLength(ulong renderTargetArrayLength)
        {
            throw new NotImplementedException();
        }

        public void SetImageblockSampleLength(ulong imageblockSampleLength)
        {
            throw new NotImplementedException();
        }

        public void SetThreadgroupMemoryLength(ulong threadgroupMemoryLength)
        {
            throw new NotImplementedException();
        }

        public void SetTileWidth(ulong tileWidth)
        {
            throw new NotImplementedException();
        }

        public void SetTileHeight(ulong tileHeight)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultRasterSampleCount(ulong defaultRasterSampleCount)
        {
            throw new NotImplementedException();
        }

        public void SetRenderTargetWidth(ulong renderTargetWidth)
        {
            throw new NotImplementedException();
        }

        public void SetRenderTargetHeight(ulong renderTargetHeight)
        {
            throw new NotImplementedException();
        }

        public void SetSamplePositions(MTLSamplePosition positions, ulong count)
        {
            throw new NotImplementedException();
        }

        public ulong GetSamplePositions(MTLSamplePosition positions, ulong count)
        {
            throw new NotImplementedException();
        }

        public void SetRasterizationRateMap(MTLRasterizationRateMap rasterizationRateMap)
        {
            throw new NotImplementedException();
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
