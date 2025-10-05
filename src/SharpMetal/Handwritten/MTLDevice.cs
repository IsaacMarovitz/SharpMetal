using System.Runtime.InteropServices;
using SharpMetal.Foundation;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Metal
{
    public partial struct MTLDevice
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NewLibraryCompletionHandler(IntPtr block, IntPtr library, IntPtr error);

        public GCHandle NewLibrary(NSString source, MTLCompileOptions options, Action<MTLLibrary, NSError> callback)
        {
            NewLibraryCompletionHandler handler = (_, library, error) => callback(new MTLLibrary(library), new NSError(error));
            var gcHandle = GCHandle.Alloc(handler);
            var block = Block.GetBlockForDelegate(handler);
            ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newLibraryWithSourceoptionscompletionHandler, (IntPtr)source, (IntPtr)options, (IntPtr)block);
            return gcHandle;
        }

        [LibraryImport(ObjectiveC.MetalFramework)]
        private static partial IntPtr MTLCopyAllDevices();

        public static NSArray CopyAllDevices()
        {
            return new(MTLCopyAllDevices());
        }

        [LibraryImport(ObjectiveC.MetalFramework)]
        private static partial IntPtr MTLCreateSystemDefaultDevice();

        public static MTLDevice CreateSystemDefaultDevice()
        {
            return new(MTLCreateSystemDefaultDevice());
        }

        private static readonly Selector sel_newLibraryWithSourceoptionscompletionHandler = "newLibraryWithSource:options:completionHandler:";
    }
}
