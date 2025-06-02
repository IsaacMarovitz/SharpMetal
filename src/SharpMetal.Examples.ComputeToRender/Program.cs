using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Foundation;
using SharpMetal.Metal;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Examples.ComputeToRender
{
    [SupportedOSPlatform("macos")]
    public class Program
    {
        private const int X = 100;
        private const int Y = 100;
        private const int Width = 1024;
        private const int Height = 1024;
        private const string WindowTitle = "SharpMetal - Compute to Render";

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
            mtkView.ColorPixelFormat = MTLPixelFormat.BGRA8UnormsRGB;
            mtkView.DepthStencilPixelFormat = MTLPixelFormat.Depth16Unorm;
            mtkView.ClearColor = new MTLClearColor { red = 0.1, green = 0.1, blue = 0.1, alpha = 1.0 };
            mtkView.Delegate = MTKViewDelegate.Init<Renderer>(device);

            window.SetContentView(mtkView);
            window.Title = WindowTitle;
            window.MakeKeyAndOrderFront();

            var app = new NSApplication(notification.Object);
            app.ActivateIgnoringOtherApps(true);
        }
    }
}
