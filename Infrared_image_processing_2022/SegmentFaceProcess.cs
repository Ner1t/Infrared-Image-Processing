using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace Infrared_image_processing_2022
{
    public static class SegmentFaceProcess
    {

        public static Image<Gray, byte> SegmentFace(Image<Gray, byte> faceImage)
        {
            // Apply a median filter to smooth the image
            Image<Gray, byte> smoothedFaceImage = faceImage.SmoothMedian(3);

            // Apply the Canny edge detector to find edges in the image
            Image<Gray, byte> edges = smoothedFaceImage.Canny(50, 150);

            // Apply morphological closing to fill gaps between edges
            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            Image<Gray, byte> closedEdges = edges.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

            return closedEdges;
        }
    }
}
