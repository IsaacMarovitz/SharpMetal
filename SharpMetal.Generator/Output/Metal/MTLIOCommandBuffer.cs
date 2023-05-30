using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLIOStatus: long
    {
        Pending = 0,
        Cancelled = 1,
        Error = 2,
        Complete = 3,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOCommandBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOCommandBuffer obj) => obj.NativePtr;
        public MTLIOCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLIOStatus Status => (MTLIOStatus)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_status);
        public NSError Error => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error));

        private static readonly Selector sel_addCompletedHandler = "addCompletedHandler:";
        private static readonly Selector sel_loadBytessizesourceHandlesourceHandleOffset = "loadBytes:size:sourceHandle:sourceHandleOffset:";
        private static readonly Selector sel_loadBufferoffsetsizesourceHandlesourceHandleOffset = "loadBuffer:offset:size:sourceHandle:sourceHandleOffset:";
        private static readonly Selector sel_loadTextureslicelevelsizesourceBytesPerRowsourceBytesPerImagedestinationOriginsourceHandlesourceHandleOffset = "loadTexture:slice:level:size:sourceBytesPerRow:sourceBytesPerImage:destinationOrigin:sourceHandle:sourceHandleOffset:";
        private static readonly Selector sel_copyStatusToBufferoffset = "copyStatusToBuffer:offset:";
        private static readonly Selector sel_commit = "commit";
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        private static readonly Selector sel_tryCancel = "tryCancel";
        private static readonly Selector sel_addBarrier = "addBarrier";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_enqueue = "enqueue";
        private static readonly Selector sel_waitForEventvalue = "waitForEvent:value:";
        private static readonly Selector sel_signalEventvalue = "signalEvent:value:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_status = "status";
        private static readonly Selector sel_error = "error";
    }
}
