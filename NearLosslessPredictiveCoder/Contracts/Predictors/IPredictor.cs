namespace NearLosslessPredictiveCoder.Contracts.Predictors
{
    public interface IPredictor
    {
        int Predict(int a, int b, int c);
        string GetDescription();
    }
}
