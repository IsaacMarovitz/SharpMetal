using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
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

        public void SetCommandTypes(MTLIndirectCommandType commandTypes)
        {
            throw new NotImplementedException();
        }

        public void SetInheritPipelineState(bool inheritPipelineState)
        {
            throw new NotImplementedException();
        }

        public void SetInheritBuffers(bool inheritBuffers)
        {
            throw new NotImplementedException();
        }

        public void SetMaxVertexBufferBindCount(ulong maxVertexBufferBindCount)
        {
            throw new NotImplementedException();
        }

        public void SetMaxFragmentBufferBindCount(ulong maxFragmentBufferBindCount)
        {
            throw new NotImplementedException();
        }

        public void SetMaxKernelBufferBindCount(ulong maxKernelBufferBindCount)
        {
            throw new NotImplementedException();
        }

        public void SetSupportRayTracing(bool supportRayTracing)
        {
            throw new NotImplementedException();
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
    public struct MTLIndirectCommandBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIndirectCommandBuffer obj) => obj.NativePtr;
        public MTLIndirectCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public ulong Size => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_size);

        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        public void Reset(NSRange range)
        {
            throw new NotImplementedException();
        }

        public MTLIndirectRenderCommand IndirectRenderCommand(ulong commandIndex)
        {
            throw new NotImplementedException();
        }

        public MTLIndirectComputeCommand IndirectComputeCommand(ulong commandIndex)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_size = "size";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_resetWithRange = "resetWithRange:";
        private static readonly Selector sel_indirectRenderCommandAtIndex = "indirectRenderCommandAtIndex:";
        private static readonly Selector sel_indirectComputeCommandAtIndex = "indirectComputeCommandAtIndex:";
    }
}
