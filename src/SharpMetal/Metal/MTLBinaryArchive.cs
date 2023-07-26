using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLBinaryArchiveError : ulong
    {
        None = 0,
        InvalidFile = 1,
        UnexpectedElement = 2,
        CompilationFailure = 3,
        InternalError = 4,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLBinaryArchiveDescriptor
    {
        public IntPtr NativePtr;
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
    public partial class MTLBinaryArchive
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBinaryArchive obj) => obj.NativePtr;
        public MTLBinaryArchive(IntPtr ptr) => NativePtr = ptr;

        protected MTLBinaryArchive()
        {
            throw new NotImplementedException();
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, ref NSError error)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_addComputePipelineFunctionsWithDescriptorerror, descriptor, ref error.NativePtr);
        }

        public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, ref NSError error)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_addRenderPipelineFunctionsWithDescriptorerror, descriptor, ref error.NativePtr);
        }

        public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, ref NSError error)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_addTileRenderPipelineFunctionsWithDescriptorerror, descriptor, ref error.NativePtr);
        }

        public bool SerializeToURL(NSURL url, ref NSError error)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_serializeToURLerror, url, ref error.NativePtr);
        }

        public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, ref NSError error)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_addFunctionWithDescriptorlibraryerror, descriptor, library, ref error.NativePtr);
        }

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
