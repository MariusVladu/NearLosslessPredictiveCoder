using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class C : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return c;
        }

        public string Description => "C";

        public int Code => PredictorCodes.C;
    }
}
