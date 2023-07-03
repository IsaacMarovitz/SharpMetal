using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLArgumentEncoder
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

        public void SetLabel(NSString label) {

        }

        public void SetArgumentBuffer(MTLBuffer argumentBuffer, ulong offset) {

        }

        public void SetArgumentBuffer(MTLBuffer argumentBuffer, ulong startOffset, ulong arrayElement) {

        }

        public void SetBuffer(MTLBuffer buffer, ulong offset, ulong index) {

        }

        public void SetBuffers(MTLBuffer[] buffers, ulong[] offsets, NSRange range) {

        }

        public void SetTexture(MTLTexture texture, ulong index) {

        }

        public void SetTextures(MTLTexture[] textures, NSRange range) {

        }

        public void SetSamplerState(MTLSamplerState sampler, ulong index) {

        }

        public void SetSamplerStates(MTLSamplerState[] samplers, NSRange range) {

        }

        public IntPtr ConstantData(ulong index) {

        }

        public void SetRenderPipelineState(MTLRenderPipelineState pipeline, ulong index) {

        }

        public void SetRenderPipelineStates(MTLRenderPipelineState[] pipelines, NSRange range) {

        }

        public void SetComputePipelineState(MTLComputePipelineState pipeline, ulong index) {

        }

        public void SetComputePipelineStates(MTLComputePipelineState[] pipelines, NSRange range) {

        }

        public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, ulong index) {

        }

        public void SetIndirectCommandBuffers(MTLIndirectCommandBuffer[] buffers, NSRange range) {

        }

        public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, ulong index) {

        }

        public MTLArgumentEncoder NewArgumentEncoder(ulong index) {

        }

        public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, ulong index) {

        }

        public void SetVisibleFunctionTables(MTLVisibleFunctionTable[] visibleFunctionTables, NSRange range) {

        }

        public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, ulong index) {

        }

        public void SetIntersectionFunctionTables(MTLIntersectionFunctionTable[] intersectionFunctionTables, NSRange range) {

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
