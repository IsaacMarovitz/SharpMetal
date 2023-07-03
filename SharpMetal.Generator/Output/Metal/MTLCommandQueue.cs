using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLCommandQueue
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandQueue obj) => obj.NativePtr;
        public MTLCommandQueue(IntPtr ptr) => NativePtr = ptr;

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLCommandBuffer CommandBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBuffer));

        public MTLCommandBuffer CommandBufferWithUnretainedReferences => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBufferWithUnretainedReferences));

        public void SetLabel(NSString label) {

        }

        public MTLCommandBuffer CommandBuffer(MTLCommandBufferDescriptor descriptor) {

        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_commandBufferWithDescriptor = "commandBufferWithDescriptor:";
        private static readonly Selector sel_commandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";
        private static readonly Selector sel_insertDebugCaptureBoundary = "insertDebugCaptureBoundary";
    }
}
