using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4ComputePipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ComputePipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4ComputePipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4ComputePipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4ComputePipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4ComputePipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4FunctionDescriptor ComputeFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setComputeFunctionDescriptor, value);
        }

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

        public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
        {
            get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, (long)value);
        }

        public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadGroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        private static readonly Selector sel_computeFunctionDescriptor = "computeFunctionDescriptor";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_requiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setComputeFunctionDescriptor = "setComputeFunctionDescriptor:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_setRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";
        private static readonly Selector sel_setStaticLinkingDescriptor = "setStaticLinkingDescriptor:";
        private static readonly Selector sel_setSupportBinaryLinking = "setSupportBinaryLinking:";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth = "setThreadGroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_staticLinkingDescriptor = "staticLinkingDescriptor";
        private static readonly Selector sel_supportBinaryLinking = "supportBinaryLinking";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_threadGroupSizeIsMultipleOfThreadExecutionWidth = "threadGroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_release = "release";
    }
}
