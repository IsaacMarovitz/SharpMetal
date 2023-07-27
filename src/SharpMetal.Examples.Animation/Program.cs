using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
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
        private const int MaxFramesInFlight = 3;
        private const string WindowTitle = "SharpMetal - Animation";
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

        struct VertexData
        {
            device float3* positions [[id(0)]];
            device float3* colors [[id(1)]];
        };

        struct FrameData
        {
            float angle;
        };

        v2f vertex vertexMain( device const VertexData* vertexData [[buffer(0)]], constant FrameData* frameData [[buffer(1)]], uint vertexId [[vertex_id]] )
        {
            float a = frameData->angle;
            float3x3 rotationMatrix = float3x3( sin(a), cos(a), 0.0, cos(a), -sin(a), 0.0, 0.0, 0.0, 1.0 );
            v2f o;
            o.position = float4( rotationMatrix * vertexData->positions[ vertexId ], 1.0 );
            o.color = half3(vertexData->colors[ vertexId ]);
            return o;
        }

        half4 fragment fragmentMain( v2f in [[stage_in]] )
        {
            return half4( in.color, 1.0 );
        }
        """;

        public static void Main()
        {
            // "Link" Metal, CoreGraphics, and AppKit
            ObjectiveC.LinkMetal();
            ObjectiveC.LinkCoreGraphics();
            ObjectiveC.LinkAppKit();

            // Create autorelease pool
            var autoreleasePool = new NSAutoreleasePool();

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
            var appDelegate = new NSApplicationDelegate(nsApplication);
            nsApplication.SetDelegate(appDelegate);
            appDelegate.OnDidFinishLaunching += OnDidFinishLaunching;

            // Create and show NSWindow
            var window = new NSWindow(rect, (ulong)(NSStyleMask.Titled | NSStyleMask.Resizable));
            window.SetContentView(nsView);
            window.MakeKeyAndOrderFront();
            window.Title = StringHelper.InitNSString(WindowTitle);

            // Build shader
            var libraryError = new NSError(IntPtr.Zero);
            var library = device.NewLibrary(StringHelper.InitNSString(ShaderSource), new(IntPtr.Zero), ref libraryError);
            if (libraryError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {StringHelper.GetError(libraryError)}");
            }

            var vertexFunction = library.NewFunction(StringHelper.InitNSString("vertexMain"));
            var fragmentFunction = library.NewFunction(StringHelper.InitNSString("fragmentMain"));

            // Build pipeline
            var pipeline = new MTLRenderPipelineDescriptor();
            pipeline.VertexFunction = vertexFunction;
            pipeline.FragmentFunction = fragmentFunction;
            pipeline.ColorAttachments.Object(0).PixelFormat = MTLPixelFormat.BGRA8Unorm;

            var pipelineStateError = new NSError(IntPtr.Zero);
            var pipelineState = device.NewRenderPipelineState(pipeline, ref pipelineStateError);
            if (pipelineStateError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create render pipeline state! {StringHelper.GetError(pipelineStateError)}");
            }

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

            var argumentEncoder = vertexFunction.NewArgumentEncoder(0);
            var argumentBuffer = device.NewBuffer(argumentEncoder.EncodedLength, MTLResourceOptions.ResourceStorageModeManaged);
            argumentEncoder.SetArgumentBuffer(argumentBuffer, 0);
            argumentEncoder.SetBuffer(vertexPositionsBuffer, 0, 0);
            argumentEncoder.SetBuffer(vertexColorsBuffer, 0, 1);
            argumentBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = argumentBuffer.Length
            });

            var frameData = new MTLBuffer[MaxFramesInFlight];

            for (int i = 0; i < frameData.Length; i++)
            {
                frameData[i] = device.NewBuffer((ulong)Marshal.SizeOf<FrameData>(), MTLResourceOptions.ResourceStorageModeManaged);
            }

            // Draw
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

            // _frame = (_frame + 1) % Renderer::kMaxFramesInFlight;
            var frame = 0;
            var frameDataBuffer = frameData[frame];

            unsafe
            {
                FrameData* pFrameData = (FrameData*)frameDataBuffer.Contents.ToPointer();
                // (_angle += 0.01f)
                pFrameData->Angle = 0f;
                frameDataBuffer.DidModifyRange(new NSRange
                {
                    location = 0,
                    length = (ulong)Marshal.SizeOf<FrameData>()
                });
            }

            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);
            encoder.SetRenderPipelineState(pipelineState);
            encoder.SetVertexBuffer(argumentBuffer, 0, 0);
            encoder.UseResource(vertexPositionsBuffer, MTLResourceUsage.Read);
            encoder.UseResource(vertexColorsBuffer, MTLResourceUsage.Read);

            encoder.SetVertexBuffer(frameDataBuffer, 0, 1);
            encoder.DrawPrimitives(MTLPrimitiveType.Triangle, 0, 3);

            encoder.EndEncoding();
            buffer.PresentDrawable(drawable);
            buffer.Commit();

            if (CaptureWorkload)
            {
                MTLCaptureManager.SharedCaptureManager().StopCapture();
            }

            nsApplication.Run();

            while (true)
            {
                // Do stuff
            }

            // Release pool
            autoreleasePool.Drain();
        }

        private static void OnDidFinishLaunching(NSApplication application)
        {
            application.Stop();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FrameData
    {
        public float Angle;
    }
}
