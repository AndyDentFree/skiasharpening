using System;
using SkiaSharp;

namespace SkiaImageDraw
{
    public interface IImageLoading
    {
		SKBitmap LoadBitmapFromResource(string resourceName);
    }
}
