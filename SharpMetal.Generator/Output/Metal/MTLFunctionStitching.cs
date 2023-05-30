using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingAttribute
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingAttribute obj) => obj.NativePtr;
        public MTLFunctionStitchingAttribute(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingAttributeAlwaysInline
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingAttributeAlwaysInline obj) => obj.NativePtr;
        public MTLFunctionStitchingAttributeAlwaysInline(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingAttributeAlwaysInline()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingAttributeAlwaysInline");
            NativePtr = cls.AllocInit();
        }
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingNode
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingNode obj) => obj.NativePtr;
        public MTLFunctionStitchingNode(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingInputNode
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingInputNode obj) => obj.NativePtr;
        public MTLFunctionStitchingInputNode(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingInputNode()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingInputNode");
            NativePtr = cls.AllocInit();
        }

        public ulong ArgumentIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndex);

        private static readonly Selector sel_argumentIndex = "argumentIndex";
        private static readonly Selector sel_setArgumentIndex = "setArgumentIndex:";
        private static readonly Selector sel_initWithArgumentIndex = "initWithArgumentIndex:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingFunctionNode
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingFunctionNode obj) => obj.NativePtr;
        public MTLFunctionStitchingFunctionNode(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingFunctionNode()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingFunctionNode");
            NativePtr = cls.AllocInit();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
        public NSArray Arguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arguments));
        public NSArray ControlDependencies => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_controlDependencies));

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_setName = "setName:";
        private static readonly Selector sel_arguments = "arguments";
        private static readonly Selector sel_setArguments = "setArguments:";
        private static readonly Selector sel_controlDependencies = "controlDependencies";
        private static readonly Selector sel_setControlDependencies = "setControlDependencies:";
        private static readonly Selector sel_initWithNameargumentscontrolDependencies = "initWithName:arguments:controlDependencies:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingGraph
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingGraph obj) => obj.NativePtr;
        public MTLFunctionStitchingGraph(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingGraph()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingGraph");
            NativePtr = cls.AllocInit();
        }

        public NSString FunctionName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionName));
        public NSArray Nodes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_nodes));
        public MTLFunctionStitchingFunctionNode OutputNode => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputNode));
        public NSArray Attributes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_attributes));

        private static readonly Selector sel_functionName = "functionName";
        private static readonly Selector sel_setFunctionName = "setFunctionName:";
        private static readonly Selector sel_nodes = "nodes";
        private static readonly Selector sel_setNodes = "setNodes:";
        private static readonly Selector sel_outputNode = "outputNode";
        private static readonly Selector sel_setOutputNode = "setOutputNode:";
        private static readonly Selector sel_attributes = "attributes";
        private static readonly Selector sel_setAttributes = "setAttributes:";
        private static readonly Selector sel_initWithFunctionNamenodesoutputNodeattributes = "initWithFunctionName:nodes:outputNode:attributes:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLStitchedLibraryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStitchedLibraryDescriptor obj) => obj.NativePtr;
        public MTLStitchedLibraryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLStitchedLibraryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLStitchedLibraryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray FunctionGraphs => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionGraphs));
        public NSArray Functions => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functions));

        private static readonly Selector sel_functionGraphs = "functionGraphs";
        private static readonly Selector sel_setFunctionGraphs = "setFunctionGraphs:";
        private static readonly Selector sel_functions = "functions";
        private static readonly Selector sel_setFunctions = "setFunctions:";
    }
}
