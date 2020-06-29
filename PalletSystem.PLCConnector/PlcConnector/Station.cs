using PalletSystem.PLCConnector.PlcConnector.Constants;
using PalletSystem.PLCConnector.PlcConnector.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector.PlcConnector
{
    class Station
    {
        public int DB { get; private set; }
        public int LiveCounter { get; private set; }
        public StationState Order { get; private set; }
        public PcModel Response { get; private set; }
        public Station(int _db)
        {
            DB = _db;
        }
        public void Processing(Sharp7.S7Client client)
        {
            byte[] buff = new byte[4];
            client.DBRead(DB, (int)TraceOffset.plcLiveCounter, 4, buff);
            LiveCounter = Sharp7.S7.GetIntAt(buff, 0);
            var order = Sharp7.S7.GetIntAt(buff, 2);
            switch (Order)
            {
                case StationState.Idle:
                    if (order != 0)
                    {
                        byte[] buffL = new byte[(int)TraceOffset.end - (int)TraceOffset.pcLiveCounter];
                        client.DBRead(DB, (int)TraceOffset.pcLiveCounter, buffL.Length, buffL);
                        if (order == 1)
                        {
                            Order = StationState.WaitForResponse;
                            
                            Task.Factory
                                .StartNew(() => { Response = GetNextStep(PlcModel.ParseBuffer(buffL))})
                                .ContinueWith(() =>
                            {                                
                                Order = StationState.ResponseReady;
                            })
                        }
                    }
            }
                    break;
            }

        private void GetNextStep(PlcModel plcModel)
        {
            throw new NotImplementedException();
        }

        client.DBWrite(DB, (int)TraceOffset.plcLiveCounter, 4, buff);
        }
    }
}
