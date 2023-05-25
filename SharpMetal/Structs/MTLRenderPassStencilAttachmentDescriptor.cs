using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassStencilAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLRenderPassStencilAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLMultisampleStencilResolveFilter StencilResolveFilter
        {
            get => (MTLMultisampleStencilResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_stencilResolveFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilResolveFilter, (ulong)value);
        }

        public uint ClearStencil
        {
            get => ObjectiveCRuntime.uint32_objc_msgSend(NativePtr, sel_clearStencil);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearStencil, value);
        }

        private static readonly Selector sel_stencilResolveFilter = "stencilResolveFilter";
        private static readonly Selector sel_setStencilResolveFilter = "setStencilResolveFilter:";
        private static readonly Selector sel_clearStencil = "clearStencil";
        private static readonly Selector sel_setClearStencil = "setClearStencil:";
    }
}