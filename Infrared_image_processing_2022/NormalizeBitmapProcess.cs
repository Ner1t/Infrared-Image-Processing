using System.Drawing;
using System.Runtime.Versioning;

namespace Infrared_image_processing_2022
{
    public static class NormalizeBitmapProcess
    {
        [SupportedOSPlatform("windows")]
        public static Bitmap Normalize(Bitmap bitmap)
        {
            // create a new Bitmap object to hold the normalized image
            Bitmap normalizedImage = new Bitmap(bitmap.Width, bitmap.Height);
            // find the minimum and maximum values of each color channel
            int minRed = 255, maxRed = 0;
            int minGreen = 255, maxGreen = 0;
            int minBlue = 255, maxBlue = 0;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    if (pixelColor.R < minRed)
                        minRed = pixelColor.R;
                    if (pixelColor.R > maxRed)
                        maxRed = pixelColor.R;

                    if (pixelColor.G < minGreen)
                        minGreen = pixelColor.G;
                    if (pixelColor.G > maxGreen)
                        maxGreen = pixelColor.G;

                    if (pixelColor.B < minBlue)
                        minBlue = pixelColor.B;
                    if (pixelColor.B > maxBlue)
                        maxBlue = pixelColor.B;
                }
            }
            // Loop through each pixel in the image and normalize the color channels
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Normalize the red channel
                    int normalizedRed = (pixelColor.R - minRed) * (255 / (maxRed - minRed));

                    // Normalize the green channel
                    int normalizedGreen = (pixelColor.G - minGreen) * (255 / (maxGreen - minGreen));

                    // Normalize the blue channel
                    int normalizedBlue = (pixelColor.B - minBlue) * (255 / (maxBlue - minBlue));

                    // Create a new Color object with the normalized RGB values
                    Color normalizedColor = Color.FromArgb(normalizedRed, normalizedGreen, normalizedBlue);

                    // Set the color of the corresponding pixel in the new Bitmap object
                    normalizedImage.SetPixel(x, y, normalizedColor);
                }
            }
            // The normalized image is stored in the normalizedImage Bitmap object
            return normalizedImage;
        }
    }
}
