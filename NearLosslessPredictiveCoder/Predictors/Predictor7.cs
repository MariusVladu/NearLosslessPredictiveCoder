using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class Predictor7 : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return (a + b) / 2;
        }

        public string GetDescription()
        {
            return "(A + B) / 2";
        }
    }
}
