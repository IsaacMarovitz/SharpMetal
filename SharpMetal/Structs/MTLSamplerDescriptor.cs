using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLSamplerDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerDescriptor samplerDescriptor) => samplerDescriptor.NativePtr;
        public MTLSamplerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public bool NormalizedCoordinates
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_normalizedCoordinates);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNoramlizedCoordinates, value);
        }

        public MTLSamplerAddressMode RAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRAddressMode, (ulong)value);
        }

        public MTLSamplerAddressMode SAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSAddressMode, (ulong)value);
        }

        public MTLSamplerAddressMode TAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTAddressMode, (ulong)value);
        }

        public MTLSamplerBorderColor BorderColor
        {
            get => (MTLSamplerBorderColor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_borderColor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBorderColor, (ulong)value);
        }

        public MTLSamplerMinMagFilter MinFilter
        {
            get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_minFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMinFilter, (ulong)value);
        }

        public MTLSamplerMinMagFilter MagFilter
        {
            get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_magFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMagFilter, (ulong)value);
        }

        public MTLSamplerMipFilter MipFilter
        {
            get => (MTLSamplerMipFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMipFilter, (ulong)value);
        }

        public float LodMinClamp
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMinClamp);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMinClamp, value);
        }

        public float LodMaxClamp
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMaxClamp);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMaxClamp, value);
        }

        public bool LodAverage
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_lodAverage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodAverage, value);
        }

        public ulong MaxAnisotropy
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxAnisotropy);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxAnisotropy, value);
        }

        public MTLCompareFunction CompareFunction
        {
            get => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_compareFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompareFuncation, (ulong)value);
        }

        public bool SupportsArgumentBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportArgumentBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportArgumentBuffers, value);
        }

        public NSString Label
        {
            get => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_label);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        private static readonly Selector sel_normalizedCoordinates = "normalizedCoordinates";
        private static readonly Selector sel_setNoramlizedCoordinates = "setNormalizedCoordinates:";
        private static readonly Selector sel_rAddressMode = "rAddressMode";
        private static readonly Selector sel_setRAddressMode = "setRAddressMode:";
        private static readonly Selector sel_sAddressMode = "sAddressMode";
        private static readonly Selector sel_setSAddressMode = "setSAddressMode:";
        private static readonly Selector sel_tAddressMode = "tAddressMode";
        private static readonly Selector sel_setTAddressMode = "setTAddressMode:";
        private static readonly Selector sel_borderColor = "borderColor";
        private static readonly Selector sel_setBorderColor = "setBorderColor:";
        private static readonly Selector sel_minFilter = "minFilter";
        private static readonly Selector sel_setMinFilter = "setMinFilter:";
        private static readonly Selector sel_magFilter = "magFilter";
        private static readonly Selector sel_setMagFilter = "setMagFilter:";
        private static readonly Selector sel_mipFilter = "mipFilter";
        private static readonly Selector sel_setMipFilter = "setMipFilter:";
        private static readonly Selector sel_lodMinClamp = "lodMinClamp";
        private static readonly Selector sel_setLodMinClamp = "setLodMinClamp:";
        private static readonly Selector sel_lodMaxClamp = "lodMaxClamp";
        private static readonly Selector sel_setLodMaxClamp = "setLodMaxClamp:";
        private static readonly Selector sel_lodAverage = "lodAverage";
        private static readonly Selector sel_setLodAverage = "setLodAverage:";
        private static readonly Selector sel_maxAnisotropy = "maxAnisotropy";
        private static readonly Selector sel_setMaxAnisotropy = "setMaxAnisotropy:";
        private static readonly Selector sel_compareFunction = "compareFunction";
        private static readonly Selector sel_setCompareFuncation = "setCompareFunction:";
        private static readonly Selector sel_supportArgumentBuffers = "supportArgumentBuffers";
        private static readonly Selector sel_setSupportArgumentBuffers = "setSupportArgumentBuffers:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel";
    }
}