using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLBuffer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLBuffer obj) => obj.NativePtr;
        public MTLBuffer(IntPtr ptr) => NativePtr = ptr;

        public ulong Length => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_length);

        public IntPtr Contents => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_contents));

        public MTLBuffer RemoteStorageBuffer => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_remoteStorageBuffer));

        public ulong GpuAddress => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_gpuAddress);

        public void DidModifyRange(NSRange range) {

        }

        public MTLTexture NewTexture(MTLTextureDescriptor descriptor, ulong offset, ulong bytesPerRow) {

        }

        public void AddDebugMarker(NSString marker, NSRange range) {

        }

        public MTLBuffer NewRemoteBufferViewForDevice(MTLDevice device) {

        }

        private static readonly Selector sel_length = "length";
        private static readonly Selector sel_contents = "contents";
        private static readonly Selector sel_didModifyRange = "didModifyRange:";
        private static readonly Selector sel_newTextureWithDescriptoroffsetbytesPerRow = "newTextureWithDescriptor:offset:bytesPerRow:";
        private static readonly Selector sel_addDebugMarkerrange = "addDebugMarker:range:";
        private static readonly Selector sel_removeAllDebugMarkers = "removeAllDebugMarkers";
        private static readonly Selector sel_remoteStorageBuffer = "remoteStorageBuffer";
        private static readonly Selector sel_newRemoteBufferViewForDevice = "newRemoteBufferViewForDevice:";
        private static readonly Selector sel_gpuAddress = "gpuAddress";
    }
}
