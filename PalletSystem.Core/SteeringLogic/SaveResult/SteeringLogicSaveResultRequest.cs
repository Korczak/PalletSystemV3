using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.SteeringLogic.SaveResult
{
    public class SteeringLogicSaveResultRequest
    {
        public string RFID { get; }
        public IEnumerable<SteeringLogicResultItem> Results { get; }

        public SteeringLogicSaveResultRequest(string rFID, IEnumerable<SteeringLogicResultItem> results)
        {
            RFID = rFID;
            Results = results;
        }
    }
}
