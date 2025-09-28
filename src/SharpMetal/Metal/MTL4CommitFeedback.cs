using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4CommitFeedback : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommitFeedback obj) => obj.NativePtr;
        public MTL4CommitFeedback(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSError Error => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error));

        public IntPtr GPUEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUEndTime));

        public IntPtr GPUStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUStartTime));

        private static readonly Selector sel_error = "error";
        private static readonly Selector sel_GPUEndTime = "GPUEndTime";
        private static readonly Selector sel_GPUStartTime = "GPUStartTime";
        private static readonly Selector sel_release = "release";
    }
}
