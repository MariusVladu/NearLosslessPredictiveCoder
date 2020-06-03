using System;
using System.IO;

namespace NearLosslessPredictiveCoder.GUI
{
    public static class Util
    {
        public static string GetCompressionRatio(string uncompressedFilePath, string compressedFilePath)
        {
            var uncompressedSize = new FileInfo(uncompressedFilePath).Length;
            var compressedSize = new FileInfo(compressedFilePath).Length;

            var compressionRatio = Decimal.Divide(uncompressedSize, compressedSize);

            return $"Compression ratio is {compressionRatio.ToString("0.##")} : 1";
        }
    }
}
