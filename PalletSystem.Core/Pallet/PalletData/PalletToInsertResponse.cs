using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.PalletData
{
    public class PalletToInsertResponse
    {
        public string RFID { get; }
        public bool IsInserted { get; }
        public string Comment { get; }

        private PalletToInsertResponse(string rfid, bool isInserted, string comment)
        {
            RFID = rfid;
            IsInserted = isInserted;
            Comment = comment;
        }

        public static PalletToInsertResponse SuccessInsertion(string rfid) => new PalletToInsertResponse(rfid, true, "");
        public static PalletToInsertResponse FailureInsertion(string rfid, string comment) => new PalletToInsertResponse(rfid, false, comment);
    }
}
