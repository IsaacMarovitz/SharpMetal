using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
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

        // missing NSString Label

        // missing MTL4PipelineOptions Options
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

        // missing MTL4ShaderReflection ShaderReflection

        // missing MTLShaderValidation ShaderValidation
        private static readonly Selector sel_release = "release";
    }
}
