using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLCaptureError : long
    {
        NotSupported = 1,
        AlreadyCapturing = 2,
        InvalidDescriptor = 3,
    }

    public enum MTLCaptureDestination : long
    {
        DeveloperTools = 1,
        GPUTraceDocument = 2,
    }

    [SupportedOSPlatform("macos")]
    public class MTLCaptureDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCaptureDescriptor obj) => obj.NativePtr;
        public MTLCaptureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLCaptureDescriptor()
        {
            var cls = new ObjectiveCClass("MTLCaptureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public IntPtr CaptureObject
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_captureObject));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCaptureObject, value);
        }

        public MTLCaptureDestination Destination
        {
            get => (MTLCaptureDestination)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_destination);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDestination, (long)value);
        }

        public NSURL OutputURL
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputURL));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputURL, value);
        }

        public void SetCaptureObject(IntPtr captureObject)
        {
            throw new NotImplementedException();
        }

        public void SetDestination(MTLCaptureDestination destination)
        {
            throw new NotImplementedException();
        }

        public void SetOutputURL(NSURL outputURL)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_captureObject = "captureObject";
        private static readonly Selector sel_setCaptureObject = "setCaptureObject:";
        private static readonly Selector sel_destination = "destination";
        private static readonly Selector sel_setDestination = "setDestination:";
        private static readonly Selector sel_outputURL = "outputURL";
        private static readonly Selector sel_setOutputURL = "setOutputURL:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLCaptureManager
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCaptureManager obj) => obj.NativePtr;
        public MTLCaptureManager(IntPtr ptr) => NativePtr = ptr;

        public MTLCaptureManager()
        {
            var cls = new ObjectiveCClass("MTLCaptureManager");
            NativePtr = cls.AllocInit();
        }

        public MTLCaptureManager SharedCaptureManager => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sharedCaptureManager));

        public MTLCaptureScope DefaultCaptureScope
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_defaultCaptureScope));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDefaultCaptureScope, value);
        }

        public bool IsCapturing => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isCapturing);

        public MTLCaptureScope NewCaptureScope(MTLDevice device)
        {
            throw new NotImplementedException();
        }

        public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
        {
            throw new NotImplementedException();
        }

        public bool SupportsDestination(MTLCaptureDestination destination)
        {
            throw new NotImplementedException();
        }

        public bool StartCapture(MTLCaptureDescriptor descriptor, NSError error)
        {
            throw new NotImplementedException();
        }

        public void StartCapture(MTLDevice device)
        {
            throw new NotImplementedException();
        }

        public void StartCapture(MTLCommandQueue commandQueue)
        {
            throw new NotImplementedException();
        }

        public void StartCapture(MTLCaptureScope captureScope)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultCaptureScope(MTLCaptureScope defaultCaptureScope)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_sharedCaptureManager = "sharedCaptureManager";
        private static readonly Selector sel_newCaptureScopeWithDevice = "newCaptureScopeWithDevice:";
        private static readonly Selector sel_newCaptureScopeWithCommandQueue = "newCaptureScopeWithCommandQueue:";
        private static readonly Selector sel_supportsDestination = "supportsDestination:";
        private static readonly Selector sel_startCaptureWithDescriptorerror = "startCaptureWithDescriptor:error:";
        private static readonly Selector sel_startCaptureWithDevice = "startCaptureWithDevice:";
        private static readonly Selector sel_startCaptureWithCommandQueue = "startCaptureWithCommandQueue:";
        private static readonly Selector sel_startCaptureWithScope = "startCaptureWithScope:";
        private static readonly Selector sel_stopCapture = "stopCapture";
        private static readonly Selector sel_defaultCaptureScope = "defaultCaptureScope";
        private static readonly Selector sel_setDefaultCaptureScope = "setDefaultCaptureScope:";
        private static readonly Selector sel_isCapturing = "isCapturing";
    }
}
