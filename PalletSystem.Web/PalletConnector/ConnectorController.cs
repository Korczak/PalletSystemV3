using Microsoft.AspNetCore.Mvc;
using PalletSystem.Core.Pallet.Run;
using System.Net;
using System.Threading.Tasks;

namespace PalletSystem.Web.PalletConnector
{
    public class ConnectorController : ControllerBase
    {
        private readonly PalletRunService _runService;

        public ConnectorController(PalletRunService runService)
        {
            _runService = runService;
        }

        //[HttpPost("api/pallet/run")]
        //[ProducesResponseType(typeof(PalletRunResult), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> RunPallet([FromBody] PalletRunRequest request)
        //{
        //    var result = await _runService.RunPallet(request);

        //    return Ok(result);
        //}
    }
}
