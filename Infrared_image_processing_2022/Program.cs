using Infrared_image_processing_2022;
using System.Drawing;

{
    Bitmap bitmap = ImageToBitmapProcess.ImageToBitmap("face.bmp");

    Bitmap grayscaleBitmap = BitmapToGrayScaleProcess.BitmapToGrayScale(bitmap);
    grayscaleBitmap.Save("GrayscaleImage.bmp");

    Bitmap denoisedGrayscaleBitmap = DenoizingBitmapProcess.Denoizing(grayscaleBitmap, 4);
    denoisedGrayscaleBitmap.Save("DenoisedGrayscaleImage.bmp");

    Bitmap normalizedDenoisedGrayscaleBitmap = NormalizeBitmapProcess.Normalize(denoisedGrayscaleBitmap);
    normalizedDenoisedGrayscaleBitmap.Save("NormalizedDenoisedGrayscaleImage.bmp");

    Bitmap equalizedNormalizedDenoisedGrayscaleBitmap = HistogramEqualizationBitmapProcess.HistogramEqualization(normalizedDenoisedGrayscaleBitmap);
    equalizedNormalizedDenoisedGrayscaleBitmap.Save("EqualizedNormalizedDenoisedGrayscaleImage.bmp");

    Bitmap ColourBitmap = BitmapToColorProcess.BitmapToColor(equalizedNormalizedDenoisedGrayscaleBitmap, bitmap);

    ColourBitmap.Save("EqualizedNormalizeDenoisedColorImage.bmp");

}


// Load the infrared image
//Mat image = Cv2.ImRead("infrared_image.png", ImreadModes.Grayscale);

//// Apply pre-processing steps, such as denoising or normalization

//// Detect face region using Haar cascade 
//CascadeClassifier classifier = new CascadeClassifier("haarcascade_frontalface_default.xml");
//Rect[] faces = classifier.DetectMultiScale(image);

//// Extract the first detected face region
//Rect faceRegion = faces[0];
//Mat faceImage = image.SubMat(faceRegion);

//// Apply postprocessing steps, such as resizing or filtering

//// Analyze the face features using a facial recognition algorithm

//// Save the output as required by the application
//faceImage.ImWrite("cropped_face.png");
