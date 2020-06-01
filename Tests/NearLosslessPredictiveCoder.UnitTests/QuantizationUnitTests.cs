using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.Contracts;

namespace NearLosslessPredictiveCoder.UnitTests
{
    [TestClass]
    public class QuantizationUnitTests
    {
        private IQuantization quantization;

        private int acceptedError = 2;
        private int[,] originalMatrix = new int[,]
        {
            { -1, -3, -1, -3 },
            { -6, 11, -9, 0 },
            { 12, 0, 10, -15 },
            { -12, -1, 9, 14 },
        };

        private int[,] quantizedMatrix = new int[,]
        {
            { 0, -1, 0, -1 },
            { -1, 2, -2, 0 },
            { 2, 0, 2, -3 },
            { -2, 0, 2, 3 },
        };

        private int[,] dequantizedMatrixFromQuantized = new int[,]
        {
            { 0, -5, 0, -5 },
            { -5, 10, -10, 0 },
            { 10, 0, 10, -15 },
            { -10, 0, 10, 15 },
        };

        [TestInitialize]
        public void Setup()
        {
            quantization = new Quantization();
        }

        [TestMethod]
        public void TestThatQuantizeReturnsExpectedQuantizedMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var expectedQuantizedValue = quantizedMatrix[i, j];
                    var calculatedQuantizedValue = quantization.Quantize(originalMatrix[i, j], acceptedError);

                    Assert.AreEqual(expectedQuantizedValue, calculatedQuantizedValue);
                }
            }
        }

        [TestMethod]
        public void TestThatDequantizeReturnsExpectedQuantizedMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var expectedDequantizedValue = dequantizedMatrixFromQuantized[i, j];
                    var calculatedDequantizedValue = quantization.Dequantize(quantizedMatrix[i, j], acceptedError);

                    Assert.AreEqual(expectedDequantizedValue, calculatedDequantizedValue);
                }
            }
        }
    }
}
