using BitReaderWriter;
using BitReaderWriter.Contracts;
using System;
using System.IO;

namespace NearLosslessPredictiveCoder.IntegrationTests.SaveModes
{
    public static class SaveModesTestsCommon
    {
        public static int[] GetArray()
        {
            return new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public static int[] GetRandom65536Array()
        {
            var array = new int[256 * 256];
            var random = new Random();

            for (int i = 0; i < 256 * 256; i++)
                array[i] = random.Next(-10, 10);

            return array;
        }

        public static IBitReader GetBitReader(string filePath)
        {
            var inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new BitReader(inputFileStream);
        }

        public static IBitWriter GetBitWriter(string filePath)
        {
            var outputFileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            return new BitWriter(outputFileStream);
        }
    }
}
