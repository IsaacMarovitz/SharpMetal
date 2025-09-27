using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Metal
{
    /// <summary>
    /// This is a private Metal API.
    /// It is not recommended for use in any production applications,
    /// and may break at any time without warning. Hic sunt dracones.
    /// </summary>
    [SupportedOSPlatform("macos")]
    public enum MTLLogicOperation : ulong
    {
        Clear,
        Set,
        Copy,
        CopyInverted,
        Noop,
        Invert,
        And,
        Nand,
        Or,
        Nor,
        Xor,
        Equivalence,
        AndReverse,
        AndInverted,
        OrReverse,
        OrInverted
    }

    public partial struct MTLRenderPipelineDescriptor
    {
        /// <summary>
        /// This is a private Metal API.
        /// It is not recommended for use in any production applications,
        /// and may break at any time without warning. Hic sunt dracones.
        /// </summary>
        public MTLLogicOperation LogicOperation
        {
            get => (MTLLogicOperation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_logicOperation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogicOperation, (ulong)value);
        }

        /// <summary>
        /// This is a private Metal API.
        /// It is not recommended for use in any production applications,
        /// and may break at any time without warning. Hic sunt dracones.
        /// </summary>
        public bool LogicOperationEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isLogicOperationEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogicOperationEnabled, value);
        }

        private static readonly Selector sel_isLogicOperationEnabled = "isLogicOperationEnabled";
        private static readonly Selector sel_logicOperation = "logicOperation";
        private static readonly Selector sel_setLogicOperation = "setLogicOperation:";
        private static readonly Selector sel_setLogicOperationEnabled = "setLogicOperationEnabled:";
    }
}
