using System;

namespace NearLosslessPredictiveCoder
{
    public static class MatrixOperations
    {

        public static int[] MatrixToUnidimensionalArray(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var array = new int[rows * columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i * rows + j] = matrix[i, j];
                }
            }

            return array;
        }

        public static int[,] UnidimensionalArrayToSquareMatrix(int[] array)
        {
            var matrixSize = (int)Math.Sqrt(array.Length);
            var matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = array[i * matrixSize + j];
                }
            }

            return matrix;
        }
    }
}
