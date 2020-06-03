using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using NearLosslessPredictiveCoder.Entities;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class TableSaveMode : ISaveMode
    {
        public int[] ReadValues(long bitsToRead, IBitReader bitReader)
        {
            var arrayLength = bitReader.ReadNBits(32);

            var values = new List<int>();
            var encodedValue = new TableEncodedValue();

            for(int i = 0; i < arrayLength; i++)
            {
                int numberOf1Before0 = 0;
                while (bitReader.ReadNBits(1) != 0)
                    numberOf1Before0++;

                if (numberOf1Before0 == 0)
                    values.Add(0);
                else
                {
                    encodedValue.NumberOf1Before0 = numberOf1Before0;
                    encodedValue.ValueAfter0 = (int)bitReader.ReadNBits(numberOf1Before0);

                    values.Add(TableValueEncoding.DecodeValue(encodedValue));
                }
            }

            return values.ToArray();
        }

        public void WriteValues(int[] values, IBitWriter bitWriter)
        {
            bitWriter.WriteNBits(32, (uint)values.Length);

            foreach (var value in values)
            {
                var encodedValue = TableValueEncoding.EncodeValue(value);

                if (encodedValue.NumberOf1Before0 == 0)
                    bitWriter.WriteNBits(1, 0);
                else
                {
                    for (int k = 0; k < encodedValue.NumberOf1Before0; k++)
                        bitWriter.WriteNBits(1, 1);

                    bitWriter.WriteNBits(1, 0);

                    bitWriter.WriteNBits(encodedValue.NumberOf1Before0, (uint)encodedValue.ValueAfter0);
                }
            }
        }
    }
}
