using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLBarrierScope : ulong
    {
        Buffers = 1,
        Textures = 1 << 1,
        RenderTargets = 1 << 2,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLResourceUsage : ulong
    {
        Read = 1,
        Write = 1 << 1,
        Sample = 1 << 2,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLStages : ulong
    {
        StageVertex = 1,
        StageFragment = 1 << 1,
        StageTile = 1 << 2,
        StageObject = 1 << 3,
        StageMesh = 1 << 4,
        StageResourceState = 1 << 26,
        StageDispatch = 1 << 27,
        StageBlit = 1 << 28,
        StageAccelerationStructure = 1 << 29,
        StageMachineLearning = 1 << 30,
        StageAll = 9223372036854775807,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLCommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandEncoder obj) => obj.NativePtr;
        public MTLCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_barrierAfterQueueStagesbeforeStages, (ulong)afterQueueStages, (ulong)beforeStages);
        }

        public void EndEncoding()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endEncoding);
        }

        public void InsertDebugSignpost(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_insertDebugSignpost, nsString);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        private static readonly Selector sel_barrierAfterQueueStagesbeforeStages = "barrierAfterQueueStages:beforeStages:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_insertDebugSignpost = "insertDebugSignpost:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_release = "release";
    }
}
