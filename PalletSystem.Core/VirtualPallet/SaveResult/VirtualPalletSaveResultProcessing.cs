﻿using NodaTime;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Pallet.Constant;
using PalletSystem.Core.Program.Constant;
using PalletSystem.Core.VirtualPallet.Constants;
using System.Linq;

namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletSaveResultProcessing
    {
        public ResultSaved Saved { get; }

        public VirtualPalletSaveResultProcessing(VirtualPalletSaveResultSource source, VirtualPalletSaveResultRequest request, IClock clock)
        {
            var programStatus = ProgramStatus.Running;
            var palletStatus = VirtualPalletStatus.Running;
            if (source.ActualStep >= source.MaximumNumberOfSteps)
            {
                programStatus = ProgramStatus.Done;
                palletStatus = VirtualPalletStatus.Done;
            }
            foreach (var result in request.Results)
            {
                if (result.Status != 0)
                {
                    programStatus = ProgramStatus.Error;
                    palletStatus = VirtualPalletStatus.Error;
                }
            }

            var currentInstant = clock.GetCurrentInstant();

            var results = request.Results.Select(r => new ProgramStepResultItem() { Status = r.Status, Value = r.Value }).ToList();

            Saved = new ResultSaved(source.Id, currentInstant, source.ActualStep, request.WorkspaceSlot, request.OperationMask, programStatus, palletStatus, results);
        }
    }
}