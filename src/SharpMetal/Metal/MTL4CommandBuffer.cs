using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4CommandBuffer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandBuffer obj) => obj.NativePtr;
        public MTL4CommandBuffer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4ComputeCommandEncoder ComputeCommandEncoder => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoder));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTL4MachineLearningCommandEncoder MachineLearningCommandEncoder => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_machineLearningCommandEncoder));

        public void BeginCommandBuffer(MTL4CommandAllocator allocator)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_beginCommandBufferWithAllocator, allocator);
        }

        public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_beginCommandBufferWithAllocatoroptions, allocator, options);
        }

        public void EndCommandBuffer()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endCommandBuffer);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        public void PushDebugGroup(NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, descriptor));
        }

        public MTL4RenderCommandEncoder RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptoroptions, descriptor, (ulong)options));
        }

        public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_resolveCounterHeapwithRangeintoBufferwaitFenceupdateFence, counterHeap, range, bufferRange, fenceToWait, fenceToUpdate);
        }

        public void UseResidencySet(MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResidencySet, residencySet);
        }

        public void UseResidencySets(MTLResidencySet[] residencySets, ulong count)
        {
            fixed (MTLResidencySet* residencySetsPtr = residencySets)
            {
                ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResidencySetscount, residencySetsPtr, count);
            }
        }

        public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_writeTimestampIntoHeapatIndex, counterHeap, index);
        }

        private static readonly Selector sel_beginCommandBufferWithAllocator = "beginCommandBufferWithAllocator:";
        private static readonly Selector sel_beginCommandBufferWithAllocatoroptions = "beginCommandBufferWithAllocator:options:";
        private static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_endCommandBuffer = "endCommandBuffer";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_machineLearningCommandEncoder = "machineLearningCommandEncoder";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_renderCommandEncoderWithDescriptoroptions = "renderCommandEncoderWithDescriptor:options:";
        private static readonly Selector sel_resolveCounterHeapwithRangeintoBufferwaitFenceupdateFence = "resolveCounterHeap:withRange:intoBuffer:waitFence:updateFence:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_useResidencySet = "useResidencySet:";
        private static readonly Selector sel_useResidencySetscount = "useResidencySets:count:";
        private static readonly Selector sel_writeTimestampIntoHeapatIndex = "writeTimestampIntoHeap:atIndex:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandBufferOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandBufferOptions obj) => obj.NativePtr;
        public MTL4CommandBufferOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommandBufferOptions()
        {
            var cls = new ObjectiveCClass("MTL4CommandBufferOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLLogState LogState
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logState));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogState, value);
        }

        private static readonly Selector sel_logState = "logState";
        private static readonly Selector sel_setLogState = "setLogState:";
        private static readonly Selector sel_release = "release";
    }
}
