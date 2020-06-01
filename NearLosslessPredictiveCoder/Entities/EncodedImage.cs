namespace NearLosslessPredictiveCoder.Entities
{
    public class EncodedImage
    {
        public int[,] QuantizedErrorPredictionMatrix { get; set; }
        public PredictorSettings PredictorSettings { get; set; }
    }
}
