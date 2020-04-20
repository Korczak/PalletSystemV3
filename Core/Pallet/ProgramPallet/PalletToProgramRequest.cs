using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Pallet.ProgramPallet
{
    public class PalletToProgramRequest
    {
        public int PalletId { get; }
        public int ProgramId { get; }

        public PalletToProgramRequest(int palletId, int programId)
        {
            PalletId = palletId;
            ProgramId = programId;
        }
    }
}
