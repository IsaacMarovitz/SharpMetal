using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLIOStatus : long
    {
        Pending = 0,
        Cancelled = 1,
        Error = 2,
        Complete = 3,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOCommandBuffer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOCommandBuffer obj) => obj.NativePtr;
        public MTLIOCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLIOStatus Status => (MTLIOStatus)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_status);

        public NSError Error => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error));

        public void LoadBytes(IntPtr pointer, ulong size, IntPtr sourceHandle, ulong sourceHandleOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_loadBytessizesourceHandlesourceHandleOffset, pointer, size, sourceHandle, sourceHandleOffset);
        }

        public void LoadBuffer(MTLBuffer buffer, ulong offset, ulong size, IntPtr sourceHandle, ulong sourceHandleOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_loadBufferoffsetsizesourceHandlesourceHandleOffset, buffer, offset, size, sourceHandle, sourceHandleOffset);
        }

        public void LoadTexture(MTLTexture texture, ulong slice, ulong level, MTLSize size, ulong sourceBytesPerRow, ulong sourceBytesPerImage, MTLOrigin destinationOrigin, IntPtr sourceHandle, ulong sourceHandleOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_loadTextureslicelevelsizesourceBytesPerRowsourceBytesPerImagedestinationOriginsourceHandlesourceHandleOffset, texture, slice, level, size, sourceBytesPerRow, sourceBytesPerImage, destinationOrigin, sourceHandle, sourceHandleOffset);
        }

        public void CopyStatusToBuffer(MTLBuffer buffer, ulong offset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyStatusToBufferoffset, buffer, offset);
        }

        public void Commit()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_commit);
        }

        public void WaitUntilCompleted()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilCompleted);
        }

        public void TryCancel()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_tryCancel);
        }

        public void AddBarrier()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addBarrier);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void Enqueue()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_enqueue);
        }

        public void Wait(MTLSharedEvent mtlEvent, ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForEventvalue, mtlEvent, value);
        }

        public void SignalEvent(MTLSharedEvent mtlEvent, ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_signalEventvalue, mtlEvent, value);
        }

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
        private static readonly Selector sel_release = "release";
    }
}
