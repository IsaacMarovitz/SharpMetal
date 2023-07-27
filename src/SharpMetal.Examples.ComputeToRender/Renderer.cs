using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Examples.Primitive;
using SharpMetal.Foundation;
using SharpMetal.Metal;

namespace SharpMetal.Examples.ComputeToRender
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
            float3 normal;
            half3 color;
            float2 texcoord;
        };

        struct VertexData
        {
            float3 position;
            float3 normal;
            float2 texcoord;
        };

        struct InstanceData
        {
            float4x4 instanceTransform;
            float3x3 instanceNormalTransform;
            float4 instanceColor;
        };

        struct CameraData
        {
            float4x4 perspectiveTransform;
            float4x4 worldTransform;
            float3x3 worldNormalTransform;
        };

        v2f vertex vertexMain( device const VertexData* vertexData [[buffer(0)]],
                               device const InstanceData* instanceData [[buffer(1)]],
                               device const CameraData& cameraData [[buffer(2)]],
                               uint vertexId [[vertex_id]],
                               uint instanceId [[instance_id]] )
        {
            v2f o;

            const device VertexData& vd = vertexData[ vertexId ];
            float4 pos = float4( vd.position, 1.0 );
            pos = instanceData[ instanceId ].instanceTransform * pos;
            pos = cameraData.perspectiveTransform * cameraData.worldTransform * pos;
            o.position = pos;

            float3 normal = instanceData[ instanceId ].instanceNormalTransform * vd.normal;
            normal = cameraData.worldNormalTransform * normal;
            o.normal = normal;

            o.texcoord = vd.texcoord.xy;

            o.color = half3( instanceData[ instanceId ].instanceColor.rgb );
            return o;
        }

        half4 fragment fragmentMain( v2f in [[stage_in]], texture2d< half, access::sample > tex [[texture(0)]] )
        {
            constexpr sampler s( address::repeat, filter::linear );
            half3 texel = tex.sample( s, in.texcoord ).rgb;

            // assume light coming from (front-top-right)
            float3 l = normalize(float3( 1.0, 1.0, 0.8 ));
            float3 n = normalize( in.normal );

            half ndotl = half( saturate( dot( n, l ) ) );

            half3 illum = (in.color * texel * 0.1) + (in.color * texel * ndotl);
            return half4( illum, 1.0 );
        }
        """;

        private const string KernelSource = """
        #include <metal_stdlib>
        using namespace metal;

        kernel void mandelbrot_set(texture2d< half, access::write > tex [[texture(0)]],
                                   uint2 index [[thread_position_in_grid]],
                                   uint2 gridSize [[threads_per_grid]],
                                   device const uint* frame [[buffer(0)]])
        {
            constexpr float kAnimationFrequency = 0.01;
            constexpr float kAnimationSpeed = 4;
            constexpr float kAnimationScaleLow = 0.62;
            constexpr float kAnimationScale = 0.38;

            constexpr float2 kMandelbrotPixelOffset = {-0.2, -0.35};
            constexpr float2 kMandelbrotOrigin = {-1.2, -0.32};
            constexpr float2 kMandelbrotScale = {2.2, 2.0};

            // Map time to zoom value in [kAnimationScaleLow, 1]
            float zoom = kAnimationScaleLow + kAnimationScale * cos(kAnimationFrequency * *frame);
            // Speed up zooming
            zoom = pow(zoom, kAnimationSpeed);

            //Scale
            float x0 = zoom * kMandelbrotScale.x * ((float)index.x / gridSize.x + kMandelbrotPixelOffset.x) + kMandelbrotOrigin.x;
            float y0 = zoom * kMandelbrotScale.y * ((float)index.y / gridSize.y + kMandelbrotPixelOffset.y) + kMandelbrotOrigin.y;

            // Implement Mandelbrot set
            float x = 0.0;
            float y = 0.0;
            uint iteration = 0;
            uint max_iteration = 1000;
            float xtmp = 0.0;
            while(x * x + y * y <= 4 && iteration < max_iteration)
            {
                xtmp = x * x - y * y + x0;
                y = 2 * x * y + y0;
                x = xtmp;
                iteration += 1;
            }

            // Convert iteration result to colors
            half color = (0.5 + 0.5 * cos(3.0 + iteration * 0.15));
            tex.write(half4(color, color, color, 1.0), index, 0);
        }
        """;

        private MTLDevice Device;
        private MTLCommandQueue Queue;
        private MTLRenderPipelineState RenderPipelineState;
        private MTLComputePipelineState ComputePipelineState;
        private MTLDepthStencilState DepthStencilState;
        private MTLLibrary ShaderLibrary;
        private MTLTexture Texture;
        private const int MaxFramesInFlight = 3;
        private const int TextureWidth = 128;
        private const int TextureHeight = 128;
        private const int InstanceRows = 10;
        private const int InstanceColumns = 10;
        private const int InstanceDepth = 10;
        private const int TotalInstances = InstanceRows * InstanceColumns * InstanceDepth;

        public Renderer(MTLDevice device)
        {
            Device = device;
            Queue = device.NewCommandQueue();
            BuildShaders();
            BuildComputePipeline();
            BuildDepthStencilStates();
            BuildTextures();
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
            pipeline.ColorAttachments.Object(0).PixelFormat = MTLPixelFormat.BGRA8Unorm;
            pipeline.DepthAttachmentPixelFormat = MTLPixelFormat.Depth16Unorm;

            var pipelineStateError = new NSError(IntPtr.Zero);
            RenderPipelineState = Device.NewRenderPipelineState(pipeline, ref pipelineStateError);
            if (pipelineStateError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create render pipeline state! {StringHelper.String(pipelineStateError.LocalizedDescription)}");
            }
        }

        private void BuildComputePipeline()
        {
            var error = new NSError(IntPtr.Zero);
            var library = Device.NewLibrary(StringHelper.NSString(KernelSource), new(IntPtr.Zero), ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {StringHelper.String(error.LocalizedDescription)}");
            }

            var mandelbrotFunction = library.NewFunction(StringHelper.NSString("mandelbrot_set"));
            ComputePipelineState = Device.NewComputePipelineState(mandelbrotFunction, ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create compute pipline state! {StringHelper.String(error.LocalizedDescription)}");
            }
        }

        private void BuildDepthStencilStates()
        {
            var descriptor = new MTLDepthStencilDescriptor();
            descriptor.DepthCompareFunction = MTLCompareFunction.Less;
            descriptor.DepthWriteEnabled = true;

            DepthStencilState = Device.NewDepthStencilState(descriptor);
        }

        private void BuildTextures()
        {
            var descriptor = new MTLTextureDescriptor();
            descriptor.Width = TextureWidth;
            descriptor.Height = TextureHeight;
            descriptor.PixelFormat = MTLPixelFormat.RGBA8Unorm;
            descriptor.TextureType = MTLTextureType.Type2D;
            descriptor.StorageMode = MTLStorageMode.Managed;
            descriptor.Usage = MTLTextureUsage.ShaderRead | MTLTextureUsage.ShaderWrite | MTLTextureUsage.RenderTarget;

            Texture = Device.NewTexture(descriptor);
        }

        private void BuildBuffers()
        {
            const float s = 0.5f;

            VertexData[] verts =
            {
                new(new Vector3(-s, -s, +s), new Vector3(0.0f, 0.0f, 1.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector3(+s, -s, +s), new Vector3(0.0f, 0.0f, 1.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector3(+s, +s, +s), new Vector3(0.0f, 0.0f, 1.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector3(-s, +s, +s), new Vector3(0.0f, 0.0f, 1.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector3(+s, -s, +s), new Vector3(1.0f, 0.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector3(+s, -s, -s), new Vector3(1.0f, 0.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector3(+s, +s, -s), new Vector3(1.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector3(+s, +s, +s), new Vector3(1.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector3(+s, -s, -s), new Vector3(0.0f, 0.0f, -1.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector3(-s, -s, -s), new Vector3(0.0f, 0.0f, -1.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector3(-s, +s, -s), new Vector3(0.0f, 0.0f, -1.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector3(+s, +s, -s), new Vector3(0.0f, 0.0f, -1.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector3(-s, -s, -s), new Vector3(-1.0f, 0.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector3(-s, -s, +s), new Vector3(-1.0f, 0.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector3(-s, +s, +s), new Vector3(-1.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector3(-s, +s, -s), new Vector3(-1.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector3(-s, +s, +s), new Vector3(0.0f, 1.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector3(+s, +s, +s), new Vector3(0.0f, 1.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector3(+s, +s, -s), new Vector3(0.0f, 1.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector3(-s, +s, -s), new Vector3(0.0f, 1.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector3(-s, -s, -s), new Vector3(0.0f, -1.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector3(+s, -s, -s), new Vector3(0.0f, -1.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector3(+s, -s, +s), new Vector3(0.0f, -1.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector3(-s, -s, +s), new Vector3(0.0f, -1.0f, 0.0f), new Vector2(0.0f, 0.0f)),
            };

            ushort[] indicies =
            {
                0, 1, 2, 2, 3, 0, // Front
                4, 5, 6, 6, 7, 4, // Right
                8, 9, 10, 10, 11, 8, // Back
                12, 13, 14, 14, 15, 12, // Left
                16, 17, 18, 18, 18, 16, // Top
                20, 21, 22, 22, 23, 20 // Bottom
            };

            var vertexDataSize = Marshal.SizeOf(verts);
            var indexDataSize = Marshal.SizeOf(indicies);
        }

        public void Draw(MTKView view)
        {
            throw new NotImplementedException();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VertexData
    {
        public Vector3 position;
        public Vector3 normal;
        public Vector2 texcoord;

        public VertexData(Vector3 position, Vector3 normal, Vector2 texcoord)
        {
            this.position = position;
            this.normal = normal;
            this.texcoord = texcoord;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InstanceData
    {
        public Matrix4x4 instanceTransform;
        public Matrix3x3 instanceNormalTransform;
        public Vector4 instanceColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CameraData
    {
        public Matrix4x4 perspectiveTransform;
        public Matrix4x4 worldTransform;
        public Matrix3x3 worldNormalTransform;
    }
}
