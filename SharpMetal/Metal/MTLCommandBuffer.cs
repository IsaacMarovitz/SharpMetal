using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLCommandBufferStatus : ulong
    {
        NotEnqueued = 0,
        Enqueued = 1,
        Committed = 2,
        Scheduled = 3,
        Completed = 4,
        Error = 5,
    }

    public enum MTLCommandBufferError : ulong
    {
        None = 0,
        Internal = 1,
        Timeout = 2,
        PageFault = 3,
        AccessRevoked = 4,
        Blacklisted = 4,
        NotPermitted = 7,
        OutOfMemory = 8,
        InvalidResource = 9,
        Memoryless = 10,
        DeviceRemoved = 11,
        StackOverflow = 12,
    }

    public enum MTLCommandBufferErrorOption : ulong
    {
        None = 0,
        EncoderExecutionStatus = 1,
    }

    public enum MTLCommandEncoderErrorState : long
    {
        Unknown = 0,
        Completed = 1,
        Affected = 2,
        Pending = 3,
        Faulted = 4,
    }

    public enum MTLDispatchType : ulong
    {
        Serial = 0,
        Concurrent = 1,
    }

    [SupportedOSPlatform("macos")]
    public class MTLCommandBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBufferDescriptor obj) => obj.NativePtr;
        public MTLCommandBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLCommandBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLCommandBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public bool RetainedReferences
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRetainedReferences, value);
        }

        public MTLCommandBufferErrorOption ErrorOptions
        {
            get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setErrorOptions, (ulong)value);
        }

        public void SetRetainedReferences(bool retainedReferences)
        {
            objc_msgSend(NativePtr, , retainedReferences);
        }

        public void SetErrorOptions(MTLCommandBufferErrorOption errorOptions)
        {
            objc_msgSend(NativePtr, , errorOptions);
        }

        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_setRetainedReferences = "setRetainedReferences:";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_setErrorOptions = "setErrorOptions:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLCommandBufferEncoderInfo
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBufferEncoderInfo obj) => obj.NativePtr;
        public MTLCommandBufferEncoderInfo(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public NSArray DebugSignposts => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_debugSignposts));

        public MTLCommandEncoderErrorState ErrorState => (MTLCommandEncoderErrorState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_errorState);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_debugSignposts = "debugSignposts";
        private static readonly Selector sel_errorState = "errorState";
    }

    [SupportedOSPlatform("macos")]
    public class MTLCommandBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBuffer obj) => obj.NativePtr;
        public MTLCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLCommandQueue CommandQueue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandQueue));

        public bool RetainedReferences => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);

        public MTLCommandBufferErrorOption ErrorOptions => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public IntPtr KernelStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelStartTime));

        public IntPtr KernelEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelEndTime));

        public MTLLogContainer Logs => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logs));

        public IntPtr GPUStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUStartTime));

        public IntPtr GPUEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUEndTime));

        public MTLCommandBufferStatus Status => (MTLCommandBufferStatus)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_status);

        public NSError Error => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error));

        public void SetLabel(NSString label)
        {
            objc_msgSend(NativePtr, , label);
        }

        public void Enqueue()
        {
            objc_msgSend(NativePtr, , );
        }

        public void Commit()
        {
            objc_msgSend(NativePtr, , );
        }

        public void PresentDrawable(MTLDrawable drawable)
        {
            objc_msgSend(NativePtr, , drawable);
        }

        public void PresentDrawableAtTime(MTLDrawable drawable, IntPtr presentationTime)
        {
            objc_msgSend(NativePtr, , drawable, presentationTime);
        }

        public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, IntPtr duration)
        {
            objc_msgSend(NativePtr, , drawable, duration);
        }

        public void WaitUntilScheduled()
        {
            objc_msgSend(NativePtr, , );
        }

        public void WaitUntilCompleted()
        {
            objc_msgSend(NativePtr, , );
        }

        public MTLRenderCommandEncoder RenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
        {
            throw new NotImplementedException();
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder(MTLComputePassDescriptor computePassDescriptor)
        {
            throw new NotImplementedException();
        }

        public MTLBlitCommandEncoder BlitCommandEncoder(MTLBlitPassDescriptor blitPassDescriptor)
        {
            throw new NotImplementedException();
        }

        public MTLBlitCommandEncoder BlitCommandEncoder()
        {
            throw new NotImplementedException();
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder()
        {
            throw new NotImplementedException();
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder(MTLDispatchType dispatchType)
        {
            throw new NotImplementedException();
        }

        public void EncodeWait(MTLEvent mltEvent, ulong value)
        {
            objc_msgSend(NativePtr, , mltEvent, value);
        }

        public void EncodeSignalEvent(MTLEvent mltEvent, ulong value)
        {
            objc_msgSend(NativePtr, , mltEvent, value);
        }

        public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(MTLRenderPassDescriptor renderPassDescriptor)
        {
            throw new NotImplementedException();
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
        {
            throw new NotImplementedException();
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder()
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder(MTLAccelerationStructurePassDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder()
        {
            throw new NotImplementedException();
        }

        public void PushDebugGroup(NSString nsString)
        {
            objc_msgSend(NativePtr, , nsString);
        }

        public void PopDebugGroup()
        {
            objc_msgSend(NativePtr, , );
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_commandQueue = "commandQueue";
        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_kernelStartTime = "kernelStartTime";
        private static readonly Selector sel_kernelEndTime = "kernelEndTime";
        private static readonly Selector sel_logs = "logs";
        private static readonly Selector sel_GPUStartTime = "GPUStartTime";
        private static readonly Selector sel_GPUEndTime = "GPUEndTime";
        private static readonly Selector sel_enqueue = "enqueue";
        private static readonly Selector sel_commit = "commit";
        private static readonly Selector sel_presentDrawable = "presentDrawable:";
        private static readonly Selector sel_presentDrawableatTime = "presentDrawable:atTime:";
        private static readonly Selector sel_presentDrawableafterMinimumDuration = "presentDrawable:afterMinimumDuration:";
        private static readonly Selector sel_waitUntilScheduled = "waitUntilScheduled";
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        private static readonly Selector sel_status = "status";
        private static readonly Selector sel_error = "error";
        private static readonly Selector sel_blitCommandEncoder = "blitCommandEncoder";
        private static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_computeCommandEncoderWithDescriptor = "computeCommandEncoderWithDescriptor:";
        private static readonly Selector sel_blitCommandEncoderWithDescriptor = "blitCommandEncoderWithDescriptor:";
        private static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        private static readonly Selector sel_computeCommandEncoderWithDispatchType = "computeCommandEncoderWithDispatchType:";
        private static readonly Selector sel_encodeWaitForEventvalue = "encodeWaitForEvent:value:";
        private static readonly Selector sel_encodeSignalEventvalue = "encodeSignalEvent:value:";
        private static readonly Selector sel_parallelRenderCommandEncoderWithDescriptor = "parallelRenderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_resourceStateCommandEncoder = "resourceStateCommandEncoder";
        private static readonly Selector sel_resourceStateCommandEncoderWithDescriptor = "resourceStateCommandEncoderWithDescriptor:";
        private static readonly Selector sel_accelerationStructureCommandEncoder = "accelerationStructureCommandEncoder";
        private static readonly Selector sel_accelerationStructureCommandEncoderWithDescriptor = "accelerationStructureCommandEncoderWithDescriptor:";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
    }
}
