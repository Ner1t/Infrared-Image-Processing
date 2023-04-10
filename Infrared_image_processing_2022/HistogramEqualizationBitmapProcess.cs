using System.Drawing;
using System.Runtime.Versioning;

namespace Infrared_image_processing_2022
{

    public static class HistogramEqualizationBitmapProcess
    {
        [SupportedOSPlatform("windows")]
        public static Bitmap HistogramEqualization(Bitmap bitmap)
        {

            Bitmap equalizeBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            // Calculate the histogram of the denoised grayscale image
            int[] histogram = new int[256];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int grayValue = pixelColor.R;
                    histogram[grayValue]++;
                }
            }

            // Calculate the cumulative distribution function (CDF) of the histogram
            int[] cdf = new int[256];
            cdf[0] = histogram[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogram[i];
            }

            // Normalize the CDF
            int cdfMin = cdf.Where(v => v > 0).Min();
            int cdfMax = cdf.Max();
            for (int i = 0; i < 256; i++)
            {
                cdf[i] = (int)(((double)(cdf[i] - cdfMin) / (bitmap.Width * bitmap.Height - cdfMin)) * 255);
            }

            // Equalize the histogram of the denoised grayscale image
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int grayValue = pixelColor.R;
                    int equalizedValue = cdf[grayValue];
                    Color equalizedColor = Color.FromArgb(equalizedValue, equalizedValue, equalizedValue);
                    equalizeBitmap.SetPixel(x, y, equalizedColor);
                }
            }
            return equalizeBitmap;
        }



    }
}