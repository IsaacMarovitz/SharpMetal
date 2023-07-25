using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLIndirectCommandType : ulong
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
        public uint location;
        public uint length;
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLIndirectCommandBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBufferDescriptor obj) => obj.NativePtr;
        public MTLIndirectCommandBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIndirectCommandBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIndirectCommandBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLIndirectCommandType CommandTypes
        {
            get => (MTLIndirectCommandType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_commandTypes);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCommandTypes, (ulong)value);
        }

        public bool InheritPipelineState
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_inheritPipelineState);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInheritPipelineState, value);
        }

        public bool InheritBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_inheritBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInheritBuffers, value);
        }

        public ulong MaxVertexBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxVertexBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxVertexBufferBindCount, value);
        }

        public ulong MaxFragmentBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxFragmentBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxFragmentBufferBindCount, value);
        }

        public ulong MaxKernelBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxKernelBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxKernelBufferBindCount, value);
        }

        public bool SupportRayTracing
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportRayTracing);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportRayTracing, value);
        }

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
    public partial class MTLIndirectCommandBuffer : MTLResource
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBuffer obj) => obj.NativePtr;
        public MTLIndirectCommandBuffer(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLIndirectCommandBuffer()
        {
            throw new NotImplementedException();
        }

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public void Reset(NSRange range)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resetWithRange, range);
        }

        public MTLIndirectRenderCommand IndirectRenderCommand(ulong commandIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indirectRenderCommandAtIndex, commandIndex));
        }

        public MTLIndirectComputeCommand IndirectComputeCommand(ulong commandIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_indirectComputeCommandAtIndex, commandIndex));
        }

        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_resetWithRange = "resetWithRange:";
        private static readonly Selector sel_indirectRenderCommandAtIndex = "indirectRenderCommandAtIndex:";
        private static readonly Selector sel_indirectComputeCommandAtIndex = "indirectComputeCommandAtIndex:";
    }
}
