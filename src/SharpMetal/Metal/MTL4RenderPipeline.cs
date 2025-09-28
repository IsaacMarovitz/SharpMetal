using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineBinaryFunctionsDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineBinaryFunctionsDescriptor obj) => obj.NativePtr;
        public MTL4RenderPipelineBinaryFunctionsDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineBinaryFunctionsDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineBinaryFunctionsDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }





        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineColorAttachmentDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineColorAttachmentDescriptor obj) => obj.NativePtr;
        public MTL4RenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }









        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineColorAttachmentDescriptorArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineColorAttachmentDescriptorArray obj) => obj.NativePtr;
        public MTL4RenderPipelineColorAttachmentDescriptorArray(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineColorAttachmentDescriptorArray()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineColorAttachmentDescriptorArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4PipelineDescriptor(MTL4RenderPipelineDescriptor obj) => new(obj.NativePtr);
        public MTL4RenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }



















        private static readonly Selector sel_release = "release";
    }
}
