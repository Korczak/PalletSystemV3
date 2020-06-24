using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.SteeringLogic.SaveResult
{
    public class SteeringLogicSaveResultService
    {
        private readonly SteeringLogicSaveResultAccess _access;

        public SteeringLogicSaveResultService(SteeringLogicSaveResultAccess access)
        {
            _access = access;
        }

        public Task SaveResult(SteeringLogicSaveResultRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return default;
        }
    }
}
