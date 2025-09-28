using System.Runtime.InteropServices;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal
{
    internal partial class ObjectiveCRuntime
    {
        [LibraryImport(ObjectiveC.ObjCRuntime, EntryPoint = "objc_msgSend")]
        internal static partial void objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr a, IntPtr b, IntPtr c);
    }
}
