using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4LogicalToPhysicalColorAttachmentMappingState : long
    {
        Identity = 0,
        Inherited = 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineBinaryFunctionsDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineBinaryFunctionsDescriptor obj) => obj.NativePtr;
        public MTL4RenderPipelineBinaryFunctionsDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineBinaryFunctionsDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineBinaryFunctionsDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray FragmentAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentAdditionalBinaryFunctions, value);
        }

        public NSArray MeshAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshAdditionalBinaryFunctions, value);
        }

        public NSArray ObjectAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectAdditionalBinaryFunctions, value);
        }

        public NSArray TileAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileAdditionalBinaryFunctions, value);
        }

        public NSArray VertexAdditionalBinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexAdditionalBinaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexAdditionalBinaryFunctions, value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_fragmentAdditionalBinaryFunctions = "fragmentAdditionalBinaryFunctions";
        private static readonly Selector sel_meshAdditionalBinaryFunctions = "meshAdditionalBinaryFunctions";
        private static readonly Selector sel_objectAdditionalBinaryFunctions = "objectAdditionalBinaryFunctions";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setFragmentAdditionalBinaryFunctions = "setFragmentAdditionalBinaryFunctions:";
        private static readonly Selector sel_setMeshAdditionalBinaryFunctions = "setMeshAdditionalBinaryFunctions:";
        private static readonly Selector sel_setObjectAdditionalBinaryFunctions = "setObjectAdditionalBinaryFunctions:";
        private static readonly Selector sel_setTileAdditionalBinaryFunctions = "setTileAdditionalBinaryFunctions:";
        private static readonly Selector sel_setVertexAdditionalBinaryFunctions = "setVertexAdditionalBinaryFunctions:";
        private static readonly Selector sel_tileAdditionalBinaryFunctions = "tileAdditionalBinaryFunctions";
        private static readonly Selector sel_vertexAdditionalBinaryFunctions = "vertexAdditionalBinaryFunctions";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineColorAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTL4RenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLBlendOperation AlphaBlendOperation
        {
            get => (MTLBlendOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alphaBlendOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaBlendOperation, (ulong)value);
        }

        public MTL4BlendState BlendingState
        {
            get => (MTL4BlendState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_blendingState);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBlendingState, (long)value);
        }

        public MTLBlendFactor DestinationAlphaBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationAlphaBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestinationAlphaBlendFactor, (ulong)value);
        }

        public MTLBlendFactor DestinationRGBBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_destinationRGBBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestinationRGBBlendFactor, (ulong)value);
        }

        public MTLPixelFormat PixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (ulong)value);
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

        public MTLBlendFactor SourceRGBBlendFactor
        {
            get => (MTLBlendFactor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sourceRGBBlendFactor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSourceRGBBlendFactor, (ulong)value);
        }

        public MTLColorWriteMask WriteMask
        {
            get => (MTLColorWriteMask)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_writeMask);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWriteMask, (ulong)value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_alphaBlendOperation = "alphaBlendOperation";
        private static readonly Selector sel_blendingState = "blendingState";
        private static readonly Selector sel_destinationAlphaBlendFactor = "destinationAlphaBlendFactor";
        private static readonly Selector sel_destinationRGBBlendFactor = "destinationRGBBlendFactor";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_rgbBlendOperation = "rgbBlendOperation";
        private static readonly Selector sel_setAlphaBlendOperation = "setAlphaBlendOperation:";
        private static readonly Selector sel_setBlendingState = "setBlendingState:";
        private static readonly Selector sel_setDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";
        private static readonly Selector sel_setDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_setRgbBlendOperation = "setRgbBlendOperation:";
        private static readonly Selector sel_setSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";
        private static readonly Selector sel_setSourceRGBBlendFactor = "setSourceRGBBlendFactor:";
        private static readonly Selector sel_setWriteMask = "setWriteMask:";
        private static readonly Selector sel_sourceAlphaBlendFactor = "sourceAlphaBlendFactor";
        private static readonly Selector sel_sourceRGBBlendFactor = "sourceRGBBlendFactor";
        private static readonly Selector sel_writeMask = "writeMask";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineColorAttachmentDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTL4RenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4RenderPipelineColorAttachmentDescriptor Object(ulong attachmentIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, attachmentIndex));
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        public void SetObject(MTL4RenderPipelineColorAttachmentDescriptor attachment, ulong attachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, attachment, attachmentIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4RenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4RenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4AlphaToCoverageState AlphaToCoverageState
        {
            get => (MTL4AlphaToCoverageState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_alphaToCoverageState);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaToCoverageState, (long)value);
        }

        public MTL4AlphaToOneState AlphaToOneState
        {
            get => (MTL4AlphaToOneState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_alphaToOneState);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAlphaToOneState, (long)value);
        }

        public MTL4LogicalToPhysicalColorAttachmentMappingState ColorAttachmentMappingState
        {
            get => (MTL4LogicalToPhysicalColorAttachmentMappingState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_colorAttachmentMappingState);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorAttachmentMappingState, (long)value);
        }

        public MTL4RenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public MTL4FunctionDescriptor FragmentFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentFunctionDescriptor, value);
        }

        public MTL4StaticLinkingDescriptor FragmentStaticLinkingDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentStaticLinkingDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentStaticLinkingDescriptor, value);
        }

        public MTLPrimitiveTopologyClass InputPrimitiveTopology
        {
            get => (MTLPrimitiveTopologyClass)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_inputPrimitiveTopology);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputPrimitiveTopology, (ulong)value);
        }

        public bool IsRasterizationEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRasterizationEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationEnabled, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong MaxVertexAmplificationCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexAmplificationCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexAmplificationCount, value);
        }

        public MTL4PipelineOptions Options
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_options));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, value);
        }

        [System.Obsolete]
        public bool RasterizationEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isRasterizationEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterizationEnabled, value);
        }

        public ulong RasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterSampleCount, value);
        }

        public bool SupportFragmentBinaryLinking
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportFragmentBinaryLinking);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportFragmentBinaryLinking, value);
        }

        public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
        {
            get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, (long)value);
        }

        public bool SupportVertexBinaryLinking
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportVertexBinaryLinking);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportVertexBinaryLinking, value);
        }

        public MTLVertexDescriptor VertexDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexDescriptor, value);
        }

        public MTL4FunctionDescriptor VertexFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexFunctionDescriptor, value);
        }

        public MTL4StaticLinkingDescriptor VertexStaticLinkingDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexStaticLinkingDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexStaticLinkingDescriptor, value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_alphaToCoverageState = "alphaToCoverageState";
        private static readonly Selector sel_alphaToOneState = "alphaToOneState";
        private static readonly Selector sel_colorAttachmentMappingState = "colorAttachmentMappingState";
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_fragmentFunctionDescriptor = "fragmentFunctionDescriptor";
        private static readonly Selector sel_fragmentStaticLinkingDescriptor = "fragmentStaticLinkingDescriptor";
        private static readonly Selector sel_inputPrimitiveTopology = "inputPrimitiveTopology";
        private static readonly Selector sel_isRasterizationEnabled = "isRasterizationEnabled";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxVertexAmplificationCount = "maxVertexAmplificationCount";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_rasterSampleCount = "rasterSampleCount";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setAlphaToCoverageState = "setAlphaToCoverageState:";
        private static readonly Selector sel_setAlphaToOneState = "setAlphaToOneState:";
        private static readonly Selector sel_setColorAttachmentMappingState = "setColorAttachmentMappingState:";
        private static readonly Selector sel_setFragmentFunctionDescriptor = "setFragmentFunctionDescriptor:";
        private static readonly Selector sel_setFragmentStaticLinkingDescriptor = "setFragmentStaticLinkingDescriptor:";
        private static readonly Selector sel_setInputPrimitiveTopology = "setInputPrimitiveTopology:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_setRasterizationEnabled = "setRasterizationEnabled:";
        private static readonly Selector sel_setRasterSampleCount = "setRasterSampleCount:";
        private static readonly Selector sel_setSupportFragmentBinaryLinking = "setSupportFragmentBinaryLinking:";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_setSupportVertexBinaryLinking = "setSupportVertexBinaryLinking:";
        private static readonly Selector sel_setVertexDescriptor = "setVertexDescriptor:";
        private static readonly Selector sel_setVertexFunctionDescriptor = "setVertexFunctionDescriptor:";
        private static readonly Selector sel_setVertexStaticLinkingDescriptor = "setVertexStaticLinkingDescriptor:";
        private static readonly Selector sel_supportFragmentBinaryLinking = "supportFragmentBinaryLinking";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_supportVertexBinaryLinking = "supportVertexBinaryLinking";
        private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        private static readonly Selector sel_vertexFunctionDescriptor = "vertexFunctionDescriptor";
        private static readonly Selector sel_vertexStaticLinkingDescriptor = "vertexStaticLinkingDescriptor";
        private static readonly Selector sel_release = "release";
    }
}
