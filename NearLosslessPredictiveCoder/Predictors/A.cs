﻿using NearLosslessPredictiveCoder.Contracts.Predictors;

namespace NearLosslessPredictiveCoder.Predictors
{
    public class A : IPredictor
    {
        public int Predict(int a, int b, int c)
        {
            return a;
        }

        public string GetDescription()
        {
            return "A";
        }
    }
}
