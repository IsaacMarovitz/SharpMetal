using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLSamplerAddressMode : ulong
    {
        ClampToEdge = 0,
        MirrorClampToEdge = 1,
        Repeat = 2,
        MirrorRepeat = 3,
        ClampToZero = 4,
        ClampToBorderColor = 5,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLSamplerBorderColor : ulong
    {
        TransparentBlack = 0,
        OpaqueBlack = 1,
        OpaqueWhite = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLSamplerMinMagFilter : ulong
    {
        Nearest = 0,
        Linear = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLSamplerMipFilter : ulong
    {
        NotMipmapped = 0,
        Nearest = 1,
        Linear = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLSamplerReductionMode : ulong
    {
        WeightedAverage = 0,
        Minimum = 1,
        Maximum = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLSamplerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerDescriptor obj) => obj.NativePtr;
        public MTLSamplerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLSamplerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLSamplerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLSamplerBorderColor BorderColor
        {
            get => (MTLSamplerBorderColor)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_borderColor);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBorderColor, (ulong)value);
        }

        public MTLCompareFunction CompareFunction
        {
            get => (MTLCompareFunction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_compareFunction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompareFunction, (ulong)value);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public bool LodAverage
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_lodAverage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodAverage, value);
        }

        public float LodBias
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodBias);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodBias, value);
        }

        public float LodMaxClamp
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMaxClamp);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMaxClamp, value);
        }

        public float LodMinClamp
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodMinClamp);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodMinClamp, value);
        }

        public MTLSamplerMinMagFilter MagFilter
        {
            get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_magFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMagFilter, (ulong)value);
        }

        public ulong MaxAnisotropy
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxAnisotropy);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxAnisotropy, value);
        }

        public MTLSamplerMinMagFilter MinFilter
        {
            get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_minFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMinFilter, (ulong)value);
        }

        public MTLSamplerMipFilter MipFilter
        {
            get => (MTLSamplerMipFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_mipFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMipFilter, (ulong)value);
        }

        public bool NormalizedCoordinates
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_normalizedCoordinates);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNormalizedCoordinates, value);
        }

        public MTLSamplerAddressMode RAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_rAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRAddressMode, (ulong)value);
        }

        public MTLSamplerReductionMode ReductionMode
        {
            get => (MTLSamplerReductionMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_reductionMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setReductionMode, (ulong)value);
        }

        public MTLSamplerAddressMode SAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_sAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSAddressMode, (ulong)value);
        }

        public bool SupportArgumentBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportArgumentBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportArgumentBuffers, value);
        }

        public MTLSamplerAddressMode TAddressMode
        {
            get => (MTLSamplerAddressMode)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_tAddressMode);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTAddressMode, (ulong)value);
        }

        private static readonly Selector sel_borderColor = "borderColor";
        private static readonly Selector sel_compareFunction = "compareFunction";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_lodAverage = "lodAverage";
        private static readonly Selector sel_lodBias = "lodBias";
        private static readonly Selector sel_lodMaxClamp = "lodMaxClamp";
        private static readonly Selector sel_lodMinClamp = "lodMinClamp";
        private static readonly Selector sel_magFilter = "magFilter";
        private static readonly Selector sel_maxAnisotropy = "maxAnisotropy";
        private static readonly Selector sel_minFilter = "minFilter";
        private static readonly Selector sel_mipFilter = "mipFilter";
        private static readonly Selector sel_normalizedCoordinates = "normalizedCoordinates";
        private static readonly Selector sel_rAddressMode = "rAddressMode";
        private static readonly Selector sel_reductionMode = "reductionMode";
        private static readonly Selector sel_sAddressMode = "sAddressMode";
        private static readonly Selector sel_setBorderColor = "setBorderColor:";
        private static readonly Selector sel_setCompareFunction = "setCompareFunction:";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setLodAverage = "setLodAverage:";
        private static readonly Selector sel_setLodBias = "setLodBias:";
        private static readonly Selector sel_setLodMaxClamp = "setLodMaxClamp:";
        private static readonly Selector sel_setLodMinClamp = "setLodMinClamp:";
        private static readonly Selector sel_setMagFilter = "setMagFilter:";
        private static readonly Selector sel_setMaxAnisotropy = "setMaxAnisotropy:";
        private static readonly Selector sel_setMinFilter = "setMinFilter:";
        private static readonly Selector sel_setMipFilter = "setMipFilter:";
        private static readonly Selector sel_setNormalizedCoordinates = "setNormalizedCoordinates:";
        private static readonly Selector sel_setRAddressMode = "setRAddressMode:";
        private static readonly Selector sel_setReductionMode = "setReductionMode:";
        private static readonly Selector sel_setSAddressMode = "setSAddressMode:";
        private static readonly Selector sel_setSupportArgumentBuffers = "setSupportArgumentBuffers:";
        private static readonly Selector sel_setTAddressMode = "setTAddressMode:";
        private static readonly Selector sel_supportArgumentBuffers = "supportArgumentBuffers";
        private static readonly Selector sel_tAddressMode = "tAddressMode";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLSamplerState : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSamplerState obj) => obj.NativePtr;
        public MTLSamplerState(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_release = "release";
    }
}
