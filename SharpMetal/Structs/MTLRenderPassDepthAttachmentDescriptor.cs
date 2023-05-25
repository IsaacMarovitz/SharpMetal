using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassDepthAttachmentDescriptor
    {
        public readonly IntPtr NativePtr;
        public MTLRenderPassDepthAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        public double ClearDepth
        {
            get => ObjectiveCRuntime.double_objc_msgSend(NativePtr, sel_clearDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setClearDepth, value);
        }

        public MTLMultisampleDepthResolveFilter DepthResolveFilter
        {
            get => (MTLMultisampleDepthResolveFilter)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_depthResolveFilter);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthResolveFilter, (ulong)value);
        }

        private static readonly Selector sel_clearDepth = "clearDepth";
        private static readonly Selector sel_setClearDepth = "setClearDepth:";
        private static readonly Selector sel_depthResolveFilter = "depthResolveFilter";
        private static readonly Selector sel_setDepthResolveFilter = "setDepthResolveFilter:";
    }
}