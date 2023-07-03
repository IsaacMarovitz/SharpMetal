using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLArgumentEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLArgumentEncoder obj) => obj.NativePtr;
        public MTLArgumentEncoder(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong EncodedLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_encodedLength);

        public ulong Alignment => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_alignment);

        public void SetLabel(NSString label)
        {
            objc_msgSend(NativePtr, , label);
        }

        public void SetArgumentBuffer(MTLBuffer argumentBuffer, ulong offset)
        {
            objc_msgSend(NativePtr, , argumentBuffer, offset);
        }

        public void SetArgumentBuffer(MTLBuffer argumentBuffer, ulong startOffset, ulong arrayElement)
        {
            objc_msgSend(NativePtr, , argumentBuffer, startOffset, arrayElement);
        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index)
        {
            objc_msgSend(NativePtr, , buffer, offset, index);
        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, offsets, range);
        }

        public void SetTexture(MTLTexture texture, ulong index)
        {
            objc_msgSend(NativePtr, , texture, index);
        }

        public void SetTextures(MTLTexture[] textures, NSRange range)
        {
            objc_msgSend(NativePtr, , textures, range);
        }

        public void SetSamplerState(MTLSamplerState sampler, ulong index)
        {
            objc_msgSend(NativePtr, , sampler, index);
        }

        public void SetSamplerStates(MTLSamplerState[] samplers, NSRange range)
        {
            objc_msgSend(NativePtr, , samplers, range);
        }

        public IntPtr ConstantData(ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetRenderPipelineState(MTLRenderPipelineState pipeline, ulong index)
        {
            objc_msgSend(NativePtr, , pipeline, index);
        }

        public void SetRenderPipelineStates(MTLRenderPipelineState[] pipelines, NSRange range)
        {
            objc_msgSend(NativePtr, , pipelines, range);
        }

        public void SetComputePipelineState(MTLComputePipelineState pipeline, ulong index)
        {
            objc_msgSend(NativePtr, , pipeline, index);
        }

        public void SetComputePipelineStates(MTLComputePipelineState[] pipelines, NSRange range)
        {
            objc_msgSend(NativePtr, , pipelines, range);
        }

        public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, ulong index)
        {
            objc_msgSend(NativePtr, , indirectCommandBuffer, index);
        }

        public void SetIndirectCommandBuffers(MTLIndirectCommandBuffer[] buffers, NSRange range)
        {
            objc_msgSend(NativePtr, , buffers, range);
        }

        public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong index)
        {
            objc_msgSend(NativePtr, , accelerationStructure, index);
        }

        public MTLArgumentEncoder NewArgumentEncoder(ulong index)
        {
            throw new NotImplementedException();
        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, ulong index)
        {
            objc_msgSend(NativePtr, , visibleFunctionTable, index);
        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , visibleFunctionTables, range);
        }

        public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong index)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTable, index);
        }

        public void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range)
        {
            objc_msgSend(NativePtr, , intersectionFunctionTables, range);
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_encodedLength = "encodedLength";
        private static readonly Selector sel_alignment = "alignment";
        private static readonly Selector sel_setArgumentBufferoffset = "setArgumentBuffer:offset:";
        private static readonly Selector sel_setArgumentBufferstartOffsetarrayElement = "setArgumentBuffer:startOffset:arrayElement:";
        private static readonly Selector sel_setBufferoffsetatIndex = "setBuffer:offset:atIndex:";
        private static readonly Selector sel_setBuffersoffsetswithRange = "setBuffers:offsets:withRange:";
        private static readonly Selector sel_setTextureatIndex = "setTexture:atIndex:";
        private static readonly Selector sel_setTextureswithRange = "setTextures:withRange:";
        private static readonly Selector sel_setSamplerStateatIndex = "setSamplerState:atIndex:";
        private static readonly Selector sel_setSamplerStateswithRange = "setSamplerStates:withRange:";
        private static readonly Selector sel_constantDataAtIndex = "constantDataAtIndex:";
        private static readonly Selector sel_setRenderPipelineStateatIndex = "setRenderPipelineState:atIndex:";
        private static readonly Selector sel_setRenderPipelineStateswithRange = "setRenderPipelineStates:withRange:";
        private static readonly Selector sel_setComputePipelineStateatIndex = "setComputePipelineState:atIndex:";
        private static readonly Selector sel_setComputePipelineStateswithRange = "setComputePipelineStates:withRange:";
        private static readonly Selector sel_setIndirectCommandBufferatIndex = "setIndirectCommandBuffer:atIndex:";
        private static readonly Selector sel_setIndirectCommandBufferswithRange = "setIndirectCommandBuffers:withRange:";
        private static readonly Selector sel_setAccelerationStructureatIndex = "setAccelerationStructure:atIndex:";
        private static readonly Selector sel_newArgumentEncoderForBufferAtIndex = "newArgumentEncoderForBufferAtIndex:";
        private static readonly Selector sel_setVisibleFunctionTableatIndex = "setVisibleFunctionTable:atIndex:";
        private static readonly Selector sel_setVisibleFunctionTableswithRange = "setVisibleFunctionTables:withRange:";
        private static readonly Selector sel_setIntersectionFunctionTableatIndex = "setIntersectionFunctionTable:atIndex:";
        private static readonly Selector sel_setIntersectionFunctionTableswithRange = "setIntersectionFunctionTables:withRange:";
    }
}
