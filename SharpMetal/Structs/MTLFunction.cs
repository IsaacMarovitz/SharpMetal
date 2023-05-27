using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLFunction
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunction mtlFunction) => mtlFunction.NativePtr;
        public MTLFunction(IntPtr ptr) => NativePtr = ptr;

        public MTLFunction()
        {
            var cls = new ObjectiveCClass("MTLFunction");
            NativePtr = cls.AllocInit();
        }

    }
}