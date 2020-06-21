using Microsoft.AspNetCore.Mvc;
using PalletSystem.Core.Devices.ConnectConnector;
using PalletSystem.Core.Devices.SyncConnector;
using PalletSystem.Core.Devices.UpdateConnections;
using PalletSystem.Core.Pallet.Run;
using System.Net;
using System.Threading.Tasks;

namespace PalletSystem.Web.PalletConnector
{
    public class ConnectorController : ControllerBase
    {
        private readonly ConnectConnectorService _connectConnector;
        private readonly UpdateConnectionsService _updateConnections;
        private readonly SyncConnectorService _syncConnector;
        private readonly PalletRunService _runService;

        public ConnectorController(
            ConnectConnectorService connectConnector,
            UpdateConnectionsService updateConnections,
            SyncConnectorService syncConnector,
            PalletRunService runService)
        {
            _connectConnector = connectConnector;
            _updateConnections = updateConnections;
            _syncConnector = syncConnector;
            _runService = runService;
        }

        //[HttpPost("api/pallet/run")]
        //[ProducesResponseType(typeof(PalletRunResult), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> RunPallet([FromBody] PalletRunRequest request)
        //{
        //    var result = await _runService.RunPallet(request);

        //    return Ok(result);
        //}



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
