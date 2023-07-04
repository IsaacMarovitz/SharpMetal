using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLCompareFunction : ulong
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

    public enum MTLStencilOperation : ulong
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
    public partial class MTLStencilDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStencilDescriptor obj) => obj.NativePtr;
        public MTLStencilDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLStencilDescriptor()
        {
            var cls = new ObjectiveCClass("MTLStencilDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCompareFunction StencilCompareFunction
        {
            get => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilCompareFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilCompareFunction, (ulong)value);
        }

        public MTLStencilOperation StencilFailureOperation
        {
            get => (MTLStencilOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilFailureOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilFailureOperation, (ulong)value);
        }

        public MTLStencilOperation DepthFailureOperation
        {
            get => (MTLStencilOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthFailureOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthFailureOperation, (ulong)value);
        }

        public MTLStencilOperation DepthStencilPassOperation
        {
            get => (MTLStencilOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthStencilPassOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStencilPassOperation, (ulong)value);
        }

        public uint ReadMask
        {
            get => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_readMask);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReadMask, value);
        }

        public uint WriteMask
        {
            get => ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_writeMask);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWriteMask, value);
        }

        public void SetStencilCompareFunction(MTLCompareFunction stencilCompareFunction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilCompareFunction, (ulong)stencilCompareFunction);
        }

        public void SetStencilFailureOperation(MTLStencilOperation stencilFailureOperation)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilFailureOperation, (ulong)stencilFailureOperation);
        }

        public void SetDepthFailureOperation(MTLStencilOperation depthFailureOperation)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthFailureOperation, (ulong)depthFailureOperation);
        }

        public void SetDepthStencilPassOperation(MTLStencilOperation depthStencilPassOperation)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStencilPassOperation, (ulong)depthStencilPassOperation);
        }

        public void SetReadMask(uint readMask)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReadMask, readMask);
        }

        public void SetWriteMask(uint writeMask)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setWriteMask, writeMask);
        }

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
    public partial class MTLDepthStencilDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDepthStencilDescriptor obj) => obj.NativePtr;
        public MTLDepthStencilDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLDepthStencilDescriptor()
        {
            var cls = new ObjectiveCClass("MTLDepthStencilDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCompareFunction DepthCompareFunction
        {
            get => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthCompareFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthCompareFunction, (ulong)value);
        }

        public bool DepthWriteEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isDepthWriteEnabled);

        public MTLStencilDescriptor FrontFaceStencil
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_frontFaceStencil));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFrontFaceStencil, value);
        }

        public MTLStencilDescriptor BackFaceStencil
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_backFaceStencil));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBackFaceStencil, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void SetDepthCompareFunction(MTLCompareFunction depthCompareFunction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthCompareFunction, (ulong)depthCompareFunction);
        }

        public void SetDepthWriteEnabled(bool depthWriteEnabled)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthWriteEnabled, depthWriteEnabled);
        }

        public void SetFrontFaceStencil(MTLStencilDescriptor frontFaceStencil)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFrontFaceStencil, frontFaceStencil);
        }

        public void SetBackFaceStencil(MTLStencilDescriptor backFaceStencil)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBackFaceStencil, backFaceStencil);
        }

        public void SetLabel(NSString label)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, label);
        }

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
    public partial class MTLDepthStencilState
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
