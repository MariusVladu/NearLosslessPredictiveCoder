using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class FixedSaveMode : BaseSaveMode
    {
        private int numberOfBitsForValue;

        public FixedSaveMode(int numberOfBitsForValue)
        {
            this.numberOfBitsForValue = numberOfBitsForValue;
        }

        protected override char SaveModeCode => 'F';

        protected override int[] ReadValues()
        {
            var values = new List<int>();

            for (int i = 0; i < bitsToRead; i += numberOfBitsForValue)
            {
                values.Add((int)bitReader.ReadNBits(numberOfBitsForValue));
            }

            return values.ToArray();
        }

        protected override void WriteValues(int[] values)
        {
            foreach (var value in values)
            {
                bitWriter.WriteNBits(numberOfBitsForValue, (uint)value);
            }
        }
    }
}
