using NearLosslessPredictiveCoder.Entities;

namespace NearLosslessPredictiveCoder.PredictionAlgorithms
{
    public class PredictionAlgorithm : BasePredictionAlgorithm
    {
        public readonly int width;
        public readonly int height;

        public int[,] original;
        public int[,] prediction;
        public int[,] errorPrediction;
        public int[,] quantizedErrorPrediction;
        public int[,] dequantizedQuantizedErrorPrediction;
        public int[,] predictionFromDecoded;
        public int[,] decoded;

        public PredictionAlgorithm(int[,] original, PredictorSettings predictorSettings) : base(predictorSettings)
        {
            this.original = original;

            width = original.GetLength(1);
            height = original.GetLength(0);

            prediction = new int[height, width];
            errorPrediction = new int[height, width];
            quantizedErrorPrediction = new int[height, width];
            dequantizedQuantizedErrorPrediction = new int[height, width];
            predictionFromDecoded = new int[height, width];
            decoded = new int[height, width];
        }

        public EncodedImage GetEncodedImage()
        {
            CalculateMatrices();

            return new EncodedImage
            {
                PredictorSettings = predictorSettings,
                QuantizedErrorPredictionMatrix = quantizedErrorPrediction,
                ErrorPrediction = errorPrediction,
                Original = original,
                Decoded = decoded
            };
        }

        public void CalculateMatrices()
        {
            InitializePredictors();

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    prediction[i, j] = NormalizeValue(GetPrediction(i, j, decoded));
                    errorPrediction[i, j] = original[i, j] - prediction[i, j];
                    quantizedErrorPrediction[i, j] = quantization.Quantize(errorPrediction[i, j], acceptedError);
                    dequantizedQuantizedErrorPrediction[i, j] = quantization.Dequantize(quantizedErrorPrediction[i, j], acceptedError);

                    predictionFromDecoded[i, j] = NormalizeValue(GetPrediction(i, j, decoded));
                    decoded[i, j] = NormalizeValue(predictionFromDecoded[i, j] + dequantizedQuantizedErrorPrediction[i, j]);
                }
        }
    }
}
