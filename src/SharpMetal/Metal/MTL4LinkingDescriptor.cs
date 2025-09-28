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

        // missing NSArray BinaryLinkedFunctions

        // missing ulong MaxCallStackDepth

        // missing NSArray PreloadedLibraries
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

        // missing MTL4PipelineStageDynamicLinkingDescriptor FragmentLinkingDescriptor

        // missing MTL4PipelineStageDynamicLinkingDescriptor MeshLinkingDescriptor

        // missing MTL4PipelineStageDynamicLinkingDescriptor ObjectLinkingDescriptor

        // missing MTL4PipelineStageDynamicLinkingDescriptor TileLinkingDescriptor

        // missing MTL4PipelineStageDynamicLinkingDescriptor VertexLinkingDescriptor
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

        // missing NSArray FunctionDescriptors

        // missing NSDictionary Groups

        // missing NSArray PrivateFunctionDescriptors
        private static readonly Selector sel_release = "release";
    }
}
