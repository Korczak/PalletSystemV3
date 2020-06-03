

using PalletSystem.Core.Pallet.Constant;
using MongoDB.Bson;

namespace PalletSystem.Core.Pallet.List
{
    public class PalletInformation
    {
        public string Id { get; }
        public string RFID { get; }
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public PalletStatus PalletStatus { get; }

        public PalletInformation(string id, string rFID, PalletStatus palletStatus)
        {
            Id = id;
            RFID = rFID;
            PalletStatus = palletStatus;
        }

        public PalletInformation(string id, string rFID, string programName, int stepsDone, int stepsTotal, PalletStatus palletStatus)
        {
            Id = id;
            RFID = rFID;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            PalletStatus = palletStatus;
        }
    }
}
