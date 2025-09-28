using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4VisibilityOptions : ulong
    {
        None = 0,
        Device = 1,
        ResourceAlias = 1 << 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandEncoder obj) => obj.NativePtr;
        public MTL4CommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4CommandBuffer CommandBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBuffer));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterEncoderStagesbeforeEncoderStagesvisibilityOptions, (ulong)afterEncoderStages, (ulong)beforeEncoderStages, (ulong)visibilityOptions);
        }

        public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterQueueStagesbeforeStagesvisibilityOptions, (ulong)afterQueueStages, (ulong)beforeStages, (ulong)visibilityOptions);
        }

        public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterStagesbeforeQueueStagesvisibilityOptions, (ulong)afterStages, (ulong)beforeQueueStages, (ulong)visibilityOptions);
        }

        public void EndEncoding()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endEncoding);
        }

        public void InsertDebugSignpost(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_insertDebugSignpost, nsString);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFenceafterEncoderStages, fence, (ulong)afterEncoderStages);
        }

        public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFencebeforeEncoderStages, fence, (ulong)beforeEncoderStages);
        }

        private static readonly Selector sel_barrierAfterEncoderStagesbeforeEncoderStagesvisibilityOptions = "barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:";
        private static readonly Selector sel_barrierAfterQueueStagesbeforeStagesvisibilityOptions = "barrierAfterQueueStages:beforeStages:visibilityOptions:";
        private static readonly Selector sel_barrierAfterStagesbeforeQueueStagesvisibilityOptions = "barrierAfterStages:beforeQueueStages:visibilityOptions:";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_insertDebugSignpost = "insertDebugSignpost:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_updateFenceafterEncoderStages = "updateFence:afterEncoderStages:";
        private static readonly Selector sel_waitForFencebeforeEncoderStages = "waitForFence:beforeEncoderStages:";
        private static readonly Selector sel_release = "release";
    }
}
