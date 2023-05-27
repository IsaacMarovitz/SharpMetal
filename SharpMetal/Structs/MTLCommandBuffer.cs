using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLCommandBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandBuffer commandBuffer) => commandBuffer.NativePtr;
        public MTLCommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public MTLRenderCommandEncoder RenderCommandEncoderWithDescriptor(MTLRenderPassDescriptor renderPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, renderPassDescriptor));
        }

        public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoderWithDescriptor(MTLRenderPassDescriptor renderPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parallelRenderCommandEncoderWithDescriptor, renderPassDescriptor));
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoderWithDescriptor(MTLAccelerationStructurePassDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_accelerationStructureCommandEncoderWithDescriptor, descriptor));
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_accelerationStructureCommandEncoder));
        }

        // TODO: Needs MTLComputePassDescriptor
        /*public MTLComputeCommandEncoder ComputeCommandEncoderWithDescriptor(MTLComputePassDescriptor computePassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoderWithDescriptor, computePassDescriptor));
        }*/

        public MTLComputeCommandEncoder ComputeCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoder));
        }

        public MTLComputeCommandEncoder ComputeCommandEncoderWithDispatchType(MTLDispatchType dispatchType)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoderWithDispatchType, (uint)dispatchType));
        }

        public MTLBlitCommandEncoder BlitCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_blitCommandEncoder));
        }

        public MTLBlitCommandEncoder BlitCommandEncoderWithDescriptor(MTLBlitPassDescriptor blitPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_blitCommandEncoderWithDescriptor, blitPassDescriptor));
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoderWithDescriptor(MTLResourceStatePassDescriptor resourceStatePassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, resourceStatePassDescriptor));
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceStateCommandEncoder));
        }

        // TODO: Needs a bunch of stuff
        /*public void EncodeWaitForEventValue(MTLEvent mtlEvent, uint value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeWaitForEventValue, mtlEvent, value);
        }

        public void EncodeSignalEventValue(MTLEvent mtlEvent, uint value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeSignalEventValue, mtlEvent, value);
        }

        public void PresentDrawable(MTLDrawable drawable)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawable, drawable);
        }

        public void PresentDrawableAtTime(MTLDrawable drawable, CFTimeInterval presentationTime)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawableAtTime, drawable, presentationTime);
        }

        public void PresentDrawableAfterMinimumDuration(MTLDrawable drawable, CFTimeInterval duration)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawableAfterMinimumDuration, drawable, duration);
        }

        public void AddScheduledHandler(MTLCommandBufferHandler block)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addScheduledHandler, block);
        }

        public void AddCompletedHandler(MTLCommandBufferHandler block)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addCompletedHandler, block);
        }*/

        public void Enqueue()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_enqueue);
        }

        public void Commit()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_commit);
        }

        public void WaitUntilScheduled()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilScheduled);
        }

        public void WaitUntilCompleted()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilCompleted);
        }

        public MTLCommandBufferStatus Status => (MTLCommandBufferStatus)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_status);

        public NSString Label
        {
            get => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_label);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLCommandQueue CommandQueue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandQueue));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        // TODO: Needs NSError
        // public NSError Error => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error);

        public MTLCommandBufferErrorOption ErrorOption => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);

        // TODO: Needs MTLLogContainer
        // public MTLLogContainer Logs => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logs);

        // TODO: Need CFTimeInterval
        /*public CFTimeInterval KernelStartTime => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelStartTime);

        public CFTimeInterval KernelEndTime => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelEndTime);

        public CFTimeInterval GPUStartTime => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUStartTime);

        public CFTimeInterval GPUEndTime => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUEndTime);*/

        public bool RetainedReferences => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);

        private static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_parallelRenderCommandEncoderWithDescriptor = "parallelRenderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_accelerationStructureCommandEncoderWithDescriptor = "accelerationStructureCommandEncoderWithDescriptor:";
        private static readonly Selector sel_accelerationStructureCommandEncoder = "accelerationStructureCommandEncoder";
        private static readonly Selector sel_computeCommandEncoderWithDescriptor = "computeCommandEncoderWithDescriptor:";
        private static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        private static readonly Selector sel_computeCommandEncoderWithDispatchType = "computeCommandEncoderWithDispatchType:";
        private static readonly Selector sel_blitCommandEncoder = "blitCommandEncoder";
        private static readonly Selector sel_blitCommandEncoderWithDescriptor = "blitCommandEncoderWithDescriptor:";
        private static readonly Selector sel_resourceStateCommandEncoderWithDescriptor = "resourceStateCommandEncoderWithDescriptor:";
        private static readonly Selector sel_resourceStateCommandEncoder = "resourceStateCommandEncoder";
        private static readonly Selector sel_encodeWaitForEventValue = "encodeWaitForEvent:value:";
        private static readonly Selector sel_encodeSignalEventValue = "encodeSignalEvent:value:";
        private static readonly Selector sel_presentDrawable = "presentDrawable:";
        private static readonly Selector sel_presentDrawableAtTime = "presentDrawable:atTime:";
        private static readonly Selector sel_presentDrawableAfterMinimumDuration = "presentDrawable:afterMinimumDuration:";
        private static readonly Selector sel_addScheduledHandler = "addScheduledHandler:";
        private static readonly Selector sel_addCompletedHandler = "addCompletedHandler:";
        private static readonly Selector sel_enqueue = "enqueue";
        private static readonly Selector sel_commit = "commit";
        private static readonly Selector sel_waitUntilScheduled = "waitUntilScheduled";
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        private static readonly Selector sel_status = "status";

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_commandQueue = "commandQueue";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_error = "error";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_logs = "logs";
        private static readonly Selector sel_kernelStartTime = "kernelStartTime";
        private static readonly Selector sel_kernelEndTime = "kernelEndTime";
        private static readonly Selector sel_GPUStartTime = "GPUStartTime";
        private static readonly Selector sel_GPUEndTime = "GPUEndTime";
        private static readonly Selector sel_retainedReferences = "retainedReferences";
    }
}