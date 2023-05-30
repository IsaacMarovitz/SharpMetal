using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLSamplerMinMagFilter: ulong
    {
        Nearest = 0,
        Linear = 1,
    }

    public enum MTLSamplerMipFilter: ulong
    {
        NotMipmapped = 0,
        Nearest = 1,
        Linear = 2,
    }

    public enum MTLSamplerAddressMode: ulong
    {
        ClampToEdge = 0,
        MirrorClampToEdge = 1,
        Repeat = 2,
        MirrorRepeat = 3,
        ClampToZero = 4,
        ClampToBorderColor = 5,
    }

    public enum MTLSamplerBorderColor: ulong
    {
        TransparentBlack = 0,
        OpaqueBlack = 1,
        OpaqueWhite = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLSamplerDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerDescriptor obj) => obj.NativePtr;
        public MTLSamplerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLSamplerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLSamplerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLSamplerMinMagFilter MinFilter => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_minFilter);
        public MTLSamplerMinMagFilter MagFilter => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_magFilter);
        public MTLSamplerMipFilter MipFilter => (MTLSamplerMipFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipFilter);
        public ulong MaxAnisotropy => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxAnisotropy);
        public MTLSamplerAddressMode SAddressMode => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sAddressMode);
        public MTLSamplerAddressMode TAddressMode => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tAddressMode);
        public MTLSamplerAddressMode RAddressMode => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rAddressMode);
        public MTLSamplerBorderColor BorderColor => (MTLSamplerBorderColor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_borderColor);
        public bool NormalizedCoordinates => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_normalizedCoordinates);
        public float LodMinClamp => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMinClamp);
        public float LodMaxClamp => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMaxClamp);
        public bool LodAverage => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_lodAverage);
        public MTLCompareFunction CompareFunction => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_compareFunction);
        public bool SupportArgumentBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportArgumentBuffers);
        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_minFilter = "minFilter";
        private static readonly Selector sel_setMinFilter = "setMinFilter:";
        private static readonly Selector sel_magFilter = "magFilter";
        private static readonly Selector sel_setMagFilter = "setMagFilter:";
        private static readonly Selector sel_mipFilter = "mipFilter";
        private static readonly Selector sel_setMipFilter = "setMipFilter:";
        private static readonly Selector sel_maxAnisotropy = "maxAnisotropy";
        private static readonly Selector sel_setMaxAnisotropy = "setMaxAnisotropy:";
        private static readonly Selector sel_sAddressMode = "sAddressMode";
        private static readonly Selector sel_setSAddressMode = "setSAddressMode:";
        private static readonly Selector sel_tAddressMode = "tAddressMode";
        private static readonly Selector sel_setTAddressMode = "setTAddressMode:";
        private static readonly Selector sel_rAddressMode = "rAddressMode";
        private static readonly Selector sel_setRAddressMode = "setRAddressMode:";
        private static readonly Selector sel_borderColor = "borderColor";
        private static readonly Selector sel_setBorderColor = "setBorderColor:";
        private static readonly Selector sel_normalizedCoordinates = "normalizedCoordinates";
        private static readonly Selector sel_setNormalizedCoordinates = "setNormalizedCoordinates:";
        private static readonly Selector sel_lodMinClamp = "lodMinClamp";
        private static readonly Selector sel_setLodMinClamp = "setLodMinClamp:";
        private static readonly Selector sel_lodMaxClamp = "lodMaxClamp";
        private static readonly Selector sel_setLodMaxClamp = "setLodMaxClamp:";
        private static readonly Selector sel_lodAverage = "lodAverage";
        private static readonly Selector sel_setLodAverage = "setLodAverage:";
        private static readonly Selector sel_compareFunction = "compareFunction";
        private static readonly Selector sel_setCompareFunction = "setCompareFunction:";
        private static readonly Selector sel_supportArgumentBuffers = "supportArgumentBuffers";
        private static readonly Selector sel_setSupportArgumentBuffers = "setSupportArgumentBuffers:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLSamplerState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerState obj) => obj.NativePtr;
        public MTLSamplerState(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public MTLResourceID GpuResourceID => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_gpuResourceID));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
    }
}
