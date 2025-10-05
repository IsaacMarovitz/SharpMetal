using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4ArgumentTable : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ArgumentTable obj) => obj.NativePtr;
        public MTL4ArgumentTable(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public void SetAddress(ulong gpuAddress, ulong bindingIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAddressatIndex, gpuAddress, bindingIndex);
        }

        public void SetAddress(ulong gpuAddress, ulong stride, ulong bindingIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAddressattributeStrideatIndex, gpuAddress, stride, bindingIndex);
        }

        public void SetResource(MTLResourceID resourceID, ulong bindingIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResourceatBufferIndex, resourceID, bindingIndex);
        }

        public void SetSamplerState(MTLResourceID resourceID, ulong bindingIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSamplerStateatIndex, resourceID, bindingIndex);
        }

        public void SetTexture(MTLResourceID resourceID, ulong bindingIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTextureatIndex, resourceID, bindingIndex);
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setAddressatIndex = "setAddress:atIndex:";
        private static readonly Selector sel_setAddressattributeStrideatIndex = "setAddress:attributeStride:atIndex:";
        private static readonly Selector sel_setResourceatBufferIndex = "setResource:atBufferIndex:";
        private static readonly Selector sel_setSamplerStateatIndex = "setSamplerState:atIndex:";
        private static readonly Selector sel_setTextureatIndex = "setTexture:atIndex:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4ArgumentTableDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4ArgumentTableDescriptor obj) => obj.NativePtr;
        public MTL4ArgumentTableDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4ArgumentTableDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4ArgumentTableDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public bool InitializeBindings
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_initializeBindings);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInitializeBindings, value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong MaxBufferBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxBufferBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxBufferBindCount, value);
        }

        public ulong MaxSamplerStateBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxSamplerStateBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxSamplerStateBindCount, value);
        }

        public ulong MaxTextureBindCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTextureBindCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTextureBindCount, value);
        }

        public bool SupportAttributeStrides
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAttributeStrides);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAttributeStrides, value);
        }

        private static readonly Selector sel_initializeBindings = "initializeBindings";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_maxBufferBindCount = "maxBufferBindCount";
        private static readonly Selector sel_maxSamplerStateBindCount = "maxSamplerStateBindCount";
        private static readonly Selector sel_maxTextureBindCount = "maxTextureBindCount";
        private static readonly Selector sel_setInitializeBindings = "setInitializeBindings:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setMaxBufferBindCount = "setMaxBufferBindCount:";
        private static readonly Selector sel_setMaxSamplerStateBindCount = "setMaxSamplerStateBindCount:";
        private static readonly Selector sel_setMaxTextureBindCount = "setMaxTextureBindCount:";
        private static readonly Selector sel_setSupportAttributeStrides = "setSupportAttributeStrides:";
        private static readonly Selector sel_supportAttributeStrides = "supportAttributeStrides";
        private static readonly Selector sel_release = "release";
    }
}
