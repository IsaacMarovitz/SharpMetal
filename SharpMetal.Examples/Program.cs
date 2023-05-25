using System.Runtime.Versioning;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class Program
    {
        public static void Main(string[] args)
        {
            var device = MTLDevice.MTLCreateSystemDefaultDevice();

            var descriptor = MTLRenderPipelineDescriptor.New();
            descriptor.Label = "Simple Pipeline";
            descriptor.VertexFunction = new MTLFunction();
            descriptor.FragmentFunction = new MTLFunction();
            // descriptor.colorAttachments[0].PixelFormat = MTLPixelFormat.MTLPixelFormatStencil8;
        }
    }
}