using System;
using Xamarin.Forms;
//using UIKit;
using SkiaSharp;
using SkiaSharp.Views.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SkiaImageDraw.ImageLoading_iOS))]
namespace SkiaImageDraw
{
	public class ImageLoading_iOS : IImageLoading
    {
        public ImageLoading_iOS()
        {
        }

		public SKBitmap LoadBitmapFromResource(string resourceName)
        {
			var image = UIKit.UIImage.FromBundle(resourceName);
			return image.ToSKBitmap();
        }
    }
}
