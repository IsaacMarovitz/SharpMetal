using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public enum MTLLogLevel : long
    {
        Undefined = 0,
        Debug = 1,
        Info = 2,
        Notice = 3,
        Error = 4,
        Fault = 5,
    }

    [SupportedOSPlatform("macos")]
    public enum MTLLogStateError : ulong
    {
        InvalidSize = 1,
        Invalid = 2,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLLogState : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLLogState obj) => obj.NativePtr;
        public MTLLogState(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLLogStateDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLLogStateDescriptor obj) => obj.NativePtr;
        public MTLLogStateDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLLogStateDescriptor()
        {
            var cls = new ObjectiveCClass("MTLLogStateDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public long BufferSize
        {
            get => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_bufferSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBufferSize, value);
        }

        public MTLLogLevel Level
        {
            get => (MTLLogLevel)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_level);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLevel, (long)value);
        }

        private static readonly Selector sel_bufferSize = "bufferSize";
        private static readonly Selector sel_level = "level";
        private static readonly Selector sel_setBufferSize = "setBufferSize:";
        private static readonly Selector sel_setLevel = "setLevel:";
        private static readonly Selector sel_release = "release";
    }
}
