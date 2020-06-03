using BitReaderWriter.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.SaveModes;
using System.IO;

namespace NearLosslessPredictiveCoder.IntegrationTests.SaveModes
{
    [TestClass]
    public class ArithmeticSaveModeIntegrationTests
    {
        private ArithmeticSaveMode arithmeticSaveMode;
        private IBitReader bitReader;
        private IBitWriter bitWriter;

        private string outputFilePath = "outputFile";
        private int[] array;

        [TestInitialize]
        public void Setup()
        {
            arithmeticSaveMode = new ArithmeticSaveMode();

            array = SaveModesTestsCommon.GetArray();
        }

        [TestMethod]
        public void TestThatArithmeticSaveModeCandReadWhatItWrote()
        {
            using (bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                arithmeticSaveMode.WriteValues(array, bitWriter);
            var bitsToRead = new FileInfo(outputFilePath).Length * 8;

            int[] returnedArray;
            using (bitReader = SaveModesTestsCommon.GetBitReader(outputFilePath))
                returnedArray = arithmeticSaveMode.ReadValues(bitsToRead, bitReader);

            CollectionAssert.AreEqual(array, returnedArray);
        }

        [TestMethod]
        public void TestThatWhenArrayHas65536ElementsArithmeticSaveModeCandReadWhatItWrote()
        {
            var longArray = SaveModesTestsCommon.GetRandom65536Array();
            using (bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                arithmeticSaveMode.WriteValues(longArray, bitWriter);
            var bitsToRead = new FileInfo(outputFilePath).Length * 8;

            int[] returnedArray;
            using (bitReader = SaveModesTestsCommon.GetBitReader(outputFilePath))
                returnedArray = arithmeticSaveMode.ReadValues(bitsToRead, bitReader);

            CollectionAssert.AreEqual(longArray, returnedArray);
        }
    }
}
