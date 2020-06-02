using NearLosslessPredictiveCoder.Contracts.Predictors;
using System;

namespace NearLosslessPredictiveCoder.Predictors
{
    public static class PredictorFactory
    {
        public static IPredictor GetPredictor(Predictor predictor)
        {
            switch(predictor)
            {
                case Predictor.HalfRange: return new HalfRange();
                case Predictor.A: return new A();
                case Predictor.B: return new B();
                case Predictor.C: return new C();
                case Predictor.Predictor4: return new Predictor4();
                case Predictor.Predictor5: return new Predictor5();
                case Predictor.Predictor6: return new Predictor6();
                case Predictor.Predictor7: return new Predictor7();
                case Predictor.JpegLS: return new JpegLS();

                default: throw new InvalidOperationException($"Requested predictor not implemented");
            }
        }
    }
}
