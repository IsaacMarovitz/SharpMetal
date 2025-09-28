using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4PipelineDataSetSerializerConfiguration : ulong
    {
        CaptureDescriptors = 1,
        CaptureBinaries = 1 << 1,
    }

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

        public bool SerializeAsArchiveAndFlushToURL(NSURL url, ref NSError error)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_serializeAsArchiveAndFlushToURLerror, url, ref error.NativePtr);
        }

        public NSData SerializeAsPipelinesScript(ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_serializeAsPipelinesScriptWithError, ref error.NativePtr));
        }

        private static readonly Selector sel_serializeAsArchiveAndFlushToURLerror = "serializeAsArchiveAndFlushToURL:error:";
        private static readonly Selector sel_serializeAsPipelinesScriptWithError = "serializeAsPipelinesScriptWithError:";
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

        public MTL4PipelineDataSetSerializerConfiguration Configuration
        {
            get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_configuration);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConfiguration, (ulong)value);
        }

        private static readonly Selector sel_configuration = "configuration";
        private static readonly Selector sel_setConfiguration = "setConfiguration:";
        private static readonly Selector sel_release = "release";
    }
}
