using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using PalletSystem.Core.Pallet.Add;
using PalletSystem.Core.Pallet.Run;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace PalletSystem.DatabaseTest.PalletTests
{
    [Collection("Database")]
    public sealed class AddPalletTests : DatabaseTest
    {
        [Fact(DisplayName = "Add pallet with valid data")]
        public async Task AddPalletSuccess()
        {
            var rfid = "123";

            var service = new PalletAddService(new PalletAddAccess());

            var tests = await service.AddPallet(new PalletAddRequest(rfid));

            using (var handler = new DatabaseHandler())
            {
                var pallet = await handler.db.Pallets.AsQueryable().Where(x => x.RFID == rfid).FirstOrDefaultAsync();
                Assert.NotNull(pallet);
            }
        }

        [Fact(DisplayName = "Throws exception on invalid data")]
        public async Task AddPalletFailure()
        {
            var service = new PalletAddService(new PalletAddAccess());

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.AddPallet(new PalletAddRequest(null)));
        }
    }
}
