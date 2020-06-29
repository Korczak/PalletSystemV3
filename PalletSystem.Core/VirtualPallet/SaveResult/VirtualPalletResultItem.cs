namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletResultItem
    {
        public float Value { get; }
        public int Status { get; }

        public VirtualPalletResultItem(float value, int status)
        {
            Value = value;
            Status = status;
        }
    }
}