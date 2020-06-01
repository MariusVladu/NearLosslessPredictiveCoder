using NearLosslessPredictiveCoder.Contracts.Predictors;
using System;

namespace NearLosslessPredictiveCoder.Predictors
{
    public static class PredictorFactory
    {
        public static IPredictor GetPredictorByCode(int predictorCode)
        {
            switch(predictorCode)
            {
                case 0: return new HalfRange();
                case 1: return new A();
                case 2: return new B();
                case 3: return new C();
                case 4: return new Predictor4();
                case 5: return new Predictor5();
                case 6: return new Predictor6();
                case 7: return new Predictor7();
                case 8: return new JpegLS();

                default: throw new InvalidOperationException($"No predictor implemented with code = {predictorCode}");
            }
        }
    }
}
