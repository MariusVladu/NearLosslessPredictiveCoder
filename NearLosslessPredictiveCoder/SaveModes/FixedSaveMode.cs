using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class FixedSaveMode : ISaveMode
    {
        public static int NumberOfBitsForValue = 9;
        public static int UnusedBits => 32 - NumberOfBitsForValue;

        public int[] ReadValues(long bitsToRead, IBitReader bitReader)
        {
            bitsToRead -= bitsToRead % NumberOfBitsForValue;

            var values = new List<int>();

            while(bitsToRead > 0)
            { 
                var readValue = bitReader.ReadNBits(NumberOfBitsForValue);
                var parsedValue = ParseValueToInt(readValue);

                values.Add(parsedValue);

                bitsToRead -= NumberOfBitsForValue;
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

        private int ParseValueToInt(uint value)
        {
            return ((int)value << UnusedBits) >> UnusedBits;
        }
    }
}
