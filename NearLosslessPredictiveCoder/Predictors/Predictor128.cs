using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class Predictor128 : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return 128;
        }

        public string GetDescription()
        {
            return "128";
        }
    }
}
