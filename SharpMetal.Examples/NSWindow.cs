using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class NSWindow
    {
        public IntPtr NativePtr;

        public NSWindow(NSRect rect)
        {
            NativePtr = new ObjectiveCClass("NSWindow").Alloc();
            ObjectiveC.objc_msgSend(NativePtr, "initWithContentRect:styleMask:backing:defer:", rect, 0, 0, 0);
        }

        public void SetContentView(IntPtr ptr)
        {
            ObjectiveC.objc_msgSend(NativePtr, "setContentView:", ptr);
        }

        public void MakeKeyAndOrderFront()
        {
            ObjectiveC.objc_msgSend(NativePtr, "makeKeyAndOrderFront:", IntPtr.Zero);
        }
    }
}
