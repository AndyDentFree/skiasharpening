SkiaImageDraw
======

A little testbed for SkiaSharp particularly to explore the issue of embedding images and drawing them.

Created with VSMac as a "Blank Forms project" with non-XAML UI, later updated to .netstandard2.1

## More Info
It has to use platform-specific calls to get the resources loaded.

The interface `IImageLoading` is used with a `DependencyService` in `SkiaImageDraw.cs`.

The loading code is in `ImageLoading_Droid.cs` and `ImageLoading_iOS.cs`

