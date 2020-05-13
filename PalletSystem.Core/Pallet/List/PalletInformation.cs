

using PalletSystem.Core.Pallet.Constant;
using MongoDB.Bson;

namespace PalletSystem.Core.Pallet.List
{
    public class PalletInformation
    {
        public string RFID { get; }
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public PalletStatus PalletStatus { get; }

        public PalletInformation(string rFID, PalletStatus palletStatus)
        {
            RFID = rFID;
            PalletStatus = palletStatus;
        }

        public PalletInformation(string rFID, string programName, int stepsDone, int stepsTotal, PalletStatus palletStatus)
        {
            RFID = rFID;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            PalletStatus = palletStatus;
        }
    }
}
