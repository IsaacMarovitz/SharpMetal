using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public class MTLFunctionStitchingAttribute
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingAttribute obj) => obj.NativePtr;
        public MTLFunctionStitchingAttribute(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public class MTLFunctionStitchingAttributeAlwaysInline
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
    public class MTLFunctionStitchingNode
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingNode obj) => obj.NativePtr;
        public MTLFunctionStitchingNode(IntPtr ptr) => NativePtr = ptr;
    }

    [SupportedOSPlatform("macos")]
    public class MTLFunctionStitchingInputNode
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingInputNode obj) => obj.NativePtr;
        public MTLFunctionStitchingInputNode(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingInputNode()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingInputNode");
            NativePtr = cls.AllocInit();
        }

        public ulong ArgumentIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArgumentIndex, value);
        }

        public void SetArgumentIndex(ulong argumentIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArgumentIndex, argumentIndex);
        }

        public MTLFunctionStitchingInputNode Init(ulong argument)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithArgumentIndex, argument));
        }

        private static readonly Selector sel_argumentIndex = "argumentIndex";
        private static readonly Selector sel_setArgumentIndex = "setArgumentIndex:";
        private static readonly Selector sel_initWithArgumentIndex = "initWithArgumentIndex:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLFunctionStitchingFunctionNode
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingFunctionNode obj) => obj.NativePtr;
        public MTLFunctionStitchingFunctionNode(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingFunctionNode()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingFunctionNode");
            NativePtr = cls.AllocInit();
        }

        public NSString Name
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setName, value);
        }

        public NSArray Arguments
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arguments));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArguments, value);
        }

        public NSArray ControlDependencies
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_controlDependencies));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlDependencies, value);
        }

        public void SetName(NSString name)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setName, name);
        }

        public void SetArguments(NSArray arguments)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArguments, arguments);
        }

        public void SetControlDependencies(NSArray controlDependencies)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setControlDependencies, controlDependencies);
        }

        public MTLFunctionStitchingFunctionNode Init(NSString name, NSArray arguments, NSArray controlDependencies)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithNameargumentscontrolDependencies, name, arguments, controlDependencies));
        }

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_setName = "setName:";
        private static readonly Selector sel_arguments = "arguments";
        private static readonly Selector sel_setArguments = "setArguments:";
        private static readonly Selector sel_controlDependencies = "controlDependencies";
        private static readonly Selector sel_setControlDependencies = "setControlDependencies:";
        private static readonly Selector sel_initWithNameargumentscontrolDependencies = "initWithName:arguments:controlDependencies:";
    }

    [SupportedOSPlatform("macos")]
    public class MTLFunctionStitchingGraph
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingGraph obj) => obj.NativePtr;
        public MTLFunctionStitchingGraph(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingGraph()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingGraph");
            NativePtr = cls.AllocInit();
        }

        public NSString FunctionName
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionName));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionName, value);
        }

        public NSArray Nodes
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_nodes));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNodes, value);
        }

        public MTLFunctionStitchingFunctionNode OutputNode
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_outputNode));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputNode, value);
        }

        public NSArray Attributes
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_attributes));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAttributes, value);
        }

        public void SetFunctionName(NSString functionName)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionName, functionName);
        }

        public void SetNodes(NSArray nodes)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setNodes, nodes);
        }

        public void SetOutputNode(MTLFunctionStitchingFunctionNode outputNode)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOutputNode, outputNode);
        }

        public void SetAttributes(NSArray attributes)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAttributes, attributes);
        }

        public MTLFunctionStitchingGraph Init(NSString functionName, NSArray nodes, MTLFunctionStitchingFunctionNode outputNode, NSArray attributes)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithFunctionNamenodesoutputNodeattributes, functionName, nodes, outputNode, attributes));
        }

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
    public class MTLStitchedLibraryDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStitchedLibraryDescriptor obj) => obj.NativePtr;
        public MTLStitchedLibraryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLStitchedLibraryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLStitchedLibraryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public NSArray FunctionGraphs
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionGraphs));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionGraphs, value);
        }

        public NSArray Functions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctions, value);
        }

        public void SetFunctionGraphs(NSArray functionGraphs)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctionGraphs, functionGraphs);
        }

        public void SetFunctions(NSArray functions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFunctions, functions);
        }

        private static readonly Selector sel_functionGraphs = "functionGraphs";
        private static readonly Selector sel_setFunctionGraphs = "setFunctionGraphs:";
        private static readonly Selector sel_functions = "functions";
        private static readonly Selector sel_setFunctions = "setFunctions:";
    }
}
