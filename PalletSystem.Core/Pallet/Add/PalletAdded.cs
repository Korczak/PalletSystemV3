namespace PalletSystem.Core.Pallet.Add
{
    public class PalletAdded
    {
        public string RFID { get; }

        public PalletAdded(string rFID)
        {
            RFID = rFID;
        }
    }
}