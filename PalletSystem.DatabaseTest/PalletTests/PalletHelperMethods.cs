using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.Database.Models.Pallet;
using PalletSystem.Core.Database.Models.ProgramScheme;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Database.Settings;
using PalletSystem.Core.Pallet.Constant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalletSystem.DatabaseTest.PalletTests
{
    public static class PalletHelperMethods
    {
        public async static Task<string> InsertPallet(PalletStatus status = PalletStatus.Ready, string rfid = "123")
        {
            using(var handler = new DatabaseHandler())
            {
                var id = ObjectIdGenerator.Instance.GenerateId(handler.db.Pallets, new Pallets()).ToString();
                var palletToInsert = new Pallets()
                {
                    Id = id,
                    RFID = rfid,
                    Status = status
                };
                await handler.db.Pallets.InsertOneAsync(palletToInsert);
                return id;
            }
        }
        public async static Task<string> InsertProgram()
        {
            using (var handler = new DatabaseHandler())
            {
                var steps = new List<ProgramStepsInstructions>()
                {
                    new ProgramStepsInstructions()
                    {
                        OperationMask = 111,
                        Step = 1,
                        Parameter1 = "1.2"
                    },
                    new ProgramStepsInstructions()
                    {
                        OperationMask = 111,
                        Step = 2,
                        Parameter1 = "1.2"
                    }
                }; 
                var id = ObjectIdGenerator.Instance.GenerateId(handler.db.ProgramSchemes, new ProgramSchemes()).ToString();
                var programToInsert = new ProgramSchemes()
                {
                    Id = id,
                    Name = "Nazwa",
                    ProgramStepsInstructions = steps
                };
                await handler.db.ProgramSchemes.InsertOneAsync(programToInsert);
                return id;
            }
        }
    }
}
