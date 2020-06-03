using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using System.Collections.Generic;
using System.Linq;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class ArithmeticSaveMode : ISaveMode
    {
        public int[] ReadValues(long bitsToRead, IBitReader bitReader)
        {
            var decoder = new ArithmeticCoding.Decoder(GetCompleteAlphabet());

            return decoder.DecodeToArray(bitsToRead, bitReader)
                .Select(x => ParseValueToInt(x))
                .ToArray();
        }

        public void WriteValues(int[] values, IBitWriter bitWriter)
        {
            var encoder = new ArithmeticCoding.Encoder(GetCompleteAlphabet());

            var byteArray = values.Select(x => (byte)x).ToArray();

            encoder.EncodeArray(byteArray, bitWriter);
        }

        private List<int> GetCompleteAlphabet()
        {
            var completeAlphabet = new List<int>();

            for (int i = 0; i < 256; i++)
            {
                completeAlphabet.Add(i);
            }

            return completeAlphabet;
        }

        private int ParseValueToInt(uint value)
        {
            return ((int)value << 24) >> 24;
        }
    }
}
