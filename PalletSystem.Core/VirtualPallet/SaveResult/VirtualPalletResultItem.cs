namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletResultItem
    {
        public int Id { get; }
        public float Value { get; }
        public int Status { get; }

        public VirtualPalletResultItem(int id, float value, int status)
        {
            Id = id;
            Value = value;
            Status = status;
        }
    }
}