using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Primitive
{
    [SupportedOSPlatform("macos")]
    public class MTKViewDelegate
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OnDrawInMTKViewDelegate(IntPtr id, IntPtr cmd, IntPtr view);

        private OnDrawInMTKViewDelegate _onDrawInMTKView;

        public Action<MTKView> OnDrawInMTKView;

        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTKViewDelegate mtkDelegate) => mtkDelegate.NativePtr;

        public unsafe MTKViewDelegate(MTLDevice device)
        {
            var renderer = new Renderer(device);
            OnDrawInMTKView += renderer.Draw;

            char[] name = "MTKViewDelegate".ToCharArray();
            char[] types = "v@:#".ToCharArray();

            fixed (char* pName = name)
            {
                fixed (char* pTypes = types)
                {
                    _onDrawInMTKView = (_, _, view) => OnDrawInMTKView(new MTKView(view));
                    var onDrawInMTKViewPtr = Marshal.GetFunctionPointerForDelegate(_onDrawInMTKView);

                    var mtkDelegateClass = ObjectiveC.objc_allocateClassPair(new ObjectiveCClass("NSObject"), pName, 0);

                    ObjectiveC.class_addMethod(mtkDelegateClass, "drawInMTKView:", onDrawInMTKViewPtr, pTypes);

                    ObjectiveC.objc_registerClassPair(mtkDelegateClass);

                    NativePtr = new ObjectiveCClass(mtkDelegateClass).AllocInit();
                }
            }
        }
    }
}
