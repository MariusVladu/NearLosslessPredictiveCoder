using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class FixedSaveMode : ISaveMode
    {
        public int numberOfBitsForValue;
        public int UnusedBits => 32 - numberOfBitsForValue;

        public FixedSaveMode(int numberOfBitsForValue)
        {
            this.numberOfBitsForValue = numberOfBitsForValue;
        }

        public int[] ReadValues(long bitsToRead, IBitReader bitReader)
        {
            bitsToRead -= bitsToRead % numberOfBitsForValue;

            var values = new List<int>();

            while(bitsToRead > 0)
            { 
                var readValue = bitReader.ReadNBits(numberOfBitsForValue);
                var parsedValue = ParseValueToInt(readValue);

                values.Add(parsedValue);

                bitsToRead -= numberOfBitsForValue;
            }

            return values.ToArray();
        }

        public void WriteValues(int[] values, IBitWriter bitWriter)
        {
            foreach (var value in values)
            {
                bitWriter.WriteNBits(numberOfBitsForValue, (uint)value);
            }
        }

        private int ParseValueToInt(uint value)
        {
            return ((int)value << UnusedBits) >> UnusedBits;
        }
    }
}
