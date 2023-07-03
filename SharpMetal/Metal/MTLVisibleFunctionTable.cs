using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLVisibleFunctionTableDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVisibleFunctionTableDescriptor obj) => obj.NativePtr;
        public MTLVisibleFunctionTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVisibleFunctionTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVisibleFunctionTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong FunctionCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionCount, value);
        }

        public void SetFunctionCount(ulong functionCount)
        {
            objc_msgSend(NativePtr, , functionCount);
        }

        private static readonly Selector sel_visibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
        private static readonly Selector sel_functionCount = "functionCount";
        private static readonly Selector sel_setFunctionCount = "setFunctionCount:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLVisibleFunctionTable
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVisibleFunctionTable obj) => obj.NativePtr;
        public MTLVisibleFunctionTable(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        public void SetFunction(MTLFunctionHandle function, ulong index)
        {
            objc_msgSend(NativePtr, , function, index);
        }

        public void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
        {
            objc_msgSend(NativePtr, , functions, range);
        }

        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
    }
}
