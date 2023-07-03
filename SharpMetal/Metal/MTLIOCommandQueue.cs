using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLIOPriority : long
    {
        High = 0,
        Normal = 1,
        Low = 2,
    }

    public enum MTLIOCommandQueueType : long
    {
        Concurrent = 0,
        Serial = 1,
    }

    public enum MTLIOError : long
    {
        URLInvalid = 1,
        Internal = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOCommandQueue
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOCommandQueue obj) => obj.NativePtr;
        public MTLIOCommandQueue(IntPtr ptr) => NativePtr = ptr;

        public MTLIOCommandBuffer CommandBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBuffer));

        public MTLIOCommandBuffer CommandBufferWithUnretainedReferences => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBufferWithUnretainedReferences));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void SetLabel(NSString label)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_enqueueBarrier = "enqueueBarrier";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_commandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOScratchBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOScratchBuffer obj) => obj.NativePtr;
        public MTLIOScratchBuffer(IntPtr ptr) => NativePtr = ptr;

        public MTLBuffer Buffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffer));

        private static readonly Selector sel_buffer = "buffer";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOScratchBufferAllocator
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOScratchBufferAllocator obj) => obj.NativePtr;
        public MTLIOScratchBufferAllocator(IntPtr ptr) => NativePtr = ptr;

        public IntPtr NewScratchBuffer(ulong minimumSize)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_newScratchBufferWithMinimumSize = "newScratchBufferWithMinimumSize:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOCommandQueueDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOCommandQueueDescriptor obj) => obj.NativePtr;
        public MTLIOCommandQueueDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIOCommandQueueDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIOCommandQueueDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong MaxCommandBufferCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCommandBufferCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCommandBufferCount, value);
        }

        public MTLIOPriority Priority
        {
            get => (MTLIOPriority)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_priority);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPriority, (long)value);
        }

        public MTLIOCommandQueueType Type
        {
            get => (MTLIOCommandQueueType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setType, (long)value);
        }

        public ulong MaxCommandsInFlight
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCommandsInFlight);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCommandsInFlight, value);
        }

        public MTLIOScratchBufferAllocator ScratchBufferAllocator
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_scratchBufferAllocator));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScratchBufferAllocator, value);
        }

        public void SetMaxCommandBufferCount(ulong maxCommandBufferCount)
        {
            throw new NotImplementedException();
        }

        public void SetPriority(MTLIOPriority priority)
        {
            throw new NotImplementedException();
        }

        public void SetType(MTLIOCommandQueueType type)
        {
            throw new NotImplementedException();
        }

        public void SetMaxCommandsInFlight(ulong maxCommandsInFlight)
        {
            throw new NotImplementedException();
        }

        public void SetScratchBufferAllocator(MTLIOScratchBufferAllocator scratchBufferAllocator)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_maxCommandBufferCount = "maxCommandBufferCount";
        private static readonly Selector sel_setMaxCommandBufferCount = "setMaxCommandBufferCount:";
        private static readonly Selector sel_priority = "priority";
        private static readonly Selector sel_setPriority = "setPriority:";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_setType = "setType:";
        private static readonly Selector sel_maxCommandsInFlight = "maxCommandsInFlight";
        private static readonly Selector sel_setMaxCommandsInFlight = "setMaxCommandsInFlight:";
        private static readonly Selector sel_scratchBufferAllocator = "scratchBufferAllocator";
        private static readonly Selector sel_setScratchBufferAllocator = "setScratchBufferAllocator:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIOFileHandle
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIOFileHandle obj) => obj.NativePtr;
        public MTLIOFileHandle(IntPtr ptr) => NativePtr = ptr;

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void SetLabel(NSString label)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }
}
