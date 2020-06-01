﻿using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class Predictor4 : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return a + b - c;
        }

        public string GetDescription()
        {
            return "A + B - C";
        }
    }
}
