using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTL4CompilerTaskStatus : long
    {
        None = 0,
        Scheduled = 1,
        Compiling = 2,
        Finished = 3,
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CompilerTask : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CompilerTask obj) => obj.NativePtr;
        public MTL4CompilerTask(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTL4Compiler Compiler => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_compiler));

        public MTL4CompilerTaskStatus Status => (MTL4CompilerTaskStatus)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_status);

        public void WaitUntilCompleted()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilCompleted);
        }

        private static readonly Selector sel_compiler = "compiler";
        private static readonly Selector sel_status = "status";
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        private static readonly Selector sel_release = "release";
    }
}
