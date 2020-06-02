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
                case SaveMode.Fixed: return new FixedSaveMode();

                default: throw new InvalidOperationException($"Requested save mode not implemented");
            }
        }
    }
}
