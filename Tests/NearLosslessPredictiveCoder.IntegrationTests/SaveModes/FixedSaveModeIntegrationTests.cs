using BitReaderWriter.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.SaveModes;
using System.IO;

namespace NearLosslessPredictiveCoder.IntegrationTests.SaveModes
{
    [TestClass]
    public class FixedSaveModeIntegrationTests
    {
        private FixedSaveMode fixedSaveMode;
        private IBitReader bitReader;
        private IBitWriter bitWriter;

        private string outputFilePath = "outputFile";
        private int[] array;

        [TestInitialize]
        public void Setup()
        {
            fixedSaveMode = new FixedSaveMode(9);

            array = SaveModesTestsCommon.GetArray();
        }

        [TestMethod]
        public void TestThatWhenNumberOfBitsIs9FixedSaveModeCreatesFileOfExpectedSize()
        {
            var expectedBitsToRead = GetExpectedBitsToRead(array);
            using(bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                fixedSaveMode.WriteValues(array, bitWriter);

            var createdFileLength = new FileInfo(outputFilePath).Length * 8;
            Assert.AreEqual(expectedBitsToRead, createdFileLength);
        }

        [TestMethod]
        public void TestThatWhenNumberOfBitsIs9FixedSaveModeCanReadWhatItWrote()
        {
            var expectedBitsToRead = GetExpectedBitsToRead(array);
            using (bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                fixedSaveMode.WriteValues(array, bitWriter);

            int[] returnedArray;
            using (bitReader = SaveModesTestsCommon.GetBitReader(outputFilePath))
                returnedArray = fixedSaveMode.ReadValues(expectedBitsToRead, bitReader);
            
            CollectionAssert.AreEqual(array, returnedArray);
        }

        [TestMethod]
        public void TestThatWhenNumberOfBitsIs9AndArrayHas65536ElementsFixedSaveModeCanReadWhatItWrote()
        {
            var longArray = SaveModesTestsCommon.GetRandom65536Array();
            var expectedBitsToRead = GetExpectedBitsToRead(longArray);
            using (bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                fixedSaveMode.WriteValues(longArray, bitWriter);

            int[] returnedArray;
            using (bitReader = SaveModesTestsCommon.GetBitReader(outputFilePath))
                returnedArray = fixedSaveMode.ReadValues(expectedBitsToRead, bitReader);


            CollectionAssert.AreEqual(longArray, returnedArray);
        }

        private long GetExpectedBitsToRead(int[] array)
        {
            var expectedBitsToRead = (array.Length * fixedSaveMode.numberOfBitsForValue);

            if (expectedBitsToRead % 8 > 0)
                return expectedBitsToRead + (8 - expectedBitsToRead % 8);

            return expectedBitsToRead;
        }
    }
}
