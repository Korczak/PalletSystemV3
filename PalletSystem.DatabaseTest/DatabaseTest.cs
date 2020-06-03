using PalletSystem.DatabaseTest.Configuration;
using System;

namespace PalletSystem.DatabaseTest
{
    public abstract class DatabaseTest : IDisposable
    {
        public DatabaseTest()
        {
            DatabaseSetup.Setup();
        }

        public void Dispose()
        {
            DatabaseSetup.Cleanup();
        }
    }
}
