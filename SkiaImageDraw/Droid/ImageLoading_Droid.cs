using System;
using System.Reflection; // to get the resourceId from a string
using Xamarin.Android;
using SkiaSharp;

[assembly: Xamarin.Forms.Dependency(typeof(SkiaImageDraw.ImageLoading_Droid))]
namespace SkiaImageDraw
{
	public class ImageLoading_Droid : IImageLoading
    {
        public ImageLoading_Droid()
        {
        }

		public SKBitmap LoadBitmapFromResource(string resourceName)
		{
			// WARNING this works only in a Single-context application
            // see https://stackoverflow.com/questions/47353986/xamarin-forms-forms-context-is-obsolete?rq=1
			var ctx = Android.App.Application.Context;

			// more efficient if you could use compiled ID
			// check the id in the generated file Resource.designer.cs
			var resId = (int)typeof(Droid.Resource.Drawable).GetField(resourceName).GetValue(null);
			var res = ctx.Resources.OpenRawResource(resId);
			return SKBitmap.Decode(res);
		}

    }
}
