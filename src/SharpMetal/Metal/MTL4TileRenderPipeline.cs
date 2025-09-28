using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4TileRenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4TileRenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4TileRenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4TileRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4TileRenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4TileRenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorAttachments));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong MaxTotalThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerThreadgroup, value);
        }

        public MTL4PipelineOptions Options
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_options));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, value);
        }

        public ulong RasterSampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rasterSampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRasterSampleCount, value);
        }

        public MTLSize RequiredThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_requiredThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRequiredThreadsPerThreadgroup, value);
        }

        public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_staticLinkingDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStaticLinkingDescriptor, value);
        }

        public bool SupportBinaryLinking
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportBinaryLinking);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportBinaryLinking, value);
        }

        public bool ThreadgroupSizeMatchesTileSize
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadgroupSizeMatchesTileSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadgroupSizeMatchesTileSize, value);
        }

        public MTL4FunctionDescriptor TileFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTileFunctionDescriptor, value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_colorAttachments = "colorAttachments";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_rasterSampleCount = "rasterSampleCount";
        private static readonly Selector sel_requiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_setRasterSampleCount = "setRasterSampleCount:";
        private static readonly Selector sel_setRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";
        private static readonly Selector sel_setStaticLinkingDescriptor = "setStaticLinkingDescriptor:";
        private static readonly Selector sel_setSupportBinaryLinking = "setSupportBinaryLinking:";
        private static readonly Selector sel_setThreadgroupSizeMatchesTileSize = "setThreadgroupSizeMatchesTileSize:";
        private static readonly Selector sel_setTileFunctionDescriptor = "setTileFunctionDescriptor:";
        private static readonly Selector sel_staticLinkingDescriptor = "staticLinkingDescriptor";
        private static readonly Selector sel_supportBinaryLinking = "supportBinaryLinking";
        private static readonly Selector sel_threadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";
        private static readonly Selector sel_tileFunctionDescriptor = "tileFunctionDescriptor";
        private static readonly Selector sel_release = "release";
    }
}
