using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLVisibleFunctionTable : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVisibleFunctionTable obj) => obj.NativePtr;
        public static implicit operator MTLResource(MTLVisibleFunctionTable obj) => new(obj.NativePtr);
        public MTLVisibleFunctionTable(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong AllocatedSize => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_allocatedSize);

        public MTLCPUCacheMode CpuCacheMode => (MTLCPUCacheMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_cpuCacheMode);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public MTLHazardTrackingMode HazardTrackingMode => (MTLHazardTrackingMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_hazardTrackingMode);

        public MTLHeap Heap => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_heap));

        public ulong HeapOffset => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_heapOffset);

        public bool IsAliasable => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isAliasable);

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLResourceOptions ResourceOptions => (MTLResourceOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceOptions);

        public MTLStorageMode StorageMode => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);

        public void MakeAliasable()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_makeAliasable);
        }

        public void SetFunction(MTLFunctionHandle function, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionatIndex, function, index);
        }

        public void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
        {
            throw new NotImplementedException();
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        private static readonly Selector sel_allocatedSize = "allocatedSize";
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_hazardTrackingMode = "hazardTrackingMode";
        private static readonly Selector sel_heap = "heap";
        private static readonly Selector sel_heapOffset = "heapOffset";
        private static readonly Selector sel_isAliasable = "isAliasable";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_makeAliasable = "makeAliasable";
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVisibleFunctionTableDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVisibleFunctionTableDescriptor obj) => obj.NativePtr;
        public MTLVisibleFunctionTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLVisibleFunctionTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTLVisibleFunctionTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong FunctionCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionCount, value);
        }

        private static readonly Selector sel_functionCount = "functionCount";
        private static readonly Selector sel_setFunctionCount = "setFunctionCount:";
        private static readonly Selector sel_visibleFunctionTableDescriptor = "visibleFunctionTableDescriptor";
        private static readonly Selector sel_release = "release";
    }
}
