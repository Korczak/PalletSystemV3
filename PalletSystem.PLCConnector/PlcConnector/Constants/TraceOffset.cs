using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.PLCConnector.PlcConnector.Constants
{
    public enum TraceOffset
    {
        pcLiveCounter = 0,
        pcOrder = pcLiveCounter + 2,
        pcRfid = pcOrder + 2,
        pcMask = pcRfid + 34,
        pcCommand = pcMask + 2,
        pcStatus = pcMask + 256,
        plcLiveCounter = pcStatus + 2,
        plcOrder = plcLiveCounter + 2,
        plcRfid = plcLiveCounter + 4,
        plcMask = plcLiveCounter + 38,
        plcStatus = plcLiveCounter + 42,
        plcWorkspaceSlot = plcLiveCounter + 44,
        plcResults = plcLiveCounter + 46,
        plcMessage = plcLiveCounter + 94,

        end = plcMessage + 255
    }
}
