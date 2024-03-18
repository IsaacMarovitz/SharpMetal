using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public struct NSBundle
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSBundle obj) => obj.NativePtr;
        public NSBundle(IntPtr ptr) => NativePtr = ptr;

        public NSBundle()
        {
            var cls = new ObjectiveCClass("NSBundle");
            NativePtr = cls.Alloc();
        }

        public NSArray AllBundles => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_allBundles));

        public NSArray AllFrameworks => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_allFrameworks));

        public bool Load => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_load);

        public bool Unload => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_unload);

        public bool IsLoaded => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isLoaded);

        public NSURL BundleURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bundleURL));

        public NSURL ResourceURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceURL));

        public NSURL ExecutableURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_executableURL));

        public NSURL PrivateFrameworksURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_privateFrameworksURL));

        public NSURL SharedFrameworksURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sharedFrameworksURL));

        public NSURL SharedSupportURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sharedSupportURL));

        public NSURL BuiltInPlugInsURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_builtInPlugInsURL));

        public NSURL AppStoreReceiptURL => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_appStoreReceiptURL));

        public NSString BundlePath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bundlePath));

        public NSString ResourcePath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourcePath));

        public NSString ExecutablePath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_executablePath));

        public NSString PrivateFrameworksPath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_privateFrameworksPath));

        public NSString SharedFrameworksPath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sharedFrameworksPath));

        public NSString SharedSupportPath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sharedSupportPath));

        public NSString BuiltInPlugInsPath => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_builtInPlugInsPath));

        public NSString BundleIdentifier => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bundleIdentifier));

        public NSDictionary InfoDictionary => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_infoDictionary));

        public NSDictionary LocalizedInfoDictionary => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_localizedInfoDictionary));

        public static NSBundle MainBundle()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSBundle"), sel_mainBundle));
        }

        public static NSBundle Bundle(NSString pPath)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSBundle"), sel_bundleWithPath, pPath));
        }

        public static NSBundle Bundle(NSURL pURL)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("NSBundle"), sel_bundleWithURL, pURL));
        }

        public NSBundle Init(NSString pPath)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithPath, pPath));
        }

        public NSBundle Init(NSURL pURL)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithURL, pURL));
        }

        public bool PreflightAndReturnError(ref NSError pError)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_preflightAndReturnError, ref pError.NativePtr);
        }

        public bool LoadAndReturnError(ref NSError pError)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_loadAndReturnError, ref pError.NativePtr);
        }

        public NSURL URLForAuxiliaryExecutable(NSString pExecutableName)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_URLForAuxiliaryExecutable, pExecutableName));
        }

        public NSString PathForAuxiliaryExecutable(NSString pExecutableName)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_pathForAuxiliaryExecutable, pExecutableName));
        }

        public NSObject ObjectForInfoDictionaryKey(NSString pKey)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectForInfoDictionaryKey, pKey));
        }

        private static readonly Selector sel_mainBundle = "mainBundle";
        private static readonly Selector sel_bundleWithPath = "bundleWithPath:";
        private static readonly Selector sel_bundleWithURL = "bundleWithURL:";
        private static readonly Selector sel_alloc = "alloc";
        private static readonly Selector sel_initWithPath = "initWithPath:";
        private static readonly Selector sel_initWithURL = "initWithURL:";
        private static readonly Selector sel_allBundles = "allBundles";
        private static readonly Selector sel_allFrameworks = "allFrameworks";
        private static readonly Selector sel_load = "load";
        private static readonly Selector sel_unload = "unload";
        private static readonly Selector sel_isLoaded = "isLoaded";
        private static readonly Selector sel_preflightAndReturnError = "preflightAndReturnError:";
        private static readonly Selector sel_loadAndReturnError = "loadAndReturnError:";
        private static readonly Selector sel_bundleURL = "bundleURL";
        private static readonly Selector sel_resourceURL = "resourceURL";
        private static readonly Selector sel_executableURL = "executableURL";
        private static readonly Selector sel_URLForAuxiliaryExecutable = "URLForAuxiliaryExecutable:";
        private static readonly Selector sel_privateFrameworksURL = "privateFrameworksURL";
        private static readonly Selector sel_sharedFrameworksURL = "sharedFrameworksURL";
        private static readonly Selector sel_sharedSupportURL = "sharedSupportURL";
        private static readonly Selector sel_builtInPlugInsURL = "builtInPlugInsURL";
        private static readonly Selector sel_appStoreReceiptURL = "appStoreReceiptURL";
        private static readonly Selector sel_bundlePath = "bundlePath";
        private static readonly Selector sel_resourcePath = "resourcePath";
        private static readonly Selector sel_executablePath = "executablePath";
        private static readonly Selector sel_pathForAuxiliaryExecutable = "pathForAuxiliaryExecutable:";
        private static readonly Selector sel_privateFrameworksPath = "privateFrameworksPath";
        private static readonly Selector sel_sharedFrameworksPath = "sharedFrameworksPath";
        private static readonly Selector sel_sharedSupportPath = "sharedSupportPath";
        private static readonly Selector sel_builtInPlugInsPath = "builtInPlugInsPath";
        private static readonly Selector sel_bundleIdentifier = "bundleIdentifier";
        private static readonly Selector sel_infoDictionary = "infoDictionary";
        private static readonly Selector sel_localizedInfoDictionary = "localizedInfoDictionary";
        private static readonly Selector sel_objectForInfoDictionaryKey = "objectForInfoDictionaryKey:";
        private static readonly Selector sel_localizedStringForKeyvaluetable = "localizedStringForKey:value:table:";
    }
}
