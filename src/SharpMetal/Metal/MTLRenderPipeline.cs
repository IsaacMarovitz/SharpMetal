using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLBlendFactor : ulong
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

    [SupportedOSPlatform("macos")]
    public enum MTLBlendOperation : ulong
    {
        Add = 0,
        Subtract = 1,
        ReverseSubtract = 2,
        Min = 3,
        Max = 4,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLColorWriteMask : ulong
    {
        None = 0,
        Red = 8,
        Green = 4,
        Blue = 2,
        Alpha = 1,
        All = 15,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLPrimitiveTopologyClass : ulong
    {
        Unspecified = 0,
        Point = 1,
        Line = 2,
        Triangle = 3,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTessellationPartitionMode : ulong
    {
        Pow2 = 0,
        Integer = 1,
        FractionalOdd = 2,
        FractionalEven = 3,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTessellationFactorStepFunction : ulong
    {
        Constant = 0,
        PerPatch = 1,
        PerInstance = 2,
        PerPatchAndPerInstance = 3,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTessellationFactorFormat : ulong
    {
        Half = 0,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLTessellationControlPointIndexType : ulong
    {
        None = 0,
        UInt16 = 1,
        UInt32 = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineColorAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTLRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
        }

        public bool BlendingEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isBlendingEnabled);

        public MTLBlendFactor SourceRGBBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceRGBBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSourceRGBBlendFactor, (ulong)value);
        }

        public MTLBlendFactor DestinationRGBBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationRGBBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestinationRGBBlendFactor, (ulong)value);
        }

        public MTLBlendOperation RgbBlendOperation
        {
            get => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rgbBlendOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRgbBlendOperation, (ulong)value);
        }

        public MTLBlendFactor SourceAlphaBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceAlphaBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSourceAlphaBlendFactor, (ulong)value);
        }

        public MTLBlendFactor DestinationAlphaBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationAlphaBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestinationAlphaBlendFactor, (ulong)value);
        }

        public MTLBlendOperation AlphaBlendOperation
        {
            get => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alphaBlendOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaBlendOperation, (ulong)value);
        }

        public MTLColorWriteMask WriteMask
        {
            get => (MTLColorWriteMask)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_writeMask);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWriteMask, (ulong)value);
        }

        public void SetBlendingEnabled(bool blendingEnabled)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBlendingEnabled, blendingEnabled);
        }

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
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineReflection : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineReflection obj) => obj.NativePtr;
        public MTLRenderPipelineReflection(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineReflection()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineReflection");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
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
        private static readonly Selector sel_release = "release";
    }

    /// <summary>
    /// This is a private Metal API.
    /// It is not recommended for use in any production applications,
    /// and may break at any time without warning. Hic sunt dracones.
    /// </summary>
    [SupportedOSPlatform("macos")]
    public enum MTLLogicOperation : ulong
    {
        Clear,
        Set,
        Copy,
        CopyInverted,
        Noop,
        Invert,
        And,
        Nand,
        Or,
        Nor,
        Xor,
        Equivalence,
        AndReverse,
        AndInverted,
        OrReverse,
        OrInverted
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineDescriptor obj) => obj.NativePtr;
        public MTLRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLFunction VertexFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexFunction, value);
        }

        public MTLFunction FragmentFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentFunction, value);
        }

        public MTLVertexDescriptor VertexDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexDescriptor, value);
        }

        public ulong SampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public ulong RasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterSampleCount, value);
        }

        public bool AlphaToCoverageEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToCoverageEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaToCoverageEnabled, value);
        }

        public bool AlphaToOneEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToOneEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaToOneEnabled, value);
        }

        public bool RasterizationEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRasterizationEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationEnabled, value);
        }

        public ulong MaxVertexAmplificationCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexAmplificationCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexAmplificationCount, value);
        }

        public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public MTLPixelFormat DepthAttachmentPixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthAttachmentPixelFormat, (ulong)value);
        }

        public MTLPixelFormat StencilAttachmentPixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilAttachmentPixelFormat, (ulong)value);
        }

        public MTLPrimitiveTopologyClass InputPrimitiveTopology
        {
            get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputPrimitiveTopology);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputPrimitiveTopology, (ulong)value);
        }

        public MTLTessellationPartitionMode TessellationPartitionMode
        {
            get => (MTLTessellationPartitionMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationPartitionMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationPartitionMode, (ulong)value);
        }

        public ulong MaxTessellationFactor
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTessellationFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTessellationFactor, value);
        }

        public bool TessellationFactorScaleEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isTessellationFactorScaleEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationFactorScaleEnabled, value);
        }

        public MTLTessellationFactorFormat TessellationFactorFormat
        {
            get => (MTLTessellationFactorFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationFactorFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationFactorFormat, (ulong)value);
        }

        public MTLTessellationControlPointIndexType TessellationControlPointIndexType
        {
            get => (MTLTessellationControlPointIndexType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationControlPointIndexType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationControlPointIndexType, (ulong)value);
        }

        public MTLTessellationFactorStepFunction TessellationFactorStepFunction
        {
            get => (MTLTessellationFactorStepFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationFactorStepFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationFactorStepFunction, (ulong)value);
        }

        public MTLWinding TessellationOutputWindingOrder
        {
            get => (MTLWinding)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tessellationOutputWindingOrder);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTessellationOutputWindingOrder, (ulong)value);
        }

        public MTLPipelineBufferDescriptorArray VertexBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexBuffers));

        public MTLPipelineBufferDescriptorArray FragmentBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentBuffers));

        public bool SupportIndirectCommandBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, value);
        }

        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
        }

        public NSArray VertexPreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexPreloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexPreloadedLibraries, value);
        }

        public NSArray FragmentPreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentPreloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentPreloadedLibraries, value);
        }

        public MTLLinkedFunctions VertexLinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexLinkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexLinkedFunctions, value);
        }

        public MTLLinkedFunctions FragmentLinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentLinkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentLinkedFunctions, value);
        }

        public bool SupportAddingVertexBinaryFunctions
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingVertexBinaryFunctions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAddingVertexBinaryFunctions, value);
        }

        public bool SupportAddingFragmentBinaryFunctions
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingFragmentBinaryFunctions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAddingFragmentBinaryFunctions, value);
        }

        public ulong MaxVertexCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexCallStackDepth, value);
        }

        public ulong MaxFragmentCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxFragmentCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxFragmentCallStackDepth, value);
        }

        /// <summary>
        /// This is a private Metal API.
        /// It is not recommended for use in any production applications,
        /// and may break at any time without warning. Hic sunt dracones.
        /// </summary>
        public bool LogicOperationEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isLogicOperationEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogicOperationEnabled, value);
        }

        /// <summary>
        /// This is a private Metal API.
        /// It is not recommended for use in any production applications,
        /// and may break at any time without warning. Hic sunt dracones.
        /// </summary>
        public MTLLogicOperation LogicOperation
        {
            get => (MTLLogicOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_logicOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogicOperation, (ulong)value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

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
        private static readonly Selector sel_isLogicOperationEnabled = "isLogicOperationEnabled";
        private static readonly Selector sel_setLogicOperationEnabled = "setLogicOperationEnabled:";
        private static readonly Selector sel_logicOperation = "logicOperation";
        private static readonly Selector sel_setLogicOperation = "setLogicOperation:";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineFunctionsDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineFunctionsDescriptor obj) => obj.NativePtr;
        public MTLRenderPipelineFunctionsDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineFunctionsDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineFunctionsDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray VertexAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexAdditionalBinaryFunctions, value);
        }

        public NSArray FragmentAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentAdditionalBinaryFunctions, value);
        }

        public NSArray TileAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileAdditionalBinaryFunctions, value);
        }

        private static readonly Selector sel_vertexAdditionalBinaryFunctions = "vertexAdditionalBinaryFunctions";
        private static readonly Selector sel_setVertexAdditionalBinaryFunctions = "setVertexAdditionalBinaryFunctions:";
        private static readonly Selector sel_fragmentAdditionalBinaryFunctions = "fragmentAdditionalBinaryFunctions";
        private static readonly Selector sel_setFragmentAdditionalBinaryFunctions = "setFragmentAdditionalBinaryFunctions:";
        private static readonly Selector sel_tileAdditionalBinaryFunctions = "tileAdditionalBinaryFunctions";
        private static readonly Selector sel_setTileAdditionalBinaryFunctions = "setTileAdditionalBinaryFunctions:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineState : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineState obj) => obj.NativePtr;
        public MTLRenderPipelineState(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

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

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public ulong ImageblockMemoryLength(MTLSize imageblockDimensions)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockMemoryLengthForDimensions, imageblockDimensions);
        }

        public MTLFunctionHandle FunctionHandle(MTLFunction function, MTLRenderStages stage)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionHandleWithFunctionstage, function, (ulong)stage));
        }

        public MTLVisibleFunctionTable NewVisibleFunctionTable(MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newVisibleFunctionTableWithDescriptorstage, descriptor, (ulong)stage));
        }

        public MTLIntersectionFunctionTable NewIntersectionFunctionTable(MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newIntersectionFunctionTableWithDescriptorstage, descriptor, (ulong)stage));
        }

        public MTLRenderPipelineState NewRenderPipelineState(MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newRenderPipelineStateWithAdditionalBinaryFunctionserror, additionalBinaryFunctions, ref error.NativePtr));
        }

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
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRenderPipelineColorAttachmentDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRenderPipelineColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLRenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLRenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLRenderPipelineColorAttachmentDescriptor Object(ulong attachmentIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, attachmentIndex));
        }

        public void SetObject(MTLRenderPipelineColorAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTileRenderPipelineColorAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTileRenderPipelineColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTLTileRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTileRenderPipelineColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTileRenderPipelineColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
        }

        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTileRenderPipelineColorAttachmentDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTileRenderPipelineColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTLTileRenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLTileRenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLTileRenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLTileRenderPipelineColorAttachmentDescriptor Object(ulong attachmentIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, attachmentIndex));
        }

        public void SetObject(MTLTileRenderPipelineColorAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLTileRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTileRenderPipelineDescriptor obj) => obj.NativePtr;
        public MTLTileRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLTileRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLTileRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLFunction TileFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileFunction, value);
        }

        public ulong RasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterSampleCount, value);
        }

        public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public bool ThreadgroupSizeMatchesTileSize
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadgroupSizeMatchesTileSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupSizeMatchesTileSize, value);
        }

        public MTLPipelineBufferDescriptorArray TileBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileBuffers));

        public ulong MaxTotalThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerThreadgroup, value);
        }

        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
        }

        public NSArray PreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreloadedLibraries, value);
        }

        public MTLLinkedFunctions LinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_linkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLinkedFunctions, value);
        }

        public bool SupportAddingBinaryFunctions
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingBinaryFunctions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAddingBinaryFunctions, value);
        }

        public ulong MaxCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCallStackDepth, value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

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
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLMeshRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLMeshRenderPipelineDescriptor obj) => obj.NativePtr;
        public MTLMeshRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLMeshRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTLMeshRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLFunction ObjectFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectFunction, value);
        }

        public MTLFunction MeshFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshFunction, value);
        }

        public MTLFunction FragmentFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentFunction, value);
        }

        public ulong MaxTotalThreadsPerObjectThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerObjectThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerObjectThreadgroup, value);
        }

        public ulong MaxTotalThreadsPerMeshThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerMeshThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerMeshThreadgroup, value);
        }

        public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_objectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_meshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public ulong PayloadMemoryLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_payloadMemoryLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPayloadMemoryLength, value);
        }

        public ulong MaxTotalThreadgroupsPerMeshGrid
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadgroupsPerMeshGrid);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadgroupsPerMeshGrid, value);
        }

        public MTLPipelineBufferDescriptorArray ObjectBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectBuffers));

        public MTLPipelineBufferDescriptorArray MeshBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshBuffers));

        public MTLPipelineBufferDescriptorArray FragmentBuffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentBuffers));

        public ulong RasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterSampleCount, value);
        }

        public bool AlphaToCoverageEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToCoverageEnabled);

        public bool AlphaToOneEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAlphaToOneEnabled);

        public bool RasterizationEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRasterizationEnabled);

        public ulong MaxVertexAmplificationCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexAmplificationCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexAmplificationCount, value);
        }

        public MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public MTLPixelFormat DepthAttachmentPixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthAttachmentPixelFormat, (ulong)value);
        }

        public MTLPixelFormat StencilAttachmentPixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilAttachmentPixelFormat, (ulong)value);
        }

        public bool SupportIndirectCommandBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, value);
        }

        public MTLLinkedFunctions ObjectLinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectLinkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectLinkedFunctions, value);
        }

        public MTLLinkedFunctions MeshLinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshLinkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshLinkedFunctions, value);
        }

        public MTLLinkedFunctions FragmentLinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentLinkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentLinkedFunctions, value);
        }

        public void SetAlphaToCoverageEnabled(bool alphaToCoverageEnabled)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaToCoverageEnabled, alphaToCoverageEnabled);
        }

        public void SetAlphaToOneEnabled(bool alphaToOneEnabled)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaToOneEnabled, alphaToOneEnabled);
        }

        public void SetRasterizationEnabled(bool rasterizationEnabled)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationEnabled, rasterizationEnabled);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

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
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_objectLinkedFunctions = "objectLinkedFunctions";
        private static readonly Selector sel_setObjectLinkedFunctions = "setObjectLinkedFunctions:";
        private static readonly Selector sel_meshLinkedFunctions = "meshLinkedFunctions";
        private static readonly Selector sel_setMeshLinkedFunctions = "setMeshLinkedFunctions:";
        private static readonly Selector sel_fragmentLinkedFunctions = "fragmentLinkedFunctions";
        private static readonly Selector sel_setFragmentLinkedFunctions = "setFragmentLinkedFunctions:";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_release = "release";
    }
}
