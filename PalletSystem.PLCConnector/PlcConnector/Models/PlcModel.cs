using S7.Net;
using System;
using System.Linq;

namespace PalletSystem.PLCConnector.PlcConnector.Models
{
    public class PlcModel
    {
        public int LiveCounter { get; set; }
        public int Order { get; set; }
        public string RFID { get; set; }
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
                Order = Sharp7.S7.GetIntAt(buffor, 2),
                RFID = Sharp7.S7.GetCharsAt(buffor, 4, 33).Trim(),
                OperationMask = Sharp7.S7.GetDWordAt(buffor, 38),
                Status = Sharp7.S7.GetIntAt(buffor, 42),
                WorkspaceSlot = Sharp7.S7.GetIntAt(buffor, 44),
                Results = Enumerable.Range(0, 8).Select(x => new ResultsItem()
                {
                    Id = Sharp7.S7.GetIntAt(buffor, 46 + x * 8),
                    Value = Sharp7.S7.GetRealAt(buffor, 48 + x * 8),
                    Status = Sharp7.S7.GetIntAt(buffor, 52 + x * 8)
                }).ToArray(),
                Message = Sharp7.S7.GetStringAt(buffor, 110).Trim()
            };
        }
    }
}