using NearLosslessPredictiveCoder.Contracts.SaveModes;
using System;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public static class SaveModeFactory
    {
        public static ISaveMode GetSaveMode(SaveMode saveMode)
        {
            switch (saveMode)
            {
                case SaveMode.Fixed9: return new FixedSaveMode(9);
                case SaveMode.Fixed16: return new FixedSaveMode(16);
                case SaveMode.Fixed32: return new FixedSaveMode(32);
                case SaveMode.Table: return new TableSaveMode();
                case SaveMode.Arithmetic: return new ArithmeticSaveMode();

                default: throw new InvalidOperationException($"Requested save mode not implemented");
            }
        }
    }
}
