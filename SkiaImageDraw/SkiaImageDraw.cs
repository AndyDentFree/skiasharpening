
using System;
using System.Diagnostics;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaImageDraw
{
    public class App : Application
    {

        private SKCanvasView _canvasView = null;
		private static SKColor _lineColor = SKColor.Parse("#ff66ff");
        private SKPaint _paint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill  // default filled circles
        };


        public App()
        {
			_canvasView = new SKCanvasView{HeightRequest=100, WidthRequest=100};

            // use a closure so can bind to our contextual items data
            // painting on rapidly triggered callback means OpenGL surface calcs are done 
            // and dimensions known at that point
            _canvasView.PaintSurface += (object sender, SKPaintSurfaceEventArgs paintArgs) => {
                SKImageInfo info = paintArgs.Info;
                SKSurface surface = paintArgs.Surface;
                SKCanvas canvas = surface.Canvas;
                Debug.WriteLine($"canvas bounds {canvas.LocalClipBounds}");
                canvas.Clear();
                DrawImageFromResource(canvas, _paint);

            };
            

			// The root page of your application
            var content = new ContentPage
            {
                Title = "SkiaImageDraw",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms 3.0!"
                        },
						new Image {Source="day_shift.png"},
                        _canvasView
                    }
                }
            };
            MainPage = new NavigationPage(content);
        }

        static private void DrawImageFromResource(SKCanvas canvas, SKPaint paint)
        {
            paint.Color = App._lineColor;
            var drawWidth = canvas.LocalClipBounds.Width;
            var drawHeight = canvas.LocalClipBounds.Height;
            var squareLen = Math.Min(drawHeight, drawWidth);
            var imageSquare = squareLen - 20;
            var horizMargin = (drawWidth - imageSquare) / 2;
            var vertMargin = (drawHeight - imageSquare) / 2;
            canvas.DrawCircle(drawWidth/2, drawHeight/2, squareLen/2 - 4, paint);
			var renderInto = new SKRect(horizMargin, vertMargin, horizMargin+imageSquare, vertMargin+imageSquare);
			// load image of appropriate resolution for device, across platforms
			var toDraw = DependencyService.Get<IImageLoading>().LoadBitmapFromResource("day_shift");
            canvas.DrawBitmap(toDraw, renderInto);
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
