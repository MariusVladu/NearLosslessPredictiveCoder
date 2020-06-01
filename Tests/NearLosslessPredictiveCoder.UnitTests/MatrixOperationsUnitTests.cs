using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.UnitTests
{
    [TestClass]
    public class MatrixOperationsUnitTests
    {
        private int[,] squareMatrix = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };

        private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        [TestMethod]
        public void TestThatMatrixToUnidimensionalArrayReturnsExpectedArray()
        {
            var result = MatrixOperations.MatrixToUnidimensionalArray(squareMatrix);

            CollectionAssert.AreEqual(new List<int>(array), new List<int>(result));
        }

        [TestMethod]
        public void TestThatUnidimensionalArrayToSquareMatrixReturnsSquareMatrixOfExpectedSize()
        {
            var result = MatrixOperations.UnidimensionalArrayToSquareMatrix(array);

            Assert.AreEqual(3, result.GetLength(0));
            Assert.AreEqual(3, result.GetLength(1));
        }

        [TestMethod]
        public void TestThatUnidimensionalArrayToSquareMatrixReturnsExpectedMatrix()
        {
            var result = MatrixOperations.UnidimensionalArrayToSquareMatrix(array);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(squareMatrix[i, j], result[i, j]);
                }
            }
        }
    }
}
