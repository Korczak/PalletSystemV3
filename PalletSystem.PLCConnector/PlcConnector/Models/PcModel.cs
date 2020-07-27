using PalletSystem.PLCConnector.PlcConnector.Constants;
using System;

namespace PalletSystem.PLCConnector.PlcConnector.Models
{
    public class PcModel
    {
        public int LiveCounter { get; set; }
        public int Order { get; set; }
        public string RFID { get; set; }
        public uint OperationMask { get; set; }
        public string Command { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Data: [LiveCounter: {LiveCounter}, Order: {Order}, RFID: {RFID}, OperationMask: {OperationMask}, Status: {Status}]";
        }

        public byte[] ToBuffor()
        {
            byte[] buff = new byte[TraceOffset.plcLiveCounter - TraceOffset.pcLiveCounter];
            Sharp7.S7.SetIntAt(buff, (int)TraceOffset.pcLiveCounter, (short)LiveCounter);
            Sharp7.S7.SetIntAt(buff, (int)TraceOffset.pcOrder, (short)Order);
            Sharp7.S7.SetCharsAt(buff, (int)TraceOffset.pcRfid, RFID);
            Sharp7.S7.SetDWordAt(buff, (int)TraceOffset.pcMask, OperationMask);
            Sharp7.S7.SetCharsAt(buff, (int)TraceOffset.pcCommand, Command);
            Sharp7.S7.SetIntAt(buff, (int)TraceOffset.pcStatus, (short)Status);
            return buff;
        }
    }
}