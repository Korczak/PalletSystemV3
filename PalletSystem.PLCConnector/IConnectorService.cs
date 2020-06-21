using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.PLCConnector
{
    public interface IConnectorService
    {
        bool IsConnected { get; }
    }
}
