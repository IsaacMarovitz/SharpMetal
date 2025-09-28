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

        // missing NSString Label

        // missing MTL4FunctionDescriptor MachineLearningFunctionDescriptor

        // missing MTL4PipelineOptions Options
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

        // missing NSArray Bindings
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

        // missing MTLDevice Device

        // missing ulong IntermediatesHeapSize

        // missing NSString Label

        // missing MTL4MachineLearningPipelineReflection Reflection

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_release = "release";
    }
}
