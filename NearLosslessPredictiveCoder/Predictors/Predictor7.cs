using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class Predictor7 : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return (a + b) / 2;
        }

        public string Description => "(A + B) / 2";

        public int Code => PredictorCodes.Predictor7;
    }
}
