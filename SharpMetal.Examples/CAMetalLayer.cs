using System.Runtime.Versioning;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class CAMetalLayer
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(CAMetalLayer layer) => layer.NativePtr;

        public CAMetalLayer()
        {
            NativePtr = new ObjectiveCClass("CAMetalLayer").AllocInit();
        }

        public CAMetalLayer(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        public MTLDevice Device
        {
            get => new(ObjectiveC.IntPtr_objc_msgSend(NativePtr, "device"));
            set => ObjectiveC.objc_msgSend(NativePtr, "device", value);
        }

        public CAMetalDrawable NextDrawable
        {
            get => new(ObjectiveC.IntPtr_objc_msgSend(NativePtr, "nextDrawable"));
        }
    }
}
