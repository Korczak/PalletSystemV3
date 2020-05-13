using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.PalletData
{
    public class PalletToInsertRequest
    {
        public string RFID { get; }

        public PalletToInsertRequest(string rfid)
        {
            RFID = rfid;
        }
    }
}
