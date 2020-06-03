using NearLosslessPredictiveCoder.Mappers;
using System.Drawing;

namespace NearLosslessPredictiveCoder.FileOperations
{
    public class ImageWriter : BaseFileOperation
    {
        public void SaveImage(Bitmap image, string headerFilePath, string outputPath)
        {
            InitializeBitWriter(outputPath);

            ImageHeaderHandler.CopyHeaderFromFile(headerFilePath, bitWriter);

            var pixelMatrix = ImageMapper.GetPixelMatrixFromImage(image);

            WritePixelMatrix(pixelMatrix);
        }

        private void WritePixelMatrix(int[,] pixelMatrix)
        {
            var height = pixelMatrix.GetLength(0);
            var width = pixelMatrix.GetLength(1);

            for (int i = height - 1; i >= 0; i--)
                for (int j = 0; j < width; j++)
                    bitWriter.WriteNBits(8, (uint)pixelMatrix[j, i]);
        }
    }
}
