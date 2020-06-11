using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.Predictors;
using NearLosslessPredictiveCoder.SaveModes;
using System;
using System.IO;

namespace NearLosslessPredictiveCoder.FileOperations
{
    public class EncodedImageReader : BaseFileOperation
    {
        protected long bitsToRead;

        public EncodedImage ReadEncodedImage(string encodedImageFilePath)
        {
            bitsToRead = (new FileInfo(encodedImageFilePath).Length - 1078) * 8;

            InitializeBitReader(encodedImageFilePath);

            ImageHeaderHandler.SkipHeaderFromImage(bitReader);

            var predictorSettings = ReadPredictorSettings();
            var readSaveMode = (SaveMode)Enum.GetValues(typeof(SaveMode)).GetValue(bitReader.ReadNBits(3));

            bitsToRead -= 4 + 4 + 3;

            return new EncodedImage
            {
                PredictorSettings = predictorSettings,
                QuantizedErrorPredictionMatrix = ReadMatrix(readSaveMode)
            };
        }

        public PredictorSettings ReadPredictorSettings()
        {
            return new PredictorSettings
            {
                Predictor = PredictorFactory.GetPredictor((Predictor)bitReader.ReadNBits(4)),
                AcceptedError = (int)bitReader.ReadNBits(4)
            };
        }

        public int[,] ReadMatrix(SaveMode saveModeType)
        {
            var saveMode = SaveModeFactory.GetSaveMode(saveModeType);

            var readValuesFromFile = saveMode.ReadValues(bitsToRead, bitReader);

            return MatrixOperations.UnidimensionalArrayToSquareMatrix(readValuesFromFile);
        }
    }
}
