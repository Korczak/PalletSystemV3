using PalletSystem.PLCConnector.Client;
using PalletSystem.PLCConnector.PlcConnector.Constants;
using PalletSystem.PLCConnector.PlcConnector.Models;
using PalletSystem.PLCConnector.WebConnect;
using S7.Net;
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
        public VirtualPalletGetNextStepResponse Response { get; private set; }
        public ushort ResponseOrder { get; set; }
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
                    {
                        if (order != 0)
                        {
                            byte[] buffL = new byte[(int)TraceOffset.end - (int)TraceOffset.plcLiveCounter];
                            client.DBRead(DB, (int)TraceOffset.plcLiveCounter, buffL.Length, buffL);
                            if (order == 1)
                            {
                                Order = StationState.WaitForResponse;

                                Task.Factory
                                    .StartNew(() => 
                                    {    
                                        GetNextStep(PlcModel.ParseBuffer(buffL));
                                    });
                            }
                        }
                        ResponseOrder = 0;
                        break;
                    }
                case StationState.WaitForResponse:
                    {
                        ResponseOrder = 0;
                        break;
                    }
                case StationState.ResponseReady:
                    {
                        if(Response != null && Response.Result != VirtualPalletGetNextStepResult.VirtualPalletError)
                        {

                        }
                        else
                        {
                            ResponseOrder = 11;
                        }
                        Order = StationState.WaitForIdle;
                        break;
                    }
                case StationState.WaitForIdle:
                    {
                        if (order == 0)
                            Order = StationState.Idle;
                        break;
                    }
            }
            Sharp7.S7.SetWordAt(buff, 2, ResponseOrder);
            client.DBWrite(DB, (int)TraceOffset.pcLiveCounter, 4, buff);

        }
        private void GetNextStep(PlcModel plcModel)
        {
            var client = new ConnectorClient(Program.GetConfig().WebApiUrl, new System.Net.Http.HttpClient());
            Response = client.GetNextStepAsync(plcModel.RFID).GetAwaiter().GetResult();
            Order = StationState.ResponseReady;
        }
    }
}
