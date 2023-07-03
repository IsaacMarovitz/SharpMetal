using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLParallelRenderCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLParallelRenderCommandEncoder obj) => obj.NativePtr;
        public MTLParallelRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderCommandEncoder RenderCommandEncoder => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoder));

        public void SetColorStoreAction(MTLStoreAction storeAction, ulong colorAttachmentIndex) {

        }

        public void SetDepthStoreAction(MTLStoreAction storeAction) {

        }

        public void SetStencilStoreAction(MTLStoreAction storeAction) {

        }

        public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, ulong colorAttachmentIndex) {

        }

        public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions) {

        }

        public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions) {

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
