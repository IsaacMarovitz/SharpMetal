using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLDynamicLibraryError: ulong
    {
        None = 0,
        InvalidFile = 1,
        CompilationFailure = 2,
        UnresolvedInstallName = 3,
        DependencyLoadFailure = 4,
        Unsupported = 5,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLDynamicLibrary
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLDynamicLibrary obj) => obj.NativePtr;
        public MTLDynamicLibrary(IntPtr ptr) => NativePtr = ptr;

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString InstallName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_installName));

        public void SetLabel(NSString label) {

        }

        public bool SerializeToURL(NSURL url, NSError error) {

        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_installName = "installName";
        private static readonly Selector sel_serializeToURLerror = "serializeToURL:error:";
    }
}
