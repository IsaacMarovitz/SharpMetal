using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Examples.Primitive;
using SharpMetal.Foundation;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.Animation
{
    [SupportedOSPlatform("macos")]
    public class Program
    {
        private const int X = 100;
        private const int Y = 100;
        private const int Width = 512;
        private const int Height = 512;
        private const string WindowTitle = "SharpMetal - Animation";

        public static void Main()
        {
            // "Link" Metal, CoreGraphics, AppKit, and MetalKit
            ObjectiveC.LinkMetal();
            ObjectiveC.LinkCoreGraphics();
            ObjectiveC.LinkAppKit();
            ObjectiveC.LinkMetalKit();

            // Create NSApplication
            var nsApplication = new NSApplication();
            var appDelegate = new NSApplicationDelegate(nsApplication);
            nsApplication.SetDelegate(appDelegate);

            appDelegate.OnApplicationDidFinishLaunching += OnApplicationDidFinishLaunching;
            appDelegate.OnApplicationWillFinishLaunching += OnApplicationWillFinishLaunching;

            nsApplication.Run();
        }

        private static void OnApplicationWillFinishLaunching(NSNotification notification)
        {
            var app = new NSApplication(notification.Object);
            app.SetActivationPolicy(NSApplicationActivationPolicy.Regular);
        }

        private static void OnApplicationDidFinishLaunching(NSNotification notification)
        {
            var rect = new NSRect(X, Y, Width, Height);
            var window = new NSWindow(rect, (ulong)(NSStyleMask.Titled | NSStyleMask.Resizable | NSStyleMask.Closable | NSStyleMask.Miniaturizable));

            var device = MTLDevice.CreateSystemDefaultDevice();
            var mtkView = new MTKView(rect, device);
            // TODO: Figure out why this won't work
            // mtkView.ColorPixelFormat = MTLPixelFormat.BGRA8UnormsRGB;
            mtkView.ClearColor = new MTLClearColor { red = 1.0, green = 0.0, blue = 0.0, alpha = 1.0 };
            mtkView.Delegate = MTKViewDelegate.Init<Renderer>(device);

            window.SetContentView(mtkView);
            window.Title = StringHelper.NSString(WindowTitle);
            window.MakeKeyAndOrderFront();

            var app = new NSApplication(notification.Object);
            app.ActivateIgnoringOtherApps(true);
        }
    }
}
