using System.Runtime.Versioning;
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
            ObjectiveC.LinkMetal();
            ObjectiveC.LinkCG();
            ObjectiveC.LinkAppKit();

            // Create CAMetalLayer
            var metalLayer = new CAMetalLayer();

            // Create a child NSView to render to
            var nsView = new NSView(new NSRect(0, 0, 1000, 1000));
            nsView.WantsLayer = true;
            nsView.Layer = metalLayer;

            // Create NSApplication
            var nsApplication = new NSApplication();

            // Create and show NSWindow
            var window = new NSWindow(new NSRect(0, 0, 1000, 1000));
            window.SetContentView(nsView);
            window.MakeKeyAndOrderFront();

            var device = MTLDevice.CreateSystemDefaultDevice();
            metalLayer.Device = device;

            // Draw color to CAMetalLayer
            var drawable = metalLayer.NextDrawable;
            var renderPassDescriptor = new MTLRenderPassDescriptor();
            var attachmentDescriptor = renderPassDescriptor.ColorAttachments.Object(0);
            attachmentDescriptor.Texture = drawable.Texture;
            attachmentDescriptor.LoadAction = MTLLoadAction.Clear;
            attachmentDescriptor.StoreAction = MTLStoreAction.Store;
            attachmentDescriptor.ClearColor = new MTLClearColor
            {
                red = 0.0,
                green = 1.0,
                blue = 1.0,
                alpha = 1.0
            };

            var queue = device.NewCommandQueue();
            var buffer = queue.CommandBuffer();
            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);
            encoder.DrawPrimitives(MTLPrimitiveType.Triangle, 0, 6);
            encoder.EndEncoding();
            buffer.PresentDrawable(drawable);
            buffer.Commit();

            nsApplication.Run();
        }

        public static void Test()
        {
            ObjectiveC.LinkMetal();
            ObjectiveC.LinkCG();

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
