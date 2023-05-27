using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCompileOptions
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLCompileOptions compileOptions) => compileOptions.NativePtr;
        public MTLCompileOptions(IntPtr ptr) => NativePtr = ptr;

        public bool FastMathEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_fastMathEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFastMathEnabled, value);
        }

        public bool PreserveInvariance
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_preserveInvariance);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreserveInvariance, value);
        }

        public MTLLanguageVersion LanguageVersion
        {
            get => (MTLLanguageVersion)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_languageVersion);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLanguageVersion, (ulong)value);
        }

        // TODO: PreprocessorMacros (needs NSDictionary)

        public MTLLibraryOptimizationLevel OptimizationLevel
        {
            get => (MTLLibraryOptimizationLevel)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_optimizationLevel);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setOptimizationLevel, (long)value);
        }

        // TODO: Libraries (needs NSArray)

        public MTLLibraryType LibraryType
        {
            get => (MTLLibraryType)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_libraryType);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLibraryType, (long)value);
        }

        public NSString InstallName
        {
            get => ObjectiveCRuntime.nsString_objc_msgSend(NativePtr, sel_installName);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInstallName, value);
        }

        public bool AllowReferencingUndefinedSymbols
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_allowReferencingUndefinedSymbols);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAllowReferencingUndefinedSymbols);
        }

        public MTLCompileSymbolVisibility CompileSymbolVisibility
        {
            get => (MTLCompileSymbolVisibility)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_compileSymbolVisibility);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCompileSymbolVisibility, (long)value);
        }

        public ulong MaxTotalThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerThreadgroup, value);
        }

        private static readonly Selector sel_fastMathEnabled = "fastMathEnabled";
        private static readonly Selector sel_setFastMathEnabled = "setFastMathEnabled:";
        private static readonly Selector sel_preserveInvariance = "preserveInvariance";
        private static readonly Selector sel_setPreserveInvariance = "setPreserveInvariance:";
        private static readonly Selector sel_languageVersion = "languageVersion";
        private static readonly Selector sel_setLanguageVersion = "setLanguageVersion:";
        private static readonly Selector sel_preprocessorMacros = "preprocessorMacros";
        private static readonly Selector sel_setPreprocessorMacros = "setPreprocessorMacros:";
        private static readonly Selector sel_optimizationLevel = "optimizationLevel";
        private static readonly Selector sel_setOptimizationLevel = "setOptimizationLevel:";
        private static readonly Selector sel_libraries = "libraries";
        private static readonly Selector sel_setLibraries = "setLibraries:";
        private static readonly Selector sel_libraryType = "libraryType";
        private static readonly Selector sel_setLibraryType = "setLibraryType:";
        private static readonly Selector sel_installName = "installName";
        private static readonly Selector sel_setInstallName = "setInstallName:";
        private static readonly Selector sel_allowReferencingUndefinedSymbols = "allowReferencingUndefinedSymbols";
        private static readonly Selector sel_setAllowReferencingUndefinedSymbols = "setAllowReferencingUndefinedSymbols:";
        private static readonly Selector sel_compileSymbolVisibility = "compileSymbolVisibility";
        private static readonly Selector sel_setCompileSymbolVisibility = "setCompileSymbolVisibility:";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
    }
}