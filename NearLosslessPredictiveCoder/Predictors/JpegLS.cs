using NearLosslessPredictiveCoder.Contracts.Predictors;
using System;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class JpegLS : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            if (c >= Math.Max(a, b))
                return Math.Min(a, b);
            if (c <= Math.Min(a, b))
                return Math.Max(a, b);

            return a + b - c;
        }

        public string GetDescription()
        {
            return "jpegLS";
        }
    }
}
