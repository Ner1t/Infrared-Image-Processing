using System.Drawing;
using System.Runtime.Versioning;

public static class BitmapToColorProcess
{
    [SupportedOSPlatform("windows")]
    public static Bitmap BitmapToColor(Bitmap grayscaleBitmap, Bitmap originalColourBitmap)
    {
        Bitmap convertedBitmap = new Bitmap(grayscaleBitmap.Width, grayscaleBitmap.Height);

        for (int x = 0; x < grayscaleBitmap.Width; x++)
        {
            for (int y = 0; y < grayscaleBitmap.Height; y++)
            {
                Color pixelColor = originalColourBitmap.GetPixel(x, y);
                int redValue = pixelColor.R;
                int greenValue = pixelColor.G;
                int blueValue = pixelColor.B;
                Color convertedColor = Color.FromArgb(redValue, greenValue, blueValue);
                convertedBitmap.SetPixel(x, y, convertedColor);
            }
        }
        return convertedBitmap;
    }
}
