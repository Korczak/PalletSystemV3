using Core.Database.Settings;
using DatabaseTest.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DatabaseTest
{
    [Collection("Database")]
    public sealed class PalletTests : IDisposable
    {
        public PalletTests()
        {
            DatabaseSetup.Setup();
        }

        public void Dispose()
        {
            DatabaseSetup.Cleanup();
        }

        [Fact(DisplayName = "Test")]
        public async void Test()
        {
            using(var handler = new DatabaseHandler())
            {
                await handler.db.Pallets.InsertOneAsync(new Core.Database.Models.Pallets.PalletModel() { RFID = "1" });
            }
        }
    }
}
