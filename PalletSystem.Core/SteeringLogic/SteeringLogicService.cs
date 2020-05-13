using PalletSystem.Core.SteeringLogic.CalculateStep;
using PalletSystem.Core.SteeringLogic.Information;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.SteeringLogic
{
    public class SteeringLogicService
    {
        private readonly SteeringLogicDataAccess _steeringLogicDataAccess;
        private readonly SteeringLogicInformationDataAccess _steeringLogicInformationDataAccess;

        public SteeringLogicService(
            SteeringLogicDataAccess steeringLogicDataAccess,
            SteeringLogicInformationDataAccess steeringLogicInformationDataAccess)
        {
            _steeringLogicDataAccess = steeringLogicDataAccess;
            _steeringLogicInformationDataAccess = steeringLogicInformationDataAccess;
        }

        public async Task<SteeringLogicActualStep> GetVirtualPalletActualStep(int id)
        {
            var actualStep = await _steeringLogicDataAccess.GetActualtStep(id);
            return actualStep;
        }

        public async Task<SteeringLogicState> CalculateNextStep(SteeringLogicRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var stepInformation = await _steeringLogicInformationDataAccess.GetStepInformation(request.VirtualPalletId);
            var processing = new SteeringLogicProcessing(request, stepInformation);

            //todo: data access

            return processing.State;
        }
    }
}
