using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLBinaryArchiveError: ulong
    {
        None = 0,
        InvalidFile = 1,
        UnexpectedElement = 2,
        CompilationFailure = 3,
        InternalError = 4,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLBinaryArchiveDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBinaryArchiveDescriptor obj) => obj.NativePtr;
        public MTLBinaryArchiveDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLBinaryArchiveDescriptor()
        {
            var cls = new ObjectiveCClass("MTLBinaryArchiveDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSURL Url
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_url));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUrl, value);
        }

        private static readonly Selector sel_url = "url";
        private static readonly Selector sel_setUrl = "setUrl:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLBinaryArchive
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBinaryArchive obj) => obj.NativePtr;
        public MTLBinaryArchive(IntPtr ptr) => NativePtr = ptr;

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_addComputePipelineFunctionsWithDescriptorerror = "addComputePipelineFunctionsWithDescriptor:error:";
        private static readonly Selector sel_addRenderPipelineFunctionsWithDescriptorerror = "addRenderPipelineFunctionsWithDescriptor:error:";
        private static readonly Selector sel_addTileRenderPipelineFunctionsWithDescriptorerror = "addTileRenderPipelineFunctionsWithDescriptor:error:";
        private static readonly Selector sel_serializeToURLerror = "serializeToURL:error:";
        private static readonly Selector sel_addFunctionWithDescriptorlibraryerror = "addFunctionWithDescriptor:library:error:";
    }
}
