using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4MachineLearningCommandEncoder : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4MachineLearningCommandEncoder obj) => obj.NativePtr;
        public static implicit operator MTL4CommandEncoder(MTL4MachineLearningCommandEncoder obj) => new(obj.NativePtr);
        public MTL4MachineLearningCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTL4CommandBuffer CommandBuffer

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }
}
