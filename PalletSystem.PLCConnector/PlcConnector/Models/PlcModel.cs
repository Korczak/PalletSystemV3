using S7.Net;
using System;

namespace PalletSystem.PLCConnector.PlcConnector.Models
{
    public class PlcModel
    {
        public int LiveCounter { get; set; }
        public int Order { get; set; }
        public char[] RFID { get; set; } = new char[32];
        public uint OperationMask { get; set; }
        public int Status { get; set; }
        public int WorkspaceSlot { get; set; }
        public ResultsItem[] Results { get; set; } = new ResultsItem[8];
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Data: [LiveCounter: {LiveCounter}, Order: {Order}, RFID: {RFID}, OperationMask: {OperationMask}, Status: {Status}]";
        }

        public static PlcModel ParseBuffer(byte[] buffor)
        {
             return new PlcModel()
             {
                 LiveCounter = Sharp7.S7.GetIntAt(buffor, 0),
                 Order
             }
        }
    }
}