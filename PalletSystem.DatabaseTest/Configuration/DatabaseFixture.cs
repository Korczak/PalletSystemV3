using System;

namespace PalletSystem.DatabaseTest.Configuration
{
    public sealed class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            DatabaseSetup.Setup();
        }

        public void Dispose()
        {
            DatabaseSetup.Cleanup().Wait();
        }
    }
}
