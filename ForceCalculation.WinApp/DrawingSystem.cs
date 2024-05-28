using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using Buffer = SharpDX.Direct3D11.Buffer;
using Device = SharpDX.Direct3D11.Device;
using SharpDX.Mathematics.Interop;
using SharpDX.D3DCompiler;
using Color = SharpDX.Color;

namespace ForceCalculation.WinApp
{
    internal class DrawingSystem : IDisposable
    {
        private Device device;
        private SwapChain swapChain;
        private RenderTargetView renderTargetView;
        private DepthStencilView depthStencilView;
        private VertexShader vertexShader;
        private PixelShader pixelShader;
        private InputLayout inputLayout;
        private Buffer vertexBuffer;
        private Buffer constantBuffer;

        private Vector3 cameraPosition;
        private Vector3 cameraTarget;
        private Matrix viewMatrix;
        private Matrix projectionMatrix;

        private List<Vector3> vectors = new List<Vector3>();
        private List<string> vectorNames = new List<string>();

        public DrawingSystem(Control renderWindow)
        {
            InitializeDevice(renderWindow);
            LoadShaders();
            SetupCamera();
            DrawAxis();
        }

        private void InitializeDevice(Control renderWindow)
        {
            var swapChainDescription = new SwapChainDescription
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(renderWindow.ClientSize.Width, renderWindow.ClientSize.Height, new Rational(60, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputHandle = renderWindow.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, swapChainDescription, out device, out swapChain);

            using (var backBuffer = swapChain.GetBackBuffer<Texture2D>(0))
            {
                renderTargetView = new RenderTargetView(device, backBuffer);
            }

            var depthBufferDesc = new Texture2DDescription
            {
                Format = Format.D16_UNorm,
                ArraySize = 1,
                MipLevels = 1,
                Width = renderWindow.ClientSize.Width,
                Height = renderWindow.ClientSize.Height,
                SampleDescription = new SampleDescription(1, 0),
                Usage = ResourceUsage.Default,
                BindFlags = BindFlags.DepthStencil,
                CpuAccessFlags = CpuAccessFlags.None,
                OptionFlags = ResourceOptionFlags.None
            };

            using (var depthBuffer = new Texture2D(device, depthBufferDesc))
            {
                depthStencilView = new DepthStencilView(device, depthBuffer);
            }

            var context = device.ImmediateContext;
            context.OutputMerger.SetTargets(depthStencilView, renderTargetView);
            context.Rasterizer.SetViewport(new ViewportF(0, 0, renderWindow.ClientSize.Width, renderWindow.ClientSize.Height));
        }

        private void LoadShaders()
        {
            var vertexShaderByteCode = ShaderBytecode.CompileFromFile("VertexShader.hlsl", "VSMain", "vs_4_0");
            vertexShader = new VertexShader(device, vertexShaderByteCode);

            var pixelShaderByteCode = ShaderBytecode.CompileFromFile("PixelShader.hlsl", "PSMain", "ps_4_0");
            pixelShader = new PixelShader(device, pixelShaderByteCode);

            inputLayout = new InputLayout(device, ShaderSignature.GetInputSignature(vertexShaderByteCode), new[]
            {
                    new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0),
                    new InputElement("COLOR", 0, Format.R32G32B32A32_Float, 12, 0)
                });
        }

        private void SetupCamera()
        {
            cameraPosition = new Vector3(0, 0, -10);
            cameraTarget = Vector3.Zero;
            viewMatrix = Matrix.LookAtLH(cameraPosition, cameraTarget, Vector3.UnitY);
            projectionMatrix = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1.0f, 0.1f, 100.0f);
        }

        public void DrawAxis()
        {
            var context = device.ImmediateContext;

            var vertices = new[]
            {
                    new VertexPositionColor { Position = new Vector3(0, -10, 0), Color = new Color4(1, 1, 1, 1) },
                    new VertexPositionColor { Position = new Vector3(0, 10, 0), Color = new Color4(1, 1, 1, 1) },
                    new VertexPositionColor { Position = new Vector3(10, 0, 0), Color = new Color4(1, 1, 1, 1) },
                    new VertexPositionColor { Position = new Vector3(-10, 0, 0), Color = new Color4(1, 1, 1, 1) },
                    new VertexPositionColor { Position = new Vector3(0, 0, 10), Color = new Color4(1, 1, 1, 1) },
                    new VertexPositionColor { Position = new Vector3(0, 0, -10), Color = new Color4(1, 1, 1, 1) }
                };

            using (var vertexBuffer = Buffer.Create(device, BindFlags.VertexBuffer, vertices))
            {
                context.ClearRenderTargetView(renderTargetView, new RawColor4(0, 0.5f, 0.5f, 1));
                context.ClearDepthStencilView(depthStencilView, DepthStencilClearFlags.Depth, 1.0f, 0);

                context.InputAssembler.InputLayout = inputLayout;
                context.InputAssembler.PrimitiveTopology = PrimitiveTopology.LineList;
                context.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, Utilities.SizeOf<VertexPositionColor>(), 0));

                context.VertexShader.Set(vertexShader);
                context.PixelShader.Set(pixelShader);

                var worldViewProj = Matrix.Identity * viewMatrix * projectionMatrix;
                var matrixBytes = Utilities.ToByteArray(new Matrix[] { worldViewProj });

                using (var dataStream = new DataStream(matrixBytes.Length, true, true))
                {
                    dataStream.Write(matrixBytes, 0, matrixBytes.Length);

                    constantBuffer = new Buffer(device, dataStream, new BufferDescription
                    {
                        Usage = ResourceUsage.Default,
                        BindFlags = BindFlags.ConstantBuffer,
                        CpuAccessFlags = CpuAccessFlags.None,
                        OptionFlags = ResourceOptionFlags.None,
                        StructureByteStride = 0,
                        SizeInBytes = Utilities.SizeOf<Matrix>()
                    });

                    context.UpdateSubresource(ref worldViewProj, constantBuffer);
                    context.VertexShader.SetConstantBuffer(0, constantBuffer);

                    context.Draw(vertices.Length, 0);
                    swapChain.Present(0, PresentFlags.None);
                }
            }
        }

        public void MoveCameraForward() => MoveCamera(Vector3.ForwardLH);
        public void MoveCameraBackward() => MoveCamera(Vector3.BackwardLH);
        public void MoveCameraLeft() => MoveCamera(Vector3.Left);
        public void MoveCameraRight() => MoveCamera(Vector3.Right);
        public void MoveCameraUp() => MoveCamera(Vector3.Up);
        public void MoveCameraDown() => MoveCamera(Vector3.Down);
        public void RotateCameraLeft() => RotateCamera(-1);
        public void RotateCameraRight() => RotateCamera(1);

        private void MoveCamera(Vector3 direction)
        {
            cameraPosition += direction;
            UpdateViewMatrix();
        }

        private void RotateCamera(float angle)
        {
            var rotation = Matrix.RotationY(angle * (float)Math.PI / 180.0f);
            cameraTarget = Vector3.TransformCoordinate(cameraTarget - cameraPosition, rotation) + cameraPosition;
            UpdateViewMatrix();
        }

        private void UpdateViewMatrix()
        {
            viewMatrix = Matrix.LookAtLH(cameraPosition, cameraTarget, Vector3.UnitY);
        }

        public void DrawVector(Vector3 startPoint, Vector3 endPoint, string vectorName)
        {
            var context = device.ImmediateContext;

            var vertices = new[]
            {
                    new VertexPositionColor { Position = startPoint, Color = new Color4(1, 0, 0, 1) },
                    new VertexPositionColor { Position = endPoint, Color = new Color4(1, 0, 0, 1) }
                };

            vectors.Add(startPoint);
            vectors.Add(endPoint);
            vectorNames.Add(vectorName);

            using (var vertexBuffer = Buffer.Create(device, BindFlags.VertexBuffer, vectors.ToArray()))
            {
                context.ClearRenderTargetView(renderTargetView, new RawColor4(0, 0.5f, 0.5f, 1));
                context.ClearDepthStencilView(depthStencilView, DepthStencilClearFlags.Depth, 1.0f, 0);

                context.InputAssembler.InputLayout = inputLayout;
                context.InputAssembler.PrimitiveTopology = PrimitiveTopology.LineList;
                context.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, Utilities.SizeOf<VertexPositionColor>(), 0));

                context.VertexShader.Set(vertexShader);
                context.PixelShader.Set(pixelShader);

                var worldViewProj = Matrix.Identity * viewMatrix * projectionMatrix;
                var matrixBytes = Utilities.ToByteArray(new Matrix[] { worldViewProj });

                using (var dataStream = new DataStream(matrixBytes.Length, true, true))
                {
                    dataStream.Write(matrixBytes, 0, matrixBytes.Length);

                    context.UpdateSubresource(ref worldViewProj, constantBuffer);
                    context.VertexShader.SetConstantBuffer(0, constantBuffer);

                    context.Draw(vectors.Count, 0);
                    swapChain.Present(0, PresentFlags.None);
                }
            }
        }

        public void Dispose()
        {
            vertexBuffer.Dispose();
            inputLayout.Dispose();
            pixelShader.Dispose();
            vertexShader.Dispose();
            depthStencilView.Dispose();
            renderTargetView.Dispose();
            swapChain.Dispose();
            device.Dispose();
        }

        private struct VertexPositionColor
        {
            public Vector3 Position;
            public Color4 Color;
        }
    }
}
