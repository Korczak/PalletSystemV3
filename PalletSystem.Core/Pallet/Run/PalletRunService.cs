using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRunService
    {
        private readonly PalletRunAccess _access;

        public PalletRunService(PalletRunAccess access)
        {
            _access = access;
        }

        public async Task<PalletRunResult> RunPallet(PalletRunRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var palletSource = await _access.GetPalletSource(new ObjectId(request.PalletId));

            if (palletSource == default || palletSource.Id == default) return PalletRunResult.PalletNotExists;
            if (palletSource.Status != Constant.PalletStatus.Ready) return PalletRunResult.PalletNotReady;

            await _access.RunPallet(new PalletRun(new ObjectId(request.PalletId), new ObjectId(request.ProgramId)));
            return PalletRunResult.PalletRun;
        }
    }
}
