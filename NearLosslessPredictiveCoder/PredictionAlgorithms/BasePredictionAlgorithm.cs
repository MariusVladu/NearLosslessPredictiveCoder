using NearLosslessPredictiveCoder.Contracts;
using NearLosslessPredictiveCoder.Contracts.Predictors;
using NearLosslessPredictiveCoder.Entities;

namespace NearLosslessPredictiveCoder.PredictionAlgorithms
{
    public class BasePredictionAlgorithm
    {
        public PredictorSettings predictorSettings;

        public int range => predictorSettings.Range;
        public int acceptedError => predictorSettings.AcceptedError;
        public IQuantization quantization = new Quantization();

        public IPredictor predictor => predictorSettings.Predictor;
        public IPredictor firstRowPredictor;
        public IPredictor firstColumnPredictor;

        public BasePredictionAlgorithm(PredictorSettings predictorSettings)
        {
            this.predictorSettings = predictorSettings;
        }

        public int GetPrediction(int i, int j, int[,] matrix)
        {
            if (i == 0 && j == 0)
                return new Predictors.HalfRange(range).Predict(0, 0, 0);

            if (i == 0)
                return firstRowPredictor.Predict(matrix[0, j - 1], 0, 0);

            if (j == 0)
                return firstColumnPredictor.Predict(0, matrix[i - 1, 0], 0);

            return predictor.Predict(matrix[i, j - 1], matrix[i - 1, j], matrix[i - 1, j - 1]);
        }

        public int NormalizeValue(int value)
        {
            if (value < 0)
                return 0;

            if (value >= range)
                return range - 1;

            return value;
        }

        public void InitializePredictors()
        {
            if (predictor.GetType() == typeof(Predictors.HalfRange))
            {
                firstRowPredictor = predictor;
                firstColumnPredictor = predictor;
            }
            else
            {
                firstRowPredictor = new Predictors.A();
                firstColumnPredictor = new Predictors.B();
            }
        }
    }
}
