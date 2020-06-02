using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.Predictors;
using NearLosslessPredictiveCoder.SaveModes;
using System.IO;

namespace NearLosslessPredictiveCoder.FileOperations
{
    public class EncodedImageReader : BaseFileOperation
    {
        protected long bitsToRead;

        public EncodedImage ReadEncodedImage(string encodedImageFilePath, SaveMode saveMode)
        {
            bitsToRead = (new FileInfo(encodedImageFilePath).Length - 1078) * 8;

            InitializeBitReader(encodedImageFilePath);

            ImageHeaderHandler.SkipHeaderFromImage(bitReader);

            return new EncodedImage
            {
                PredictorSettings = ReadPredictorSettings(),
                QuantizedErrorPredictionMatrix = ReadMatrix(saveMode)
            };
        }

        public PredictorSettings ReadPredictorSettings()
        {
            var predictorSettings = new PredictorSettings();

            predictorSettings.Predictor = PredictorFactory.GetPredictor((Predictor)bitReader.ReadNBits(4));
            predictorSettings.AcceptedError = (int)bitReader.ReadNBits(4);
            bitReader.ReadNBits(8);

            bitsToRead -= 4 + 4 + 8;

            return predictorSettings;
        }

        public int[,] ReadMatrix(SaveMode saveModeType)
        {
            var saveMode = SaveModeFactory.GetSaveMode(saveModeType);

            var readValuesFromFile = saveMode.ReadValues(bitsToRead, bitReader);

            return MatrixOperations.UnidimensionalArrayToSquareMatrix(readValuesFromFile);
        }
    }
}
