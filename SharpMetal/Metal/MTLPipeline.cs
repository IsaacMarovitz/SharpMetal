using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLMutability : ulong
    {
        Default = 0,
        Mutable = 1,
        Immutable = 2,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLPipelineBufferDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPipelineBufferDescriptor obj) => obj.NativePtr;
        public MTLPipelineBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLPipelineBufferDescriptor()
        {
            var cls = new ObjectiveCClass("MTLPipelineBufferDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLMutability Mutability
        {
            get => (MTLMutability)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mutability);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMutability, (ulong)value);
        }

        public void SetMutability(MTLMutability mutability)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMutability, (ulong)mutability);
        }

        private static readonly Selector sel_mutability = "mutability";
        private static readonly Selector sel_setMutability = "setMutability:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLPipelineBufferDescriptorArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLPipelineBufferDescriptorArray obj) => obj.NativePtr;
        public MTLPipelineBufferDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTLPipelineBufferDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTLPipelineBufferDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public MTLPipelineBufferDescriptor Object(ulong bufferIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, bufferIndex));
        }

        public void SetObject(MTLPipelineBufferDescriptor buffer, ulong bufferIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, buffer, bufferIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }
}
