using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.Finish
{
    public class PalletFinishRequest
    {
        public string PalletId { get; }
        public string RFID { get; }

        public PalletFinishRequest(string palletId, string rFID)
        {
            PalletId = palletId;
            RFID = rFID;
        }
    }
}
