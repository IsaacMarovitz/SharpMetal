using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public unsafe struct ObjectiveCClass
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

        public IntPtr GetProperty(string propertyName)
        {
            var ptr = Marshal.StringToHGlobalAnsi(propertyName);
            return ObjectiveCRuntime.class_getProperty(this, ptr);
        }

        public string Name => Marshal.PtrToStringAnsi(ObjectiveCRuntime.class_getName(this)) ?? string.Empty;

        public IntPtr AllocInit()
        {
            var value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.alloc);
            ObjectiveCRuntime.objc_msgSend(value, Selectors.init);
            return value;
        }

        public IntPtr Alloc()
        {
            var value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.alloc);
            return value;
        }

        public ObjectiveCMethod* class_copyMethodList(out uint count)
        {
            return ObjectiveCRuntime.class_copyMethodList(this, out count);
        }
    }
}