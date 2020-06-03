using BitReaderWriter;
using BitReaderWriter.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.SaveModes;
using System;
using System.IO;

namespace NearLosslessPredictiveCoder.IntegrationTests
{
    [TestClass]
    public class FixedSaveModeIntegrationTests
    {
        private FixedSaveMode fixedSaveMode;
        private IBitReader bitReader;
        private IBitWriter bitWriter;

        private string outputFilePath = "outputFile";

        private int[] array = { -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [TestInitialize]
        public void Setup()
        {
            fixedSaveMode = new FixedSaveMode();
        }

        [TestMethod]
        public void TestThatWhenNumberOfBitsIs9FixedSaveModeCreatesFileOfExpectedSize()
        {
            FixedSaveMode.NumberOfBitsForValue = 9;
            var expectedBitsToRead = GetExpectedBitsToRead(array);
            InitializeBitWriter(outputFilePath);

            fixedSaveMode.WriteValues(array, bitWriter);
            bitWriter.Dispose();

            var createdFileLength = new FileInfo(outputFilePath).Length * 8;
            Assert.AreEqual(expectedBitsToRead, createdFileLength);
        }

        [TestMethod]
        public void TestThatWhenNumberOfBitsIs9FixedSaveModeCanReadWhatItWrote()
        {
            FixedSaveMode.NumberOfBitsForValue = 9;
            var expectedBitsToRead = GetExpectedBitsToRead(array);
            InitializeBitWriter(outputFilePath);

            fixedSaveMode.WriteValues(array, bitWriter);
            bitWriter.Dispose();

            InitializeBitReader(outputFilePath);
            var returnedArray = fixedSaveMode.ReadValues(expectedBitsToRead, bitReader);
            bitReader.Dispose();

            CollectionAssert.AreEqual(array, returnedArray);
        }

        [TestMethod]
        public void TestThatWhenNumberOfBitsIs9AndArrayHas65536ElementsFixedSaveModeCanReadWhatItWrote()
        {
            FixedSaveMode.NumberOfBitsForValue = 9;
            var longArray = GetRandom65536Array();
            var expectedBitsToRead = GetExpectedBitsToRead(longArray);
            InitializeBitWriter(outputFilePath);

            fixedSaveMode.WriteValues(longArray, bitWriter);
            bitWriter.Dispose();

            InitializeBitReader(outputFilePath);
            var returnedArray = fixedSaveMode.ReadValues(expectedBitsToRead, bitReader);
            bitReader.Dispose();

            CollectionAssert.AreEqual(longArray, returnedArray);
        }

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

        private long GetExpectedBitsToRead(int[] array)
        {
            var expectedBitsToRead = (array.Length * 9);

            if (expectedBitsToRead % 8 > 0)
                return expectedBitsToRead + (8 - expectedBitsToRead % 8);

            return expectedBitsToRead;
        }

        private int[] GetRandom65536Array()
        {
            var array = new int[256 * 256];
            var random = new Random();

            for (int i = 0; i < 256 * 256; i++)
                array[i] = random.Next(-2, 2);

            return array;
        }
    }
}
