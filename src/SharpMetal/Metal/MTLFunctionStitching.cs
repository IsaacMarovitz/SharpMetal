using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    [Flags]
    public enum MTLStitchedLibraryOptions : ulong
    {
        None = 0,
        FailOnBinaryArchiveMiss = 1,
        StoreLibraryInMetalPipelinesScript = 1 << 1,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingAttribute : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingAttribute obj) => obj.NativePtr;
        public MTLFunctionStitchingAttribute(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingAttributeAlwaysInline : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingAttributeAlwaysInline obj) => obj.NativePtr;
        public static implicit operator MTLFunctionStitchingAttribute(MTLFunctionStitchingAttributeAlwaysInline obj) => new(obj.NativePtr);
        public MTLFunctionStitchingAttributeAlwaysInline(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingAttributeAlwaysInline()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingAttributeAlwaysInline");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingFunctionNode : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingFunctionNode obj) => obj.NativePtr;
        public static implicit operator MTLFunctionStitchingNode(MTLFunctionStitchingFunctionNode obj) => new(obj.NativePtr);
        public MTLFunctionStitchingFunctionNode(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingFunctionNode()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingFunctionNode");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
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

        public NSString Name
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setName, value);
        }

        public MTLFunctionStitchingFunctionNode Init(NSString name, NSArray arguments, NSArray controlDependencies)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithNameargumentscontrolDependencies, name, arguments, controlDependencies));
        }

        private static readonly Selector sel_arguments = "arguments";
        private static readonly Selector sel_controlDependencies = "controlDependencies";
        private static readonly Selector sel_initWithNameargumentscontrolDependencies = "initWithName:arguments:controlDependencies:";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_setArguments = "setArguments:";
        private static readonly Selector sel_setControlDependencies = "setControlDependencies:";
        private static readonly Selector sel_setName = "setName:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingGraph : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingGraph obj) => obj.NativePtr;
        public MTLFunctionStitchingGraph(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingGraph()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingGraph");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray Attributes
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_attributes));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAttributes, value);
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

        public MTLFunctionStitchingGraph Init(NSString functionName, NSArray nodes, MTLFunctionStitchingFunctionNode outputNode, NSArray attributes)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithFunctionNamenodesoutputNodeattributes, functionName, nodes, outputNode, attributes));
        }

        private static readonly Selector sel_attributes = "attributes";
        private static readonly Selector sel_functionName = "functionName";
        private static readonly Selector sel_initWithFunctionNamenodesoutputNodeattributes = "initWithFunctionName:nodes:outputNode:attributes:";
        private static readonly Selector sel_nodes = "nodes";
        private static readonly Selector sel_outputNode = "outputNode";
        private static readonly Selector sel_setAttributes = "setAttributes:";
        private static readonly Selector sel_setFunctionName = "setFunctionName:";
        private static readonly Selector sel_setNodes = "setNodes:";
        private static readonly Selector sel_setOutputNode = "setOutputNode:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingInputNode : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingInputNode obj) => obj.NativePtr;
        public static implicit operator MTLFunctionStitchingNode(MTLFunctionStitchingInputNode obj) => new(obj.NativePtr);
        public MTLFunctionStitchingInputNode(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionStitchingInputNode()
        {
            var cls = new ObjectiveCClass("MTLFunctionStitchingInputNode");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public ulong ArgumentIndex
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_argumentIndex);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setArgumentIndex, value);
        }

        public MTLFunctionStitchingInputNode Init(ulong argument)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithArgumentIndex, argument));
        }

        private static readonly Selector sel_argumentIndex = "argumentIndex";
        private static readonly Selector sel_initWithArgumentIndex = "initWithArgumentIndex:";
        private static readonly Selector sel_setArgumentIndex = "setArgumentIndex:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionStitchingNode : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionStitchingNode obj) => obj.NativePtr;
        public MTLFunctionStitchingNode(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLStitchedLibraryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLStitchedLibraryDescriptor obj) => obj.NativePtr;
        public MTLStitchedLibraryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLStitchedLibraryDescriptor()
        {
            var cls = new ObjectiveCClass("MTLStitchedLibraryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
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

        public MTLStitchedLibraryOptions Options
        {
            get => (MTLStitchedLibraryOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_options);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptions, (ulong)value);
        }

        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_functionGraphs = "functionGraphs";
        private static readonly Selector sel_functions = "functions";
        private static readonly Selector sel_options = "options";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
        private static readonly Selector sel_setFunctionGraphs = "setFunctionGraphs:";
        private static readonly Selector sel_setFunctions = "setFunctions:";
        private static readonly Selector sel_setOptions = "setOptions:";
        private static readonly Selector sel_release = "release";
    }
}
