using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.Add
{
    public class PalletAddRequest
    {
        public string RFID { get; }

        public PalletAddRequest(string rFID)
        {
            RFID = rFID;
        }
    }
}
