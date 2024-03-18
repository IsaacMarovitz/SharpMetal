using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLIntersectionFunctionSignature : ulong
    {
        None = 0,
        Instancing = 1,
        TriangleData = 2,
        WorldSpaceData = 4,
        InstanceMotion = 8,
        PrimitiveMotion = 16,
        ExtendedLimits = 32,
        MaxLevels = 64,
        CurveData = 128,
    }

    [SupportedOSPlatform("macos")]
    public class MTLIntersectionFunctionTableDescriptor
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionTableDescriptor obj) => obj.NativePtr;
        public MTLIntersectionFunctionTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIntersectionFunctionTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIntersectionFunctionTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public ulong FunctionCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionCount, value);
        }

        private static readonly Selector sel_intersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";
        private static readonly Selector sel_functionCount = "functionCount";
        private static readonly Selector sel_setFunctionCount = "setFunctionCount:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLIntersectionFunctionTable : MTLResource
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionTable obj) => obj.NativePtr;
        public MTLIntersectionFunctionTable(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferoffsetatIndex, buffer, offset, index);
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetFunction(MTLFunctionHandle function, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionatIndex, function, index);
        }

        public void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
        {
            throw new NotImplementedException();
        }

        public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueTriangleIntersectionFunctionWithSignatureatIndex, (ulong)signature, index);
        }

        public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueTriangleIntersectionFunctionWithSignaturewithRange, (ulong)signature, range);
        }

        public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueCurveIntersectionFunctionWithSignatureatIndex, (ulong)signature, index);
        }

        public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOpaqueCurveIntersectionFunctionWithSignaturewithRange, (ulong)signature, range);
        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVisibleFunctionTableatBufferIndex, functionTable, bufferIndex);
        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange bufferRange)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_setBufferoffsetatIndex = "setBuffer:offset:atIndex:";
        private static readonly Selector sel_setBuffersoffsetswithRange = "setBuffers:offsets:withRange:";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
        private static readonly Selector sel_setOpaqueTriangleIntersectionFunctionWithSignatureatIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";
        private static readonly Selector sel_setOpaqueTriangleIntersectionFunctionWithSignaturewithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";
        private static readonly Selector sel_setOpaqueCurveIntersectionFunctionWithSignatureatIndex = "setOpaqueCurveIntersectionFunctionWithSignature:atIndex:";
        private static readonly Selector sel_setOpaqueCurveIntersectionFunctionWithSignaturewithRange = "setOpaqueCurveIntersectionFunctionWithSignature:withRange:";
        private static readonly Selector sel_setVisibleFunctionTableatBufferIndex = "setVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVisibleFunctionTableswithBufferRange = "setVisibleFunctionTables:withBufferRange:";
    }
}
