namespace NearLosslessPredictiveCoder.Contracts
{
    public interface IQuantization
    {
        int Quantize(int value, int acceptedError);
        int Dequantize(int value, int acceptedError);
    }
}
