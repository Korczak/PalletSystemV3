using PalletSystem.PLCConnector.PlcConnector.Models;

namespace PalletSystem.PLCConnector.PlcConnector
{
    public class PlcSourceData
    {
        public PcModel PcModel { get; }
        public PlcModel PlcModel { get; }

        public PlcSourceData(PcModel pcModel, PlcModel plcModel)
        {
            PcModel = pcModel;
            PlcModel = plcModel;
        }
    }
}