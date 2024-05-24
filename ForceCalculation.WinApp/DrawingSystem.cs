using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.Direct3D;
using Device = SharpDX.Direct3D11.Device;
using Buffer = SharpDX.Direct3D11.Buffer;
using System.Drawing.Drawing2D;
using Color = System.Drawing.Color;
using Matrix = SharpDX.Matrix;
//using System.Numerics;

namespace ForceCalculation.WinApp
{
    internal class DrawingSystem : IDisposable
    {
        private Device device;
        private SwapChain swapChain;
        private RenderTargetView renderTargetView;
        private DepthStencilView depthStencilView;

        public DrawingSystem(Control renderWindow)
        {
            StartSetup(renderWindow);
            DrawAxis();
        }

        private void StartSetup(Control renderWindow)
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

        private void DrawAxis()
        {
            var context = device.ImmediateContext;
            context.ClearRenderTargetView(renderTargetView, new RawColor4(0, 0.5f, 0.5f, 1));
            context.ClearDepthStencilView(depthStencilView, DepthStencilClearFlags.Depth, 1.0f, 0);

            var axisVertices = new[]
            {
                // Axis Y
                new Vector3(0, -10, 0),
                new Vector3(0, 10, 0),
                // Axis X
                new Vector3(-10, 0, 0),
                new Vector3(10, 0, 0),
                // Axis Z
                new Vector3(0, 0, -10),
                new Vector3(0, 0, 10)
            };

            var colors = new[]
            {
                Color.White.ToArgb(),
                Color.White.ToArgb(),
                Color.White.ToArgb(),
                Color.White.ToArgb(),
                Color.White.ToArgb(),
                Color.White.ToArgb()
            };

            var vertices = new[]
            {
                new VertexPositionColor { Position = axisVertices[0], Color = colors[0] },
                new VertexPositionColor { Position = axisVertices[1], Color = colors[1] },
                new VertexPositionColor { Position = axisVertices[2], Color = colors[2] },
                new VertexPositionColor { Position = axisVertices[3], Color = colors[3] },
                new VertexPositionColor { Position = axisVertices[4], Color = colors[4] },
                new VertexPositionColor { Position = axisVertices[5], Color = colors[5] }
            };

            var vertexBuffer = Buffer.Create(device, BindFlags.VertexBuffer, vertices);

            context.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, Utilities.SizeOf<VertexPositionColor>(), 0));
            context.InputAssembler.PrimitiveTopology = PrimitiveTopology.LineList;

            context.Draw(vertices.Length, 0);

            swapChain.Present(0, PresentFlags.None);
        }

        private void SetupProjection()
        {
            SetupLight();
            SetupCamera();
        }

        private void SetupLight()
        {
            // Light setup is generally handled in shaders in DirectX 11
        }

        private void SetupCamera()
        {
            var context = device.ImmediateContext;

            var projectionMatrix = Matrix.PerspectiveFovLH(
                (float)Math.PI / 4,
                (float)swapChain.Description.ModeDescription.Width / swapChain.Description.ModeDescription.Height,
                0.1f, 100.0f);

            var viewMatrix = Matrix.LookAtLH(new Vector3(1, 2, -5), new Vector3(1, 2, 0), Vector3.UnitY);

            // Update the view and projection matrices here
        }

        public void Dispose()
        {
            renderTargetView.Dispose();
            depthStencilView.Dispose();
            swapChain.Dispose();
            device.Dispose();
        }

        struct VertexPositionColor
        {
            public Vector3 Position;
            public int Color;
        }
    }
}
