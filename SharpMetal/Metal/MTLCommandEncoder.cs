using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLResourceUsage : ulong
    {
        Read = 1,
        Write = 2,
        Sample = 4,
    }

    public enum MTLBarrierScope : ulong
    {
        Buffers = 1,
        Textures = 2,
        RenderTargets = 4,
    }

    [SupportedOSPlatform("macos")]
    public class MTLCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCommandEncoder obj) => obj.NativePtr;
        public MTLCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void SetLabel(NSString label)
        {
            objc_msgSend(NativePtr, , label);
        }

        public void EndEncoding()
        {
            objc_msgSend(NativePtr, , );
        }

        public void InsertDebugSignpost(NSString nsString)
        {
            objc_msgSend(NativePtr, , nsString);
        }

        public void PushDebugGroup(NSString nsString)
        {
            objc_msgSend(NativePtr, , nsString);
        }

        public void PopDebugGroup()
        {
            objc_msgSend(NativePtr, , );
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_insertDebugSignpost = "insertDebugSignpost:";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
    }
}
