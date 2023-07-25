using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLFunctionOptions : ulong
    {
        FunctionOptionNone = 0,
        FunctionOptionCompileToBinary = 1,
    }

    [SupportedOSPlatform("macos")]
    public partial class MTLFunctionDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionDescriptor obj) => obj.NativePtr;
        public MTLFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTLFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSString Name
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setName, value);
        }

        public NSString SpecializedName
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_specializedName));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSpecializedName, value);
        }

        public MTLFunctionConstantValues ConstantValues
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_constantValues));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantValues, value);
        }

        public MTLFunctionOptions Options
        {
            get => (MTLFunctionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_options);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, (ulong)value);
        }

        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
        }

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
    public partial class MTLIntersectionFunctionDescriptor : MTLFunctionDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLIntersectionFunctionDescriptor obj) => obj.NativePtr;
        public MTLIntersectionFunctionDescriptor(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        public MTLIntersectionFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTLIntersectionFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }
    }
}
