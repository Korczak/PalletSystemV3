using PalletSystem.Core.Database.Settings;
using PalletSystem.DatabaseTest.Configuration;
using System;
using Xunit;

namespace PalletSystem.DatabaseTest
{
    [Collection("Database")]
    public sealed class DeviceTests : IDisposable
    {
        public DeviceTests()
        {
            DatabaseSetup.Setup();
        }

        public void Dispose()
        {
            DatabaseSetup.Cleanup();
        }
    }
}
