using PalletSystem.Core.Program.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletSaveResultRequest
    {
        public string RFID { get; }
        public int WorkspaceSlot { get; }
        public int OperationMask { get; }
        public int Status { get; }
        public IEnumerable<VirtualPalletResultItem> Results { get; }

        public VirtualPalletSaveResultRequest(string rFID, int workspaceSlot, int operationMask, int status, IEnumerable<VirtualPalletResultItem> results)
        {
            RFID = rFID;
            WorkspaceSlot = workspaceSlot;
            OperationMask = operationMask;
            Status = status;
            Results = results;
        }
    }
}
