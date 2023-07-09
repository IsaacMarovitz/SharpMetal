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
            // "Link" Metal and CoreGraphics
            ObjectiveC.dlopen("/System/Library/Frameworks/Metal.framework/Metal", 0);
            ObjectiveC.dlopen("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics", 0);

            // Get the default device
            var device = MTLDevice.CreateSystemDefaultDevice();

            var textureDescriptor = MTLTextureDescriptor.Texture2DDescriptor(MTLPixelFormat.R16Float, 200, 200, false);
            var renderPipelineDescriptor = new MTLRenderPipelineDescriptor();
            renderPipelineDescriptor.SampleCount = 60;
            // TODO: This is invalid NSError() usage and needs to be fixed for these APIs to work
            var pipelineState = device.NewRenderPipelineState(renderPipelineDescriptor, new NSError());
            Console.WriteLine(pipelineState.Device.MaxArgumentBufferSamplerCount);
            // TODO: Make NSStrings actually work nicely with C#
            // descriptor.Label = new NSString("Simple Pipeline");
            // descriptor.VertexFunction = new MTLFunction();
            // descriptor.FragmentFunction = new MTLFunction();
            // device.NewCommandQueue();
            // descriptor.ColorAttachments[0].PixelFormat = MTLPixelFormat.RG32Float;
            //
            // Console.WriteLine(device.Name);
            // descriptor.ColorAttachments[0].PixelFormat = MTLPixelFormat.Stencil8;
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
            Console.WriteLine(device.Headless);
            Console.WriteLine(device.PeerCount);
            Console.WriteLine(device.PeerIndex);
        }
    }
}