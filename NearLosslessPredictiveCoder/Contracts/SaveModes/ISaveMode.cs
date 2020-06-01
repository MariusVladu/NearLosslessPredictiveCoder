using NearLosslessPredictiveCoder.Entities;

namespace NearLosslessPredictiveCoder.Contracts.SaveModes
{
    public interface ISaveMode
    {
        void SaveToFile(EncodedImage encodedImage, string originalImagePath);
        EncodedImage ReadFromFile(string filePath);
    }
}
