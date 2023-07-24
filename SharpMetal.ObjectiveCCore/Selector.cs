using System.Runtime.InteropServices;

namespace SharpMetal.ObjectiveCCore
{
    public partial struct Selector
    {
        [LibraryImport("/usr/lib/libobjc.A.dylib", StringMarshalling = StringMarshalling.Utf8)]
        private static unsafe partial IntPtr sel_getUid(string name);

        [LibraryImport("/usr/lib/libobjc.A.dylib")]
        private static unsafe partial IntPtr sel_getName(IntPtr sel);

        public readonly IntPtr SelPtr;

        public Selector(string name)
        {
            var ptr = sel_getUid(name);

            if (ptr == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to get selector {name}!");
            }

            SelPtr = ptr;
        }

        public string Name
        {
            get
            {
                var ptr = sel_getName(SelPtr);
                return Marshal.PtrToStringAnsi(ptr) ?? string.Empty;
            }
        }

        public static implicit operator Selector(string value) => new(value);
        public static implicit operator IntPtr(Selector sel) => sel.SelPtr;
    }
}
