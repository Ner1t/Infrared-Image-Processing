using System.Drawing;
using System.Runtime.Versioning;

public static class BitmapToGrayScaleProcess
{
    [SupportedOSPlatform("windows")]
    public static Bitmap BitmapToGrayScale(Bitmap cirImage)
    {
        Bitmap grayImage = new Bitmap(cirImage.Width, cirImage.Height);

        for (int x = 0; x < cirImage.Width; x++)
        {
            for (int y = 0; y < cirImage.Height; y++)
            {
                Color pixelColor = cirImage.GetPixel(x, y);

                // apply the grayscale conversion formula
                int grayValue = (int)(0.2989 * pixelColor.R + 0.5870 * pixelColor.G + 0.1140 * pixelColor.B);

                // set the grayscale value for the current pixel
                grayImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
            }
        }
        return grayImage;
    }
}

