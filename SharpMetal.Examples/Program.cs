using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class Program
    {
        public static void Main(string[] args)
        {
            // "Link" Metal and CoreGraphics
            ObjectiveCRuntime.dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
            ObjectiveCRuntime.dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);

            // Get the default device
            var device = MTLDevice.MTLCreateSystemDefaultDevice();

            var descriptor = new MTLRenderPipelineDescriptor();
            // descriptor.colorAttachments[0].Pi

            Console.WriteLine(device.Name);
            // descriptor.colorAttachments[0].PixelFormat = MTLPixelFormat.MTLPixelFormatStencil8;
        }
    }
}