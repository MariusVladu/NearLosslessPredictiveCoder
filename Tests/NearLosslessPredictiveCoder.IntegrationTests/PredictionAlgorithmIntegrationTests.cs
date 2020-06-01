using Microsoft.VisualStudio.TestTools.UnitTesting;
using NearLosslessPredictiveCoder.Contracts.Predictors;
using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.PredictionAlgorithms;

namespace NearLosslessPredictiveCoder.IntegrationTests
{
    [TestClass]
    public class PredictionAlgorithmIntegrationTests
    {
        private PredictionAlgorithm predictionAlgorithm;

        private int range = 16;
        private int acceptedError = 2;
        private IPredictor predictor = new Predictors.Predictor4();

        private int[,] originalMatrix = new int[,]
        {
            { 7, 5, 2, 0 },
            { 2, 11, 1, 0 },
            { 15, 15, 15, 0 },
            { 1, 4, 14, 14 },
        };

        private int[,] predictedMatrix = new int[,]
        {
            { 8, 8, 3, 3 },
            { 8, 0, 10, 0 },
            { 3, 15, 5, 15 },
            { 13, 5, 5, 0 },
        };

        private int[,] errorPredictionMatrix = new int[,]
        {
            { -1, -3, -1, -3 },
            { -6, 11, -9, 0 },
            { 12, 0, 10, -15 },
            { -12, -1, 9, 14 },
        };

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

            predictionAlgorithm = new PredictionAlgorithm(originalMatrix, predictorSettings);
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedPredictionMatrix()
        {
            predictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(predictedMatrix[i, j], predictionAlgorithm.prediction[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedErrorPredictionMatrix()
        {
            predictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(errorPredictionMatrix[i, j], predictionAlgorithm.errorPrediction[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedQuantizedErrorPredictionMatrix()
        {
            predictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(quantizedErrorPredictionMatrix[i, j], predictionAlgorithm.quantizedErrorPrediction[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedDequantizedQuantizedErrorPredictionMatrix()
        {
            predictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(dequantizedQuantizedErrorPredictionMatrix[i, j], predictionAlgorithm.dequantizedQuantizedErrorPrediction[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedPredictionFromDecodedMatrix()
        {
            predictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(predictionFromDecodedMatrix[i, j], predictionAlgorithm.predictionFromDecoded[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestThatEncoderCalculateMatricesCalculatesExpectedDecodedMatrix()
        {
            predictionAlgorithm.CalculateMatrices();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(decodedMatrix[i, j], predictionAlgorithm.decoded[i, j]);
                }
            }
        }
    }
}
