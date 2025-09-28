using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4Compiler : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4Compiler obj) => obj.NativePtr;
        public MTL4Compiler(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTLDevice Device

        // missing NSString Label

        // missing MTL4PipelineDataSetSerializer PipelineDataSetSerializer
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CompilerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CompilerDescriptor obj) => obj.NativePtr;
        public MTL4CompilerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4CompilerDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4CompilerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing NSString Label

        // missing MTL4PipelineDataSetSerializer PipelineDataSetSerializer
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CompilerTaskOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CompilerTaskOptions obj) => obj.NativePtr;
        public MTL4CompilerTaskOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4CompilerTaskOptions()
        {
            var cls = new ObjectiveCClass("MTL4CompilerTaskOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing NSArray LookupArchives
        private static readonly Selector sel_release = "release";
    }
}
