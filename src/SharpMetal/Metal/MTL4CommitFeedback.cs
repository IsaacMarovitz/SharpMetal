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

        // missing NSError Error

        // missing IntPtr GPUEndTime

        // missing IntPtr GPUStartTime
        private static readonly Selector sel_release = "release";
    }
}
