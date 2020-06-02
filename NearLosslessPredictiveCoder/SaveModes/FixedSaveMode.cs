using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class FixedSaveMode : ISaveMode
    {
        public static int NumberOfBitsForValue = 9;

        public int[] ReadValues(long bitsToRead, IBitReader bitReader)
        {
            var values = new List<int>();

            for (int i = 0; i < bitsToRead; i += NumberOfBitsForValue)
            {
                values.Add((int)bitReader.ReadNBits(NumberOfBitsForValue));
            }

            return values.ToArray();
        }

        public void WriteValues(int[] values, IBitWriter bitWriter)
        {
            foreach (var value in values)
            {
                bitWriter.WriteNBits(NumberOfBitsForValue, (uint)value);
            }
        }
    }
}
