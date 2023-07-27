using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Foundation;
using SharpMetal.Metal;

namespace SharpMetal.Examples.Primitive
{
    [SupportedOSPlatform("macos")]
    public class Renderer : IRenderer
    {
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

        private MTLDevice Device;
        private MTLCommandQueue Queue;
        private MTLRenderPipelineState PipelineState;
        private MTLBuffer VertexPositionsBuffer;
        private MTLBuffer VertexColorsBuffer;
        const int NumVertices = 3;

        public Renderer(MTLDevice device)
        {
            Device = device;
            Queue = device.NewCommandQueue();
            BuildShaders();
            BuildBuffers();
        }

        public static IRenderer Init(MTLDevice device)
        {
            return new Renderer(device);
        }

        private void BuildShaders()
        {
            // Build shader
            var libraryError = new NSError(IntPtr.Zero);
            var library = Device.NewLibrary(StringHelper.NSString(ShaderSource), new(IntPtr.Zero), ref libraryError);
            if (libraryError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {StringHelper.String(libraryError.LocalizedDescription)}");
            }

            var vertexFunction = library.NewFunction(StringHelper.NSString("vertexMain"));
            var fragmentFunction = library.NewFunction(StringHelper.NSString("fragmentMain"));

            // Build pipeline
            var pipeline = new MTLRenderPipelineDescriptor();
            pipeline.VertexFunction = vertexFunction;
            pipeline.FragmentFunction = fragmentFunction;
            pipeline.ColorAttachments.Object(0).PixelFormat = MTLPixelFormat.BGRA8Unorm;

            var pipelineStateError = new NSError(IntPtr.Zero);
            PipelineState = Device.NewRenderPipelineState(pipeline, ref pipelineStateError);
            if (pipelineStateError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create render pipeline state! {StringHelper.String(pipelineStateError.LocalizedDescription)}");
            }
        }

        private void BuildBuffers()
        {
            // Build buffers
            Vector4[] positions =
            {
                new(-0.8f, 0.8f, 0.0f, 0.0f),
                new(0.0f, -0.8f, 0.0f, 0.0f),
                new(0.8f, 0.8f, 0.0f, 0.0f)
            };

            Vector4[] colors =
            {
                new(1.0f, 0.3f, 0.2f, 0.0f),
                new(0.8f, 1.0f, 0.0f, 0.0f),
                new(0.8f, 0.0f, 1.0f, 0.0f)
            };

            var positionsDataSize = (ulong)(NumVertices * Marshal.SizeOf<Vector4>());
            var colorsDataSize = (ulong)(NumVertices * Marshal.SizeOf<Vector4>());

            VertexPositionsBuffer = Device.NewBuffer(positionsDataSize, MTLResourceOptions.ResourceStorageModeManaged);
            VertexColorsBuffer = Device.NewBuffer(colorsDataSize, MTLResourceOptions.ResourceStorageModeManaged);

            BufferHelper.CopyToBuffer(positions, VertexPositionsBuffer);
            BufferHelper.CopyToBuffer(colors, VertexColorsBuffer);

            VertexPositionsBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = VertexPositionsBuffer.Length
            });
            VertexColorsBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = VertexColorsBuffer.Length
            });
        }

        public void Draw(MTKView mtkView)
        {
            var buffer = Queue.CommandBuffer();
            var renderPassDescriptor = mtkView.CurrentRenderPassDescriptor;
            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);

            encoder.SetRenderPipelineState(PipelineState);
            encoder.SetVertexBuffer(VertexPositionsBuffer, 0, 0);
            encoder.SetVertexBuffer(VertexColorsBuffer, 0, 1);
            encoder.DrawPrimitives(MTLPrimitiveType.Triangle, 0, NumVertices);

            encoder.EndEncoding();
            buffer.PresentDrawable(mtkView.CurrentDrawable);
            buffer.Commit();
        }
    }
}
