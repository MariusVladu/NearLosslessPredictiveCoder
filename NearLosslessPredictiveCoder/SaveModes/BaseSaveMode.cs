using BitReaderWriter;
using BitReaderWriter.Contracts;
using NearLosslessPredictiveCoder.Contracts.SaveModes;
using NearLosslessPredictiveCoder.Entities;
using NearLosslessPredictiveCoder.Predictors;
using System;
using System.IO;

namespace NearLosslessPredictiveCoder.SaveModes
{
    public abstract class BaseSaveMode : ISaveMode, IDisposable
    {
        protected IBitReader bitReader;
        protected IBitWriter bitWriter;
        protected long bitsToRead;

        protected abstract char SaveModeCode { get; }
        protected abstract int[] ReadValues();
        protected abstract void WriteValues(int[] values);

        public EncodedImage ReadFromFile(string filePath)
        {
            InitializeBitReader(filePath);

            SkipHeaderFromImage();

            return new EncodedImage
            {
                PredictorSettings = ReadPredictorSettings(),
                QuantizedErrorPredictionMatrix = ReadMatrix()
            };
        }

        public void SaveToFile(EncodedImage encodedImage, string originalImagePath)
        {
            InitializeBitWriter(GetOutputPath(originalImagePath, encodedImage.PredictorSettings));

            WriteHeaderFromOriginalImage(originalImagePath);

            WritePredictorSettings(encodedImage.PredictorSettings);

            WriteMatrix(encodedImage.QuantizedErrorPredictionMatrix);
        }

        public void WriteHeaderFromOriginalImage(string originalFilePath)
        {
            InitializeBitReader(originalFilePath);

            for (int i = 0; i < 1078; i++)
            {
                bitWriter.WriteNBits(8, bitReader.ReadNBits(8));
            }
        }

        public void SkipHeaderFromImage()
        {
            for (int i = 0; i < 1078; i++)
            {
                bitReader.ReadNBits(8);
            }
        }

        public void WritePredictorSettings(PredictorSettings predictorSettings)
        {
            bitWriter.WriteNBits(4, (uint)predictorSettings.Predictor.Code);
            bitWriter.WriteNBits(4, (uint)predictorSettings.AcceptedError);
            bitWriter.WriteNBits(8, SaveModeCode);
        }

        public PredictorSettings ReadPredictorSettings()
        {
            var predictorSettings = new PredictorSettings();

            predictorSettings.Predictor = PredictorFactory.GetPredictorByCode((int)bitReader.ReadNBits(4));
            predictorSettings.AcceptedError = (int)bitReader.ReadNBits(4);
            bitReader.ReadNBits(8);

            bitsToRead -= 4 + 4 + 8;

            return predictorSettings;
        }

        public void WriteMatrix(int[,] matrix)
        {
            var valuesToWrite = MatrixOperations.MatrixToUnidimensionalArray(matrix);

            WriteValues(valuesToWrite);
        }

        public int[,] ReadMatrix()
        {
            var readValuesFromFile = ReadValues();

            return MatrixOperations.UnidimensionalArrayToSquareMatrix(readValuesFromFile);
        }

        public string GetOutputPath(string originalImagePath, PredictorSettings predictorSettings)
        {
            return $"{originalImagePath}.{GetEncodedFileExtension(predictorSettings)}";
        }

        public string GetEncodedFileExtension(PredictorSettings predictorSettings)
        {
            return $"k{predictorSettings.AcceptedError}p{predictorSettings.Predictor.Code}{SaveModeCode}.nlp";
        }

        public void InitializeBitReader(string filePath)
        {
            bitsToRead = (new FileInfo(filePath).Length - 1078) * 8;

            var inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            bitReader = new BitReader(inputFileStream);
        }

        public void InitializeBitWriter(string filePath)
        {
            var outputFileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            bitWriter = new BitWriter(outputFileStream);
        }

        public void Dispose()
        {
            if (bitReader != null)
                bitReader.Dispose();

            if (bitWriter != null)
                bitWriter.Dispose();
        }
    }
}
