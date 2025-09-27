using SharpMetal.ObjectiveCCore;

namespace SharpMetal.QuartzCore
{
    public partial struct CAMetalLayer
    {
        public IntPtr Colorspace
        {
            get => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_colorspace);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setColorspace, value);
        }

        public bool DisplaySyncEnabled
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_displaySyncEnabled);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDisplaySyncEnabled, value);
        }

        private static readonly Selector sel_colorspace = "colorspace";
        private static readonly Selector sel_displaySyncEnabled = "displaySyncEnabled";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setColorspace = "setColorspace:";
        private static readonly Selector sel_setDisplaySyncEnabled = "setDisplaySyncEnabled:";
    }
}
