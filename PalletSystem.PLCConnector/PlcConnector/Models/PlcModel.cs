using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.PLCConnector.PlcConnector.Models
{
    public class PlcModel
    {
        public int LiveCounter { get; set; }
        public int Order { get; set; }
        public DateTime DateTime { get; set; }
        public char[] RFID { get; set; } = new char[32];
        public uint OperationMask { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Data: [LiveCounter: {LiveCounter}, Order: {Order}, DateTime: {DateTime}, RFID: {RFID}, OperationMask: {OperationMask}, Status: {Status}]";
        }

    }
}
