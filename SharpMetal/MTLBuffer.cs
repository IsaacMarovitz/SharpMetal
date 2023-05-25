using System.Runtime.Versioning;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBuffer buffer) => buffer.NativePtr;
        public MTLBuffer(IntPtr nativePtr) => NativePtr = nativePtr;

        public ulong Length => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_length);

        // public RemoteStorageBuffer

        public ulong GpuAddress => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_gpuAddress);

        private static readonly ObjectiveCRuntime.Selector sel_newTextureWithDescriptorOffsetBytesPerRow = "newTextureWithDescriptor:offset:bytesPerRow:";
        private static readonly ObjectiveCRuntime.Selector sel_contents = "contents";
        private static readonly ObjectiveCRuntime.Selector sel_didModifyRange = "didModifyRange:";
        private static readonly ObjectiveCRuntime.Selector sel_addDebugMarkerRange = "addDebugMarker:range:";
        private static readonly ObjectiveCRuntime.Selector sel_removeAllDebugMarkers = "removeAllDebugMarkers";
        private static readonly ObjectiveCRuntime.Selector sel_length = "length";
        private static readonly ObjectiveCRuntime.Selector sel_newRemoteBufferViewForDevice = "newRemoteBufferViewForDevice:";
        private static readonly ObjectiveCRuntime.Selector sel_remoteStorageBuffer = "remoteStorageBuffer";
        private static readonly ObjectiveCRuntime.Selector sel_gpuAddress = "gpuAddress";
    }
}