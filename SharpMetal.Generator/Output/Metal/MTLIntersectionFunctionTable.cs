using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLIntersectionFunctionSignature: ulong
    {
        None = 0,
        Instancing = 1,
        TriangleData = 2,
        WorldSpaceData = 4,
        InstanceMotion = 8,
        PrimitiveMotion = 16,
        ExtendedLimits = 32,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIntersectionFunctionTableDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionTableDescriptor obj) => obj.NativePtr;
        public MTLIntersectionFunctionTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIntersectionFunctionTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIntersectionFunctionTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_intersectionFunctionTableDescriptor));
        public ulong FunctionCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionCount);

        private static readonly Selector sel_intersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";
        private static readonly Selector sel_functionCount = "functionCount";
        private static readonly Selector sel_setFunctionCount = "setFunctionCount:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIntersectionFunctionTable
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionTable obj) => obj.NativePtr;
        public MTLIntersectionFunctionTable(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_setBufferoffsetatIndex = "setBuffer:offset:atIndex:";
        private static readonly Selector sel_setBuffersoffsetswithRange = "setBuffers:offsets:withRange:";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_setFunctionatIndex = "setFunction:atIndex:";
        private static readonly Selector sel_setFunctionswithRange = "setFunctions:withRange:";
        private static readonly Selector sel_setOpaqueTriangleIntersectionFunctionWithSignatureatIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";
        private static readonly Selector sel_setOpaqueTriangleIntersectionFunctionWithSignaturewithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";
        private static readonly Selector sel_setVisibleFunctionTableatBufferIndex = "setVisibleFunctionTable:atBufferIndex:";
        private static readonly Selector sel_setVisibleFunctionTableswithBufferRange = "setVisibleFunctionTables:withBufferRange:";
    }
}
