using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Pallets.PalletData
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
