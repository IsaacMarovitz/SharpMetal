using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4LibraryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4LibraryDescriptor obj) => obj.NativePtr;
        public MTL4LibraryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4LibraryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4LibraryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Name
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setName, value);
        }

        public MTLCompileOptions Options
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_options));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, value);
        }

        public NSString Source
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_source));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSource, value);
        }

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_setName = "setName:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_setSource = "setSource:";
        private static readonly Selector sel_source = "source";
        private static readonly Selector sel_release = "release";
    }
}
