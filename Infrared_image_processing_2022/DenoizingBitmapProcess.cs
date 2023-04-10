using System.Drawing;
using System.Runtime.Versioning;

namespace Infrared_image_processing_2022
{
    public static class DenoizingBitmapProcess
    {
        [SupportedOSPlatform("windows")]
        public static Bitmap Denoizing(Bitmap grayscaleImage, int filterSize)
        {
            //Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);

            //// iterate over each pixel in image
            //for (int x = 0; x < inputImage.Width; x++)
            //{
            //    for (int y = 0; y < inputImage.Height; y++)
            //    {
            //        // create a new array to hold the values of the pixels in the filter
            //        int[] filter = new int[filterSize * filterSize];
            //        int index = 0;

            //        // iterate over each pixel in filter
            //        for (int fx = 0; fx < filterSize; fx++)
            //        {
            //            for (int fy = 0; fy < filterSize; fy++)
            //            {
            //                // calculate the position of the current pixel in the filter
            //                int px = x + fx - filterSize / 2;
            //                int py = y + fy - filterSize / 2;

            //                // check if the current pixel is within the bounds of the image
            //                if (px >= 0 && px < inputImage.Width && py >= 0 && py < inputImage.Height)
            //                {
            //                    // add the value of the current pixel to the filter
            //                    filter[index] = inputImage.GetPixel(px, py).R;
            //                    index++;
            //                }
            //            }
            //        }

            //        // sort the values in filter
            //        Array.Sort(filter);

            //        // get the median value from the filter
            //        int median = filter[filterSize * filterSize / 2];

            //        // set the output pixel to the median value
            //        outputImage.SetPixel(x, y, Color.FromArgb(median, median, median));
            //    }
            //}

            Bitmap denoisedImage = new Bitmap(grayscaleImage.Width, grayscaleImage.Height);

            // Define  size of the window used for median filtering
            //int filterSize = 3;

            // apply median filtering to remove noise from the grayscale image
            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    // Get the pixel values in  window around  current pixel
                    List<int> pixelValues = new List<int>();
                    for (int i = x - filterSize / 2; i <= x + filterSize / 2; i++)
                    {
                        for (int j = y - filterSize / 2; j <= y + filterSize / 2; j++)
                        {
                            if (i >= 0 && i < grayscaleImage.Width && j >= 0 && j < grayscaleImage.Height)
                            {
                                Color pixelColor = grayscaleImage.GetPixel(i, j);
                                int grayValue = pixelColor.R;
                                pixelValues.Add(grayValue);
                            }
                        }
                    }

                    // calculate the median value of the pixel values in the window
                    pixelValues.Sort();
                    int medianValue;
                    if (pixelValues.Count % 2 == 0)
                    {
                        medianValue = (pixelValues[pixelValues.Count / 2 - 1] + pixelValues[pixelValues.Count / 2]) / 2;
                    }
                    else
                    {
                        medianValue = pixelValues[pixelValues.Count / 2];
                    }

                    // set the value of the current pixel in the denoised image to the median value
                    Color denoisedColor = Color.FromArgb(medianValue, medianValue, medianValue);
                    denoisedImage.SetPixel(x, y, denoisedColor);
                }
            }



            return denoisedImage;
        }

    }
}
