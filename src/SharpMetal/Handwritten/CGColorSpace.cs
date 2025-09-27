using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Foundation;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.QuartzCore
{
    public enum ColorSpace
    {
        DisplayP3,
        DisplayP3HLG,
        ExtendedLinearDisplayP3,
        SRGB,
        LinearSRGB,
        ExtendedSRGB,
        ExtendedLinearSRGB,
        GenericGrayGamma22,
        LinearGray,
        ExtendedGray,
        ExtendedLinearGray,
        GenericRGBLinear,
        GenericCMYK,
        GenericXYZ,
        GenericLab,
        ACESCGLinear,
        AdobeRGB1998,
        DCIP3,
        ITUR709,
        ROMMRGB,
        ITUR2020,
        ExtendedLinearITUR2020
    }

    [SupportedOSPlatform("macos")]
    public partial struct CGColorSpace
    {
        private const string CoreGraphicsFramework = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";

        [LibraryImport(CoreGraphicsFramework)]
        private static partial IntPtr CGColorSpaceCreateWithName(IntPtr name);

        private static NSString GetString(ColorSpace colorSpace)
        {
            var colorSpaceName = colorSpace switch
            {
                ColorSpace.DisplayP3 => "kCGColorSpaceDisplayP3",
                ColorSpace.DisplayP3HLG => "kCGColorSpaceDisplayP3_HLG",
                ColorSpace.ExtendedLinearDisplayP3 => "kCGColorSpaceExtendedLinearDisplayP3",
                ColorSpace.SRGB => "kCGColorSpaceSRGB",
                ColorSpace.LinearSRGB => "kCGColorSpaceLinearSRGB",
                ColorSpace.ExtendedSRGB => "kCGColorSpaceExtendedSRGB",
                ColorSpace.ExtendedLinearSRGB => "kCGColorSpaceExtendedLinearSRGB",
                ColorSpace.GenericGrayGamma22 => "kCGColorSpaceGenericGrayGamma2_2",
                ColorSpace.LinearGray => "kCGColorSpaceLinearGray",
                ColorSpace.ExtendedGray => "kCGColorSpaceExtendedGray",
                ColorSpace.ExtendedLinearGray => "kCGColorSpaceExtendedLinearGray",
                ColorSpace.GenericRGBLinear => "kCGColorSpaceGenericRGBLinear",
                ColorSpace.GenericCMYK => "kCGColorSpaceGenericCMYK",
                ColorSpace.GenericXYZ => "kCGColorSpaceGenericXYZ",
                ColorSpace.GenericLab => "kCGColorSpaceGenericLab",
                ColorSpace.ACESCGLinear => "kCGColorSpaceACESCGLinear",
                ColorSpace.AdobeRGB1998 => "kCGColorSpaceAdobeRGB1998",
                ColorSpace.DCIP3 => "kCGColorSpaceDCIP3",
                ColorSpace.ITUR709 => "kCGColorSpaceITUR_709",
                ColorSpace.ROMMRGB => "kCGColorSpaceROMMRGB",
                ColorSpace.ITUR2020 => "kCGColorSpaceITUR_2020",
                ColorSpace.ExtendedLinearITUR2020 => "kCGColorSpaceExtendedLinearITUR_2020",
                _ => throw new ArgumentOutOfRangeException(nameof(colorSpace), colorSpace, "Invalid color space.")
            };

            return new(ObjectiveC.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), "stringWithUTF8String:", colorSpaceName));
        }

        public static IntPtr CreateCGColorSpace(ColorSpace colorSpace)
        {
            return CGColorSpaceCreateWithName(GetString(colorSpace));
        }
    }
}
