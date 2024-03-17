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

        private MTLDevice Device;
        private MTLCommandQueue Queue;
        private MTLRenderPipelineState PipelineState;
        private MTLBuffer VertexPositionsBuffer;
        private MTLBuffer VertexColorsBuffer;
        private MTLBuffer ArgumentBuffer;
        private MTLLibrary ShaderLibrary;
        private const int MaxFramesInFlight = 3;
        private MTLBuffer[] FrameData = new MTLBuffer[MaxFramesInFlight];
        private int Frame;
        private float Angle;
        const int NumVertices = 3;

        public Renderer(MTLDevice device)
        {
            Device = device;
            Queue = device.NewCommandQueue();
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
            var libraryError = new NSError(IntPtr.Zero);
            ShaderLibrary = Device.NewLibrary(StringHelper.NSString(ShaderSource), new(IntPtr.Zero), ref libraryError);
            if (libraryError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {StringHelper.String(libraryError.LocalizedDescription)}");
            }

            var vertexFunction = ShaderLibrary.NewFunction(StringHelper.NSString("vertexMain"));
            var fragmentFunction = ShaderLibrary.NewFunction(StringHelper.NSString("fragmentMain"));

            // Build pipeline
            var pipeline = new MTLRenderPipelineDescriptor();
            pipeline.VertexFunction = vertexFunction;
            pipeline.FragmentFunction = fragmentFunction;
            pipeline.ColorAttachments.Object(0).PixelFormat = MTLPixelFormat.BGRA8UnormsRGB;

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

            var vertexFunction = ShaderLibrary.NewFunction(StringHelper.NSString("vertexMain"));
            var argumentEncoder = vertexFunction.NewArgumentEncoder(0);
            ArgumentBuffer = Device.NewBuffer(argumentEncoder.EncodedLength, MTLResourceOptions.ResourceStorageModeManaged);
            argumentEncoder.SetArgumentBuffer(ArgumentBuffer, 0);
            argumentEncoder.SetBuffer(VertexPositionsBuffer, 0, 0);
            argumentEncoder.SetBuffer(VertexColorsBuffer, 0, 1);

            ArgumentBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = ArgumentBuffer.Length
            });
        }

        private void BuildFrameData()
        {
            for (int i = 0; i < FrameData.Length; i++)
            {
                FrameData[i] = Device.NewBuffer((ulong)Marshal.SizeOf<FrameData>(), MTLResourceOptions.ResourceStorageModeManaged);
            }
        }

        public void Draw(MTKView view)
        {
            Frame = (Frame + 1) % MaxFramesInFlight;
            var frameDataBuffer = FrameData[Frame];

            unsafe
            {
                FrameData* pFrameData = (FrameData*)frameDataBuffer.Contents.ToPointer();
                pFrameData->Angle = Angle += 0.01f;
                frameDataBuffer.DidModifyRange(new NSRange
                {
                    location = 0,
                    length = (ulong)Marshal.SizeOf<FrameData>()
                });
            }

            var buffer = Queue.CommandBuffer();
            var renderPassDescriptor = view.CurrentRenderPassDescriptor;
            var encoder = buffer.RenderCommandEncoder(renderPassDescriptor);

            encoder.SetRenderPipelineState(PipelineState);
            encoder.SetVertexBuffer(ArgumentBuffer, 0, 0);
            encoder.UseResource(VertexPositionsBuffer, MTLResourceUsage.Read);
            encoder.UseResource(VertexColorsBuffer, MTLResourceUsage.Read);

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
