using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct NSFastEnumerationState
    {
        public IntPtr itemsPtr;
    }

    [SupportedOSPlatform("macos")]
    public struct NSFastEnumeration
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSFastEnumeration obj) => obj.NativePtr;
        public NSFastEnumeration(IntPtr ptr) => NativePtr = ptr;

        public ulong CountByEnumerating(NSFastEnumerationState pState, NSObject pBuffer, ulong len)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_countByEnumeratingWithStateobjectscount, pState, pBuffer, len);
        }

        private static readonly Selector sel_countByEnumeratingWithStateobjectscount = "countByEnumeratingWithState:objects:count:";
    }

    [SupportedOSPlatform("macos")]
    public struct NSEnumerator
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSEnumerator obj) => obj.NativePtr;
        public static implicit operator NSFastEnumeration(NSEnumerator obj) => new(obj.NativePtr);
        public NSEnumerator(IntPtr ptr) => NativePtr = ptr;



        public ulong CountByEnumerating(NSFastEnumerationState pState, NSObject pBuffer, ulong len)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_countByEnumeratingWithStateobjectscount, pState, pBuffer, len);
        }

        private static readonly Selector sel_countByEnumeratingWithStateobjectscount = "countByEnumeratingWithState:objects:count:";
    }
}
