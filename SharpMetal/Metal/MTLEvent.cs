using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public partial class MTLEvent
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLEvent obj) => obj.NativePtr;
        public MTLEvent(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public void SetLabel(NSString label)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, label);
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLSharedEventListener
    {
        public readonly IntPtr NativePtr;
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
    public partial class MTLSharedEvent
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLSharedEvent obj) => obj.NativePtr;
        public MTLSharedEvent(IntPtr ptr) => NativePtr = ptr;

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

        public void SetSignaledValue(ulong signaledValue)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSignaledValue, signaledValue);
        }

        private static readonly Selector sel_notifyListeneratValueblock = "notifyListener:atValue:block:";
        private static readonly Selector sel_newSharedEventHandle = "newSharedEventHandle";
        private static readonly Selector sel_signaledValue = "signaledValue";
        private static readonly Selector sel_setSignaledValue = "setSignaledValue:";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLSharedEventHandle
    {
        public readonly IntPtr NativePtr;
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
