using PalletSystem.PLCConnector.Client;
using PalletSystem.PLCConnector.PlcConnector.Constants;
using PalletSystem.PLCConnector.PlcConnector.Models;
using Serilog;
using Sharp7;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector.PlcConnector
{
    internal class Station
    {
        public int DB { get; private set; }
        public int LiveCounter { get; private set; }
        public StationState Order { get; private set; }
        public VirtualPalletGetNextStepResponse NextStepResponse { get; private set; }
        public VirtualPalletSaveResult SaveResultResponse { get; private set; }
        private CurrentOperation currentOperation;
        public ushort ResponseOrder { get; set; }

        public Station(int _db)
        {
            DB = _db;
        }

        public void Processing(S7Client client)
        {
            byte[] buff = new byte[4];
            client.DBRead(DB, (int)TraceOffset.plcLiveCounter, 4, buff);
            LiveCounter = Sharp7.S7.GetIntAt(buff, 0);
            var order = Sharp7.S7.GetIntAt(buff, 2);
            bool autoResponse = true;

            switch (Order)
            {
                case StationState.Idle:
                    {
                        Log.Debug($"Station {DB} is IDLE");
                        IdleProcessing(client, order);
                        ResponseOrder = 0;
                        break;
                    }
                case StationState.WaitForResponse:
                    {
                        Log.Debug($"Station {DB} is waiting for response");
                        ResponseOrder = 0;
                        break;
                    }
                case StationState.ResponseReady:
                    {
                        Log.Debug($"Station {DB} response is ready");
                        var isSuccess = true;
                        ResponseProcessing(client, ref autoResponse, ref isSuccess);
                        Order = StationState.WaitForIdle;
                        break;
                    }
                case StationState.WaitForIdle:
                    {
                        Log.Debug($"Station {DB} waits for idle");
                        if (order == 0)
                            Order = StationState.Idle;
                        break;
                    }
            }
            if (autoResponse)
            {
                Sharp7.S7.SetWordAt(buff, 2, ResponseOrder);
                client.DBWrite(DB, (int)TraceOffset.pcLiveCounter, 4, buff);
            }
        }

        private void ResponseProcessing(S7Client client, ref bool autoResponse, ref bool isSuccess)
        {
            if (currentOperation == CurrentOperation.GetNextStep)
            {
                if (NextStepResponse != null && NextStepResponse.Result != VirtualPalletGetNextStepResult.VirtualPalletError)
                {
                    var response = new PcModel()
                    {
                        LiveCounter = LiveCounter,
                        Order = 1,
                        Command = string.Join(';',
                                              NextStepResponse.NextStep.Command,
                                              NextStepResponse.NextStep.Parameters),
                        OperationMask = (uint)NextStepResponse.NextStep.OperationMask,
                        RFID = NextStepResponse.Rfid,
                        Status = 1
                    };

                    var responseBuff = response.ToBuffor();
                    autoResponse = false;
                    client.DBWrite(DB, (int)TraceOffset.pcLiveCounter, responseBuff.Length, responseBuff);
                    ResponseOrder = 1;
                }
                else
                {
                    isSuccess = false;
                }
            }
            else if (currentOperation == CurrentOperation.SavingResult)
            {
                if (SaveResultResponse == VirtualPalletSaveResult.ResultSaved)
                {
                    ResponseOrder = 2;
                }
                else
                {
                    isSuccess = false;
                }
            }

            if (!isSuccess)
            {
                ResponseOrder = 11;
            }
        }

        private void IdleProcessing(S7Client client, int order)
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
                    currentOperation = CurrentOperation.GetNextStep;
                }
                else if (order == 2)
                {
                    Order = StationState.WaitForResponse;

                    Task.Factory.StartNew(() =>
                    {
                        SaveResults(PlcModel.ParseBuffer(buffL));
                    });
                    currentOperation = CurrentOperation.SavingResult;
                }
            }
        }

        private void SaveResults(PlcModel plcModel)
        {
            Log.Debug($"Result is saved for pallet with rfid {plcModel.RFID} on station {DB}");
            var client = new ConnectorClient(Program.GetConfig().WebApiUrl, new System.Net.Http.HttpClient());
            var results = new List<VirtualPalletResultItem>();
            foreach (var result in plcModel.Results)
            {
                results.Add(new VirtualPalletResultItem()
                {
                    Id = result.Id,
                    Status = result.Status,
                    Value = result.Value
                });
            }
            var request = new VirtualPalletSaveResultRequest()
            {
                OperationMask = (int)plcModel.OperationMask,
                Results = results,
                Status = plcModel.Status,
                Rfid = plcModel.RFID,
                WorkspaceSlot = plcModel.WorkspaceSlot
            };

            SaveResultResponse = client.SaveResultAsync(request).GetAwaiter().GetResult();
            Order = StationState.ResponseReady;
        }

        private void GetNextStep(PlcModel plcModel)
        {
            Log.Debug($"Pallet with rfid {plcModel.RFID} on station {DB} retrieves for next step");
            var client = new ConnectorClient(Program.GetConfig().WebApiUrl, new System.Net.Http.HttpClient());
            var response = client.GetNextStepAsync(plcModel.RFID).GetAwaiter().GetResult();
            if (response.NextStep.OperationMask > 0)
            {
                var operationMask = ((int)plcModel.OperationMask) & (1 << (response.NextStep.OperationMask - 1));
                response.NextStep.OperationMask = operationMask;
            }
            else
            {
                response.NextStep.OperationMask = 0;
            }
            NextStepResponse = response;

            Order = StationState.ResponseReady;
        }
    }
}