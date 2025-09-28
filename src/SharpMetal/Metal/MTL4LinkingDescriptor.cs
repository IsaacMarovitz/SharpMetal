using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4PipelineStageDynamicLinkingDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PipelineStageDynamicLinkingDescriptor obj) => obj.NativePtr;
        public MTL4PipelineStageDynamicLinkingDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4PipelineStageDynamicLinkingDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4PipelineStageDynamicLinkingDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }



        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4RenderPipelineDynamicLinkingDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4RenderPipelineDynamicLinkingDescriptor obj) => obj.NativePtr;
        public MTL4RenderPipelineDynamicLinkingDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4RenderPipelineDynamicLinkingDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4RenderPipelineDynamicLinkingDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }





        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4StaticLinkingDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4StaticLinkingDescriptor obj) => obj.NativePtr;
        public MTL4StaticLinkingDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4StaticLinkingDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4StaticLinkingDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }



        private static readonly Selector sel_release = "release";
    }
}
