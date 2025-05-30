using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Foundation;
using SharpMetal.Metal;

namespace SharpMetal.Examples.Animation
{
    [SupportedOSPlatform("macos")]
    public class Renderer : IRenderer
    {
        private const int MaxFramesInFlight = 3;
        private const int NumVertices = 3;

        private MTLDevice _device;
        private MTLCommandQueue _queue;
        private MTLRenderPipelineState _pipelineState;
        private MTLBuffer _vertexPositionsBuffer;
        private MTLBuffer _vertexColorsBuffer;
        private MTLBuffer _argumentBuffer;
        private MTLLibrary _shaderLibrary;
        private MTLBuffer[] _frameData = new MTLBuffer[MaxFramesInFlight];

        private int _frame;
        private float _angle;

        public Renderer(MTLDevice device)
        {
            _device = device;
            _queue = device.NewCommandQueue();
            BuildShaders();
            BuildBuffers();
            BuildFrameData();
        }

        public static IRenderer Init(MTLDevice device)
        {
            return new Renderer(device);
        }

        private void BuildShaders()
        {
            // Build shader
            var shaderSource = EmbeddedResources.ReadAllText("Animation/Shaders/Shader.metal");
            var libraryError = new NSError(IntPtr.Zero);
            _shaderLibrary = _device.NewLibrary(shaderSource, new(IntPtr.Zero), ref libraryError);
            if (libraryError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {libraryError.LocalizedDescription}");
            }

            var vertexFunction = _shaderLibrary.NewFunction("vertexMain");
            var fragmentFunction = _shaderLibrary.NewFunction("fragmentMain");

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
                throw new Exception($"Failed to create render pipeline state! {pipelineStateError.LocalizedDescription}");
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

            var vertexFunction = _shaderLibrary.NewFunction("vertexMain");
            var argumentEncoder = vertexFunction.NewArgumentEncoder(0);
            _argumentBuffer = _device.NewBuffer(argumentEncoder.EncodedLength, MTLResourceOptions.ResourceStorageModeManaged);
            argumentEncoder.SetArgumentBuffer(_argumentBuffer, 0);
            argumentEncoder.SetBuffer(_vertexPositionsBuffer, 0, 0);
            argumentEncoder.SetBuffer(_vertexColorsBuffer, 0, 1);

            _argumentBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = _argumentBuffer.Length
            });
        }

        private void BuildFrameData()
        {
            for (int i = 0; i < _frameData.Length; i++)
            {
                _frameData[i] = _device.NewBuffer((ulong)Marshal.SizeOf<FrameData>(), MTLResourceOptions.ResourceStorageModeManaged);
            }
        }

        public void Draw(MTKView view)
        {
            _frame = (_frame + 1) % MaxFramesInFlight;
            var frameDataBuffer = _frameData[_frame];

            unsafe
            {
                FrameData* pFrameData = (FrameData*)frameDataBuffer.Contents.ToPointer();
                pFrameData->Angle = _angle += 0.01f;
                frameDataBuffer.DidModifyRange(new NSRange
                {
                    location = 0,
                    length = (ulong)Marshal.SizeOf<FrameData>()
                });
            }

            var buffer = _queue.CommandBuffer();
            var renderPassDescriptor = view.CurrentRenderPassDescriptor;
            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);

            encoder.SetRenderPipelineState(_pipelineState);
            encoder.SetVertexBuffer(_argumentBuffer, 0, 0);
            encoder.UseResource(_vertexPositionsBuffer, MTLResourceUsage.Read);
            encoder.UseResource(_vertexColorsBuffer, MTLResourceUsage.Read);

            encoder.SetVertexBuffer(frameDataBuffer, 0, 1);
            encoder.DrawPrimitives(MTLPrimitiveType.Triangle, 0, NumVertices);

            encoder.EndEncoding();
            buffer.PresentDrawable(view.CurrentDrawable);
            buffer.Commit();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FrameData
    {
        public float Angle;
    }
}
