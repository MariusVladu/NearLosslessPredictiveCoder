using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class Predictor6 : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return b + (a - c) / 2;
        }

        public string Description => "B + (A - C) / 2";

        public int Code => PredictorCodes.Predictor6;
    }
}
