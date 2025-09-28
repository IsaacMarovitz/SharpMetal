using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLResidencySet : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResidencySet obj) => obj.NativePtr;
        public MTLResidencySet(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray AllAllocations => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_allAllocations));

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public ulong AllocationCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocationCount);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public void AddAllocation(MTLAllocation allocation)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addAllocation, allocation);
        }

        public void AddAllocations(MTLAllocation[] allocations, ulong count)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_commit);
        }

        public bool ContainsAllocation(MTLAllocation anAllocation)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_containsAllocation, anAllocation);
        }

        public void EndResidency()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endResidency);
        }

        public void RemoveAllAllocations()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_removeAllAllocations);
        }

        public void RemoveAllocation(MTLAllocation allocation)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_removeAllocation, allocation);
        }

        public void RemoveAllocations(MTLAllocation[] allocations, ulong count)
        {
            throw new NotImplementedException();
        }

        public void RequestResidency()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_requestResidency);
        }

        private static readonly Selector sel_addAllocation = "addAllocation:";
        private static readonly Selector sel_addAllocationscount = "addAllocations:count:";
        private static readonly Selector sel_allAllocations = "allAllocations";
        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_allocationCount = "allocationCount";
        private static readonly Selector sel_commit = "commit";
        private static readonly Selector sel_containsAllocation = "containsAllocation:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_endResidency = "endResidency";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_removeAllAllocations = "removeAllAllocations";
        private static readonly Selector sel_removeAllocation = "removeAllocation:";
        private static readonly Selector sel_removeAllocationscount = "removeAllocations:count:";
        private static readonly Selector sel_requestResidency = "requestResidency";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLResidencySetDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResidencySetDescriptor obj) => obj.NativePtr;
        public MTLResidencySetDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLResidencySetDescriptor()
        {
            var cls = new ObjectiveCClass("MTLResidencySetDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong InitialCapacity
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_initialCapacity);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInitialCapacity, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        private static readonly Selector sel_initialCapacity = "initialCapacity";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setInitialCapacity = "setInitialCapacity:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_release = "release";
    }
}
