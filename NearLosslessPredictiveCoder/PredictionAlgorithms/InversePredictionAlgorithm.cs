using NearLosslessPredictiveCoder.Entities;

namespace NearLosslessPredictiveCoder.PredictionAlgorithms
{
    public class InversePredictionAlgorithm : BasePredictionAlgorithm
    {
        public readonly int width;
        public readonly int height;

        public int[,] quantizedErrorPrediction;
        public int[,] dequantizedQuantizedErrorPrediction;
        public int[,] predictionFromDecoded;
        public int[,] decoded;

        public InversePredictionAlgorithm(EncodedImage encodedImage) : base(encodedImage.PredictorSettings)
        {
            this.quantizedErrorPrediction = encodedImage.QuantizedErrorPredictionMatrix;

            width = quantizedErrorPrediction.GetLength(1);
            height = quantizedErrorPrediction.GetLength(0);

            dequantizedQuantizedErrorPrediction = new int[height, width];
            predictionFromDecoded = new int[height, width];
            decoded = new int[height, width];
        }

        public DecodedImage GetDecodedImage()
        {
            CalculateMatrices();

            return new DecodedImage
            {
                QuantizedErrorPredictionMatrix = quantizedErrorPrediction,
                ErrorPredictionMatrix = dequantizedQuantizedErrorPrediction,
                Decoded = decoded,
                PredictorSettings = predictorSettings
            };
        }

        public void CalculateMatrices()
        {
            InitializePredictors();

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    dequantizedQuantizedErrorPrediction[i, j] = quantization.Dequantize(quantizedErrorPrediction[i, j], acceptedError);

                    predictionFromDecoded[i, j] = NormalizeValue(GetPrediction(i, j, decoded));
                    decoded[i, j] = NormalizeValue(predictionFromDecoded[i, j] + dequantizedQuantizedErrorPrediction[i, j]);
                }
        }
    }
}
