using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4SpecializedFunctionDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4SpecializedFunctionDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4FunctionDescriptor(MTL4SpecializedFunctionDescriptor obj) => new(obj.NativePtr);
        public MTL4SpecializedFunctionDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4SpecializedFunctionDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4SpecializedFunctionDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLFunctionConstantValues ConstantValues
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_constantValues));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantValues, value);
        }

        public MTL4FunctionDescriptor FunctionDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionDescriptor, value);
        }

        public NSString SpecializedName
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_specializedName));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSpecializedName, value);
        }

        private static readonly Selector sel_constantValues = "constantValues";
        private static readonly Selector sel_functionDescriptor = "functionDescriptor";
        private static readonly Selector sel_setConstantValues = "setConstantValues:";
        private static readonly Selector sel_setFunctionDescriptor = "setFunctionDescriptor:";
        private static readonly Selector sel_setSpecializedName = "setSpecializedName:";
        private static readonly Selector sel_specializedName = "specializedName";
        private static readonly Selector sel_release = "release";
    }
}
