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
                case SaveMode.Table: return new TableSaveMode();

                default: throw new InvalidOperationException($"Requested save mode not implemented");
            }
        }
    }
}
