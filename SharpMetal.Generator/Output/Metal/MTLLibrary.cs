using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLPatchType: ulong
    {
        None = 0,
        Triangle = 1,
        Quad = 2,
    }

    public enum MTLFunctionType: ulong
    {
        Vertex = 1,
        Fragment = 2,
        Kernel = 3,
        Visible = 5,
        Intersection = 6,
        Mesh = 7,
        Object = 8,
    }

    public enum MTLLanguageVersion: ulong
    {
        Version10 = 65536,
        Version11 = 65537,
        Version12 = 65538,
        Version20 = 131072,
        Version21 = 131073,
        Version22 = 131074,
        Version23 = 131075,
        Version24 = 131076,
        Version30 = 196608,
    }

    public enum MTLLibraryType: long
    {
        Executable = 0,
        Dynamic = 1,
    }

    public enum MTLLibraryOptimizationLevel: long
    {
        Default = 0,
        Size = 1,
    }

    public enum MTLCompileSymbolVisibility: long
    {
        Default = 0,
        Hidden = 1,
    }

    public enum MTLLibraryError: ulong
    {
        Unsupported = 1,
        Internal = 2,
        CompileFailure = 3,
        CompileWarning = 4,
        FunctionNotFound = 5,
        FileNotFound = 6,
    }

    [SupportedOSPlatform("macos")]
    public struct MTLVertexAttribute
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLVertexAttribute obj) => obj.NativePtr;
        public MTLVertexAttribute(IntPtr ptr) => NativePtr = ptr;

        public MTLVertexAttribute()
        {
            var cls = new ObjectiveCClass("MTLVertexAttribute");
            NativePtr = cls.AllocInit();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
        public ulong AttributeIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_attributeIndex);
        public MTLDataType AttributeType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_attributeType);
        public bool Active => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isActive);
        public bool PatchData => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isPatchData);
        public bool PatchControlPointData => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isPatchControlPointData);

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_attributeIndex = "attributeIndex";
        private static readonly Selector sel_attributeType = "attributeType";
        private static readonly Selector sel_isActive = "isActive";
        private static readonly Selector sel_isPatchData = "isPatchData";
        private static readonly Selector sel_isPatchControlPointData = "isPatchControlPointData";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLAttribute
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLAttribute obj) => obj.NativePtr;
        public MTLAttribute(IntPtr ptr) => NativePtr = ptr;

        public MTLAttribute()
        {
            var cls = new ObjectiveCClass("MTLAttribute");
            NativePtr = cls.AllocInit();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
        public ulong AttributeIndex => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_attributeIndex);
        public MTLDataType AttributeType => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_attributeType);
        public bool Active => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isActive);
        public bool PatchData => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isPatchData);
        public bool PatchControlPointData => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isPatchControlPointData);

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_attributeIndex = "attributeIndex";
        private static readonly Selector sel_attributeType = "attributeType";
        private static readonly Selector sel_isActive = "isActive";
        private static readonly Selector sel_isPatchData = "isPatchData";
        private static readonly Selector sel_isPatchControlPointData = "isPatchControlPointData";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunctionConstant
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunctionConstant obj) => obj.NativePtr;
        public MTLFunctionConstant(IntPtr ptr) => NativePtr = ptr;

        public MTLFunctionConstant()
        {
            var cls = new ObjectiveCClass("MTLFunctionConstant");
            NativePtr = cls.AllocInit();
        }

        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
        public MTLDataType Type => (MTLDataType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_type);
        public ulong Index => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_index);
        public bool Required => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_required);

        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_index = "index";
        private static readonly Selector sel_required = "required";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLFunction
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLFunction obj) => obj.NativePtr;
        public MTLFunction(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public MTLFunctionType FunctionType => (MTLFunctionType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_functionType);
        public MTLPatchType PatchType => (MTLPatchType)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_patchType);
        public long PatchControlPointCount => ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_patchControlPointCount);
        public NSArray VertexAttributes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertexAttributes));
        public NSArray StageInputAttributes => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stageInputAttributes));
        public NSString Name => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_name));
        public NSDictionary FunctionConstantsDictionary => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionConstantsDictionary));
        public MTLFunctionOptions Options => (MTLFunctionOptions)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_options);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_functionType = "functionType";
        private static readonly Selector sel_patchType = "patchType";
        private static readonly Selector sel_patchControlPointCount = "patchControlPointCount";
        private static readonly Selector sel_vertexAttributes = "vertexAttributes";
        private static readonly Selector sel_stageInputAttributes = "stageInputAttributes";
        private static readonly Selector sel_name = "name";
        private static readonly Selector sel_functionConstantsDictionary = "functionConstantsDictionary";
        private static readonly Selector sel_newArgumentEncoderWithBufferIndex = "newArgumentEncoderWithBufferIndex:";
        private static readonly Selector sel_newArgumentEncoderWithBufferIndexreflection = "newArgumentEncoderWithBufferIndex:reflection:";
        private static readonly Selector sel_options = "options";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLCompileOptions
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCompileOptions obj) => obj.NativePtr;
        public MTLCompileOptions(IntPtr ptr) => NativePtr = ptr;

        public MTLCompileOptions()
        {
            var cls = new ObjectiveCClass("MTLCompileOptions");
            NativePtr = cls.AllocInit();
        }

        public NSDictionary PreprocessorMacros => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preprocessorMacros));
        public bool FastMathEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_fastMathEnabled);
        public MTLLanguageVersion LanguageVersion => (MTLLanguageVersion)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_languageVersion);
        public MTLLibraryType LibraryType => (MTLLibraryType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_libraryType);
        public NSString InstallName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_installName));
        public NSArray Libraries => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_libraries));
        public bool PreserveInvariance => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_preserveInvariance);
        public MTLLibraryOptimizationLevel OptimizationLevel => (MTLLibraryOptimizationLevel)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_optimizationLevel);
        public MTLCompileSymbolVisibility CompileSymbolVisibility => (MTLCompileSymbolVisibility)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compileSymbolVisibility);
        public bool AllowReferencingUndefinedSymbols => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowReferencingUndefinedSymbols);
        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);

        private static readonly Selector sel_preprocessorMacros = "preprocessorMacros";
        private static readonly Selector sel_setPreprocessorMacros = "setPreprocessorMacros:";
        private static readonly Selector sel_fastMathEnabled = "fastMathEnabled";
        private static readonly Selector sel_setFastMathEnabled = "setFastMathEnabled:";
        private static readonly Selector sel_languageVersion = "languageVersion";
        private static readonly Selector sel_setLanguageVersion = "setLanguageVersion:";
        private static readonly Selector sel_libraryType = "libraryType";
        private static readonly Selector sel_setLibraryType = "setLibraryType:";
        private static readonly Selector sel_installName = "installName";
        private static readonly Selector sel_setInstallName = "setInstallName:";
        private static readonly Selector sel_libraries = "libraries";
        private static readonly Selector sel_setLibraries = "setLibraries:";
        private static readonly Selector sel_preserveInvariance = "preserveInvariance";
        private static readonly Selector sel_setPreserveInvariance = "setPreserveInvariance:";
        private static readonly Selector sel_optimizationLevel = "optimizationLevel";
        private static readonly Selector sel_setOptimizationLevel = "setOptimizationLevel:";
        private static readonly Selector sel_compileSymbolVisibility = "compileSymbolVisibility";
        private static readonly Selector sel_setCompileSymbolVisibility = "setCompileSymbolVisibility:";
        private static readonly Selector sel_allowReferencingUndefinedSymbols = "allowReferencingUndefinedSymbols";
        private static readonly Selector sel_setAllowReferencingUndefinedSymbols = "setAllowReferencingUndefinedSymbols:";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLLibrary
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLLibrary obj) => obj.NativePtr;
        public MTLLibrary(IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public NSArray FunctionNames => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionNames));
        public MTLLibraryType Type => (MTLLibraryType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_type);
        public NSString InstallName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_installName));

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_newFunctionWithName = "newFunctionWithName:";
        private static readonly Selector sel_newFunctionWithNameconstantValueserror = "newFunctionWithName:constantValues:error:";
        private static readonly Selector sel_newFunctionWithDescriptorerror = "newFunctionWithDescriptor:error:";
        private static readonly Selector sel_newIntersectionFunctionWithDescriptorerror = "newIntersectionFunctionWithDescriptor:error:";
        private static readonly Selector sel_functionNames = "functionNames";
        private static readonly Selector sel_type = "type";
        private static readonly Selector sel_installName = "installName";
    }
}