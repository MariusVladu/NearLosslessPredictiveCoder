using BitReaderWriter.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.SaveModes;

namespace NearLosslessPredictiveCoder.IntegrationTests.SaveModes
{
    [TestClass]
    public class TableSaveModeIntegrationTests
    {
        private TableSaveMode tableSaveMode;
        private IBitReader bitReader;
        private IBitWriter bitWriter;

        private string outputFilePath = "outputFile";
        private int[] array;

        [TestInitialize]
        public void Setup()
        {
            tableSaveMode = new TableSaveMode();

            array = SaveModesTestsCommon.GetArray();
        }

        [TestMethod]
        public void TestThatTableSaveModeCandReadWhatItWrote()
        {
            using (bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                tableSaveMode.WriteValues(array, bitWriter);

            int[] returnedArray;
            using (bitReader = SaveModesTestsCommon.GetBitReader(outputFilePath))
                returnedArray = tableSaveMode.ReadValues(123, bitReader);

            CollectionAssert.AreEqual(array, returnedArray);
        }

        [TestMethod]
        public void TestThatWhenArrayHas65536ElementsTableSaveModeCandReadWhatItWrote()
        {
            var longArray = SaveModesTestsCommon.GetRandom65536Array();
            using (bitWriter = SaveModesTestsCommon.GetBitWriter(outputFilePath))
                tableSaveMode.WriteValues(longArray, bitWriter);

            int[] returnedArray;
            using (bitReader = SaveModesTestsCommon.GetBitReader(outputFilePath))
                returnedArray = tableSaveMode.ReadValues(123, bitReader);

            CollectionAssert.AreEqual(longArray, returnedArray);
        }
    }
}
