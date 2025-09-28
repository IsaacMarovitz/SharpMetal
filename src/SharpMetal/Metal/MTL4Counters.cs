using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4TimestampHeapEntry
    {
        public ulong timestamp;
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CounterHeap : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CounterHeap obj) => obj.NativePtr;
        public MTL4CounterHeap(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing ulong Count

        // missing NSString Label

        // missing MTL4CounterHeapType Type
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CounterHeapDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CounterHeapDescriptor obj) => obj.NativePtr;
        public MTL4CounterHeapDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4CounterHeapDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4CounterHeapDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing ulong Count

        // missing MTL4CounterHeapType Type
        private static readonly Selector sel_release = "release";
    }
}
