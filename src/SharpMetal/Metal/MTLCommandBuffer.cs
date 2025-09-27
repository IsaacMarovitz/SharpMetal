using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLCommandBufferError : ulong
    {
        None = 0,
        Internal = 1,
        Timeout = 2,
        PageFault = 3,
        Blacklisted = 4,
        AccessRevoked = 4,
        NotPermitted = 7,
        OutOfMemory = 8,
        InvalidResource = 9,
        Memoryless = 10,
        DeviceRemoved = 11,
        StackOverflow = 12,
    }

    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLCommandBufferErrorOption : ulong
    {
        None = 0,
        EncoderExecutionStatus = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLCommandBufferStatus : ulong
    {
        NotEnqueued = 0,
        Enqueued = 1,
        Committed = 2,
        Scheduled = 3,
        Completed = 4,
        Error = 5,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLCommandEncoderErrorState : long
    {
        Unknown = 0,
        Completed = 1,
        Affected = 2,
        Pending = 3,
        Faulted = 4,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLDispatchType : ulong
    {
        Serial = 0,
        Concurrent = 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLCommandBuffer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBuffer obj) => obj.NativePtr;
        public MTLCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLCommandQueue CommandQueue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandQueue));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSError Error => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error));

        public MTLCommandBufferErrorOption ErrorOptions => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);

        public IntPtr GPUEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUEndTime));

        public IntPtr GPUStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUStartTime));

        public IntPtr KernelEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelEndTime));

        public IntPtr KernelStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelStartTime));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLLogContainer Logs => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logs));

        public bool RetainedReferences => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);

        public MTLCommandBufferStatus Status => (MTLCommandBufferStatus)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_status);

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder(MTLAccelerationStructurePassDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_accelerationStructureCommandEncoderWithDescriptor, descriptor));
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_accelerationStructureCommandEncoderWithDescriptor));
        }

        public MTLBlitCommandEncoder BlitCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_blitCommandEncoderWithDescriptor));
        }

        public MTLBlitCommandEncoder BlitCommandEncoder(MTLBlitPassDescriptor blitPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_blitCommandEncoderWithDescriptor, blitPassDescriptor));
        }

        public void Commit()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_commit);
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder(MTLDispatchType dispatchType)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoderWithDispatchType, (ulong)dispatchType));
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder(MTLComputePassDescriptor computePassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoderWithDescriptor, computePassDescriptor));
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoder));
        }

        public void EncodeSignalEvent(MTLEvent mtlEvent, ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeSignalEventvalue, mtlEvent, value);
        }

        public void EncodeWait(MTLEvent mtlEvent, ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeWaitForEventvalue, mtlEvent, value);
        }

        public void Enqueue()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_enqueue);
        }

        public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parallelRenderCommandEncoderWithDescriptor, renderPassDescriptor));
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PresentDrawable(MTLDrawable drawable)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawable, drawable);
        }

        public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, IntPtr duration)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawableafterMinimumDuration, drawable, duration);
        }

        public void PresentDrawableAtTime(MTLDrawable drawable, IntPtr presentationTime)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawableatTime, drawable, presentationTime);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, renderPassDescriptor));
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceStateCommandEncoderWithDescriptor));
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceStateCommandEncoderWithDescriptor, resourceStatePassDescriptor));
        }

        public void UseResidencySet(MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResidencySet, residencySet);
        }

        public void UseResidencySets(MTLResidencySet[] residencySets, ulong count)
        {
            throw new NotImplementedException();
        }

        public void WaitUntilCompleted()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilCompleted);
        }

        public void WaitUntilScheduled()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilScheduled);
        }

        private static readonly Selector sel_accelerationStructureCommandEncoder = "accelerationStructureCommandEncoder";
        private static readonly Selector sel_accelerationStructureCommandEncoderWithDescriptor = "accelerationStructureCommandEncoderWithDescriptor:";
        private static readonly Selector sel_blitCommandEncoder = "blitCommandEncoder";
        private static readonly Selector sel_blitCommandEncoderWithDescriptor = "blitCommandEncoderWithDescriptor:";
        private static readonly Selector sel_commandQueue = "commandQueue";
        private static readonly Selector sel_commit = "commit";
        private static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        private static readonly Selector sel_computeCommandEncoderWithDescriptor = "computeCommandEncoderWithDescriptor:";
        private static readonly Selector sel_computeCommandEncoderWithDispatchType = "computeCommandEncoderWithDispatchType:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_encodeSignalEventvalue = "encodeSignalEvent:value:";
        private static readonly Selector sel_encodeWaitForEventvalue = "encodeWaitForEvent:value:";
        private static readonly Selector sel_enqueue = "enqueue";
        private static readonly Selector sel_error = "error";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_GPUEndTime = "GPUEndTime";
        private static readonly Selector sel_GPUStartTime = "GPUStartTime";
        private static readonly Selector sel_kernelEndTime = "kernelEndTime";
        private static readonly Selector sel_kernelStartTime = "kernelStartTime";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_logs = "logs";
        private static readonly Selector sel_parallelRenderCommandEncoderWithDescriptor = "parallelRenderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_presentDrawable = "presentDrawable:";
        private static readonly Selector sel_presentDrawableafterMinimumDuration = "presentDrawable:afterMinimumDuration:";
        private static readonly Selector sel_presentDrawableatTime = "presentDrawable:atTime:";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_resourceStateCommandEncoder = "resourceStateCommandEncoder";
        private static readonly Selector sel_resourceStateCommandEncoderWithDescriptor = "resourceStateCommandEncoderWithDescriptor:";
        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_status = "status";
        private static readonly Selector sel_useResidencySet = "useResidencySet:";
        private static readonly Selector sel_useResidencySetscount = "useResidencySets:count:";
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        private static readonly Selector sel_waitUntilScheduled = "waitUntilScheduled";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLCommandBufferDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBufferDescriptor obj) => obj.NativePtr;
        public MTLCommandBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLCommandBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLCommandBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLCommandBufferErrorOption ErrorOptions
        {
            get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setErrorOptions, (ulong)value);
        }

        public MTLLogState LogState
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logState));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogState, value);
        }

        public bool RetainedReferences
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRetainedReferences, value);
        }

        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_logState = "logState";
        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_setErrorOptions = "setErrorOptions:";
        private static readonly Selector sel_setLogState = "setLogState:";
        private static readonly Selector sel_setRetainedReferences = "setRetainedReferences:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLCommandBufferEncoderInfo : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBufferEncoderInfo obj) => obj.NativePtr;
        public MTLCommandBufferEncoderInfo(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray DebugSignposts => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_debugSignposts));

        public MTLCommandEncoderErrorState ErrorState => (MTLCommandEncoderErrorState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_errorState);

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_debugSignposts = "debugSignposts";
        private static readonly Selector sel_errorState = "errorState";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_release = "release";
    }
}
