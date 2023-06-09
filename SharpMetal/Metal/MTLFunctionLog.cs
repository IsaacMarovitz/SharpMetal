using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLFunctionLogType : ulong
    {
        Validation = 0,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLLogContainer
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLLogContainer obj) => obj.NativePtr;
        public MTLLogContainer(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLFunctionLogDebugLocation
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionLogDebugLocation obj) => obj.NativePtr;
        public MTLFunctionLogDebugLocation(IntPtr ptr) => NativePtr = ptr;

        public NSString FunctionName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionName));

        public NSURL URL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_URL));

        public ulong Line => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_line);

        public ulong Column => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_column);

        private static readonly Selector sel_functionName = "functionName";
        private static readonly Selector sel_URL = "URL";
        private static readonly Selector sel_line = "line";
        private static readonly Selector sel_column = "column";
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLFunctionLog
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionLog obj) => obj.NativePtr;
        public MTLFunctionLog(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionLogType Type => (MTLFunctionLogType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_type);

        public NSString EncoderLabel => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_encoderLabel));

        public MTLFunction Function => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_function));

        public MTLFunctionLogDebugLocation DebugLocation => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_debugLocation));

        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_encoderLabel = "encoderLabel";
        private static readonly Selector sel_function = "function";
        private static readonly Selector sel_debugLocation = "debugLocation";
    }
}
