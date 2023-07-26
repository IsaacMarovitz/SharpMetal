using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using SharpMetal.Foundation;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public static class StringHelper
    {
        public static NSString InitNSString(string source)
        {
            return new(ObjectiveC.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), "stringWithUTF8String:", source));
        }

        public static unsafe string GetError(NSError error)
        {
            char[] errorDescription = new char[error.LocalizedDescription.Length];
            fixed (char* pointer = errorDescription)
            {
                ObjectiveC.bool_objc_msgSend(error.LocalizedDescription,
                    "getCString:maxLength:encoding:",
                    pointer,
                    error.LocalizedDescription.MaximumLengthOfBytes(NSStringEncoding.UTF16) + 1,
                    (ulong)NSStringEncoding.UTF16);
            }

            return new string(errorDescription);
        }
    }
}
