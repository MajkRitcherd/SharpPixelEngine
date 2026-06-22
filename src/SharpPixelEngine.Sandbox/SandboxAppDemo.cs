using SharpPixelEngine.Core.Graphics;

namespace SharpPixelEngine.Sandbox
{
    /// <summary>
    /// A sandbox application demonstrating the basic rendering capabilities
    /// of the custom pixel engine.
    /// </summary>
    internal class SandboxAppDemo : Core.PixelGameEngine
    {
        private readonly Random _rnd = new();

        /// <inheritdoc/>
        protected override void OnUserCreate()
        {
            // Initialization logic goes here.
            // Left empty for this demo as no assets or entities need to be loaded.
        }

        /// <inheritdoc/>
        protected override void OnUserUpdate(float deltaTime)
        {
            // Noise output
            for (int x = 0; x < ScreenWidth; x++)
            {
                for (int y = 0; y < ScreenHeight; y++)
                {
                    byte r = (byte)_rnd.Next(256);
                    byte g = (byte)_rnd.Next(256);
                    byte b = (byte)_rnd.Next(256);

                    Draw(x, y, new PixelColor(r, g, b));
                }
            }
        }
    }
}