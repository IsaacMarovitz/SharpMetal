using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4CopySparseBufferMappingOperation
    {
        public NSRange sourceRange;
        public ulong destinationOffset;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4CopySparseTextureMappingOperation
    {
        public MTLRegion sourceRegion;
        public ulong sourceLevel;
        public ulong sourceSlice;
        public MTLOrigin destinationOrigin;
        public ulong destinationLevel;
        public ulong destinationSlice;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4UpdateSparseBufferMappingOperation
    {
        public MTLSparseTextureMappingMode mode;
        public NSRange bufferRange;
        public ulong heapOffset;
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTL4UpdateSparseTextureMappingOperation
    {
        public MTLSparseTextureMappingMode mode;
        public MTLRegion textureRegion;
        public ulong textureLevel;
        public ulong textureSlice;
        public ulong heapOffset;
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandQueue : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandQueue obj) => obj.NativePtr;
        public MTL4CommandQueue(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing MTLDevice Device

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommandQueueDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommandQueueDescriptor obj) => obj.NativePtr;
        public MTL4CommandQueueDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommandQueueDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4CommandQueueDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        // missing IntPtr FeedbackQueue

        // missing NSString Label
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4CommitOptions : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4CommitOptions obj) => obj.NativePtr;
        public MTL4CommitOptions(IntPtr ptr) => NativePtr = ptr;

        public MTL4CommitOptions()
        {
            var cls = new ObjectiveCClass("MTL4CommitOptions");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }
        private static readonly Selector sel_release = "release";
    }
}
