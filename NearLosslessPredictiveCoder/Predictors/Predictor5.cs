using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class Predictor5 : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return a + (b - c) / 2;
        }

        public string GetDescription()
        {
            return "A + (B - C) / 2";
        }
    }
}
