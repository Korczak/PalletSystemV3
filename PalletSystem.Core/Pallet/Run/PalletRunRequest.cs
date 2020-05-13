using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRunRequest
    {
        public string PalletId { get; }
        public string ProgramId { get; }

        public PalletRunRequest(string palletId, string programId)
        {
            PalletId = palletId;
            ProgramId = programId;
        }
    }
}
