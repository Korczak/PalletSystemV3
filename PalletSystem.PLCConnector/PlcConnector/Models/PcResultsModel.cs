using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.PLCConnector.PlcConnector.Models
{
    public class PcResultsModel
    {
        public PcResultsItem[] Results => new PcResultsItem[8];
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Data: [Message: {Message}]";
        }

    }
}
