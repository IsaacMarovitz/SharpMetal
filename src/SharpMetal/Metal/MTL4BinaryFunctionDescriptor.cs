using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4BinaryFunctionOptions : ulong
    {
        None = 0,
        PipelineIndependent = 1 << 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4BinaryFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4BinaryFunctionDescriptor obj) => obj.NativePtr;
        public MTL4BinaryFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4BinaryFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4BinaryFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4FunctionDescriptor FunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionDescriptor, value);
        }

        public NSString Name
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setName, value);
        }

        public MTL4BinaryFunctionOptions Options
        {
            get => (MTL4BinaryFunctionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_options);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, (ulong)value);
        }

        private static readonly Selector sel_functionDescriptor = "functionDescriptor";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_setFunctionDescriptor = "setFunctionDescriptor:";
        private static readonly Selector sel_setName = "setName:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_release = "release";
    }
}
