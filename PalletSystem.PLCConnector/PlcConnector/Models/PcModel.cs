using System;

namespace PalletSystem.PLCConnector.PlcConnector.Models
{
    public class PcModel
    {
        public int LiveCounter { get; set; }
        public int Order { get; set; }
        public char[] RFID { get; set; } = new char[32];
        public uint OperationMask { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Data: [LiveCounter: {LiveCounter}, Order: {Order}, RFID: {RFID}, OperationMask: {OperationMask}, Status: {Status}]";
        }
    }
}