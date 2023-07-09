using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Foundation
{
    public enum NSProcessInfoThermalState : long
    {
        Nominal = 0,
        Fair = 1,
        Serious = 2,
        Critical = 3,
    }

    public enum NSActivityOptions : ulong
    {
        ActivityIdleDisplaySleepDisabled = (1UL << 40),
        ActivityIdleSystemSleepDisabled = (1UL << 20),
        ActivitySuddenTerminationDisabled = (1UL << 14),
        ActivityAutomaticTerminationDisabled = (1UL << 15),
        ActivityUserInitiated = (0x00FFFFFFUL | ActivityIdleSystemSleepDisabled),
        ActivityUserInitiatedAllowingIdleSystemSleep = (ActivityUserInitiated & ~ActivityIdleSystemSleepDisabled),
        ActivityBackground = 0x000000FFUL,
        ActivityLatencyCritical = 0xFF00000000UL,
    }

    [SupportedOSPlatform("macos")]
    public partial class NSProcessInfo
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSProcessInfo obj) => obj.NativePtr;
        public NSProcessInfo(IntPtr ptr) => NativePtr = ptr;

        public NSArray Arguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arguments));

        public NSDictionary Environment => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_environment));

        public NSString HostName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_hostName));

        public NSString ProcessName
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_processName));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setProcessName, value);
        }

        public int ProcessIdentifier => ObjectiveCRuntime.int_objc_msgSend(NativePtr, sel_processIdentifier);

        public NSString GloballyUniqueString => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_globallyUniqueString));

        public NSString UserName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_userName));

        public NSString FullUserName => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_fullUserName));

        public ulong OperatingSystem => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_operatingSystem);

        public NSOperatingSystemVersion OperatingSystemVersion => ObjectiveCRuntime.NSOperatingSystemVersion_objc_msgSend(NativePtr, sel_operatingSystemVersion);

        public NSString OperatingSystemVersionString => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_operatingSystemVersionString));

        public ulong ProcessorCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_processorCount);

        public ulong ActiveProcessorCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_activeProcessorCount);

        public ulong PhysicalMemory => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_physicalMemory);

        public IntPtr SystemUptime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_systemUptime));

        public bool AutomaticTerminationSupportEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_automaticTerminationSupportEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setAutomaticTerminationSupportEnabled, value);
        }

        public NSProcessInfoThermalState ThermalState => (NSProcessInfoThermalState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_thermalState);

        public bool IsLowPowerModeEnabled => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isLowPowerModeEnabled);

        public bool IsiOSAppOnMac => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isiOSAppOnMac);

        public bool IsMacCatalystApp => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isMacCatalystApp);

        public bool IsOperatingSystemAtLeastVersion(NSOperatingSystemVersion version)
        {
            return ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_isOperatingSystemAtLeastVersion, version);
        }

        public void DisableSuddenTermination()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_disableSuddenTermination);
        }

        public void EnableSuddenTermination()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_enableSuddenTermination);
        }

        public void DisableAutomaticTermination(NSString pReason)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_disableAutomaticTermination, pReason);
        }

        public void EnableAutomaticTermination(NSString pReason)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_enableAutomaticTermination, pReason);
        }

        public NSObject BeginActivity(NSActivityOptions options, NSString pReason)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_beginActivityWithOptionsreason, (ulong)options, pReason));
        }

        public void EndActivity(NSObject pActivity)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endActivity, pActivity);
        }

        private static readonly Selector sel_processInfo = "processInfo";
        private static readonly Selector sel_arguments = "arguments";
        private static readonly Selector sel_environment = "environment";
        private static readonly Selector sel_hostName = "hostName";
        private static readonly Selector sel_processName = "processName";
        private static readonly Selector sel_setProcessName = "setProcessName:";
        private static readonly Selector sel_processIdentifier = "processIdentifier";
        private static readonly Selector sel_globallyUniqueString = "globallyUniqueString";
        private static readonly Selector sel_userName = "userName";
        private static readonly Selector sel_fullUserName = "fullUserName";
        private static readonly Selector sel_operatingSystem = "operatingSystem";
        private static readonly Selector sel_operatingSystemVersion = "operatingSystemVersion";
        private static readonly Selector sel_operatingSystemVersionString = "operatingSystemVersionString";
        private static readonly Selector sel_isOperatingSystemAtLeastVersion = "isOperatingSystemAtLeastVersion:";
        private static readonly Selector sel_processorCount = "processorCount";
        private static readonly Selector sel_activeProcessorCount = "activeProcessorCount";
        private static readonly Selector sel_physicalMemory = "physicalMemory";
        private static readonly Selector sel_systemUptime = "systemUptime";
        private static readonly Selector sel_disableSuddenTermination = "disableSuddenTermination";
        private static readonly Selector sel_enableSuddenTermination = "enableSuddenTermination";
        private static readonly Selector sel_disableAutomaticTermination = "disableAutomaticTermination:";
        private static readonly Selector sel_enableAutomaticTermination = "enableAutomaticTermination:";
        private static readonly Selector sel_automaticTerminationSupportEnabled = "automaticTerminationSupportEnabled";
        private static readonly Selector sel_setAutomaticTerminationSupportEnabled = "setAutomaticTerminationSupportEnabled:";
        private static readonly Selector sel_beginActivityWithOptionsreason = "beginActivityWithOptions:reason:";
        private static readonly Selector sel_endActivity = "endActivity:";
        private static readonly Selector sel_performActivityWithOptionsreasonusingBlock = "performActivityWithOptions:reason:usingBlock:";
        private static readonly Selector sel_performExpiringActivityWithReasonusingBlock = "performExpiringActivityWithReason:usingBlock:";
        private static readonly Selector sel_thermalState = "thermalState";
        private static readonly Selector sel_isLowPowerModeEnabled = "isLowPowerModeEnabled";
        private static readonly Selector sel_isiOSAppOnMac = "isiOSAppOnMac";
        private static readonly Selector sel_isMacCatalystApp = "isMacCatalystApp";
    }
}
