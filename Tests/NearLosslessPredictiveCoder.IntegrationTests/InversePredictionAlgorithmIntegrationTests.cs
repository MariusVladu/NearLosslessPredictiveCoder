using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.Contracts.Predictors;
using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.PredictionAlgorithms;

namespace NearLosslessPredictiveCoder.IntegrationTests
{
    [TestClass]
    public class InversePredictionAlgorithmIntegrationTests
    {
        private InversePredictionAlgorithm inversePredictionAlgorithm;

        private int range = 16;
        private int acceptedError = 2;
        private IPredictor predictor = new Predictors.Predictor4();

        private int[,] quantizedErrorPredictionMatrix = new int[,]
        {
            { 0, -1, 0, -1 },
            { -1, 2, -2, 0 },
            { 2, 0, 2, -3 },
            { -2, 0, 2, 3 },
        };

        private int[,] dequantizedQuantizedErrorPredictionMatrix = new int[,]
        {
            { 0, -5, 0, -5 },
            { -5, 10, -10, 0 },
            { 10, 0, 10, -15 },
            { -10, 0, 10, 15 },
        };

        private int[,] predictionFromDecodedMatrix = new int[,]
        {
            { 8, 8, 3, 3 },
            { 8, 0, 10, 0 },
            { 3, 15, 5, 15 },
            { 13, 5, 5, 0 },
        };

        private int[,] decodedMatrix = new int[,]
        {
            { 8, 3, 3, 0 },
            { 3, 10, 0, 0 },
            { 13, 15, 15, 0 },
            { 3, 5, 15, 15 },
        };

        [TestInitialize]
        public void Setup()
        {
            var predictorSettings = new PredictorSettings
            {
                Predictor = predictor,
                AcceptedError = acceptedError,
                Range = range
            };

            var encodedImage = new EncodedImage
            {
                PredictorSettings = predictorSettings,
                QuantizedErrorPredictionMatrix = quantizedErrorPredictionMatrix
            };

            inversePredictionAlgorithm = new InversePredictionAlgorithm(encodedImage);
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedQuantizedErrorPredictionMatrix()
        {
            inversePredictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(quantizedErrorPredictionMatrix[i, j], inversePredictionAlgorithm.quantizedErrorPrediction[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedDequantizedQuantizedErrorPredictionMatrix()
        {
            inversePredictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(dequantizedQuantizedErrorPredictionMatrix[i, j], inversePredictionAlgorithm.dequantizedQuantizedErrorPrediction[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedPredictionFromDecodedMatrix()
        {
            inversePredictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(predictionFromDecodedMatrix[i, j], inversePredictionAlgorithm.predictionFromDecoded[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedDecodedMatrix()
        {
            inversePredictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(decodedMatrix[i, j], inversePredictionAlgorithm.decoded[i, j]);
                }
            }
        }
    }
}
