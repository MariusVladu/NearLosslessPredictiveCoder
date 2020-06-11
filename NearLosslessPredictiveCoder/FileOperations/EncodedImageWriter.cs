using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.SaveModes;
using System;
using System.Collections.Generic;

namespace NearLosslessPredictiveCoder.FileOperations
{
    public class EncodedImageWriter : BaseFileOperation
    {
        public void SaveToFile(EncodedImage encodedImage, string originalImagePath, SaveMode saveMode)
        {
            InitializeBitWriter(GetOutputPath(originalImagePath, encodedImage.PredictorSettings, saveMode));

            ImageHeaderHandler.CopyHeaderFromFile(originalImagePath, bitWriter);

            WritePredictorSettings(encodedImage.PredictorSettings, saveMode);

            WriteMatrix(encodedImage.QuantizedErrorPredictionMatrix, saveMode);
        }

        public void WritePredictorSettings(PredictorSettings predictorSettings, SaveMode saveMode)
        {
            bitWriter.WriteNBits(4, (uint)predictorSettings.Predictor.Code);
            bitWriter.WriteNBits(4, (uint)predictorSettings.AcceptedError);
            bitWriter.WriteNBits(2, (uint)Array.IndexOf(Enum.GetValues(typeof(SaveMode)), saveMode));
        }

        public void WriteMatrix(int[,] matrix, SaveMode saveModeType)
        {
            var valuesToWrite = MatrixOperations.MatrixToUnidimensionalArray(matrix);
            var saveMode = SaveModeFactory.GetSaveMode(saveModeType);

            saveMode.WriteValues(valuesToWrite, bitWriter);
        }

        public string GetOutputPath(string originalImagePath, PredictorSettings predictorSettings, SaveMode saveMode)
        {
            return $"{originalImagePath}.{GetEncodedFileExtension(predictorSettings, saveMode)}";
        }

        public string GetEncodedFileExtension(PredictorSettings predictorSettings, SaveMode saveMode)
        {
            return $"k{predictorSettings.AcceptedError}p{predictorSettings.Predictor.Code}{(char)saveMode}.nlp";
        }
    }
}
