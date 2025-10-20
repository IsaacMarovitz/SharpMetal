using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4CommandQueueError : long
    {
        None = 0,
        Timeout = 1,
        NotPermitted = 2,
        OutOfMemory = 3,
        DeviceRemoved = 4,
        AccessRevoked = 5,
        Internal = 6,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4CopySparseBufferMappingOperation
    {
        public NSRange sourceRange;
        public ulong destinationOffset;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4CopySparseTextureMappingOperation
    {
        public MTLRegion sourceRegion;
        public ulong sourceLevel;
        public ulong sourceSlice;
        public MTLOrigin destinationOrigin;
        public ulong destinationLevel;
        public ulong destinationSlice;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4UpdateSparseBufferMappingOperation
    {
        public MTLSparseTextureMappingMode mode;
        public NSRange bufferRange;
        public ulong heapOffset;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4UpdateSparseTextureMappingOperation
    {
        public MTLSparseTextureMappingMode mode;
        public MTLRegion textureRegion;
        public ulong textureLevel;
        public ulong textureSlice;
        public ulong heapOffset;
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandQueue : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandQueue obj) => obj.NativePtr;
        public MTL4CommandQueue(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public void AddResidencySet(MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addResidencySet, residencySet);
        }

        public void AddResidencySets(MTLResidencySet[] residencySets, ulong count)
        {
            throw new NotImplementedException();
        }

        public void Commit(MTL4CommandBuffer[] commandBuffers, ulong count)
        {
            throw new NotImplementedException();
        }

        public void Commit(MTL4CommandBuffer[] commandBuffers, ulong count, MTL4CommitOptions options)
        {
            throw new NotImplementedException();
        }

        public void CopyBufferMappingsFromBuffer(MTLBuffer sourceBuffer, MTLBuffer destinationBuffer, MTL4CopySparseBufferMappingOperation operations, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyBufferMappingsFromBuffertoBufferoperationscount, sourceBuffer, destinationBuffer, operations, count);
        }

        public void CopyTextureMappingsFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture, MTL4CopySparseTextureMappingOperation operations, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyTextureMappingsFromTexturetoTextureoperationscount, sourceTexture, destinationTexture, operations, count);
        }

        public void RemoveResidencySet(MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_removeResidencySet, residencySet);
        }

        public void RemoveResidencySets(MTLResidencySet[] residencySets, ulong count)
        {
            throw new NotImplementedException();
        }

        public void SignalDrawable(MTLDrawable drawable)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_signalDrawable, drawable);
        }

        public void SignalEvent(MTLEvent mtlEvent, ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_signalEventvalue, mtlEvent, value);
        }

        public void UpdateBufferMappings(MTLBuffer buffer, MTLHeap heap, MTL4UpdateSparseBufferMappingOperation operations, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateBufferMappingsheapoperationscount, buffer, heap, operations, count);
        }

        public void UpdateTextureMappings(MTLTexture texture, MTLHeap heap, MTL4UpdateSparseTextureMappingOperation operations, ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateTextureMappingsheapoperationscount, texture, heap, operations, count);
        }

        public void Wait(MTLEvent mtlEvent, ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForEventvalue, mtlEvent, value);
        }

        public void Wait(MTLDrawable drawable)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForDrawable, drawable);
        }

        private static readonly Selector sel_addResidencySet = "addResidencySet:";
        private static readonly Selector sel_addResidencySetscount = "addResidencySets:count:";
        private static readonly Selector sel_commitcount = "commit:count:";
        private static readonly Selector sel_commitcountoptions = "commit:count:options:";
        private static readonly Selector sel_copyBufferMappingsFromBuffertoBufferoperationscount = "copyBufferMappingsFromBuffer:toBuffer:operations:count:";
        private static readonly Selector sel_copyTextureMappingsFromTexturetoTextureoperationscount = "copyTextureMappingsFromTexture:toTexture:operations:count:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_removeResidencySet = "removeResidencySet:";
        private static readonly Selector sel_removeResidencySetscount = "removeResidencySets:count:";
        private static readonly Selector sel_signalDrawable = "signalDrawable:";
        private static readonly Selector sel_signalEventvalue = "signalEvent:value:";
        private static readonly Selector sel_updateBufferMappingsheapoperationscount = "updateBufferMappings:heap:operations:count:";
        private static readonly Selector sel_updateTextureMappingsheapoperationscount = "updateTextureMappings:heap:operations:count:";
        private static readonly Selector sel_waitForDrawable = "waitForDrawable:";
        private static readonly Selector sel_waitForEventvalue = "waitForEvent:value:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandQueueDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandQueueDescriptor obj) => obj.NativePtr;
        public MTL4CommandQueueDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommandQueueDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4CommandQueueDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public IntPtr FeedbackQueue
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_feedbackQueue));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFeedbackQueue, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        private static readonly Selector sel_feedbackQueue = "feedbackQueue";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setFeedbackQueue = "setFeedbackQueue:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommitOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommitOptions obj) => obj.NativePtr;
        public MTL4CommitOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommitOptions()
        {
            var cls = new ObjectiveCClass("MTL4CommitOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }
}
