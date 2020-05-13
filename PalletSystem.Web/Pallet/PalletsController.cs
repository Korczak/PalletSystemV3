using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using PalletSystem.Core.Pallet.List;
using PalletSystem.Core.Pallet.Add;
using PalletSystem.Core.Pallet.Run;

namespace PalletSystem.Web.Pallet
{
    public class PalletsController : ControllerBase
    {
        private readonly PalletListDataAccess _listDataAccess;
        private readonly PalletAddService _addService;
        private readonly PalletRunService _runService;

        public PalletsController(PalletListDataAccess listDataAccess, PalletAddService addService, PalletRunService runService)
        {
            _listDataAccess = listDataAccess;
            _addService = addService;
            _runService = runService;
        }

        [HttpPost("api/pallet/run")]
        [ProducesResponseType(typeof(PalletRunResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RunPallet([FromBody] PalletRunRequest request)
        {
            var result = await _runService.RunPallet(request);

            return Ok(result);
        }


        [HttpPut("api/pallet/add")]
        [ProducesResponseType(typeof(PalletAddResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddPallet([FromBody] PalletAddRequest request)
        {
            var result = await _addService.AddPallet(request);

            return Ok(result);
        }

        [HttpGet("api/pallet/list")]
        [ProducesResponseType(typeof(List<PalletInformation>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPallets()
        {
            var result = await _listDataAccess.GetPalletList();

            return Ok(result);
        }
    }
}
