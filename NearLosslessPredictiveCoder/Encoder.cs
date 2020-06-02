using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.Mappers;
using NearLosslessPredictiveCoder.PredictionAlgorithms;
using System.Drawing;

namespace NearLosslessPredictiveCoder
{
    public class Encoder
    {
        public EncodedImage Encode(Bitmap image, PredictorSettings predictorSettings)
        {
            var originalImageMatrix = ImageMapper.GetPixelMatrixFromImage(image);

            var predictionAlgorithm = new PredictionAlgorithm(originalImageMatrix, predictorSettings);

            return predictionAlgorithm.GetEncodedImage();
        }
    }
}
