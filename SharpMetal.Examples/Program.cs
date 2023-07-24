using System.Runtime.Versioning;
using SharpMetal.Foundation;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class Program
    {
        public static void Main(string[] args)
        {
            // "Link" Metal, CoreGraphics, and AppKit
            ObjectiveC.dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
            ObjectiveC.dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);
            ObjectiveC.dlopen("/System/Library/Frameworks/AppKit.framework/AppKit", 0);

            // Create CAMetalLayer
            ObjectiveCClass layerObject = new("CAMetalLayer");
            var metalLayer = layerObject.AllocInit();

            // Create a child NSView to render to
            ObjectiveCClass nsViewObject = new("NSView");
            var child = nsViewObject.Alloc();
            child.SendMessage("init", new ObjectiveC.NSRect(0, 0, 1000, 1000));
            child.SendMessage("setWantsLayer:", 1);
            child.SendMessage("setLayer:", metalLayer);

            // Create NSApplication
            ObjectiveCClass nsApplicationObject = new("NSApplication");
            ObjectiveCClass application = new(ObjectiveC.IntPtr_objc_msgSend(nsApplicationObject, "sharedApplication"));

            // Create and show NSWindow
            ObjectiveCClass nsWindowObject = new("NSWindow");
            var window = nsWindowObject.Alloc();
            window.SendMessage("initWithContentRect:styleMask:backing:defer:", new ObjectiveC.NSRect(0, 0, 1000, 1000), 0, 0, 0);
            window.SendMessage("setContentView:", child);
            window.SendMessage("makeKeyAndOrderFront:");

            application.SendMessage("run");

            while (true) { }
        }

        public static void Test()
        {
            ObjectiveC.dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
            ObjectiveC.dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);

            var device = MTLDevice.CreateSystemDefaultDevice();
            Console.WriteLine(device.MaxThreadgroupMemoryLength);
            Console.WriteLine(device.MaxThreadsPerThreadgroup.depth);
            Console.WriteLine(device.SupportsRaytracing);
            Console.WriteLine(device.SupportsPrimitiveMotionBlur);
            Console.WriteLine(device.SupportsRaytracingFromRender);
            Console.WriteLine(device.Supports32BitMSAA);
            Console.WriteLine(device.SupportsPullModelInterpolation);
            Console.WriteLine(device.SupportsShaderBarycentricCoordinates);
            Console.WriteLine(device.ProgrammableSamplePositionsSupported);
            Console.WriteLine(device.RasterOrderGroupsSupported);
            Console.WriteLine(device.Supports32BitFloatFiltering);
            Console.WriteLine(device.SupportsBCTextureCompression);
            Console.WriteLine(device.Depth24Stencil8PixelFormatSupported);
            Console.WriteLine(device.SupportsQueryTextureLOD);
            Console.WriteLine(device.ReadWriteTextureSupport);
            Console.WriteLine(device.SupportsFunctionPointers);
            Console.WriteLine(device.SupportsFunctionPointersFromRender);
            Console.WriteLine(device.CurrentAllocatedSize);
            Console.WriteLine(device.RecommendedMaxWorkingSetSize);
            Console.WriteLine(device.HasUnifiedMemory);
            Console.WriteLine(device.MaxTransferRate);
            Console.WriteLine($"Name: {device.Name}");
            Console.WriteLine(device.RegistryID);
            Console.WriteLine(device.Location);
            Console.WriteLine(device.LocationNumber);
            Console.WriteLine(device.LowPower);
            Console.WriteLine(device.Removable);
            Console.WriteLine(device.IsHeadless);
            Console.WriteLine(device.PeerCount);
            Console.WriteLine(device.PeerIndex);
        }
    }
}
