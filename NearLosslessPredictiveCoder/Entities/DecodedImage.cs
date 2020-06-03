namespace NearLosslessPredictiveCoder.Entities
{
    public class DecodedImage
    {
        public int[,] QuantizedErrorPredictionMatrix { get; set; }
        public int[,] ErrorPredictionMatrix { get; set; }
        public int[,] Decoded { get; set; }
        public PredictorSettings PredictorSettings { get; set; }
    }
}
