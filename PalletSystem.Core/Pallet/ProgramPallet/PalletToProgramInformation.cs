using PalletSystem.Core.Program.List;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.ProgramPallet
{
    public class PalletToProgramInformation
    {
        public int PalletId { get; }
        public string PalletRFID { get; }
        public IEnumerable<ProgramInformation> Programs { get; }

        public PalletToProgramInformation(int palletId, string palletRFID, IEnumerable<ProgramInformation> programs)
        {
            PalletId = palletId;
            PalletRFID = palletRFID;
            Programs = programs;
        }
    }
}
