using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4MachineLearningPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MachineLearningPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4MachineLearningPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4MachineLearningPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4MachineLearningPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4MachineLearningPipelineDescriptor");
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

        public MTL4FunctionDescriptor MachineLearningFunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_machineLearningFunctionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMachineLearningFunctionDescriptor, value);
        }

        public MTL4PipelineOptions Options
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_options));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, value);
        }

        public MTLTensorExtents InputDimensionsAtBufferIndex(long bufferIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_inputDimensionsAtBufferIndex, bufferIndex));
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        public void SetInputDimensions(MTLTensorExtents dimensions, long bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputDimensionsatBufferIndex, dimensions, bufferIndex);
        }

        public void SetInputDimensions(NSArray dimensions, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInputDimensionswithRange, dimensions, range);
        }

        private static readonly Selector sel_inputDimensionsAtBufferIndex = "inputDimensionsAtBufferIndex:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_machineLearningFunctionDescriptor = "machineLearningFunctionDescriptor";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_setInputDimensionsatBufferIndex = "setInputDimensions:atBufferIndex:";
        private static readonly Selector sel_setInputDimensionswithRange = "setInputDimensions:withRange:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMachineLearningFunctionDescriptor = "setMachineLearningFunctionDescriptor:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4MachineLearningPipelineReflection : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MachineLearningPipelineReflection obj) => obj.NativePtr;
        public MTL4MachineLearningPipelineReflection(IntPtr ptr) => NativePtr = ptr;

        public MTL4MachineLearningPipelineReflection()
        {
            var cls = new ObjectiveCClass("MTL4MachineLearningPipelineReflection");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray Bindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bindings));

        private static readonly Selector sel_bindings = "bindings";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4MachineLearningPipelineState : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MachineLearningPipelineState obj) => obj.NativePtr;
        public static implicit operator MTLAllocation(MTL4MachineLearningPipelineState obj) => new(obj.NativePtr);
        public MTL4MachineLearningPipelineState(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public ulong IntermediatesHeapSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_intermediatesHeapSize);

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public MTL4MachineLearningPipelineReflection Reflection => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_reflection));

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_intermediatesHeapSize = "intermediatesHeapSize";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_reflection = "reflection";
        private static readonly Selector sel_release = "release";
    }
}
