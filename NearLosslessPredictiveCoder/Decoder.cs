using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.Mappers;
using NearLosslessPredictiveCoder.PredictionAlgorithms;
using System.Drawing;

namespace NearLosslessPredictiveCoder
{
    public class Decoder
    {
        public Bitmap Decode(EncodedImage encodedImage)
        {
            var inversePredictionAlgorithm = new InversePredictionAlgorithm(encodedImage);
            
            var decodedMatrix = inversePredictionAlgorithm.GetDecodedMatrix();

            return ImageMapper.GetImageFromPixelMatrix(decodedMatrix);
        }
    }
}
