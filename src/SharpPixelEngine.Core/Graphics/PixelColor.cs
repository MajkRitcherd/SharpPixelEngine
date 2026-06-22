using System.Runtime.CompilerServices;

namespace SharpPixelEngine.Core.Graphics
{
    /// <summary>
    /// Represents a 32-bit color strictly formatted for Raylib's UncompressedR8G8B8A8.
    /// Designed as a zero-allocation readonly struct (4 bytes total).
    /// </summary>
    /// <param name="r">Red value (0 - 255).</param>
    /// <param name="g">Green value (0 - 255).</param>
    /// <param name="b">Blue value (0 - 255).</param>
    /// <param name="a">Alpha (0 - 255).</param>
    [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly struct PixelColor(byte r, byte g, byte b, byte a = 255)
    {
        // --- Standard predefined colors
        public static readonly PixelColor Black = new(0, 0, 0);
        public static readonly PixelColor Blank = new(0, 0, 0, 0);
        public static readonly PixelColor Blue = new(0, 0, 255);
        public static readonly PixelColor Cyan = new(0, 255, 255);
        public static readonly PixelColor Green = new(0, 255, 0);
        public static readonly PixelColor Magenta = new(255, 0, 255);
        public static readonly PixelColor Red = new(255, 0, 0);
        public static readonly PixelColor White = new(255, 255, 255);
        public static readonly PixelColor Yellow = new(255, 255, 0);

        /// <summary>
        /// The raw 32-bit color value.
        /// </summary>
        public readonly uint Value = (uint)(r | (g << 8) | (b << 16) | (a << 24));

        /// <summary>
        /// Implicitly converts PixelColor to uint when writting directly to the uint[] buffer.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(PixelColor color) => color.Value;
    }
}