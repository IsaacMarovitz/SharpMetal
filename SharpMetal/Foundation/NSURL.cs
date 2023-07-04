using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSURL
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

        public static NSURL FileURLWithPath(NSString pPath)
        {
            throw new NotImplementedException();
        }

        public NSURL Init(NSString pString)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithString, pString));
        }

        public NSURL InitFileURLWithPath(NSString pPath)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initFileURLWithPath, pPath));
        }

        private static readonly Selector sel_fileURLWithPath = "fileURLWithPath:";
        private static readonly Selector sel_initWithString = "initWithString:";
        private static readonly Selector sel_initFileURLWithPath = "initFileURLWithPath:";
        private static readonly Selector sel_fileSystemRepresentation = "fileSystemRepresentation";
    }
}
