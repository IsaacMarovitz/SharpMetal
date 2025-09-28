using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLTextureViewPool : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLTextureViewPool obj) => obj.NativePtr;
        public static implicit operator MTLResourceViewPool(MTLTextureViewPool obj) => new(obj.NativePtr);
        public MTLTextureViewPool(IntPtr ptr) => NativePtr = ptr;

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

        public MTLResourceID SetTextureView(MTLTexture texture, ulong index)
        {
            return ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_setTextureViewatIndex, texture, index);
        }

        public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, ulong index)
        {
            return ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_setTextureViewdescriptoratIndex, texture, descriptor, index);
        }

        public MTLResourceID SetTextureViewFromBuffer(MTLBuffer buffer, MTLTextureDescriptor descriptor, ulong offset, ulong bytesPerRow, ulong index)
        {
            return ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_setTextureViewFromBufferdescriptoroffsetbytesPerRowatIndex, buffer, descriptor, offset, bytesPerRow, index);
        }

        private static readonly Selector sel_baseResourceID = "baseResourceID";
        private static readonly Selector sel_copyResourceViewsFromPoolsourceRangedestinationIndex = "copyResourceViewsFromPool:sourceRange:destinationIndex:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_resourceViewCount = "resourceViewCount";
        private static readonly Selector sel_setTextureViewatIndex = "setTextureView:atIndex:";
        private static readonly Selector sel_setTextureViewdescriptoratIndex = "setTextureView:descriptor:atIndex:";
        private static readonly Selector sel_setTextureViewFromBufferdescriptoroffsetbytesPerRowatIndex = "setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:";
        private static readonly Selector sel_release = "release";
    }
}
