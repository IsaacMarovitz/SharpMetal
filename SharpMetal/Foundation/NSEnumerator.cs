using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NSFastEnumerationState
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSFastEnumerationState obj) => obj.NativePtr;
        public NSFastEnumerationState(IntPtr ptr) => NativePtr = ptr;

        public IntPtr itemsPtr;
    }

    [SupportedOSPlatform("macos")]
    public struct NSFastEnumeration
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSFastEnumeration obj) => obj.NativePtr;
        public NSFastEnumeration(IntPtr ptr) => NativePtr = ptr;

        public ulong CountByEnumerating(NSFastEnumerationState pState, NSObject pBuffer, ulong len)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_countByEnumeratingWithStateobjectscount = "countByEnumeratingWithState:objects:count:";
    }

    [SupportedOSPlatform("macos")]
    public struct NSEnumerator
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSEnumerator obj) => obj.NativePtr;
        public NSEnumerator(IntPtr ptr) => NativePtr = ptr;

        public IntPtr NextObject;

        public NSArray AllObjects;
    }
}
