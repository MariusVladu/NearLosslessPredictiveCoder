using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class B : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return b;
        }

        public string Description => "B";

        public int Code => (int)Predictor.B;
    }
}
