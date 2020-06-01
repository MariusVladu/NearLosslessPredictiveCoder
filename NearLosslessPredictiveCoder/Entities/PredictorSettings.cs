using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Entities
{
    public class PredictorSettings
    {
        public IPredictor Predictor { get; set; }
        public int AcceptedError { get; set; }
        public int Range { get; set; } = 256;
    }
}
