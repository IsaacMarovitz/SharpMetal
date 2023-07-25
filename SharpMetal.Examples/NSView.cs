using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class NSView
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSView view) => view.NativePtr;

        public NSView(NSRect rect)
        {
            NativePtr = new ObjectiveCClass("NSView").Alloc();
            ObjectiveC.objc_msgSend(NativePtr, "init", rect);
        }

        public bool WantsLayer
        {
            get => ObjectiveC.bool_objc_msgSend(NativePtr, "wantsLayer");
            set => ObjectiveC.objc_msgSend(NativePtr, "wantsLayer", value);
        }

        public CAMetalLayer Layer
        {
            get => new(ObjectiveC.IntPtr_objc_msgSend(NativePtr, "layer"));
            set => ObjectiveC.objc_msgSend(NativePtr, "layer", value);
        }
    }
}
