using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public class MTKViewDelegate
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OnDrawInMTKViewDelegate(IntPtr id, IntPtr cmd, IntPtr view);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OnMTKViewDrawableSizeWillChangeDelegate(IntPtr id, IntPtr cmd, IntPtr view, NSRect size);

        private OnDrawInMTKViewDelegate _onDrawInMTKView;
        private OnMTKViewDrawableSizeWillChangeDelegate _onMtkViewDrawableSizeWillChange;

        public Action<MTKView> OnDrawInMTKView;
        public Action<MTKView, NSRect> OnMTKViewDrawableSizeWillChange;

        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTKViewDelegate mtkDelegate) => mtkDelegate.NativePtr;

        public unsafe MTKViewDelegate(IRenderer renderer)
        {
            OnDrawInMTKView += renderer.Draw;
            OnMTKViewDrawableSizeWillChange += (view, rect) => { Console.WriteLine("MTKView Changed Size!"); };

            char[] name = "MTKViewDelegate".ToCharArray();
            char[] types1 = "v@:#".ToCharArray();
            char[] types2 = "v@:#{CGRect={CGPoint=dd}{CGPoint=dd}}".ToCharArray();

            fixed (char* pName = name)
            {
                fixed (char* pTypes1 = types1)
                {
                    fixed (char* pTypes2 = types2)
                    {
                        _onDrawInMTKView = (_, _, view) => OnDrawInMTKView(new MTKView(view));
                        _onMtkViewDrawableSizeWillChange = (_, _, view, rect) => OnMTKViewDrawableSizeWillChange(new MTKView(view), rect);

                        var onDrawInMTKViewPtr = Marshal.GetFunctionPointerForDelegate(_onDrawInMTKView);
                        var onMTKViewDrawableWillChange = Marshal.GetFunctionPointerForDelegate(_onMtkViewDrawableSizeWillChange);

                        var mtkDelegateClass = ObjectiveC.objc_allocateClassPair(new ObjectiveCClass("NSObject"), pName, 0);

                        ObjectiveC.class_addMethod(mtkDelegateClass, "drawInMTKView:", onDrawInMTKViewPtr, pTypes1);
                        ObjectiveC.class_addMethod(mtkDelegateClass, "mtkView:drawableSizeWillChange:", onMTKViewDrawableWillChange, pTypes2);

                        ObjectiveC.objc_registerClassPair(mtkDelegateClass);

                        NativePtr = new ObjectiveCClass(mtkDelegateClass).AllocInit();
                    }
                }
            }
        }

        public static MTKViewDelegate Init<T>(MTLDevice device) where T : IRenderer
        {
            var renderer = T.Init(device);
            return new MTKViewDelegate(renderer);
        }
    }
}
