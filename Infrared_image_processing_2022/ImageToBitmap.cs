using System.Drawing;
using System.Runtime.Versioning;

public static class ImageToBitmapProcess
{
    [SupportedOSPlatform("windows")]
    public static Bitmap ImageToBitmap(string filePath)
    {
        Bitmap bitmap = new Bitmap(filePath);

        //int width = bitmap.Width;
        //int height = bitmap.Height;

        //image.Save("newImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        return bitmap;
    }



}
