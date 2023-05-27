using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassColorAttachmentDescriptor: MTLRenderPassAttachmentDescriptor
    {
        public readonly IntPtr NativePtr { get; }
        public static implicit operator IntPtr(MTLRenderPassColorAttachmentDescriptor descriptor) => descriptor.NativePtr;
        public MTLRenderPassColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        // TODO: Add MTLClearColor
        public MTLRenderPassColorAttachmentDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRenderPassColorAttachmentDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLTexture Texture
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_texture));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTexture, value);
        }

        public ulong Level
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, value);
        }

        public ulong Slice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_slice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSlice, value);
        }

        public ulong DepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthPlane, value);
        }

        public MTLLoadAction LoadAction
        {
            get => (MTLLoadAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_loadAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLoadAction, (ulong)value);
        }

        public MTLStoreAction StoreAction
        {
            get => (MTLStoreAction)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeAction);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreAction, (ulong)value);
        }

        public MTLStoreActionOptions StoreActionOptions
        {
            get => (MTLStoreActionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_storeActionOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStoreActionOptions, (ulong)value);
        }

        public IntPtr ResolveTexture
        {
            get => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resolveTexture);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveTexture, value);
        }

        public ulong ResolveLevel
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveLevel);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveLevel, value);
        }

        public ulong ResolveSlice
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveSlice);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveSlice, value);
        }

        public ulong ResolveDepthPlane
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resolveDepthPlane);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResolveDepthPlane, value);
        }

        private static readonly Selector sel_texture = "texture";
        private static readonly Selector sel_setTexture = "setTexture:";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_slice = "slice";
        private static readonly Selector sel_setSlice = "setSlice:";
        private static readonly Selector sel_depthPlane = "depthPlane";
        private static readonly Selector sel_setDepthPlane = "setDepthPlant:";

        private static readonly Selector sel_loadAction = "loadAction";
        private static readonly Selector sel_setLoadAction = "setLoadAction:";
        private static readonly Selector sel_storeAction = "storeAction";
        private static readonly Selector sel_setStoreAction = "setStoreAction:";
        private static readonly Selector sel_storeActionOptions = "storeActionOptions";
        private static readonly Selector sel_setStoreActionOptions = "setStoreActionOptions:";

        private static readonly Selector sel_resolveTexture = "resolveTexture";
        private static readonly Selector sel_setResolveTexture = "setResolveTexture:";
        private static readonly Selector sel_resolveLevel = "resolveLevel";
        private static readonly Selector sel_setResolveLevel = "setResolveLevel:";
        private static readonly Selector sel_resolveSlice = "resolveSlice";
        private static readonly Selector sel_setResolveSlice = "setResolveSlice:";
        private static readonly Selector sel_resolveDepthPlane = "resolveDepthPlane";
        private static readonly Selector sel_setResolveDepthPlane = "setResolveDepthPlant:";
    }
}