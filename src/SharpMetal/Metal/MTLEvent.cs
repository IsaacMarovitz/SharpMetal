using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLEvent
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLEvent obj) => obj.NativePtr;
        public MTLEvent(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLSharedEventListener
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSharedEventListener obj) => obj.NativePtr;
        public MTLSharedEventListener(IntPtr ptr) => NativePtr = ptr;

        public MTLSharedEventListener()
        {
            var cls = new ObjectiveCClass("MTLSharedEventListener");
            NativePtr = cls.AllocInit();
        }

        public IntPtr DispatchQueue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_dispatchQueue));

        public MTLSharedEventListener Init(IntPtr dispatchQueue)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithDispatchQueue, dispatchQueue));
        }

        private static readonly Selector sel_initWithDispatchQueue = "initWithDispatchQueue:";
        private static readonly Selector sel_dispatchQueue = "dispatchQueue";
    }

    [SupportedOSPlatform("macos")]
    public class MTLSharedEvent : MTLEvent
    {
        public static implicit operator IntPtr(MTLSharedEvent obj) => obj.NativePtr;
        public MTLSharedEvent(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        public MTLSharedEventHandle NewSharedEventHandle => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newSharedEventHandle));

        public ulong SignaledValue
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_signaledValue);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSignaledValue, value);
        }

        public void NotifyListener(MTLSharedEventListener listener, ulong value, IntPtr block)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_notifyListeneratValueblock, listener, value, block);
        }

        private static readonly Selector sel_notifyListeneratValueblock = "notifyListener:atValue:block:";
        private static readonly Selector sel_newSharedEventHandle = "newSharedEventHandle";
        private static readonly Selector sel_signaledValue = "signaledValue";
        private static readonly Selector sel_setSignaledValue = "setSignaledValue:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLSharedEventHandle
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSharedEventHandle obj) => obj.NativePtr;
        public MTLSharedEventHandle(IntPtr ptr) => NativePtr = ptr;

        public MTLSharedEventHandle()
        {
            var cls = new ObjectiveCClass("MTLSharedEventHandle");
            NativePtr = cls.AllocInit();
        }

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        private static readonly Selector sel_label = "label";
    }
}
