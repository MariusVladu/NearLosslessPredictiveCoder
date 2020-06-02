using BitReaderWriter;
using BitReaderWriter.Contracts;
using System;
using System.IO;

namespace NearLosslessPredictiveCoder.FileOperations
{
    public class BaseFileOperation : IDisposable
    {
        protected IBitReader bitReader;
        protected IBitWriter bitWriter;

        public void InitializeBitReader(string filePath)
        {
            var inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            bitReader = new BitReader(inputFileStream);
        }

        public void InitializeBitWriter(string filePath)
        {
            var outputFileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            bitWriter = new BitWriter(outputFileStream);
        }

        public void Dispose()
        {
            if (bitReader != null)
                bitReader.Dispose();

            if (bitWriter != null)
                bitWriter.Dispose();
        }
    }
}
