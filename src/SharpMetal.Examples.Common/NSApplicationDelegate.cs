using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Foundation;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public class NSApplicationDelegate
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OnApplicationWillFinishLaunchingDelegate(IntPtr id, IntPtr cmd, IntPtr notification);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OnApplicationDidFinishLaunchingDelegate(IntPtr id, IntPtr cmd, IntPtr notification);

        private OnApplicationWillFinishLaunchingDelegate _onApplicationWillFinishLaunching;
        private OnApplicationDidFinishLaunchingDelegate _onApplicationDidFinishLaunching;

        public Action<NSNotification> OnApplicationWillFinishLaunching;
        public Action<NSNotification> OnApplicationDidFinishLaunching;

        public IntPtr NativePtr;

        public unsafe NSApplicationDelegate(NSApplication application)
        {
            char[] name = "AppDelegate".ToCharArray();
            char[] types = "v@:#".ToCharArray();

            fixed (char* pName = name)
            {
                fixed (char* pTypes = types)
                {
                    _onApplicationWillFinishLaunching = (_, _, notif) => OnApplicationWillFinishLaunching?.Invoke(new NSNotification(notif));
                    var onApplicationWillFinishLaunchingPtr = Marshal.GetFunctionPointerForDelegate(_onApplicationWillFinishLaunching);

                    _onApplicationDidFinishLaunching = (_, _, notif) => OnApplicationDidFinishLaunching?.Invoke(new NSNotification(notif));
                    var onDidFinishLaunchingPtr = Marshal.GetFunctionPointerForDelegate(_onApplicationDidFinishLaunching);

                    var appDelegateClass = ObjectiveC.objc_allocateClassPair(new ObjectiveCClass("NSObject"), pName, 0);

                    ObjectiveC.class_addMethod(appDelegateClass, "applicationWillFinishLaunching:", onApplicationWillFinishLaunchingPtr, pTypes);
                    ObjectiveC.class_addMethod(appDelegateClass, "applicationDidFinishLaunching:", onDidFinishLaunchingPtr, pTypes);

                    ObjectiveC.objc_registerClassPair(appDelegateClass);

                    NativePtr = new ObjectiveCClass(appDelegateClass).AllocInit();
                }
            }
        }
    }
}
