using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4AlphaToCoverageState : long
    {
        Disabled = 0,
        Enabled = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTL4AlphaToOneState : long
    {
        Disabled = 0,
        Enabled = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTL4BlendState : long
    {
        Disabled = 0,
        Enabled = 1,
        Unspecialized = 2,
    }

    [SupportedOSPlatform("macos")]
    public enum MTL4IndirectCommandBufferSupportState : long
    {
        Disabled = 0,
        Enabled = 1,
    }

    [SupportedOSPlatform("macos")]
    public enum MTL4ShaderReflection : ulong
    {
        None = 0,
        BindingInfo = 1,
        BufferTypeInfo = 1 << 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4PipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PipelineDescriptor obj) => obj.NativePtr;
        public MTL4PipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4PipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4PipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTL4PipelineOptions Options
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_options));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, value);
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4PipelineOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PipelineOptions obj) => obj.NativePtr;
        public MTL4PipelineOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4PipelineOptions()
        {
            var cls = new ObjectiveCClass("MTL4PipelineOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4ShaderReflection ShaderReflection
        {
            get => (MTL4ShaderReflection)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_shaderReflection);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShaderReflection, (ulong)value);
        }

        public MTLShaderValidation ShaderValidation
        {
            get => (MTLShaderValidation)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_shaderValidation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShaderValidation, (long)value);
        }

        private static readonly Selector sel_setShaderReflection = "setShaderReflection:";
        private static readonly Selector sel_setShaderValidation = "setShaderValidation:";
        private static readonly Selector sel_shaderReflection = "shaderReflection";
        private static readonly Selector sel_shaderValidation = "shaderValidation";
        private static readonly Selector sel_release = "release";
    }
}
