using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.PredictionAlgorithms;
using System.Drawing;

namespace NearLosslessPredictiveCoder
{
    public class Encoder
    {
        public EncodedImage EncodeAndSave(string filePath, PredictorSettings predictorSettings)
        {
            var originalImageMatrix = ExtractPixelMatrixFromImage(filePath);

            var predictionAlgorithm = new PredictionAlgorithm(originalImageMatrix, predictorSettings);

            return predictionAlgorithm.GetEncodedImage();
        }

        public int[,] ExtractPixelMatrixFromImage(string filePath)
        {
            var bitmap = new Bitmap(filePath);
            int[,] pixelMatrix = new int[bitmap.Height, bitmap.Width];

            for (int i = 0; i < bitmap.Height; i++)
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    pixelMatrix[i, j] = (color.R + color.G + color.B) / 3;
                }

            return pixelMatrix;
        }
    }
}
