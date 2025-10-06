using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Examples.Common;
using SharpMetal.Foundation;
using SharpMetal.Metal;

namespace SharpMetal.Examples.ComputeToRenderMTL4
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
        private MTL4CommandQueue _queue;
        private MTL4CommandBuffer _commandBuffer;
        private MTL4Compiler _compiler;
        private MTLRenderPipelineState _renderPipelineState;
        private MTLComputePipelineState _computePipelineState;
        private MTLDepthStencilState _depthStencilState;
        private MTL4ArgumentTable _vertexArgumentTable;
        private MTL4ArgumentTable _fragmentArgumentTable;
        private MTL4ArgumentTable _computeArgumentTable;
        private MTLLibrary _shaderLibrary;
        private MTLTexture _texture;
        private MTLBuffer _vertexBuffer;
        private MTLBuffer _indexBuffer;
        private MTLBuffer _textureAnimationBuffer;
        private MTLFence _fence;
        private MTLResidencySet _residencySet;
        private readonly MTL4CommandAllocator[] _commandAllocators;
        private readonly MTLBuffer[] _instanceDataBuffer = new MTLBuffer[MaxFramesInFlight];
        private readonly MTLBuffer[] _cameraDataBuffer = new MTLBuffer[MaxFramesInFlight];

        private int _frame;
        private float _angle;
        private uint _animationIndex;

        public Renderer(MTLDevice device)
        {
            _device = device;
            _queue = _device.NewMTL4CommandQueue();
            _commandBuffer = _device.NewCommandBuffer;

            _commandAllocators = new MTL4CommandAllocator[MaxFramesInFlight];
            for (var i = 0; i < MaxFramesInFlight; i++)
            {
                _commandAllocators[i] = _device.NewCommandAllocator();
            }

            var residencySetDescriptor = new MTLResidencySetDescriptor();
            residencySetDescriptor.InitialCapacity = 64;

            var residencySetError = new NSError(IntPtr.Zero);

            _residencySet = _device.NewResidencySet(residencySetDescriptor, ref residencySetError);

            if (residencySetError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create residency set! {residencySetError.LocalizedDescription}");
            }

            _queue.AddResidencySet(_residencySet);

            var compilerError = new NSError(IntPtr.Zero);

            var compilerDescriptor = new MTL4CompilerDescriptor();
            _compiler = _device.NewCompiler(compilerDescriptor, ref compilerError);

            if (compilerError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create compiler! {compilerError.LocalizedDescription}");
            }

            var argumentDescriptor = new MTL4ArgumentTableDescriptor();
            argumentDescriptor.MaxBufferBindCount = 1;
            argumentDescriptor.MaxTextureBindCount = 1;

            var argumentTableError = new NSError(IntPtr.Zero);

            _computeArgumentTable = _device.NewArgumentTable(argumentDescriptor, ref argumentTableError);

            if (argumentTableError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create argument table! {argumentTableError.LocalizedDescription}");
            }

            argumentDescriptor.MaxBufferBindCount = 3;
            argumentDescriptor.MaxTextureBindCount = 0;

            _vertexArgumentTable = _device.NewArgumentTable(argumentDescriptor, ref argumentTableError);

            if (argumentTableError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create argument table! {argumentTableError.LocalizedDescription}");
            }

            argumentDescriptor.MaxBufferBindCount = 0;
            argumentDescriptor.MaxTextureBindCount = 1;

            _fragmentArgumentTable = _device.NewArgumentTable(argumentDescriptor, ref argumentTableError);

            if (argumentTableError != IntPtr.Zero)
            {
                throw new Exception($"Failed to create argument table! {argumentTableError.LocalizedDescription}");
            }

            BuildShaders();
            BuildComputePipeline();
            BuildDepthStencilStates();
            BuildTextures();
            BuildBuffers();

            _residencySet.Commit();
            _fence = _device.NewFence;
        }

        public static IRenderer Init(MTLDevice device)
        {
            return new Renderer(device);
        }

        private void BuildShaders()
        {
            // Build shader
            var shaderSource = EmbeddedResources.ReadAllText("ComputeToRenderMTL4/Shaders/Shader.metal");
            var error = new NSError(IntPtr.Zero);
            _shaderLibrary = _device.NewLibrary(shaderSource, new(IntPtr.Zero), ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {error.LocalizedDescription}");
            }

            var vertexFunctionDescriptor = new MTL4LibraryFunctionDescriptor();
            vertexFunctionDescriptor.Name = "vertexMain";
            vertexFunctionDescriptor.Library = _shaderLibrary;

            var fragmentFunctionDescriptor = new MTL4LibraryFunctionDescriptor();
            fragmentFunctionDescriptor.Name = "fragmentMain";
            fragmentFunctionDescriptor.Library = _shaderLibrary;

            // Build pipeline
            var pipeline = new MTL4RenderPipelineDescriptor();
            pipeline.VertexFunctionDescriptor = vertexFunctionDescriptor;
            pipeline.FragmentFunctionDescriptor = fragmentFunctionDescriptor;

            var colorAttachment = pipeline.ColorAttachments.Object(0);
            colorAttachment.PixelFormat = MTLPixelFormat.BGRA8UnormsRGB;
            pipeline.ColorAttachments.SetObject(colorAttachment, 0);

            _renderPipelineState = _compiler.NewRenderPipelineState(pipeline, new MTL4CompilerTaskOptions(), ref error);

            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create render pipeline state! {error.LocalizedDescription}");
            }
        }

        private void BuildComputePipeline()
        {
            var kernelSource = EmbeddedResources.ReadAllText("ComputeToRenderMTL4/Shaders/Compute.metal");
            var error = new NSError(IntPtr.Zero);
            var library = _device.NewLibrary(kernelSource, new(IntPtr.Zero), ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create library! {error.LocalizedDescription}");
            }

            var computeFunctionDescriptor = new MTL4LibraryFunctionDescriptor();
            computeFunctionDescriptor.Name = "mandelbrot_set";
            computeFunctionDescriptor.Library = library;

            var pipelineDescriptor = new MTL4ComputePipelineDescriptor();
            pipelineDescriptor.ComputeFunctionDescriptor = computeFunctionDescriptor;

            _computePipelineState = _compiler.NewComputePipelineState(pipelineDescriptor, new MTL4CompilerTaskOptions(), ref error);
            if (error != IntPtr.Zero)
            {
                throw new Exception($"Failed to create compute pipeline state! {error.LocalizedDescription}");
            }
        }

        private void BuildDepthStencilStates()
        {
            var descriptor = new MTLDepthStencilDescriptor();
            descriptor.DepthCompareFunction = MTLCompareFunction.Less;
            descriptor.IsDepthWriteEnabled = true;

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
            _residencySet.AddAllocation(new MTLAllocation(_texture.NativePtr));
        }

        private void BuildBuffers()
        {
            const float s = 0.5f;

            VertexData[] verts =
            [
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
            ];

            ushort[] indices =
            [
                0, 1, 2, 2, 3, 0, // Front
                4, 5, 6, 6, 7, 4, // Right
                8, 9, 10, 10, 11, 8, // Back
                12, 13, 14, 14, 15, 12, // Left
                16, 17, 18, 18, 19, 16, // Top
                20, 21, 22, 22, 23, 20 // Bottom
            ];

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

            _residencySet.AddAllocation(new MTLAllocation(_vertexBuffer.NativePtr));
            _residencySet.AddAllocation(new MTLAllocation(_indexBuffer.NativePtr));

            var instanceDataSize = (ulong)(MaxFramesInFlight * TotalInstances * Marshal.SizeOf<InstanceData>());
            for (var i = 0; i < MaxFramesInFlight; i++)
            {
                _instanceDataBuffer[i] = _device.NewBuffer(instanceDataSize, MTLResourceOptions.ResourceStorageModeManaged);
                _residencySet.AddAllocation(new MTLAllocation(_instanceDataBuffer[i].NativePtr));
            }

            var cameraDataSize = (ulong)(MaxFramesInFlight * TotalInstances * Marshal.SizeOf<CameraData>());
            for (var i = 0; i < MaxFramesInFlight; i++)
            {
                _cameraDataBuffer[i] = _device.NewBuffer(cameraDataSize, MTLResourceOptions.ResourceStorageModeManaged);
                _residencySet.AddAllocation(new MTLAllocation(_cameraDataBuffer[i].NativePtr));
            }

            _textureAnimationBuffer = _device.NewBuffer(sizeof(uint), MTLResourceOptions.ResourceStorageModeManaged);
            _residencySet.AddAllocation(new MTLAllocation(_textureAnimationBuffer.NativePtr));
        }

        public unsafe void GenerateMandelbrotTexture(MTL4CommandBuffer commandBuffer)
        {
            var animationIndex = (uint*)_textureAnimationBuffer.Contents.ToPointer();
            animationIndex[0] = _animationIndex++ % 500;
            _textureAnimationBuffer.DidModifyRange(new NSRange
            {
                location = 0,
                length = sizeof(uint)
            });

            var computeEncoder = commandBuffer.ComputeCommandEncoder;

            _computeArgumentTable.SetTexture(_texture.GpuResourceID, 0);
            _computeArgumentTable.SetAddress(_textureAnimationBuffer.GpuAddress, 0);

            computeEncoder.SetArgumentTable(_computeArgumentTable);
            computeEncoder.SetComputePipelineState(_computePipelineState);

            var gridSize = new MTLSize { width = TextureWidth, height = TextureHeight, depth = 1 };

            var maxThreads = _computePipelineState.MaxTotalThreadsPerThreadgroup;
            var threadGroupSize = new MTLSize { width = maxThreads, height = 1, depth = 1 };

            computeEncoder.DispatchThreads(gridSize, threadGroupSize);
            computeEncoder.UpdateFence(_fence, MTLStages.StageDispatch);
            computeEncoder.EndEncoding();
        }

        public unsafe void Draw(MTKView view)
        {
            _frame = (_frame + 1) % MaxFramesInFlight;
            var instanceDataBuffer = _instanceDataBuffer[_frame];

            _commandAllocators[_frame].Reset();
            _commandBuffer.BeginCommandBuffer(_commandAllocators[_frame]);

            var pInstanceData = (InstanceData*)instanceDataBuffer.Contents.ToPointer();

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

            for (var i = 0; i < TotalInstances; i++)
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
            var pCameraData = (CameraData*)cameraDataBuffer.Contents.ToPointer();
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

            GenerateMandelbrotTexture(_commandBuffer);

            var descriptor = view.CurrentMTL4RenderPassDescriptor;
            _residencySet.AddAllocation(new MTLAllocation(descriptor.ColorAttachments.Object(0).Texture));
            _residencySet.Commit();

            var encoder = _commandBuffer.RenderCommandEncoder(descriptor);

            encoder.SetRenderPipelineState(_renderPipelineState);
            encoder.SetDepthStencilState(_depthStencilState);

            _vertexArgumentTable.SetAddress(_vertexBuffer.GpuAddress, 0);
            _vertexArgumentTable.SetAddress(instanceDataBuffer.GpuAddress, 1);
            _vertexArgumentTable.SetAddress(cameraDataBuffer.GpuAddress, 2);

            _fragmentArgumentTable.SetTexture(_texture.GpuResourceID, 0);

            encoder.SetArgumentTable(_vertexArgumentTable, MTLRenderStages.RenderStageVertex);
            encoder.SetArgumentTable(_fragmentArgumentTable, MTLRenderStages.RenderStageFragment);

            encoder.SetCullMode(MTLCullMode.Back);
            encoder.SetFrontFacingWinding(MTLWinding.CounterClockwise);

            encoder.WaitForFence(_fence, MTLStages.StageFragment);
            encoder.DrawIndexedPrimitives(MTLPrimitiveType.Triangle, 6 * 6, MTLIndexType.UInt16, _indexBuffer.GpuAddress, 0, TotalInstances);

            encoder.EndEncoding();
            _commandBuffer.EndCommandBuffer();

            _queue.Wait(view.CurrentDrawable);
            _queue.Commit([_commandBuffer], 1);
            _queue.SignalDrawable(view.CurrentDrawable);

            view.CurrentDrawable.Present();
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
