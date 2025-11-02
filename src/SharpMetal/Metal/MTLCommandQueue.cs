using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLCommandQueue : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandQueue obj) => obj.NativePtr;
        public MTLCommandQueue(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLCommandBuffer CommandBufferWithUnretainedReferences => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBufferWithUnretainedReferences));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void AddResidencySet(MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addResidencySet, residencySet);
        }

        public void AddResidencySets(MTLResidencySet[] residencySets, ulong count)
        {
            unsafe
            {
                fixed (MTLResidencySet* residencySetsPtr = residencySets)
                {
                    ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addResidencySetscount, residencySetsPtr, count);
                }
            }
        }

        public MTLCommandBuffer CommandBuffer(MTLCommandBufferDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBufferWithDescriptor, descriptor));
        }

        public MTLCommandBuffer CommandBuffer()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandBuffer));
        }

        public void InsertDebugCaptureBoundary()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_insertDebugCaptureBoundary);
        }

        public void RemoveResidencySet(MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_removeResidencySet, residencySet);
        }

        public void RemoveResidencySets(MTLResidencySet[] residencySets, ulong count)
        {
            unsafe
            {
                fixed (MTLResidencySet* residencySetsPtr = residencySets)
                {
                    ObjectiveCRuntime.objc_msgSend(NativePtr, sel_removeResidencySetscount, residencySetsPtr, count);
                }
            }
        }

        private static readonly Selector sel_addResidencySet = "addResidencySet:";
        private static readonly Selector sel_addResidencySetscount = "addResidencySets:count:";
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        private static readonly Selector sel_commandBufferWithDescriptor = "commandBufferWithDescriptor:";
        private static readonly Selector sel_commandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_insertDebugCaptureBoundary = "insertDebugCaptureBoundary";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_removeResidencySet = "removeResidencySet:";
        private static readonly Selector sel_removeResidencySetscount = "removeResidencySets:count:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLCommandQueueDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandQueueDescriptor obj) => obj.NativePtr;
        public MTLCommandQueueDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLCommandQueueDescriptor()
        {
            var cls = new ObjectiveCClass("MTLCommandQueueDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLLogState LogState
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logState));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogState, value);
        }

        public ulong MaxCommandBufferCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCommandBufferCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCommandBufferCount, value);
        }

        private static readonly Selector sel_logState = "logState";
        private static readonly Selector sel_maxCommandBufferCount = "maxCommandBufferCount";
        private static readonly Selector sel_setLogState = "setLogState:";
        private static readonly Selector sel_setMaxCommandBufferCount = "setMaxCommandBufferCount:";
        private static readonly Selector sel_release = "release";
    }
}
