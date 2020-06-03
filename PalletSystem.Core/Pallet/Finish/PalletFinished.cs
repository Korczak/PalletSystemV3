using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.Finish
{
    public class PalletFinished
    {
        public string PalletId { get; }
        public string RFID { get; }

        public PalletFinished(string palletId, string rFID)
        {
            PalletId = palletId;
            RFID = rFID;
        }
    }
}
