using BitReaderWriter;
using BitReaderWriter.Contracts;
using System.IO;

namespace NearLosslessPredictiveCoder.FileOperations
{
    public static class ImageHeaderHandler
    {
        public static void SkipHeaderFromImage(IBitReader bitReader)
        {
            for (int i = 0; i < 1078; i++)
            {
                bitReader.ReadNBits(8);
            }
        }

        public static void CopyHeaderFromFile(string filePath, IBitWriter bitWriter)
        {
            using(var bitReader = new BitReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
            {
                for (int i = 0; i < 1078; i++)
                {
                    bitWriter.WriteNBits(8, bitReader.ReadNBits(8));
                }
            }
        }
    }
}
