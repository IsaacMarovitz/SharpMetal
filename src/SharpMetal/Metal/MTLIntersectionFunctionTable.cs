using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLIntersectionFunctionSignature : ulong
    {
        None = 0,
        Instancing = 1,
        TriangleData = 1 << 1,
        WorldSpaceData = 1 << 2,
        InstanceMotion = 1 << 3,
        PrimitiveMotion = 1 << 4,
        ExtendedLimits = 1 << 5,
        MaxLevels = 1 << 6,
        CurveData = 1 << 7,
        IntersectionFunctionBuffer = 1 << 8,
        UserData = 1 << 9,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLIntersectionFunctionBufferArguments
    {
        public ulong intersectionFunctionBuffer;
        public ulong intersectionFunctionBufferSize;
        public ulong intersectionFunctionStride;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIntersectionFunctionTable : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionTable obj) => obj.NativePtr;
        public static implicit operator MTLResource(MTLIntersectionFunctionTable obj) => new(obj.NativePtr);
        public MTLIntersectionFunctionTable(IntPtr ptr) => NativePtr = ptr;

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

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            unsafe
            {
                fixed (MTLBuffer* buffersPtr = buffers)
                fixed (ulong* offsetsPtr = offsets)
                {
                    ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBuffersoffsetswithRange, buffersPtr, offsetsPtr, range);
                }
            }
        }

        public void SetFunction(MTLFunctionHandle function, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionatIndex, function, index);
        }

        public void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
        {
            unsafe
            {
                fixed (MTLFunctionHandle* functionsPtr = functions)
                {
                    ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionswithRange, functionsPtr, range);
                }
            }
        }

        public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueCurveIntersectionFunctionWithSignatureatIndex, (ulong)signature, index);
        }

        public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueCurveIntersectionFunctionWithSignaturewithRange, (ulong)signature, range);
        }

        public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueTriangleIntersectionFunctionWithSignatureatIndex, (ulong)signature, index);
        }

        public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueTriangleIntersectionFunctionWithSignaturewithRange, (ulong)signature, range);
        }

        public int SetOwner(IntPtr task_id_token)
        {
            return ObjectiveCRuntime.int_objc_msgSend(NativePtr, sel_setOwnerWithIdentity, task_id_token);
        }

        public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
        {
            return (MTLPurgeableState)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_setPurgeableState, (ulong)state);
        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibleFunctionTableatBufferIndex, functionTable, bufferIndex);
        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange bufferRange)
        {
            unsafe
            {
                fixed (MTLVisibleFunctionTable* functionTablesPtr = functionTables)
                {
                    ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibleFunctionTableswithBufferRange, functionTablesPtr, bufferRange);
                }
            }
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
        private static readonly Selector sel_setBufferoffsetatIndex = "setBuffer:offset:atIndex:";
        private static readonly Selector sel_setBuffersoffsetswithRange = "setBuffers:offsets:withRange:";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOpaqueCurveIntersectionFunctionWithSignatureatIndex = "setOpaqueCurveIntersectionFunctionWithSignature:atIndex:";
        private static readonly Selector sel_setOpaqueCurveIntersectionFunctionWithSignaturewithRange = "setOpaqueCurveIntersectionFunctionWithSignature:withRange:";
        private static readonly Selector sel_setOpaqueTriangleIntersectionFunctionWithSignatureatIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";
        private static readonly Selector sel_setOpaqueTriangleIntersectionFunctionWithSignaturewithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";
        private static readonly Selector sel_setOwnerWithIdentity = "setOwnerWithIdentity:";
        private static readonly Selector sel_setPurgeableState = "setPurgeableState:";
        private static readonly Selector sel_setVisibleFunctionTableatBufferIndex = "setVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVisibleFunctionTableswithBufferRange = "setVisibleFunctionTables:withBufferRange:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIntersectionFunctionTableDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionTableDescriptor obj) => obj.NativePtr;
        public MTLIntersectionFunctionTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIntersectionFunctionTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIntersectionFunctionTableDescriptor");
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
        private static readonly Selector sel_intersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";
        private static readonly Selector sel_setFunctionCount = "setFunctionCount:";
        private static readonly Selector sel_release = "release";
    }
}
