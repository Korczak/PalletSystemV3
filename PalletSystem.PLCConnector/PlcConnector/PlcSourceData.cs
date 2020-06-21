using PalletSystem.PLCConnector.PlcConnector.Models;

namespace PalletSystem.PLCConnector.PlcConnector
{
    public class PlcSourceData
    {
        public PcModel PcModel { get; }
        public PlcModel PlcModel { get; }
        public PcResultsModel PcResultsModel { get; }

        public PlcSourceData(PcModel pcModel, PlcModel plcModel, PcResultsModel pcResultsModel)
        {
            PcModel = pcModel;
            PlcModel = plcModel;
            PcResultsModel = pcResultsModel;
        }
    }
}