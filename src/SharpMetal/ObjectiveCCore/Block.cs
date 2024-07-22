using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveCCore
{
    [StructLayout(LayoutKind.Sequential)]
    [SupportedOSPlatform("macos")]
    public unsafe partial struct Block : IDisposable
    {
        IntPtr isa;
        int flags;
        int reserved;
        IntPtr invoke;
        IntPtr blockDescriptor;

        public Block(Delegate callback)
        {
            var libSystem = ObjectiveC.LinkLibSystem();

            isa = ObjectiveC.dlsym(libSystem, "_NSConcreteStackBlock");
            invoke = Marshal.GetFunctionPointerForDelegate(callback);
            blockDescriptor = Marshal.AllocHGlobal(sizeof(BlockDescriptor));

            var descriptor = (BlockDescriptor*)blockDescriptor;
            descriptor->size = sizeof(Block);
        }

        public static IntPtr GetBlockForDelegate(Delegate callback)
        {
            using var block = new Block(callback);

            return _Block_copy(&block);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(blockDescriptor);
        }

        [LibraryImport(ObjectiveC.ObjCRuntime)]
        internal static partial IntPtr _Block_copy(Block* block);
    }

    [StructLayout(LayoutKind.Sequential)]
    struct BlockDescriptor
    {
        private IntPtr reserved;
        public IntPtr size;
    }
}
