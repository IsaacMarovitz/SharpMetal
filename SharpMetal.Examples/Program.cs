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
            // "Link" Metal and CoreGraphics
            ObjectiveC.dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
            ObjectiveC.dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);

            // Get the default device
            // var device = MTLDevice.CreateSystemDefaultDevice();

            // var descriptor = new MTLRenderPipelineDescriptor();
            // descriptor.Label = new NSString("Simple Pipeline");
            // descriptor.VertexFunction = new MTLFunction();
            // descriptor.FragmentFunction = new MTLFunction();
            // device.NewCommandQueue();
            // descriptor.ColorAttachments[0].PixelFormat = MTLPixelFormat.RG32Float;

            // Console.WriteLine(device.Name);
            // descriptor.colorAttachments[0].PixelFormat = MTLPixelFormat.MTLPixelFormatStencil8;
        }

        public static void Test()
        {
            ObjectiveC.dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
            ObjectiveC.dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);

            // var device = MTLDevice.CreateSystemDefaultDevice();
            // Console.WriteLine(device.MaxThreadgroupMemoryLength);
            // Console.WriteLine(device.MaxThreadsPerThreadgroup);
            // Console.WriteLine(device.SupportsRaytracing);
            // Console.WriteLine(device.SupportsPrimitiveMotionBlur);
            // Console.WriteLine(device.SupportsRaytracingFromRender);
            // Console.WriteLine(device.Supports32BitMSAA);
            // Console.WriteLine(device.SupportsPullModelInterpolation);
            // Console.WriteLine(device.SupportsShaderBarycentricCoordinates);
            // Console.WriteLine(device.ProgrammableSamplePositionsSupported);
            // Console.WriteLine(device.RasterOrderGroupsSupported);
            // Console.WriteLine(device.Supports32BitFloatFiltering);
            // Console.WriteLine(device.SupportsBCTextureCompression);
            // Console.WriteLine(device.Depth24Stencil8PixelFormatSupported);
            // Console.WriteLine(device.SupportsQueryTextureLOD);
            // Console.WriteLine(device.ReadWriteTextureSupport);
            // Console.WriteLine(device.SupportsFunctionPointers);
            // Console.WriteLine(device.SupportsFunctionPointersFromRender);
            // Console.WriteLine(device.CurrentAllocatedSize);
            // Console.WriteLine(device.RecommendedMaxWorkingSetSize);
            // Console.WriteLine(device.HasUnifiedMemory);
            // Console.WriteLine(device.MaxTransferRate);
            // Console.WriteLine(device.Name);
            // Console.WriteLine(device.RegistryID);
            // Console.WriteLine(device.Location);
            // Console.WriteLine(device.LocationNumber);
            // Console.WriteLine(device.LowPower);
            // Console.WriteLine(device.Removable);
            // Console.WriteLine(device.Headless);
            // Console.WriteLine(device.PeerCount);
            // Console.WriteLine(device.PeerIndex);
        }
    }
}