using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Threading.Tasks;

namespace PalletSystem.Core.SteeringLogic.SaveResult
{
    public class SteeringLogicSaveResultAccess
    {
        public async Task<SteeringLogicSaveResultSourceData> GetSourceData(string RFID)
        {
            using (var handler = new DatabaseHandler())
            {
                var programQuery = from pallet in handler.db.Pallets.AsQueryable()
                                   where pallet.RFID == RFID
                                   join virtualPallet in handler.db.VirtualPallets.AsQueryable() on pallet.Id equals virtualPallet.PalletId
                                   where virtualPallet.IsActive == true
                                   select new { virtualPallet.Program.ActiveStep, virtualPallet.Status, Instructions = virtualPallet.Program.ProgramStepsInstructions };

                return null;
            }
        }
    }
}