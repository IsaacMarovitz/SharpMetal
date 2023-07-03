using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLCounterSampleBufferError : long
    {
        OutOfMemory = 0,
        Invalid = 1,
        Internal = 2,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCounterResultTimestamp
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounterResultTimestamp obj) => obj.NativePtr;
        public MTLCounterResultTimestamp(IntPtr ptr) => NativePtr = ptr;

        public ulong timestamp;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCounterResultStageUtilization
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounterResultStageUtilization obj) => obj.NativePtr;
        public MTLCounterResultStageUtilization(IntPtr ptr) => NativePtr = ptr;

        public ulong totalCycles;

        public ulong vertexCycles;

        public ulong tessellationCycles;

        public ulong postTessellationVertexCycles;

        public ulong fragmentCycles;

        public ulong renderTargetCycles;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCounterResultStatistic
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounterResultStatistic obj) => obj.NativePtr;
        public MTLCounterResultStatistic(IntPtr ptr) => NativePtr = ptr;

        public ulong tessellationInputPatches;

        public ulong vertexInvocations;

        public ulong postTessellationVertexInvocations;

        public ulong clipperInvocations;

        public ulong clipperPrimitivesOut;

        public ulong fragmentInvocations;

        public ulong fragmentsPassed;

        public ulong computeKernelInvocations;
    }

    [SupportedOSPlatform("macos")]
    public class MTLCounter
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounter obj) => obj.NativePtr;
        public MTLCounter(IntPtr ptr) => NativePtr = ptr;

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        private static readonly Selector sel_name = "name";
    }

    [SupportedOSPlatform("macos")]
    public class MTLCounterSet
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounterSet obj) => obj.NativePtr;
        public MTLCounterSet(IntPtr ptr) => NativePtr = ptr;

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));

        public NSArray Counters => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_counters));

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_counters = "counters";
    }

    [SupportedOSPlatform("macos")]
    public class MTLCounterSampleBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounterSampleBufferDescriptor obj) => obj.NativePtr;
        public MTLCounterSampleBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLCounterSampleBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLCounterSampleBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLCounterSet CounterSet
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_counterSet));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCounterSet, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLStorageMode StorageMode
        {
            get => (MTLStorageMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storageMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)value);
        }

        public ulong SampleCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public void SetCounterSet(MTLCounterSet counterSet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCounterSet, counterSet);
        }

        public void SetLabel(NSString label)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, label);
        }

        public void SetStorageMode(MTLStorageMode storageMode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStorageMode, (ulong)storageMode);
        }

        public void SetSampleCount(ulong sampleCount)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, sampleCount);
        }

        private static readonly Selector sel_counterSet = "counterSet";
        private static readonly Selector sel_setCounterSet = "setCounterSet:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_storageMode = "storageMode";
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLCounterSampleBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCounterSampleBuffer obj) => obj.NativePtr;
        public MTLCounterSampleBuffer(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public ulong SampleCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sampleCount);

        public NSData ResolveCounterRange(NSRange range)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_resolveCounterRange = "resolveCounterRange:";
    }
}
