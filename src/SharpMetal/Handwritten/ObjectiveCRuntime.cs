using System.Runtime.InteropServices;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal
{
    public partial class ObjectiveCRuntime
    {
        [LibraryImport(ObjectiveC.ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr a, IntPtr b, IntPtr c);
    }
}
