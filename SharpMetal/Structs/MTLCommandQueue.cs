using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLCommandQueue
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandQueue mtlCommandQueue) => mtlCommandQueue.NativePtr;
        public MTLCommandQueue(IntPtr ptr) => NativePtr = ptr;

        public MTLCommandBuffer CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
        {
            return new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBufferWithDescriptor));
        }

        public MTLCommandBuffer CommandBuffer()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBuffer));
        }

        public MTLCommandBuffer CommandBufferWithUnretainedReferences()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBufferWithUnretainedReferences));
        }

        public MTLDevice Device => new (ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_label);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        private static readonly Selector sel_commandBufferWithDescriptor = "commandBufferWithDescriptor:";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_commandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }
}