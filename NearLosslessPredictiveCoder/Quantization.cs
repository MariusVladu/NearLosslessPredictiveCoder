using NearLosslessPredictiveCoder.Contracts;
using System;

namespace NearLosslessPredictiveCoder
{
    public class Quantization : IQuantization
    {
        public int Quantize(int value, int acceptedError)
        {
            return (int)Math.Floor((double)(value + acceptedError) / (2 * acceptedError + 1));
        }

        public int Dequantize(int value, int acceptedError)
        {
            return value * (2 * acceptedError + 1);
        }
    }
}
