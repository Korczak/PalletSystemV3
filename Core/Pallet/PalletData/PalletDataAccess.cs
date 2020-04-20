using Core.Database.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using Core.Pallet.Common;

namespace Core.Pallets.PalletData
{
    public class PalletDataAccess
    {
        public async Task<PalletToInsertResponse> InsertPallet(PalletToInsertRequest request)
        {
            //using(var db = new PalletDB())
            //{
            //    try
            //    {
            //        db.BeginTransaction();

            //        await db.InsertWithInt32IdentityAsync(new Database.Models.Pallet()
            //        {
            //            RFID = request.RFID,
            //            Status = PalletStatus.READY
            //        });

            //        db.CommitTransaction();
            //    }
            //    catch (PostgresException e)
            //    {
            //        var message = new StringBuilder($"Could not insert pallet with RFID { request.RFID }");
            //        if(e.SqlState == PostgresErrorCodes.UniqueViolation)
            //        {
            //            message.Append(", cause pallet with this RFID already exists");
            //        }
            //        db.RollbackTransaction();
            //        return PalletToInsertResponse.FailureInsertion(request.RFID, message.ToString());
            //    }
            //    catch (Exception)
            //    {
            //        db.RollbackTransaction();
            //        return PalletToInsertResponse.FailureInsertion(request.RFID, "Could not insert this pallet");
            //    }

            //    return PalletToInsertResponse.SuccessInsertion(request.RFID);
            //}
            return null;
        } 
    }
}
