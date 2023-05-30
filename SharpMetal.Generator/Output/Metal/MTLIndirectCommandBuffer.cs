using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLIndirectCommandType: ulong
    {
        Draw = 1,
        DrawIndexed = 2,
        DrawPatches = 4,
        DrawIndexedPatches = 8,
        ConcurrentDispatch = 32,
        ConcurrentDispatchThreads = 64,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLIndirectCommandBufferExecutionRange
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBufferExecutionRange obj) => obj.NativePtr;
        public MTLIndirectCommandBufferExecutionRange(IntPtr ptr) => NativePtr = ptr;

        public uint location;
        public uint length;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIndirectCommandBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBufferDescriptor obj) => obj.NativePtr;
        public MTLIndirectCommandBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIndirectCommandBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIndirectCommandBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLIndirectCommandType CommandTypes => (MTLIndirectCommandType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_commandTypes);
        public bool InheritPipelineState => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_inheritPipelineState);
        public bool InheritBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_inheritBuffers);
        public ulong MaxVertexBufferBindCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexBufferBindCount);
        public ulong MaxFragmentBufferBindCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxFragmentBufferBindCount);
        public ulong MaxKernelBufferBindCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxKernelBufferBindCount);
        public bool SupportRayTracing => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportRayTracing);

        private static readonly Selector sel_commandTypes = "commandTypes";
        private static readonly Selector sel_setCommandTypes = "setCommandTypes:";
        private static readonly Selector sel_inheritPipelineState = "inheritPipelineState";
        private static readonly Selector sel_setInheritPipelineState = "setInheritPipelineState:";
        private static readonly Selector sel_inheritBuffers = "inheritBuffers";
        private static readonly Selector sel_setInheritBuffers = "setInheritBuffers:";
        private static readonly Selector sel_maxVertexBufferBindCount = "maxVertexBufferBindCount";
        private static readonly Selector sel_setMaxVertexBufferBindCount = "setMaxVertexBufferBindCount:";
        private static readonly Selector sel_maxFragmentBufferBindCount = "maxFragmentBufferBindCount";
        private static readonly Selector sel_setMaxFragmentBufferBindCount = "setMaxFragmentBufferBindCount:";
        private static readonly Selector sel_maxKernelBufferBindCount = "maxKernelBufferBindCount";
        private static readonly Selector sel_setMaxKernelBufferBindCount = "setMaxKernelBufferBindCount:";
        private static readonly Selector sel_supportRayTracing = "supportRayTracing";
        private static readonly Selector sel_setSupportRayTracing = "setSupportRayTracing:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIndirectCommandBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBuffer obj) => obj.NativePtr;
        public MTLIndirectCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);
        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_resetWithRange = "resetWithRange:";
        private static readonly Selector sel_indirectRenderCommandAtIndex = "indirectRenderCommandAtIndex:";
        private static readonly Selector sel_indirectComputeCommandAtIndex = "indirectComputeCommandAtIndex:";
    }
}
