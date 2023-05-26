using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLCommandBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLCommandBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public bool RetainedReferences
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRetainedReferences, value);
        }

        public MTLCommandBufferErrorOption ErrorOptions
        {
            get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setErrorOptions, (ulong)value);
        }

        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_setRetainedReferences = "setRetainedReferences:";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_setErrorOptions = "setErrorOptions:";
    }
}