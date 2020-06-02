using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class HalfRange : IPredictor
    {
        private readonly int range;

        public HalfRange(int range = 256)
        {
            this.range = range;
        }

        public int Predict(int a, int b, int c)
        {
            return range / 2;
        }

        public string Description => $"{range / 2}";

        public int Code => (int)Predictor.HalfRange;
    }
}
