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

        public NSArray BinaryLinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryLinkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryLinkedFunctions, value);
        }

        public ulong MaxCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCallStackDepth, value);
        }

        public NSArray PreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreloadedLibraries, value);
        }

        private static readonly Selector sel_binaryLinkedFunctions = "binaryLinkedFunctions";
        private static readonly Selector sel_maxCallStackDepth = "maxCallStackDepth";
        private static readonly Selector sel_preloadedLibraries = "preloadedLibraries";
        private static readonly Selector sel_setBinaryLinkedFunctions = "setBinaryLinkedFunctions:";
        private static readonly Selector sel_setMaxCallStackDepth = "setMaxCallStackDepth:";
        private static readonly Selector sel_setPreloadedLibraries = "setPreloadedLibraries:";
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

        public MTL4PipelineStageDynamicLinkingDescriptor FragmentLinkingDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fragmentLinkingDescriptor));

        public MTL4PipelineStageDynamicLinkingDescriptor MeshLinkingDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_meshLinkingDescriptor));

        public MTL4PipelineStageDynamicLinkingDescriptor ObjectLinkingDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectLinkingDescriptor));

        public MTL4PipelineStageDynamicLinkingDescriptor TileLinkingDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_tileLinkingDescriptor));

        public MTL4PipelineStageDynamicLinkingDescriptor VertexLinkingDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexLinkingDescriptor));

        private static readonly Selector sel_fragmentLinkingDescriptor = "fragmentLinkingDescriptor";
        private static readonly Selector sel_meshLinkingDescriptor = "meshLinkingDescriptor";
        private static readonly Selector sel_objectLinkingDescriptor = "objectLinkingDescriptor";
        private static readonly Selector sel_tileLinkingDescriptor = "tileLinkingDescriptor";
        private static readonly Selector sel_vertexLinkingDescriptor = "vertexLinkingDescriptor";
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

        public NSArray FunctionDescriptors
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionDescriptors));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionDescriptors, value);
        }

        public NSDictionary Groups
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_groups));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setGroups, value);
        }

        public NSArray PrivateFunctionDescriptors
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_privateFunctionDescriptors));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrivateFunctionDescriptors, value);
        }

        private static readonly Selector sel_functionDescriptors = "functionDescriptors";
        private static readonly Selector sel_groups = "groups";
        private static readonly Selector sel_privateFunctionDescriptors = "privateFunctionDescriptors";
        private static readonly Selector sel_setFunctionDescriptors = "setFunctionDescriptors:";
        private static readonly Selector sel_setGroups = "setGroups:";
        private static readonly Selector sel_setPrivateFunctionDescriptors = "setPrivateFunctionDescriptors:";
        private static readonly Selector sel_release = "release";
    }
}
