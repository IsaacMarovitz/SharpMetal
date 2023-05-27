using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLLibrary
    {
        public readonly IntPtr NativePtr;
        public MTLLibrary(IntPtr ptr) => NativePtr = ptr;

        public NSString InstallName => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_installName);

        public MTLLibraryType Type => (MTLLibraryType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);

        // TODO: Needs NSArray
        // public NSArray<NSString> FunctionNames;

        public MTLFunction NewFunctionWithName(NSString name)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newFunctionWithName, name.NativePtr));
        }

        // TODO: Needs MTLFunctionConstantValues
        /*public void NewFunctionWithNameConstantValuesCompletionHandler(NSString name, MTLFunctionConstantValues constantValues, IntPtr completionHandler)
        {

        }*/

        // TODO: Needs MTLFunctionConstantValues, NSError
        /*public MTLFunction NewFunctionWithNameConstantValuesError(NSString name, MTLFunctionConstantValues constantValues, out NSError error)
        {

        }*/

        // TODO: Needs MTLFunctionDescriptor
        /*public void NewFunctionWithDescriptorCompletionHandler(MTLFunctionDescriptor descriptor, IntPtr completionHandler)
        {

        }*/

        // TODO: Needs MTLFunctionDescriptor, NSError
        /*public void NewFunctionWithDescriptorError(MTLFunctionDescriptor descriptor, out NSError error)
        {

        }*/

        // TODO: Needs MTLIntersectionFunctionDescriptor
        /*public void NewIntersectionFunctionWithDescriptorCompletionHandler(MTLIntersectionFunctionDescriptor descriptor, IntPtr completionHandler)
        {

        }*/

        // TODO: Needs MTLIntersectionFunctionDescriptor, NSError
        /*public void NewIntersectionFunctionWithDescriptorError(MTLIntersectionFunctionDescriptor descriptor, out NSError error)
        {

        }*/

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        private NSString Label => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_label);

        private static readonly Selector sel_installName = "installName";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_functionNames = "functionNames";
        private static readonly Selector sel_newFunctionWithName = "newFunctionWithName:";
        private static readonly Selector sel_newFunctionWithNameConstantValuesCompletionHandler = "newFunctionWithName:constantValues:completionHandler:";
        private static readonly Selector sel_newFunctionWithNameConstantValuesError = "newFunctionWithName:constantValues:error:";
        private static readonly Selector sel_newFunctionWithDescriptorCompletionHandler = "newFunctionWithDescriptor:completionHandler:";
        private static readonly Selector sel_newFunctionWithDescriptorError = "newFunctionWithDescriptor:error:";
        private static readonly Selector sel_newIntersectionFunctionWithDescriptorCompletionHandler = "newIntersectionFunctionWithDescriptor:completionHandler:";
        private static readonly Selector sel_newIntersectionFunctionWithDescriptorError = "newIntersectionFunctionWithDescriptor:error:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
    }
}