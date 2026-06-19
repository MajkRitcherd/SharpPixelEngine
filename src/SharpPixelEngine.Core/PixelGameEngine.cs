using System.Runtime.CompilerServices;

namespace SharpPixelEngine.Core
{
    /// <summary>
    /// The main abstract engine class. <br />
    /// It handles canvas initialization, screen memory management and defines the game's lifecycle.
    /// </summary>
    public abstract class PixelGameEngine
    {
        /// <summary>
        /// Total number of pixels on the canvas.
        /// </summary>
        public int PixelCount => ScreenWidth * ScreenHeight;

        /// <summary>
        /// Logical screen height in pixels.
        /// </summary>
        public int ScreenHeight { get; set; }

        /// <summary>
        /// Logical screen width in pixels.
        /// </summary>
        public int ScreenWidth { get; set; }

        /// <summary>
        /// 1D array representing the linear pixel buffer (RGBA / ABGR formatdepending on endianness). <br />
        /// Protected allows fast, direct access from derived game classes or simulations.
        /// </summary>
        protected uint[] PixelBuffer { get; private set; } = [];

        /// <summary>
        /// Clears the entire screen with the specified color. <br />
        /// Thanks to Array.Fill(), .NET uses SIMD (vectorization) under the hood for maximum speed.
        /// </summary>
        /// <param name="color">The color to clear the screen with (HEX format).</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear(uint color)
        {
            Array.Fill(PixelBuffer, color);
        }

        /// <summary>
        /// Initializes the logical game dimensions and allocates memory for the pixel buffer. <br />
        /// This method is called only once at the start of the game (Zero GC allocation in the hot path).
        /// </summary>
        /// <param name="width">Screen width in pixels.</param>
        /// <param name="height">Screen height in pixels.</param>
        public void Construct(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Screen dimensions must be greater than 0.");

            ScreenWidth = width;
            ScreenHeight = height;

            PixelBuffer = new uint[PixelCount];

            Clear(0xFF000000);
        }

        #region Game Lifecycle

        /// <summary>
        /// Called once at game start after window and graphics initialization. <br />
        /// Ideal place for loading assets and initializing entities.
        /// </summary>
        protected abstract void OnUserCreate();

        /// <summary>
        /// Called every frame. <br />
        /// Game logic updates, pixel simulations, and drawing go here.
        /// </summary>
        /// <param name="deltaTime">Time elapsed since the last frame in seconds.</param>
        protected abstract void OnUserUpdate(float deltaTime);

        #endregion Game Lifecycle
    }
}