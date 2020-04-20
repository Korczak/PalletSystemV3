using Core.Pallet.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Pallet.ProgramPallet
{
    public class PalletToProgramDataAccess
    {
        public async Task<PalletToProgramInformation> GetPalletToProgramInformation(int id)
        {
            //using(var db = new PalletDB())
            //{
            //    var programs = await db.Programs.Select(x => new ProgramInformation(x.Id, x.Name, x.Description, x.NumberOfSteps)).ToListAsync();

            //    var palletInformation = await db.Pallets.Where(x => x.Id == id).Select(x => new PalletToProgramInformation(x.Id, x.RFID, programs)).FirstOrDefaultAsync();

            //    return palletInformation;
            //}
            return null;
        }

        public async Task<PalletToProgramResponse> ProgramPallet(PalletToProgramRequest request)
        {
            //using(var db = new PalletDB())
            //{
            //    try
            //    {
            //        db.BeginTransaction();

            //        var virtualPalletId = await db.InsertWithInt32IdentityAsync(new Database.Models.VirtualPallet()
            //        {
            //            ProgramId = request.ProgramId,
            //            StepId = 1,
            //            Status = PalletStatus.RUNNING,
            //            PalletId = request.PalletId
            //        });

            //        await db.Pallets
            //            .Where(x => x.Id == request.PalletId)
            //            .Set(x => x.Status, PalletStatus.RUNNING)
            //            .Set(x => x.VirtualPalletId, virtualPalletId)
            //            .UpdateAsync();

            //        db.CommitTransaction();
            //    }
            //    catch (Exception)
            //    {
            //        db.RollbackTransaction();
            //        return PalletToProgramResponse.Failure(request.PalletId, "Could not assign pallet { request.PalletId } to program {request.ProgramId}");
            //    }

            //    return PalletToProgramResponse.Success(request.PalletId);

            //}
            return null;
        }
    }
}
