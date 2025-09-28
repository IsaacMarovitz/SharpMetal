using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4PipelineDataSetSerializer : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PipelineDataSetSerializer obj) => obj.NativePtr;
        public MTL4PipelineDataSetSerializer(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4PipelineDataSetSerializerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PipelineDataSetSerializerDescriptor obj) => obj.NativePtr;
        public MTL4PipelineDataSetSerializerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4PipelineDataSetSerializerDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4PipelineDataSetSerializerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTL4PipelineDataSetSerializerConfiguration Configuration
        private static readonly Selector sel_release = "release";
    }
}
