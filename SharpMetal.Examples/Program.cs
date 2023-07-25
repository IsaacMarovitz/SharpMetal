using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Metal;
using SharpMetal.Foundation;

namespace SharpMetal.Examples
{
    [SupportedOSPlatform("macos")]
    public class Program
    {
        private const int X = 100;
        private const int Y = 100;
        private const int Width = 512;
        private const int Height = 512;
        private const string WindowTitle = "SharpMetal - Primitive";
        private const bool CaptureWorkload = false;
        private const string CaptureFilePath = "/Users/isaacmarovitz/Desktop/Trace.gputrace";

        private const string ShaderSource = """
        #include <metal_stdlib>
        using namespace metal;

        struct v2f
        {
            float4 position [[position]];
            half3 color;
        };

        v2f vertex vertexMain( uint vertexId [[vertex_id]],
                               device const float3* positions [[buffer(0)]],
                               device const float3* colors [[buffer(1)]] )
        {
            v2f o;
            o.position = float4( positions[ vertexId ], 1.0 );
            o.color = half3 ( colors[ vertexId ] );
            return o;
        }

        half4 fragment fragmentMain( v2f in [[stage_in]] )
        {
            return half4( in.color, 1.0 );
        }
        """;

        public static void Main(string[] args)
        {
            // "Link" Metal, CoreGraphics, and AppKit
            ObjectiveC.LinkMetal();
            ObjectiveC.LinkCoreGraphics();
            ObjectiveC.LinkAppKit();

            // Create MTLDevice
            var device = MTLDevice.CreateSystemDefaultDevice();

            // Create CAMetalLayer
            var metalLayer = new CAMetalLayer();
            metalLayer.Device = device;

            if (CaptureWorkload)
            {
                // Setup Capture
                var captureDescriptor = new MTLCaptureDescriptor();
                captureDescriptor.CaptureObject = device;
                captureDescriptor.Destination = MTLCaptureDestination.GPUTraceDocument;
                captureDescriptor.OutputURL = NSURL.FileURLWithPath(StringHelper.InitNSString(CaptureFilePath));
                var captureError = new NSError(IntPtr.Zero);
                MTLCaptureManager.SharedCaptureManager().StartCapture(captureDescriptor, ref captureError);
                if (captureError != IntPtr.Zero)
                {
                    Console.Write($"Failed to start capture! {StringHelper.GetError(captureError)}");

                }
            }

            // Create a child NSView to render to
            var rect = new NSRect(X, Y, Width, Height);
            var nsView = new NSView(rect);
            nsView.WantsLayer = true;
            nsView.Layer = metalLayer;

            // Create NSApplication
            var nsApplication = new NSApplication();

            // Create and show NSWindow
            var window = new NSWindow(rect, (ulong)(NSStyleMask.Titled | NSStyleMask.Resizable));
            window.SetContentView(nsView);
            window.MakeKeyAndOrderFront();
            window.Title = StringHelper.InitNSString(WindowTitle);

            // Build shader
            var error = new NSError(IntPtr.Zero);
            var library = device.NewLibrary(StringHelper.InitNSString(ShaderSource), new(IntPtr.Zero), ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {StringHelper.GetError(error)}");
            }

            var vertexFunction = library.NewFunction(StringHelper.InitNSString("vertexMain"));
            var fragmentFunction = library.NewFunction(StringHelper.InitNSString("fragmentMain"));

            // Build pipeline
            var pipeline = new MTLRenderPipelineDescriptor();
            pipeline.VertexFunction = vertexFunction;
            pipeline.FragmentFunction = fragmentFunction;
            pipeline.ColorAttachments.Object(0).PixelFormat = MTLPixelFormat.BGRA8Unorm;

            var pipelineState = device.NewRenderPipelineState(pipeline, new NSError(IntPtr.Zero));

            // Build buffers
            int numVerticies = 3;

            Vector3[] positions =
            {
                new(-0.8f, 0.8f, 0.0f),
                new(0.0f, -0.8f, 0.0f),
                new(0.8f, 0.8f, 0.0f)
            };

            Vector3[] colors =
            {
                new(1.0f, 0.3f, 0.2f),
                new(0.8f, 1.0f, 0.0f),
                new(0.8f, 0.0f, 1.0f)
            };

            var positionsDataSize = (ulong)(numVerticies * Marshal.SizeOf<Vector3>());
            var colorsDataSize = (ulong)(numVerticies * Marshal.SizeOf<Vector3>());

            var vertexPositionsBuffer = device.NewBuffer(positionsDataSize, MTLResourceOptions.ResourceStorageModeManaged);
            var vertexColorsBuffer = device.NewBuffer(colorsDataSize, MTLResourceOptions.ResourceStorageModeManaged);

            unsafe
            {
                var posSpan = new Span<Vector3>(vertexPositionsBuffer.Contents.ToPointer(), numVerticies);
                var colSpan = new Span<Vector3>(vertexColorsBuffer.Contents.ToPointer(), numVerticies);

                positions.CopyTo(posSpan);
                colors.CopyTo(colSpan);
            }

            vertexPositionsBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = vertexPositionsBuffer.Length
            });
            vertexColorsBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = vertexColorsBuffer.Length
            });

            // Draw color to CAMetalLayer
            var drawable = metalLayer.NextDrawable;
            var renderPassDescriptor = new MTLRenderPassDescriptor();
            var attachmentDescriptor = renderPassDescriptor.ColorAttachments.Object(0);
            attachmentDescriptor.Texture = drawable.Texture;
            attachmentDescriptor.LoadAction = MTLLoadAction.Clear;
            attachmentDescriptor.StoreAction = MTLStoreAction.Store;
            attachmentDescriptor.ClearColor = new MTLClearColor
            {
                red = 1.0,
                green = 0.0,
                blue = 0.0,
                alpha = 1.0
            };
            var queue = device.NewCommandQueue();
            var buffer = queue.CommandBuffer();
            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);
            encoder.SetRenderPipelineState(pipelineState);
            encoder.SetVertexBuffer(vertexPositionsBuffer, 0, 0);
            encoder.SetVertexBuffer(vertexColorsBuffer, 0, 1);
            encoder.DrawPrimitives(MTLPrimitiveType.Triangle, 0, 3);
            encoder.EndEncoding();

            buffer.PresentDrawable(drawable);
            buffer.Commit();

            if (CaptureWorkload)
            {
                MTLCaptureManager.SharedCaptureManager().StopCapture();
            }

            nsApplication.Run();
        }

        public static void Test()
        {
            ObjectiveC.LinkMetal();
            ObjectiveC.LinkCoreGraphics();

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
