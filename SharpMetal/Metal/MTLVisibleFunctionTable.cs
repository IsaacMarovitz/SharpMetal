using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
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
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionCount, functionCount);
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
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionatIndex, function, index);
        }

        public void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
    }
}
