using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.Mappers;
using NearLosslessPredictiveCoder.PredictionAlgorithms;
using System.Drawing;

namespace NearLosslessPredictiveCoder
{
    public static class Decoder
    {
        public static Bitmap Decode(EncodedImage encodedImage)
        {
            var inversePredictionAlgorithm = new InversePredictionAlgorithm(encodedImage);
            
            var decodedImage = inversePredictionAlgorithm.GetDecodedImage();

            return ImageMapper.GetImageFromPixelMatrix(decodedImage.Decoded);
        }

        public static DecodedImage GetDecodedImage(EncodedImage encodedImage)
        {
            var inversePredictionAlgorithm = new InversePredictionAlgorithm(encodedImage);

            return inversePredictionAlgorithm.GetDecodedImage();
        }
    }
}
