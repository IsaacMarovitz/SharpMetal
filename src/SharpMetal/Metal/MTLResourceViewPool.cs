using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLResourceViewPool : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceViewPool obj) => obj.NativePtr;
        public MTLResourceViewPool(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLResourceID BaseResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_baseResourceID);

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public ulong ResourceViewCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceViewCount);

        public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, ulong destinationIndex)
        {
            return ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_copyResourceViewsFromPoolsourceRangedestinationIndex, sourcePool, sourceRange, destinationIndex);
        }

        private static readonly Selector sel_baseResourceID = "baseResourceID";
        private static readonly Selector sel_copyResourceViewsFromPoolsourceRangedestinationIndex = "copyResourceViewsFromPool:sourceRange:destinationIndex:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_resourceViewCount = "resourceViewCount";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLResourceViewPoolDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceViewPoolDescriptor obj) => obj.NativePtr;
        public MTLResourceViewPoolDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLResourceViewPoolDescriptor()
        {
            var cls = new ObjectiveCClass("MTLResourceViewPoolDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong ResourceViewCount
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_resourceViewCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setResourceViewCount, value);
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_resourceViewCount = "resourceViewCount";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setResourceViewCount = "setResourceViewCount:";
        private static readonly Selector sel_release = "release";
    }
}
