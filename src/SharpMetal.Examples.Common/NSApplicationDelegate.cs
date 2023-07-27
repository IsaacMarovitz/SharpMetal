using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public class NSApplicationDelegate
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OnDidFinishLaunchingDelegate(IntPtr id, IntPtr cmd, IntPtr notification);

        private OnDidFinishLaunchingDelegate _onDidFinishLaunching;
        private NSApplication _application;

        public Action<NSApplication> OnDidFinishLaunching;
        public IntPtr NativePtr;

        public unsafe NSApplicationDelegate(NSApplication application)
        {
            _application = application;
            char[] name = "AppDelegate".ToCharArray();
            char[] types = "v@:#".ToCharArray();

            fixed (char* pName = name)
            {
                fixed (char* pTypes = types)
                {
                    _onDidFinishLaunching = (_, _, _) => OnDidFinishLaunching?.Invoke(_application);
                    var delegatePtr = Marshal.GetFunctionPointerForDelegate(_onDidFinishLaunching);

                    var appDelegateClass = ObjectiveC.objc_allocateClassPair(new ObjectiveCClass("NSObject"), pName, 0);
                    ObjectiveC.class_addMethod(appDelegateClass, "applicationDidFinishLaunching:", delegatePtr, pTypes);
                    ObjectiveC.objc_registerClassPair(appDelegateClass);

                    NativePtr = new ObjectiveCClass(appDelegateClass).AllocInit();
                }
            }
        }
    }
}
