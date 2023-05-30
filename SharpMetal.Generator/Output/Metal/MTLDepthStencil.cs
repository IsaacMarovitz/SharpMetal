using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLCompareFunction: ulong
    {
        Never = 0,
        Less = 1,
        Equal = 2,
        LessEqual = 3,
        Greater = 4,
        NotEqual = 5,
        GreaterEqual = 6,
        Always = 7,
    }

    public enum MTLStencilOperation: ulong
    {
        Keep = 0,
        Zero = 1,
        Replace = 2,
        IncrementClamp = 3,
        DecrementClamp = 4,
        Invert = 5,
        IncrementWrap = 6,
        DecrementWrap = 7,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLStencilDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStencilDescriptor obj) => obj.NativePtr;
        public MTLStencilDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLStencilDescriptor()
        {
            var cls = new ObjectiveCClass("MTLStencilDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCompareFunction StencilCompareFunction => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilCompareFunction);
        public MTLStencilOperation StencilFailureOperation => (MTLStencilOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilFailureOperation);
        public MTLStencilOperation DepthFailureOperation => (MTLStencilOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthFailureOperation);
        public MTLStencilOperation DepthStencilPassOperation => (MTLStencilOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthStencilPassOperation);
        public uint ReadMask => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_readMask);
        public uint WriteMask => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_writeMask);

        private static readonly Selector sel_stencilCompareFunction = "stencilCompareFunction";
        private static readonly Selector sel_setStencilCompareFunction = "setStencilCompareFunction:";
        private static readonly Selector sel_stencilFailureOperation = "stencilFailureOperation";
        private static readonly Selector sel_setStencilFailureOperation = "setStencilFailureOperation:";
        private static readonly Selector sel_depthFailureOperation = "depthFailureOperation";
        private static readonly Selector sel_setDepthFailureOperation = "setDepthFailureOperation:";
        private static readonly Selector sel_depthStencilPassOperation = "depthStencilPassOperation";
        private static readonly Selector sel_setDepthStencilPassOperation = "setDepthStencilPassOperation:";
        private static readonly Selector sel_readMask = "readMask";
        private static readonly Selector sel_setReadMask = "setReadMask:";
        private static readonly Selector sel_writeMask = "writeMask";
        private static readonly Selector sel_setWriteMask = "setWriteMask:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLDepthStencilDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDepthStencilDescriptor obj) => obj.NativePtr;
        public MTLDepthStencilDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLDepthStencilDescriptor()
        {
            var cls = new ObjectiveCClass("MTLDepthStencilDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCompareFunction DepthCompareFunction => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthCompareFunction);
        public bool DepthWriteEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthWriteEnabled);
        public MTLStencilDescriptor FrontFaceStencil => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_frontFaceStencil));
        public MTLStencilDescriptor BackFaceStencil => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_backFaceStencil));
        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_depthCompareFunction = "depthCompareFunction";
        private static readonly Selector sel_setDepthCompareFunction = "setDepthCompareFunction:";
        private static readonly Selector sel_isDepthWriteEnabled = "isDepthWriteEnabled";
        private static readonly Selector sel_setDepthWriteEnabled = "setDepthWriteEnabled:";
        private static readonly Selector sel_frontFaceStencil = "frontFaceStencil";
        private static readonly Selector sel_setFrontFaceStencil = "setFrontFaceStencil:";
        private static readonly Selector sel_backFaceStencil = "backFaceStencil";
        private static readonly Selector sel_setBackFaceStencil = "setBackFaceStencil:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLDepthStencilState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDepthStencilState obj) => obj.NativePtr;
        public MTLDepthStencilState(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_device = "device";
    }
}
