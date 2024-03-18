using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLParallelRenderCommandEncoder : MTLCommandEncoder
    {
        public static implicit operator IntPtr(MTLParallelRenderCommandEncoder obj) => obj.NativePtr;
        public MTLParallelRenderCommandEncoder(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        public MTLRenderCommandEncoder RenderCommandEncoder => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoder));

        public void SetColorStoreAction(MTLStoreAction storeAction, ulong colorAttachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorStoreActionatIndex, (ulong)storeAction, colorAttachmentIndex);
        }

        public void SetDepthStoreAction(MTLStoreAction storeAction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStoreAction, (ulong)storeAction);
        }

        public void SetStencilStoreAction(MTLStoreAction storeAction)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilStoreAction, (ulong)storeAction);
        }

        public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, ulong colorAttachmentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorStoreActionOptionsatIndex, (ulong)storeActionOptions, colorAttachmentIndex);
        }

        public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStoreActionOptions, (ulong)storeActionOptions);
        }

        public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilStoreActionOptions, (ulong)storeActionOptions);
        }

        private static readonly Selector sel_renderCommandEncoder = "renderCommandEncoder";
        private static readonly Selector sel_setColorStoreActionatIndex = "setColorStoreAction:atIndex:";
        private static readonly Selector sel_setDepthStoreAction = "setDepthStoreAction:";
        private static readonly Selector sel_setStencilStoreAction = "setStencilStoreAction:";
        private static readonly Selector sel_setColorStoreActionOptionsatIndex = "setColorStoreActionOptions:atIndex:";
        private static readonly Selector sel_setDepthStoreActionOptions = "setDepthStoreActionOptions:";
        private static readonly Selector sel_setStencilStoreActionOptions = "setStencilStoreActionOptions:";
    }
}
