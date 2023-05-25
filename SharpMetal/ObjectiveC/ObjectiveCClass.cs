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
            NativePtr = ObjectiveCRuntime.objc_getClass(name);
        }

        public IntPtr GetProperty(string propertyName)
        {
            var ptr = Marshal.StringToHGlobalAnsi(propertyName);
            return ObjectiveCRuntime.class_getProperty(this, ptr);
        }

        public string Name => Marshal.PtrToStringAnsi(ObjectiveCRuntime.class_getName(this)) ?? string.Empty;

        public T Alloc<T>() where T : struct
        {
            IntPtr value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.alloc);
            return Unsafe.AsRef<T>(&value);
        }

        public T AllocInit<T>() where T : struct
        {
            IntPtr value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.alloc);
            ObjectiveCRuntime.objc_msgSend(value, Selectors.init);
            return Unsafe.AsRef<T>(&value);
        }

        public ObjectiveCMethod* class_copyMethodList(out uint count)
        {
            return ObjectiveCRuntime.class_copyMethodList(this, out count);
        }
    }
}