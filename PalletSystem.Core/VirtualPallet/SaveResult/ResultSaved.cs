using NodaTime;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Program.Constant;
using PalletSystem.Core.VirtualPallet.Constants;
using System.Collections.Generic;

namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class ResultSaved
    {
        public string VirtualPalletId { get; }
        public Instant Instant { get; }
        public int ActualStep { get; }
        public int WorkspaceSlot { get; }
        public int OperationMask { get; }
        public ProgramStatus ProgramStatus { get; }
        public VirtualPalletStatus VirtualPalletStatus { get; }
        public IEnumerable<ProgramStepResultItem> Results { get; }

        public ResultSaved(
            string virtualPalletId,
            Instant instant,
            int actualStep,
            int workspaceSlot,
            int operationMask,
            ProgramStatus programStatus,
            VirtualPalletStatus virtualPalletStatus,
            IEnumerable<ProgramStepResultItem> results)
        {
            VirtualPalletId = virtualPalletId;
            Instant = instant;
            ActualStep = actualStep;
            WorkspaceSlot = workspaceSlot;
            OperationMask = operationMask;
            ProgramStatus = programStatus;
            VirtualPalletStatus = virtualPalletStatus;
            Results = results;
        }
    }
}