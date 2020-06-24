namespace PalletSystem.Core.SteeringLogic.SaveResult
{
    public class SteeringLogicResultItem
    {
        public float Value { get; }
        public int Status { get; }

        public SteeringLogicResultItem(float value, int status)
        {
            Value = value;
            Status = status;
        }
    }
}