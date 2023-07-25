using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveCCore
{
    [SupportedOSPlatform("macos")]
    public struct ObjectiveCClass
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(ObjectiveCClass c) => c.NativePtr;

        public ObjectiveCClass(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        public ObjectiveCClass(string name)
        {
            var ptr = ObjectiveC.objc_getClass(name);

            if (ptr == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to get class {name}!");
            }

            NativePtr = ptr;
        }

        public ObjectiveCClass AllocInit()
        {
            var value = ObjectiveC.IntPtr_objc_msgSend(NativePtr, "alloc");
            ObjectiveC.objc_msgSend(value, "init");
            return new ObjectiveCClass(value);
        }

        public ObjectiveCClass Alloc()
        {
            var value = ObjectiveC.IntPtr_objc_msgSend(NativePtr, "alloc");
            return new ObjectiveCClass(value);
        }
    }
}
