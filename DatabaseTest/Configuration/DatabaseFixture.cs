using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseTest.Configuration
{
    public sealed class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            DatabaseSetup.Setup();
        }

        public void Dispose()
        {
            DatabaseSetup.Cleanup();
        }
    }
}
