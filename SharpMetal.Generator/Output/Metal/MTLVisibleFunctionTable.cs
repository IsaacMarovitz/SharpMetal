using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLVisibleFunctionTableDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVisibleFunctionTableDescriptor obj) => obj.NativePtr;
        public MTLVisibleFunctionTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVisibleFunctionTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVisibleFunctionTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_visibleFunctionTableDescriptor));
        public ulong FunctionCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionCount);

        private static readonly Selector sel_visibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
        private static readonly Selector sel_functionCount = "functionCount";
        private static readonly Selector sel_setFunctionCount = "setFunctionCount:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVisibleFunctionTable
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVisibleFunctionTable obj) => obj.NativePtr;
        public MTLVisibleFunctionTable(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
    }
}
