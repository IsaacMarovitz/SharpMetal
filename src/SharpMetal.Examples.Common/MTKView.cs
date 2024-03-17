using System.Runtime.Versioning;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;
using SharpMetal.QuartzCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public class MTKView
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTKView mtkView) => mtkView.NativePtr;

        public MTKView(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        public MTKView(NSRect frameRect, MTLDevice device)
        {
            var ptr = new ObjectiveCClass("MTKView").Alloc();
            NativePtr = ObjectiveC.IntPtr_objc_msgSend(ptr, "initWithFrame:device:", frameRect, device);
        }

        public MTLPixelFormat ColorPixelFormat
        {
            set => ObjectiveC.objc_msgSend(NativePtr, "setColorPixelFormat:atIndex:", (ulong)value, 0);
        }

        public MTLClearColor ClearColor
        {
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, new Selector("setClearColor:"), value);
        }

        public MTLPixelFormat DepthStencilPixelFormat
        {
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, new Selector("setDepthStencilPixelFormat:"), (ulong)value);
        }

        public MTKViewDelegate Delegate
        {
            set => ObjectiveC.objc_msgSend(NativePtr, "setDelegate:", value);
        }

        public CAMetalDrawable CurrentDrawable
        {
            get => new(ObjectiveC.IntPtr_objc_msgSend(NativePtr, "currentDrawable"));
        }

        public MTLRenderPassDescriptor CurrentRenderPassDescriptor
        {
            get => new(ObjectiveC.IntPtr_objc_msgSend(NativePtr, "currentRenderPassDescriptor"));
        }
    }
}
