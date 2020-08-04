using PalletSystem.Core.Pallet.StatusHub;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRunService
    {
        private readonly PalletRunAccess _access;
        private readonly PalletStatusHub _statusHub;

        public PalletRunService(PalletRunAccess access, PalletStatusHub statusHub)
        {
            _access = access;
            _statusHub = statusHub;
        }

        public async Task<PalletRunResult> RunPallet(PalletRunRequest request)
        {
            if (request == null || request.ProgramId == null || request.PalletId == null) throw new ArgumentNullException(nameof(request));

            var palletSource = await _access.GetPalletSource(request.PalletId);
            var programName = await _access.GetProgramName(request.ProgramId);
            var instrucions = await _access.GetProgramInstructions(request.ProgramId);

            if (palletSource == default || palletSource.Id == default) return PalletRunResult.PalletNotExists;
            if (palletSource.Status != Constant.PalletStatus.Ready) return PalletRunResult.PalletNotReady;
            if (programName == default) return PalletRunResult.ProgramNotExists;

            await _access.RunPallet(new PalletRun(request.PalletId, request.ProgramId, programName, instrucions));
            await _statusHub.ActualStatusUpdate(Constant.PalletStatus.Running);
            return PalletRunResult.PalletRun;
        }
    }
}