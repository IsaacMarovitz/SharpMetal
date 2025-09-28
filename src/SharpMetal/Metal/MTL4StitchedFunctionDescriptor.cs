using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4StitchedFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4StitchedFunctionDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4FunctionDescriptor(MTL4StitchedFunctionDescriptor obj) => new(obj.NativePtr);
        public MTL4StitchedFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4StitchedFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4StitchedFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray FunctionDescriptors
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionDescriptors));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionDescriptors, value);
        }

        public MTLFunctionStitchingGraph FunctionGraph
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionGraph));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionGraph, value);
        }

        private static readonly Selector sel_functionDescriptors = "functionDescriptors";
        private static readonly Selector sel_functionGraph = "functionGraph";
        private static readonly Selector sel_setFunctionDescriptors = "setFunctionDescriptors:";
        private static readonly Selector sel_setFunctionGraph = "setFunctionGraph:";
        private static readonly Selector sel_release = "release";
    }
}
