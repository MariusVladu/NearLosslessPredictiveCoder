namespace NearLosslessPredictiveCoder.Entities
{
    public class EncodedImage
    {
        public int[,] Original { get; set; }
        public int[,] ErrorPrediction { get; set; }
        public int[,] QuantizedErrorPredictionMatrix { get; set; }
        public PredictorSettings PredictorSettings { get; set; }
    }
}
