using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public class NSApplication
    {
        public IntPtr NativePtr;

        public NSApplication()
        {
            NativePtr = ObjectiveC.IntPtr_objc_msgSend(new ObjectiveCClass("NSApplication"), "sharedApplication");
        }

        public void Run()
        {
            ObjectiveC.objc_msgSend(NativePtr, "run");
        }

        public void Stop()
        {
            ObjectiveC.objc_msgSend(NativePtr, "stop:", IntPtr.Zero);
        }

        public void SetDelegate(NSApplicationDelegate appDelegate)
        {
            ObjectiveC.objc_msgSend(NativePtr, "setDelegate:", appDelegate.NativePtr);
        }
    }
}
