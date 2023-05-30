using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLBlendFactor: ulong
    {
        Zero = 0,
        One = 1,
        SourceColor = 2,
        OneMinusSourceColor = 3,
        SourceAlpha = 4,
        OneMinusSourceAlpha = 5,
        DestinationColor = 6,
        OneMinusDestinationColor = 7,
        DestinationAlpha = 8,
        OneMinusDestinationAlpha = 9,
        SourceAlphaSaturated = 10,
        BlendColor = 11,
        OneMinusBlendColor = 12,
        BlendAlpha = 13,
        OneMinusBlendAlpha = 14,
        Source1Color = 15,
        OneMinusSource1Color = 16,
        Source1Alpha = 17,
        OneMinusSource1Alpha = 18,
    }

    public enum MTLBlendOperation: ulong
    {
        Add = 0,
        Subtract = 1,
        ReverseSubtract = 2,
        Min = 3,
        Max = 4,
    }

    public enum MTLColorWriteMask: ulong
    {
        None = 0,
        Alpha = 1,
        Blue = 2,
        Green = 4,
        Red = 8,
        All = 15,
    }

    public enum MTLPrimitiveTopologyClass: ulong
    {
        Unspecified = 0,
        Point = 1,
        Line = 2,
        Triangle = 3,
    }

    public enum MTLTessellationPartitionMode: ulong
    {
        Pow2 = 0,
        Integer = 1,
        FractionalOdd = 2,
        FractionalEven = 3,
    }

    public enum MTLTessellationFactorStepFunction: ulong
    {
        Constant = 0,
        PerPatch = 1,
        PerInstance = 2,
        PerPatchAndPerInstance = 3,
    }

    public enum MTLTessellationFactorFormat: ulong
    {
        Half = 0,
    }

    public enum MTLTessellationControlPointIndexType: ulong
    {
        None = 0,
        UInt16 = 1,
        UInt32 = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineColorAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
        public bool BlendingEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isBlendingEnabled);
        public MTLBlendFactor SourceRGBBlendFactor => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceRGBBlendFactor);
        public MTLBlendFactor DestinationRGBBlendFactor => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationRGBBlendFactor);
        public MTLBlendOperation RgbBlendOperation => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rgbBlendOperation);
        public MTLBlendFactor SourceAlphaBlendFactor => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceAlphaBlendFactor);
        public MTLBlendFactor DestinationAlphaBlendFactor => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationAlphaBlendFactor);
        public MTLBlendOperation AlphaBlendOperation => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alphaBlendOperation);
        public MTLColorWriteMask WriteMask => (MTLColorWriteMask)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_writeMask);

        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_isBlendingEnabled = "isBlendingEnabled";
        private static readonly Selector sel_setBlendingEnabled = "setBlendingEnabled:";
        private static readonly Selector sel_sourceRGBBlendFactor = "sourceRGBBlendFactor";
        private static readonly Selector sel_setSourceRGBBlendFactor = "setSourceRGBBlendFactor:";
        private static readonly Selector sel_destinationRGBBlendFactor = "destinationRGBBlendFactor";
        private static readonly Selector sel_setDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";
        private static readonly Selector sel_rgbBlendOperation = "rgbBlendOperation";
        private static readonly Selector sel_setRgbBlendOperation = "setRgbBlendOperation:";
        private static readonly Selector sel_sourceAlphaBlendFactor = "sourceAlphaBlendFactor";
        private static readonly Selector sel_setSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";
        private static readonly Selector sel_destinationAlphaBlendFactor = "destinationAlphaBlendFactor";
        private static readonly Selector sel_setDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";
        private static readonly Selector sel_alphaBlendOperation = "alphaBlendOperation";
        private static readonly Selector sel_setAlphaBlendOperation = "setAlphaBlendOperation:";
        private static readonly Selector sel_writeMask = "writeMask";
        private static readonly Selector sel_setWriteMask = "setWriteMask:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineReflection
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineReflection obj) => obj.NativePtr;
        public MTLRenderPipelineReflection(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineReflection()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineReflection");
            NativePtr = cls.AllocInit();
        }

        public NSArray VertexBindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBindings));
        public NSArray FragmentBindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentBindings));
        public NSArray TileBindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileBindings));
        public NSArray ObjectBindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectBindings));
        public NSArray MeshBindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshBindings));
        public NSArray VertexArguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexArguments));
        public NSArray FragmentArguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentArguments));
        public NSArray TileArguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileArguments));

        private static readonly Selector sel_vertexBindings = "vertexBindings";
        private static readonly Selector sel_fragmentBindings = "fragmentBindings";
        private static readonly Selector sel_tileBindings = "tileBindings";
        private static readonly Selector sel_objectBindings = "objectBindings";
        private static readonly Selector sel_meshBindings = "meshBindings";
        private static readonly Selector sel_vertexArguments = "vertexArguments";
        private static readonly Selector sel_fragmentArguments = "fragmentArguments";
        private static readonly Selector sel_tileArguments = "tileArguments";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineDescriptor obj) => obj.NativePtr;
        public MTLRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLFunction VertexFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexFunction));
        public MTLFunction FragmentFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunction));
        public MTLVertexDescriptor VertexDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexDescriptor));
        public ulong SampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);
        public ulong RasterSampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
        public bool AlphaToCoverageEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToCoverageEnabled);
        public bool AlphaToOneEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToOneEnabled);
        public bool RasterizationEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRasterizationEnabled);
        public ulong MaxVertexAmplificationCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexAmplificationCount);
        public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));
        public MTLPixelFormat DepthAttachmentPixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
        public MTLPixelFormat StencilAttachmentPixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);
        public MTLPrimitiveTopologyClass InputPrimitiveTopology => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputPrimitiveTopology);
        public MTLTessellationPartitionMode TessellationPartitionMode => (MTLTessellationPartitionMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationPartitionMode);
        public ulong MaxTessellationFactor => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTessellationFactor);
        public bool TessellationFactorScaleEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isTessellationFactorScaleEnabled);
        public MTLTessellationFactorFormat TessellationFactorFormat => (MTLTessellationFactorFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationFactorFormat);
        public MTLTessellationControlPointIndexType TessellationControlPointIndexType => (MTLTessellationControlPointIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationControlPointIndexType);
        public MTLTessellationFactorStepFunction TessellationFactorStepFunction => (MTLTessellationFactorStepFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationFactorStepFunction);
        public MTLWinding TessellationOutputWindingOrder => (MTLWinding)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationOutputWindingOrder);
        public MTLPipelineBufferDescriptorArray VertexBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffers));
        public MTLPipelineBufferDescriptorArray FragmentBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentBuffers));
        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
        public NSArray BinaryArchives => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
        public NSArray VertexPreloadedLibraries => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexPreloadedLibraries));
        public NSArray FragmentPreloadedLibraries => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentPreloadedLibraries));
        public MTLLinkedFunctions VertexLinkedFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexLinkedFunctions));
        public MTLLinkedFunctions FragmentLinkedFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentLinkedFunctions));
        public bool SupportAddingVertexBinaryFunctions => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingVertexBinaryFunctions);
        public bool SupportAddingFragmentBinaryFunctions => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingFragmentBinaryFunctions);
        public ulong MaxVertexCallStackDepth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexCallStackDepth);
        public ulong MaxFragmentCallStackDepth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxFragmentCallStackDepth);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_vertexFunction = "vertexFunction";
        private static readonly Selector sel_setVertexFunction = "setVertexFunction:";
        private static readonly Selector sel_fragmentFunction = "fragmentFunction";
        private static readonly Selector sel_setFragmentFunction = "setFragmentFunction:";
        private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        private static readonly Selector sel_setVertexDescriptor = "setVertexDescriptor:";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        private static readonly Selector sel_rasterSampleCount = "rasterSampleCount";
        private static readonly Selector sel_setRasterSampleCount = "setRasterSampleCount:";
        private static readonly Selector sel_isAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";
        private static readonly Selector sel_setAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";
        private static readonly Selector sel_isAlphaToOneEnabled = "isAlphaToOneEnabled";
        private static readonly Selector sel_setAlphaToOneEnabled = "setAlphaToOneEnabled:";
        private static readonly Selector sel_isRasterizationEnabled = "isRasterizationEnabled";
        private static readonly Selector sel_setRasterizationEnabled = "setRasterizationEnabled:";
        private static readonly Selector sel_maxVertexAmplificationCount = "maxVertexAmplificationCount";
        private static readonly Selector sel_setMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_depthAttachmentPixelFormat = "depthAttachmentPixelFormat";
        private static readonly Selector sel_setDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";
        private static readonly Selector sel_stencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";
        private static readonly Selector sel_setStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";
        private static readonly Selector sel_inputPrimitiveTopology = "inputPrimitiveTopology";
        private static readonly Selector sel_setInputPrimitiveTopology = "setInputPrimitiveTopology:";
        private static readonly Selector sel_tessellationPartitionMode = "tessellationPartitionMode";
        private static readonly Selector sel_setTessellationPartitionMode = "setTessellationPartitionMode:";
        private static readonly Selector sel_maxTessellationFactor = "maxTessellationFactor";
        private static readonly Selector sel_setMaxTessellationFactor = "setMaxTessellationFactor:";
        private static readonly Selector sel_isTessellationFactorScaleEnabled = "isTessellationFactorScaleEnabled";
        private static readonly Selector sel_setTessellationFactorScaleEnabled = "setTessellationFactorScaleEnabled:";
        private static readonly Selector sel_tessellationFactorFormat = "tessellationFactorFormat";
        private static readonly Selector sel_setTessellationFactorFormat = "setTessellationFactorFormat:";
        private static readonly Selector sel_tessellationControlPointIndexType = "tessellationControlPointIndexType";
        private static readonly Selector sel_setTessellationControlPointIndexType = "setTessellationControlPointIndexType:";
        private static readonly Selector sel_tessellationFactorStepFunction = "tessellationFactorStepFunction";
        private static readonly Selector sel_setTessellationFactorStepFunction = "setTessellationFactorStepFunction:";
        private static readonly Selector sel_tessellationOutputWindingOrder = "tessellationOutputWindingOrder";
        private static readonly Selector sel_setTessellationOutputWindingOrder = "setTessellationOutputWindingOrder:";
        private static readonly Selector sel_vertexBuffers = "vertexBuffers";
        private static readonly Selector sel_fragmentBuffers = "fragmentBuffers";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
        private static readonly Selector sel_vertexPreloadedLibraries = "vertexPreloadedLibraries";
        private static readonly Selector sel_setVertexPreloadedLibraries = "setVertexPreloadedLibraries:";
        private static readonly Selector sel_fragmentPreloadedLibraries = "fragmentPreloadedLibraries";
        private static readonly Selector sel_setFragmentPreloadedLibraries = "setFragmentPreloadedLibraries:";
        private static readonly Selector sel_vertexLinkedFunctions = "vertexLinkedFunctions";
        private static readonly Selector sel_setVertexLinkedFunctions = "setVertexLinkedFunctions:";
        private static readonly Selector sel_fragmentLinkedFunctions = "fragmentLinkedFunctions";
        private static readonly Selector sel_setFragmentLinkedFunctions = "setFragmentLinkedFunctions:";
        private static readonly Selector sel_supportAddingVertexBinaryFunctions = "supportAddingVertexBinaryFunctions";
        private static readonly Selector sel_setSupportAddingVertexBinaryFunctions = "setSupportAddingVertexBinaryFunctions:";
        private static readonly Selector sel_supportAddingFragmentBinaryFunctions = "supportAddingFragmentBinaryFunctions";
        private static readonly Selector sel_setSupportAddingFragmentBinaryFunctions = "setSupportAddingFragmentBinaryFunctions:";
        private static readonly Selector sel_maxVertexCallStackDepth = "maxVertexCallStackDepth";
        private static readonly Selector sel_setMaxVertexCallStackDepth = "setMaxVertexCallStackDepth:";
        private static readonly Selector sel_maxFragmentCallStackDepth = "maxFragmentCallStackDepth";
        private static readonly Selector sel_setMaxFragmentCallStackDepth = "setMaxFragmentCallStackDepth:";
        private static readonly Selector sel_reset = "reset";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineFunctionsDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineFunctionsDescriptor obj) => obj.NativePtr;
        public MTLRenderPipelineFunctionsDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineFunctionsDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineFunctionsDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray VertexAdditionalBinaryFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexAdditionalBinaryFunctions));
        public NSArray FragmentAdditionalBinaryFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentAdditionalBinaryFunctions));
        public NSArray TileAdditionalBinaryFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileAdditionalBinaryFunctions));

        private static readonly Selector sel_vertexAdditionalBinaryFunctions = "vertexAdditionalBinaryFunctions";
        private static readonly Selector sel_setVertexAdditionalBinaryFunctions = "setVertexAdditionalBinaryFunctions:";
        private static readonly Selector sel_fragmentAdditionalBinaryFunctions = "fragmentAdditionalBinaryFunctions";
        private static readonly Selector sel_setFragmentAdditionalBinaryFunctions = "setFragmentAdditionalBinaryFunctions:";
        private static readonly Selector sel_tileAdditionalBinaryFunctions = "tileAdditionalBinaryFunctions";
        private static readonly Selector sel_setTileAdditionalBinaryFunctions = "setTileAdditionalBinaryFunctions:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineState obj) => obj.NativePtr;
        public MTLRenderPipelineState(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
        public bool ThreadgroupSizeMatchesTileSize => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadgroupSizeMatchesTileSize);
        public ulong ImageblockSampleLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockSampleLength);
        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
        public ulong MaxTotalThreadsPerObjectThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerObjectThreadgroup);
        public ulong MaxTotalThreadsPerMeshThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerMeshThreadgroup);
        public ulong ObjectThreadExecutionWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_objectThreadExecutionWidth);
        public ulong MeshThreadExecutionWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_meshThreadExecutionWidth);
        public ulong MaxTotalThreadgroupsPerMeshGrid => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadgroupsPerMeshGrid);
        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_threadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
        private static readonly Selector sel_imageblockSampleLength = "imageblockSampleLength";
        private static readonly Selector sel_imageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_maxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";
        private static readonly Selector sel_maxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";
        private static readonly Selector sel_objectThreadExecutionWidth = "objectThreadExecutionWidth";
        private static readonly Selector sel_meshThreadExecutionWidth = "meshThreadExecutionWidth";
        private static readonly Selector sel_maxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_functionHandleWithFunctionstage = "functionHandleWithFunction:stage:";
        private static readonly Selector sel_newVisibleFunctionTableWithDescriptorstage = "newVisibleFunctionTableWithDescriptor:stage:";
        private static readonly Selector sel_newIntersectionFunctionTableWithDescriptorstage = "newIntersectionFunctionTableWithDescriptor:stage:";
        private static readonly Selector sel_newRenderPipelineStateWithAdditionalBinaryFunctionserror = "newRenderPipelineStateWithAdditionalBinaryFunctions:error:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineColorAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTileRenderPipelineColorAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTileRenderPipelineColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTLTileRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTileRenderPipelineColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTileRenderPipelineColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLPixelFormat PixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);

        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTileRenderPipelineColorAttachmentDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTileRenderPipelineColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLTileRenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLTileRenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLTileRenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTileRenderPipelineDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTileRenderPipelineDescriptor obj) => obj.NativePtr;
        public MTLTileRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTileRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTileRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLFunction TileFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileFunction));
        public ulong RasterSampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
        public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));
        public bool ThreadgroupSizeMatchesTileSize => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadgroupSizeMatchesTileSize);
        public MTLPipelineBufferDescriptorArray TileBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileBuffers));
        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
        public NSArray BinaryArchives => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
        public NSArray PreloadedLibraries => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
        public MTLLinkedFunctions LinkedFunctions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_linkedFunctions));
        public bool SupportAddingBinaryFunctions => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingBinaryFunctions);
        public ulong MaxCallStackDepth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_tileFunction = "tileFunction";
        private static readonly Selector sel_setTileFunction = "setTileFunction:";
        private static readonly Selector sel_rasterSampleCount = "rasterSampleCount";
        private static readonly Selector sel_setRasterSampleCount = "setRasterSampleCount:";
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_threadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
        private static readonly Selector sel_setThreadgroupSizeMatchesTileSize = "setThreadgroupSizeMatchesTileSize:";
        private static readonly Selector sel_tileBuffers = "tileBuffers";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
        private static readonly Selector sel_preloadedLibraries = "preloadedLibraries";
        private static readonly Selector sel_setPreloadedLibraries = "setPreloadedLibraries:";
        private static readonly Selector sel_linkedFunctions = "linkedFunctions";
        private static readonly Selector sel_setLinkedFunctions = "setLinkedFunctions:";
        private static readonly Selector sel_supportAddingBinaryFunctions = "supportAddingBinaryFunctions";
        private static readonly Selector sel_setSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";
        private static readonly Selector sel_maxCallStackDepth = "maxCallStackDepth";
        private static readonly Selector sel_setMaxCallStackDepth = "setMaxCallStackDepth:";
        private static readonly Selector sel_reset = "reset";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLMeshRenderPipelineDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLMeshRenderPipelineDescriptor obj) => obj.NativePtr;
        public MTLMeshRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLMeshRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLMeshRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLFunction ObjectFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectFunction));
        public MTLFunction MeshFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshFunction));
        public MTLFunction FragmentFunction => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunction));
        public ulong MaxTotalThreadsPerObjectThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerObjectThreadgroup);
        public ulong MaxTotalThreadsPerMeshThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerMeshThreadgroup);
        public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_objectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_meshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
        public ulong PayloadMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_payloadMemoryLength);
        public ulong MaxTotalThreadgroupsPerMeshGrid => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadgroupsPerMeshGrid);
        public MTLPipelineBufferDescriptorArray ObjectBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectBuffers));
        public MTLPipelineBufferDescriptorArray MeshBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshBuffers));
        public MTLPipelineBufferDescriptorArray FragmentBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentBuffers));
        public ulong RasterSampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
        public bool AlphaToCoverageEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToCoverageEnabled);
        public bool AlphaToOneEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToOneEnabled);
        public bool RasterizationEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRasterizationEnabled);
        public ulong MaxVertexAmplificationCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexAmplificationCount);
        public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));
        public MTLPixelFormat DepthAttachmentPixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
        public MTLPixelFormat StencilAttachmentPixelFormat => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_objectFunction = "objectFunction";
        private static readonly Selector sel_setObjectFunction = "setObjectFunction:";
        private static readonly Selector sel_meshFunction = "meshFunction";
        private static readonly Selector sel_setMeshFunction = "setMeshFunction:";
        private static readonly Selector sel_fragmentFunction = "fragmentFunction";
        private static readonly Selector sel_setFragmentFunction = "setFragmentFunction:";
        private static readonly Selector sel_maxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerObjectThreadgroup = "setMaxTotalThreadsPerObjectThreadgroup:";
        private static readonly Selector sel_maxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerMeshThreadgroup = "setMaxTotalThreadsPerMeshThreadgroup:";
        private static readonly Selector sel_objectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "objectThreadgroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_meshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "meshThreadgroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_payloadMemoryLength = "payloadMemoryLength";
        private static readonly Selector sel_setPayloadMemoryLength = "setPayloadMemoryLength:";
        private static readonly Selector sel_maxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";
        private static readonly Selector sel_setMaxTotalThreadgroupsPerMeshGrid = "setMaxTotalThreadgroupsPerMeshGrid:";
        private static readonly Selector sel_objectBuffers = "objectBuffers";
        private static readonly Selector sel_meshBuffers = "meshBuffers";
        private static readonly Selector sel_fragmentBuffers = "fragmentBuffers";
        private static readonly Selector sel_rasterSampleCount = "rasterSampleCount";
        private static readonly Selector sel_setRasterSampleCount = "setRasterSampleCount:";
        private static readonly Selector sel_isAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";
        private static readonly Selector sel_setAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";
        private static readonly Selector sel_isAlphaToOneEnabled = "isAlphaToOneEnabled";
        private static readonly Selector sel_setAlphaToOneEnabled = "setAlphaToOneEnabled:";
        private static readonly Selector sel_isRasterizationEnabled = "isRasterizationEnabled";
        private static readonly Selector sel_setRasterizationEnabled = "setRasterizationEnabled:";
        private static readonly Selector sel_maxVertexAmplificationCount = "maxVertexAmplificationCount";
        private static readonly Selector sel_setMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_depthAttachmentPixelFormat = "depthAttachmentPixelFormat";
        private static readonly Selector sel_setDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";
        private static readonly Selector sel_stencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";
        private static readonly Selector sel_setStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";
        private static readonly Selector sel_reset = "reset";
    }
}
