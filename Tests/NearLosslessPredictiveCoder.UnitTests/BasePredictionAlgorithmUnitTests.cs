using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NearLosslessPredictiveCoder.Contracts.Predictors;
using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.PredictionAlgorithms;

namespace NearLosslessPredictiveCoder.UnitTests
{
    [TestClass]
    public class BasePredictionAlgorithmUnitTests
    {
        private BasePredictionAlgorithm basePredictionAlgorithm;
        private Mock<IPredictor> predictorMock;
        private Mock<IPredictor> firstRowPredictorMock;
        private Mock<IPredictor> firstColumnPredictorMock;

        private int acceptedError = 2;
        private int range = 16;

        private int[,] matrix = new int[,]
        {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
        };

        [TestInitialize]
        public void Setup()
        {
            predictorMock = new Mock<IPredictor>();
            firstRowPredictorMock = new Mock<IPredictor>();
            firstColumnPredictorMock = new Mock<IPredictor>();

            var predictorSettings = new PredictorSettings
            {
                Predictor = predictorMock.Object,
                AcceptedError = acceptedError,
                Range = range
            };

            basePredictionAlgorithm = new BasePredictionAlgorithm(predictorSettings)
            {
                firstRowPredictor = firstRowPredictorMock.Object,
                firstColumnPredictor = firstColumnPredictorMock.Object
            };
        }

        [TestMethod]
        public void TestThatWhenPredictorIsHalfRangeInitializePredictorsSetsFirstRowAndColumnPredictorsToBeTheSame()
        {
            basePredictionAlgorithm.predictorSettings.Predictor = new Predictors.HalfRange(range);

            basePredictionAlgorithm.InitializePredictors();

            Assert.AreEqual(basePredictionAlgorithm.predictor, basePredictionAlgorithm.firstRowPredictor);
            Assert.AreEqual(basePredictionAlgorithm.predictor, basePredictionAlgorithm.firstColumnPredictor);
        }

        [TestMethod]
        public void TestThatWhenPredictorIsNotHalfRangeInitializePredictorsSetsFirstRowPredictorIsPredictorA()
        {
            basePredictionAlgorithm.predictorSettings.Predictor = new Predictors.Predictor4();

            basePredictionAlgorithm.InitializePredictors();

            Assert.AreEqual(typeof(Predictors.A), basePredictionAlgorithm.firstRowPredictor.GetType());
        }

        [TestMethod]
        public void TestThatWhenPredictorIsNotHalfRangeInitializePredictorsSetsFirstColumnPredictorIsPredictorB()
        {
            basePredictionAlgorithm.predictorSettings.Predictor = new Predictors.Predictor4();

            basePredictionAlgorithm.InitializePredictors();

            Assert.AreEqual(typeof(Predictors.B), basePredictionAlgorithm.firstColumnPredictor.GetType());
        }

        [TestMethod]
        public void TestThatWhenOnFirstCellGetPredictionReturnsHalfRange()
        {
            var result = basePredictionAlgorithm.GetPrediction(0, 0, matrix);

            Assert.AreEqual(range/2, result);
        }

        [TestMethod]
        public void TestThatWhenOnFirstRowGetPredictionCallsFirstRowPredictorPredictOnce()
        {
            basePredictionAlgorithm.GetPrediction(0, 2, matrix);

            firstRowPredictorMock.Verify(x => x.Predict(matrix[0, 1], It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void TestThatWhenOnFirstColumnGetPredictionCallsFirstColumnPredictorPredictOnce()
        {
            basePredictionAlgorithm.GetPrediction(2, 0, matrix);

            firstColumnPredictorMock.Verify(x => x.Predict(It.IsAny<int>(), matrix[1, 0], It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void TestThatGetPredictionCallsPredictorPredictOnce()
        {
            basePredictionAlgorithm.GetPrediction(1, 2, matrix);

            predictorMock.Verify(x => x.Predict(matrix[1, 1], matrix[0, 2], matrix[0, 1]), Times.Once);
        }

        [TestMethod]
        public void TestThatWhenValueIsLowerThan0NormalizeValueReturns0()
        {
            var result = basePredictionAlgorithm.NormalizeValue(-1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestThatWhenValueIsGreaterThanMaxValueInRangeNormalizeValueReturnsMaxValue()
        {
            var result = basePredictionAlgorithm.NormalizeValue(range + 1);

            Assert.AreEqual(range - 1, result);
        }

        [TestMethod]
        public void TestThatWhenValueIsInRangeNormalizeValueReturnsValue()
        {
            var value = range / 2;

            var result = basePredictionAlgorithm.NormalizeValue(value);

            Assert.AreEqual(value, result);
        }
    }
}
