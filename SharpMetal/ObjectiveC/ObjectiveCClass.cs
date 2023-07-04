using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public struct ObjectiveCClass
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(ObjectiveCClass c) => c.NativePtr;

        public ObjectiveCClass(string name)
        {
            var ptr = ObjectiveCRuntime.objc_getClass(name);

            if (ptr == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to get class {name}!");
            }

            NativePtr = ptr;
        }

        public IntPtr AllocInit()
        {
            var value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, "alloc");
            ObjectiveCRuntime.objc_msgSend(value, "init");
            return value;
        }

        public IntPtr Alloc()
        {
            var value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, "alloc");
            return value;
        }
    }
}