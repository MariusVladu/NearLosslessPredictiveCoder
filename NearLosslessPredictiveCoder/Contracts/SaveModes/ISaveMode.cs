using BitReaderWriter.Contracts;

namespace NearLosslessPredictiveCoder.Contracts.SaveModes
{
    public interface ISaveMode
    {
        void WriteValues(int[] values, IBitWriter bitWriter);
        int[] ReadValues(long bitsToRead, IBitReader bitReader);
    }
}
