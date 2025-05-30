using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Foundation;
using SharpMetal.Metal;

namespace SharpMetal.Examples.ComputeToRender
{
    [SupportedOSPlatform("macos")]
    public class Renderer : IRenderer
    {
        private const int MaxFramesInFlight = 3;
        private const int TextureWidth = 128;
        private const int TextureHeight = 128;
        private const int InstanceRows = 10;
        private const int InstanceColumns = 10;
        private const int InstanceDepth = 10;
        private const int TotalInstances = InstanceRows * InstanceColumns * InstanceDepth;

        private MTLDevice _device;
        private MTLCommandQueue _queue;
        private MTLRenderPipelineState _renderPipelineState;
        private MTLComputePipelineState _computePipelineState;
        private MTLDepthStencilState _depthStencilState;
        private MTLLibrary _shaderLibrary;
        private MTLTexture _texture;
        private MTLBuffer _vertexBuffer;
        private MTLBuffer _indexBuffer;
        private MTLBuffer _textureAnimationBuffer;
        private MTLBuffer[] _instanceDataBuffer = new MTLBuffer[MaxFramesInFlight];
        private MTLBuffer[] _cameraDataBuffer = new MTLBuffer[MaxFramesInFlight];

        private int _frame;
        private float _angle;
        private uint _animationIndex;

        public Renderer(MTLDevice device)
        {
            _device = device;
            _queue = device.NewCommandQueue();

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
            var shaderSource = EmbeddedResources.ReadAllText("ComputeToRender/Shaders/Shader.metal");
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
            pipeline.DepthAttachmentPixelFormat = MTLPixelFormat.Depth16Unorm;

            var pipelineStateError = new NSError(IntPtr.Zero);
            _renderPipelineState = _device.NewRenderPipelineState(pipeline, ref pipelineStateError);
            if (pipelineStateError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create render pipeline state! {pipelineStateError.LocalizedDescription}");
            }
        }

        private void BuildComputePipeline()
        {
            var kernelSource = EmbeddedResources.ReadAllText("ComputeToRender/Shaders/Compute.metal");
            var error = new NSError(IntPtr.Zero);
            var library = _device.NewLibrary(kernelSource, new(IntPtr.Zero), ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {error.LocalizedDescription}");
            }

            var mandelbrotFunction = library.NewFunction("mandelbrot_set");
            _computePipelineState = _device.NewComputePipelineState(mandelbrotFunction, ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create compute pipline state! {error.LocalizedDescription}");
            }
        }

        private void BuildDepthStencilStates()
        {
            var descriptor = new MTLDepthStencilDescriptor();
            descriptor.DepthCompareFunction = MTLCompareFunction.Less;
            descriptor.DepthWriteEnabled = true;

            _depthStencilState = _device.NewDepthStencilState(descriptor);
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

            _texture = _device.NewTexture(descriptor);
        }

        private void BuildBuffers()
        {
            const float s = 0.5f;

            VertexData[] verts =
            {
                new(new Vector4(-s, -s, +s, 0.0f), new Vector4(0.0f, 0.0f, 1.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector4(+s, -s, +s, 0.0f), new Vector4(0.0f, 0.0f, 1.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector4(+s, +s, +s, 0.0f), new Vector4(0.0f, 0.0f, 1.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector4(-s, +s, +s, 0.0f), new Vector4(0.0f, 0.0f, 1.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector4(+s, -s, +s, 0.0f), new Vector4(1.0f, 0.0f, 0.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector4(+s, -s, -s, 0.0f), new Vector4(1.0f, 0.0f, 0.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector4(+s, +s, -s, 0.0f), new Vector4(1.0f, 0.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector4(+s, +s, +s, 0.0f), new Vector4(1.0f, 0.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector4(+s, -s, -s, 0.0f), new Vector4(0.0f, 0.0f, -1.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector4(-s, -s, -s, 0.0f), new Vector4(0.0f, 0.0f, -1.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector4(-s, +s, -s, 0.0f), new Vector4(0.0f, 0.0f, -1.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector4(+s, +s, -s, 0.0f), new Vector4(0.0f, 0.0f, -1.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector4(-s, -s, -s, 0.0f), new Vector4(-1.0f, 0.0f, 0.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector4(-s, -s, +s, 0.0f), new Vector4(-1.0f, 0.0f, 0.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector4(-s, +s, +s, 0.0f), new Vector4(-1.0f, 0.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector4(-s, +s, -s, 0.0f), new Vector4(-1.0f, 0.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector4(-s, +s, +s, 0.0f), new Vector4(0.0f, 1.0f, 0.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector4(+s, +s, +s, 0.0f), new Vector4(0.0f, 1.0f, 0.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector4(+s, +s, -s, 0.0f), new Vector4(0.0f, 1.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector4(-s, +s, -s, 0.0f), new Vector4(0.0f, 1.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),

                new(new Vector4(-s, -s, -s, 0.0f), new Vector4(0.0f, -1.0f, 0.0f, 0.0f), new Vector2(0.0f, 1.0f)),
                new(new Vector4(+s, -s, -s, 0.0f), new Vector4(0.0f, -1.0f, 0.0f, 0.0f), new Vector2(1.0f, 1.0f)),
                new(new Vector4(+s, -s, +s, 0.0f), new Vector4(0.0f, -1.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f)),
                new(new Vector4(-s, -s, +s, 0.0f), new Vector4(0.0f, -1.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),
            };

            ushort[] indices =
            {
                0, 1, 2, 2, 3, 0, // Front
                4, 5, 6, 6, 7, 4, // Right
                8, 9, 10, 10, 11, 8, // Back
                12, 13, 14, 14, 15, 12, // Left
                16, 17, 18, 18, 19, 16, // Top
                20, 21, 22, 22, 23, 20 // Bottom
            };

            var vertexDataSize = (ulong)(Unsafe.SizeOf<VertexData>() * verts.Length);
            var indexDataSize = (ulong)(sizeof(ushort) * indices.Length);

            _vertexBuffer = _device.NewBuffer(vertexDataSize, MTLResourceOptions.ResourceStorageModeManaged);
            _indexBuffer = _device.NewBuffer(indexDataSize, MTLResourceOptions.ResourceStorageModeManaged);

            BufferHelper.CopyToBuffer(verts, _vertexBuffer);
            BufferHelper.CopyToBuffer(indices, _indexBuffer);

            _vertexBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = _vertexBuffer.Length
            });
            _indexBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = _indexBuffer.Length
            });

            var instanceDataSize = (ulong)(MaxFramesInFlight * TotalInstances * Marshal.SizeOf<InstanceData>());
            for (int i = 0; i < MaxFramesInFlight; i++)
            {
                _instanceDataBuffer[i] = _device.NewBuffer(instanceDataSize, MTLResourceOptions.ResourceStorageModeManaged);
            }

            var cameraDataSize = (ulong)(MaxFramesInFlight * TotalInstances * Marshal.SizeOf<CameraData>());
            for (int i = 0; i < MaxFramesInFlight; i++)
            {
                _cameraDataBuffer[i] = _device.NewBuffer(cameraDataSize, MTLResourceOptions.ResourceStorageModeManaged);
            }

            _textureAnimationBuffer = _device.NewBuffer(sizeof(uint), MTLResourceOptions.ResourceStorageModeManaged);
        }

        public unsafe void GenerateMandelbrotTexture(MTLCommandBuffer commandBuffer)
        {
            uint* animationIndex = (uint*)_textureAnimationBuffer.Contents.ToPointer();
            animationIndex[0] = _animationIndex++ % 500;
            _textureAnimationBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = sizeof(uint)
            });

            var computeEncoder = commandBuffer.ComputeCommandEncoder();

            computeEncoder.SetComputePipelineState(_computePipelineState);
            computeEncoder.SetTexture(_texture, 0);
            computeEncoder.SetBuffer(_textureAnimationBuffer, 0, 0);

            var gridSize = new MTLSize { width = TextureWidth, height = TextureHeight, depth = 1 };

            var maxThreads = _computePipelineState.MaxTotalThreadsPerThreadgroup;
            var threadGroupSize = new MTLSize { width = maxThreads, height = 1, depth = 1 };

            computeEncoder.DispatchThreads(gridSize, threadGroupSize);

            computeEncoder.EndEncoding();
        }

        public unsafe void Draw(MTKView view)
        {
            _frame = (_frame + 1) % MaxFramesInFlight;
            var instanceDataBuffer = _instanceDataBuffer[_frame];

            InstanceData* pInstanceData = (InstanceData*)instanceDataBuffer.Contents.ToPointer();

            _angle += 0.002f;

            const float scale = 0.2f;
            var objectPosition = new Vector3(0.0f, 0.0f, -10.0f);

            var rt = Matrix4x4.CreateTranslation(objectPosition);
            var rr1 = Matrix4x4.CreateRotationY(-_angle);
            var rr0 = Matrix4x4.CreateRotationX(_angle * 0.5f);
            var rtInv = Matrix4x4.CreateTranslation(-objectPosition);
            var fullObjectRotation = rtInv * rr0 * rr1 * rt;

            var indexX = 0;
            var indexY = 0;
            var indexZ = 0;
            for (int i = 0; i < TotalInstances; i++)
            {
                if (indexX == InstanceRows)
                {
                    indexX = 0;
                    indexY++;
                }
                if (indexY == InstanceRows)
                {
                    indexY = 0;
                    indexZ++;
                }

                var scaleMatrix = Matrix4x4.CreateScale(new Vector3(scale, scale, scale));
                var zRotation = Matrix4x4.CreateRotationZ(_angle * float.Sin(indexX));
                var yRotation = Matrix4x4.CreateRotationY(_angle * float.Cos(indexY));

                var x = (indexX - InstanceRows / 2.0f) * (2.0f * scale) + scale;
                var y = (indexY - InstanceColumns / 2.0f) * (2.0f * scale) + scale;
                var z = (indexZ - InstanceDepth / 2.0f) * (2.0f * scale);
                var translate = Matrix4x4.CreateTranslation(objectPosition + new Vector3(x, y, z));

                var transform = scaleMatrix * zRotation * yRotation * translate * fullObjectRotation;
                pInstanceData[i].instanceTransform = transform;
                pInstanceData[i].instanceNormalTransform = new Matrix3x3
                {
                    a = new Vector4(transform[0, 0], transform[0, 1], transform[0, 2], 0f),
                    b = new Vector4(transform[1, 0], transform[1, 1], transform[1, 2], 0f),
                    c = new Vector4(transform[2, 0], transform[2, 1], transform[2, 2], 0f),
                };

                var iDivNumInstances = i / (float)TotalInstances;
                var r = iDivNumInstances;
                var g = 1.0f - r;
                var b = float.Sin(float.Pi * 2.0f * iDivNumInstances);
                pInstanceData[i].instanceColor = new Vector4(r, g, b, 1.0f);

                indexX++;
            }

            instanceDataBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = instanceDataBuffer.Length
            });

            var cameraDataBuffer = _cameraDataBuffer[_frame];
            var cameraTransform = Matrix4x4.Identity;
            CameraData* pCameraData = (CameraData*)cameraDataBuffer.Contents.ToPointer();
            pCameraData->perspectiveTransform = Matrix4x4.CreatePerspectiveFieldOfView(45.0f * float.Pi / 180.0f, 1.0f, 0.03f, 500.0f);
            pCameraData->worldTransform = cameraTransform;
            pCameraData->worldNormalTransform = new Matrix3x3
            {
                a = new Vector4(cameraTransform[0, 0], cameraTransform[0, 1], cameraTransform[0, 2], 0f),
                b = new Vector4(cameraTransform[1, 0], cameraTransform[1, 1], cameraTransform[1, 2], 0f),
                c = new Vector4(cameraTransform[2, 0], cameraTransform[2, 1], cameraTransform[2, 2], 0f),
            };
            cameraDataBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = (ulong)Marshal.SizeOf<CameraData>()
            });

            var buffer = _queue.CommandBuffer();
            GenerateMandelbrotTexture(buffer);

            var descriptor = view.CurrentRenderPassDescriptor;
            var encoder = buffer.RenderCommandEncoder(descriptor);

            encoder.SetRenderPipelineState(_renderPipelineState);
            encoder.SetDepthStencilState(_depthStencilState);

            encoder.SetVertexBuffer(_vertexBuffer, 0, 0);
            encoder.SetVertexBuffer(instanceDataBuffer, 0, 1);
            encoder.SetVertexBuffer(cameraDataBuffer, 0, 2);

            encoder.SetFragmentTexture(_texture, 0);

            encoder.SetCullMode(MTLCullMode.Back);
            encoder.SetFrontFacingWinding(MTLWinding.CounterClockwise);

            encoder.DrawIndexedPrimitives(MTLPrimitiveType.Triangle, 6 * 6, MTLIndexType.UInt16, _indexBuffer, 0, TotalInstances);

            encoder.EndEncoding();
            buffer.PresentDrawable(view.CurrentDrawable);
            buffer.Commit();
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 48)]
    public struct VertexData(Vector4 position, Vector4 normal, Vector2 texcoord)
    {
        public Vector4 position = position;
        public Vector4 normal = normal;
        public Vector2 texcoord = texcoord;
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

    [StructLayout(LayoutKind.Sequential, Size = 48)]
    public struct Matrix3x3
    {
        public Vector4 a;
        public Vector4 b;
        public Vector4 c;
    }
}
