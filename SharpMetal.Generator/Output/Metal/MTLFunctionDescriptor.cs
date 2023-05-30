using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLFunctionOptions: ulong
    {
        FunctionOptionNone = 0,
        FunctionOptionCompileToBinary = 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionDescriptor obj) => obj.NativePtr;
        public MTLFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLFunctionDescriptor FunctionDescriptor => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionDescriptor));
        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
        public NSString SpecializedName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_specializedName));
        public MTLFunctionConstantValues AntValues => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_constantValues));
        public MTLFunctionOptions Options => (MTLFunctionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_options);
        public NSArray BinaryArchives => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));

        private static readonly Selector sel_functionDescriptor = "functionDescriptor";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_setName = "setName:";
        private static readonly Selector sel_specializedName = "specializedName";
        private static readonly Selector sel_setSpecializedName = "setSpecializedName:";
        private static readonly Selector sel_constantValues = "constantValues";
        private static readonly Selector sel_setConstantValues = "setConstantValues:";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLIntersectionFunctionDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionDescriptor obj) => obj.NativePtr;
        public MTLIntersectionFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLIntersectionFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIntersectionFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }
    }
}