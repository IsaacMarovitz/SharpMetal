using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4MeshRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MeshRenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4MeshRenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4MeshRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4MeshRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4MeshRenderPipelineDescriptor");
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

        public ulong MaxTotalThreadgroupsPerMeshGrid
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadgroupsPerMeshGrid);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadgroupsPerMeshGrid, value);
        }

        public ulong MaxTotalThreadsPerMeshThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerMeshThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerMeshThreadgroup, value);
        }

        public ulong MaxTotalThreadsPerObjectThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerObjectThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerObjectThreadgroup, value);
        }

        public ulong MaxVertexAmplificationCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexAmplificationCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexAmplificationCount, value);
        }

        public MTL4FunctionDescriptor MeshFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshFunctionDescriptor, value);
        }

        public MTL4StaticLinkingDescriptor MeshStaticLinkingDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshStaticLinkingDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshStaticLinkingDescriptor, value);
        }

        public bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_meshThreadgroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public MTL4FunctionDescriptor ObjectFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectFunctionDescriptor, value);
        }

        public MTL4StaticLinkingDescriptor ObjectStaticLinkingDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectStaticLinkingDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectStaticLinkingDescriptor, value);
        }

        public bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_objectThreadgroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public MTL4PipelineOptions Options
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_options));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, value);
        }

        public ulong PayloadMemoryLength
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_payloadMemoryLength);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPayloadMemoryLength, value);
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

        public MTLSize RequiredThreadsPerMeshThreadgroup
        {
            get => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_requiredThreadsPerMeshThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRequiredThreadsPerMeshThreadgroup, value);
        }

        public MTLSize RequiredThreadsPerObjectThreadgroup
        {
            get => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_requiredThreadsPerObjectThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRequiredThreadsPerObjectThreadgroup, value);
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

        public bool SupportMeshBinaryLinking
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportMeshBinaryLinking);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportMeshBinaryLinking, value);
        }

        public bool SupportObjectBinaryLinking
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportObjectBinaryLinking);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportObjectBinaryLinking, value);
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
        private static readonly Selector sel_isRasterizationEnabled = "isRasterizationEnabled";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxTotalThreadgroupsPerMeshGrid = "maxTotalThreadgroupsPerMeshGrid";
        private static readonly Selector sel_maxTotalThreadsPerMeshThreadgroup = "maxTotalThreadsPerMeshThreadgroup";
        private static readonly Selector sel_maxTotalThreadsPerObjectThreadgroup = "maxTotalThreadsPerObjectThreadgroup";
        private static readonly Selector sel_maxVertexAmplificationCount = "maxVertexAmplificationCount";
        private static readonly Selector sel_meshFunctionDescriptor = "meshFunctionDescriptor";
        private static readonly Selector sel_meshStaticLinkingDescriptor = "meshStaticLinkingDescriptor";
        private static readonly Selector sel_meshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "meshThreadgroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_objectFunctionDescriptor = "objectFunctionDescriptor";
        private static readonly Selector sel_objectStaticLinkingDescriptor = "objectStaticLinkingDescriptor";
        private static readonly Selector sel_objectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "objectThreadgroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_payloadMemoryLength = "payloadMemoryLength";
        private static readonly Selector sel_rasterSampleCount = "rasterSampleCount";
        private static readonly Selector sel_requiredThreadsPerMeshThreadgroup = "requiredThreadsPerMeshThreadgroup";
        private static readonly Selector sel_requiredThreadsPerObjectThreadgroup = "requiredThreadsPerObjectThreadgroup";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setAlphaToCoverageState = "setAlphaToCoverageState:";
        private static readonly Selector sel_setAlphaToOneState = "setAlphaToOneState:";
        private static readonly Selector sel_setColorAttachmentMappingState = "setColorAttachmentMappingState:";
        private static readonly Selector sel_setFragmentFunctionDescriptor = "setFragmentFunctionDescriptor:";
        private static readonly Selector sel_setFragmentStaticLinkingDescriptor = "setFragmentStaticLinkingDescriptor:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMaxTotalThreadgroupsPerMeshGrid = "setMaxTotalThreadgroupsPerMeshGrid:";
        private static readonly Selector sel_setMaxTotalThreadsPerMeshThreadgroup = "setMaxTotalThreadsPerMeshThreadgroup:";
        private static readonly Selector sel_setMaxTotalThreadsPerObjectThreadgroup = "setMaxTotalThreadsPerObjectThreadgroup:";
        private static readonly Selector sel_setMaxVertexAmplificationCount = "setMaxVertexAmplificationCount:";
        private static readonly Selector sel_setMeshFunctionDescriptor = "setMeshFunctionDescriptor:";
        private static readonly Selector sel_setMeshStaticLinkingDescriptor = "setMeshStaticLinkingDescriptor:";
        private static readonly Selector sel_setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setMeshThreadgroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_setObjectFunctionDescriptor = "setObjectFunctionDescriptor:";
        private static readonly Selector sel_setObjectStaticLinkingDescriptor = "setObjectStaticLinkingDescriptor:";
        private static readonly Selector sel_setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth = "setObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_setPayloadMemoryLength = "setPayloadMemoryLength:";
        private static readonly Selector sel_setRasterizationEnabled = "setRasterizationEnabled:";
        private static readonly Selector sel_setRasterSampleCount = "setRasterSampleCount:";
        private static readonly Selector sel_setRequiredThreadsPerMeshThreadgroup = "setRequiredThreadsPerMeshThreadgroup:";
        private static readonly Selector sel_setRequiredThreadsPerObjectThreadgroup = "setRequiredThreadsPerObjectThreadgroup:";
        private static readonly Selector sel_setSupportFragmentBinaryLinking = "setSupportFragmentBinaryLinking:";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_setSupportMeshBinaryLinking = "setSupportMeshBinaryLinking:";
        private static readonly Selector sel_setSupportObjectBinaryLinking = "setSupportObjectBinaryLinking:";
        private static readonly Selector sel_supportFragmentBinaryLinking = "supportFragmentBinaryLinking";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_supportMeshBinaryLinking = "supportMeshBinaryLinking";
        private static readonly Selector sel_supportObjectBinaryLinking = "supportObjectBinaryLinking";
        private static readonly Selector sel_release = "release";
    }
}
