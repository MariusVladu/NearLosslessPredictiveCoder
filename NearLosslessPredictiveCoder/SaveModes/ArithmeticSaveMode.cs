using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public class ArithmeticSaveMode : ISaveMode
    {
        public int[] ReadValues(long bitsToRead, IBitReader bitReader)
        {
            var decoder = new ArithmeticCoding.Decoder(GetCompleteAlphabet());

            return decoder.DecodeToArray(bitsToRead, bitReader);
        }

        public void WriteValues(int[] values, IBitWriter bitWriter)
        {
            var encoder = new ArithmeticCoding.Encoder(GetCompleteAlphabet());

            encoder.EncodeArray(values, bitWriter);
        }

        private List<int> GetCompleteAlphabet()
        {
            var completeAlphabet = new List<int>();

            for (int i = -255; i < 256; i++)
            {
                completeAlphabet.Add(i);
            }

            return completeAlphabet;
        }
    }
}
