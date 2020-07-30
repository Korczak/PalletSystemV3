using Microsoft.AspNetCore.Mvc;
using PalletSystem.Core.Devices.ConnectConnector;
using PalletSystem.Core.Devices.SyncConnector;
using PalletSystem.Core.Devices.UpdateConnections;
using PalletSystem.Core.VirtualPallet.GetNextStep;
using PalletSystem.Core.VirtualPallet.SaveResult;
using System.Net;
using System.Threading.Tasks;

namespace PalletSystem.Web.PalletConnector
{
    public class ConnectorController : ControllerBase
    {
        private readonly ConnectConnectorService _connectConnector;
        private readonly UpdateConnectionsService _updateConnections;
        private readonly SyncConnectorService _syncConnector;
        private readonly VirtualPalletGetNextStepService _nextStepService;
        private readonly VirtualPalletSaveResultService _saveResultService;

        public ConnectorController(
            ConnectConnectorService connectConnector,
            UpdateConnectionsService updateConnections,
            SyncConnectorService syncConnector,
            VirtualPalletGetNextStepService nextStepService,
            VirtualPalletSaveResultService saveResultService)
        {
            _connectConnector = connectConnector;
            _updateConnections = updateConnections;
            _syncConnector = syncConnector;
            _nextStepService = nextStepService;
            _saveResultService = saveResultService;
        }

        [HttpGet("api/connector/pallet/{rfid}/next-step")]
        [ProducesResponseType(typeof(VirtualPalletGetNextStepResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNextStep(string rfid)
        {
            var result = await _nextStepService.GetNextStep(rfid);

            return Ok(result);
        }

        [HttpPost("api/connector/pallet/save-result")]
        [ProducesResponseType(typeof(VirtualPalletSaveResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveResult([FromBody] VirtualPalletSaveResultRequest request)
        {
            var result = await _saveResultService.SaveResult(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("/api/connector/sync")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SyncConnectorModel))]
        public async Task<IActionResult> PostSyncSignal([FromBody] SyncConnectorRequest request)
        {
            var result = await _syncConnector.SyncConnector(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/connector/connect")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ConnectConnector([FromBody] ConnectorConnectRequest request)
        {
            var address = Request.HttpContext.Connection.RemoteIpAddress;
            await _connectConnector.ConnectConnector(request, address);
            return Ok();
        }

        [HttpPost]
        [Route("/api/connections")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateConnections([FromBody] ConnectionsStatusRequest connections)
        {
            await _updateConnections.UpdateConnections(connections);
            return Ok();
        }
    }
}