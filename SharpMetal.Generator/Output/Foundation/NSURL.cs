using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct NSURL
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSURL obj) => obj.NativePtr;
        public NSURL(IntPtr ptr) => NativePtr = ptr;

        public NSURL()
        {
            var cls = new ObjectiveCClass("NSURL");
            NativePtr = cls.AllocInit();
        }

        public ushort FileSystemRepresentation => ObjectiveCRuntime.ushort_objc_msgSend(NativePtr, sel_fileSystemRepresentation);

        private static readonly Selector sel_fileURLWithPath = "fileURLWithPath:";
        private static readonly Selector sel_initWithString = "initWithString:";
        private static readonly Selector sel_initFileURLWithPath = "initFileURLWithPath:";
        private static readonly Selector sel_fileSystemRepresentation = "fileSystemRepresentation";
    }
}
