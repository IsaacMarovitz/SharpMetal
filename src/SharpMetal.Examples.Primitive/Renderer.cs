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
        const int NumVertices = 3;

        private MTLDevice _device;
        private MTLCommandQueue _queue;
        private MTLRenderPipelineState _pipelineState;
        private MTLBuffer _vertexPositionsBuffer;
        private MTLBuffer _vertexColorsBuffer;
        private bool _ready;

        public Renderer(MTLDevice device)
        {
            _device = device;
            _queue = device.NewCommandQueue();
            BuildShaders();
        }

        public static IRenderer Init(MTLDevice device)
        {
            return new Renderer(device);
        }

        private void BuildShaders()
        {
            // Build shader
            var shaderSource = EmbeddedResources.ReadAllText("Primitive/Shaders/Shader.metal");

            _device.NewLibrary(StringHelper.NSString(shaderSource), new(IntPtr.Zero), (library, error) =>
            {
                if (error != IntPtr.Zero)
                {
                    throw new Exception($"Failed to create library! {StringHelper.String(error.LocalizedDescription)}");
                }

                var vertexFunction = library.NewFunction(StringHelper.NSString("vertexMain"));
                var fragmentFunction = library.NewFunction(StringHelper.NSString("fragmentMain"));

                // Build pipeline
                var pipeline = new MTLRenderPipelineDescriptor();
                pipeline.VertexFunction = vertexFunction;
                pipeline.FragmentFunction = fragmentFunction;

                var colorAttachment = pipeline.ColorAttachments.Object(0);
                colorAttachment.PixelFormat = MTLPixelFormat.BGRA8UnormsRGB;
                pipeline.ColorAttachments.SetObject(colorAttachment, 0);

                var pipelineStateError = new NSError(IntPtr.Zero);
                _pipelineState = _device.NewRenderPipelineState(pipeline, ref pipelineStateError);
                if (pipelineStateError != IntPtr.Zero)
                {
                    throw new Exception(
                        $"Failed to create render pipeline state! {StringHelper.String(pipelineStateError.LocalizedDescription)}");
                }

                BuildBuffers();

                _ready = true;
            });
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

            _vertexPositionsBuffer = _device.NewBuffer(positionsDataSize, MTLResourceOptions.ResourceStorageModeManaged);
            _vertexColorsBuffer = _device.NewBuffer(colorsDataSize, MTLResourceOptions.ResourceStorageModeManaged);

            BufferHelper.CopyToBuffer(positions, _vertexPositionsBuffer);
            BufferHelper.CopyToBuffer(colors, _vertexColorsBuffer);

            _vertexPositionsBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = _vertexPositionsBuffer.Length
            });
            _vertexColorsBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = _vertexColorsBuffer.Length
            });
        }

        public void Draw(MTKView mtkView)
        {
            if (!_ready)
            {
                return;
            }

            var buffer = _queue.CommandBuffer();
            var renderPassDescriptor = mtkView.CurrentRenderPassDescriptor;
            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);

            encoder.SetRenderPipelineState(_pipelineState);
            encoder.SetVertexBuffer(_vertexPositionsBuffer, 0, 0);
            encoder.SetVertexBuffer(_vertexColorsBuffer, 0, 1);
            encoder.DrawPrimitives(MTLPrimitiveType.Triangle, 0, NumVertices);

            encoder.EndEncoding();
            buffer.PresentDrawable(mtkView.CurrentDrawable);
            buffer.Commit();
        }
    }
}
