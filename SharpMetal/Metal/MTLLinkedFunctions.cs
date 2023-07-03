using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLLinkedFunctions
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLLinkedFunctions obj) => obj.NativePtr;
        public MTLLinkedFunctions(IntPtr ptr) => NativePtr = ptr;

        public MTLLinkedFunctions()
        {
            var cls = new ObjectiveCClass("MTLLinkedFunctions");
            NativePtr = cls.AllocInit();
        }

        public NSArray Functions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctions, value);
        }

        public NSArray BinaryFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryFunctions, value);
        }

        public NSDictionary Groups
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_groups));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setGroups, value);
        }

        public NSArray PrivateFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_privateFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPrivateFunctions, value);
        }

        public void SetFunctions(NSArray functions)
        {
            throw new NotImplementedException();
        }

        public void SetBinaryFunctions(NSArray binaryFunctions)
        {
            throw new NotImplementedException();
        }

        public void SetGroups(NSDictionary groups)
        {
            throw new NotImplementedException();
        }

        public void SetPrivateFunctions(NSArray privateFunctions)
        {
            throw new NotImplementedException();
        }

        private static readonly Selector sel_linkedFunctions = "linkedFunctions";
        private static readonly Selector sel_functions = "functions";
        private static readonly Selector sel_setFunctions = "setFunctions:";
        private static readonly Selector sel_binaryFunctions = "binaryFunctions";
        private static readonly Selector sel_setBinaryFunctions = "setBinaryFunctions:";
        private static readonly Selector sel_groups = "groups";
        private static readonly Selector sel_setGroups = "setGroups:";
        private static readonly Selector sel_privateFunctions = "privateFunctions";
        private static readonly Selector sel_setPrivateFunctions = "setPrivateFunctions:";
    }
}
