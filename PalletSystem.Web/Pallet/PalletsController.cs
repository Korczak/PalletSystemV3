using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using PalletSystem.Core.Pallet.List;
using PalletSystem.Core.Pallet.Add;
using PalletSystem.Core.Pallet.Run;
using PalletSystem.Core.Pallet.Finish;
using PalletSystem.Core.VirtualPallet.Details;

namespace PalletSystem.Web.Pallet
{
    public class PalletsController : ControllerBase
    {
        private readonly PalletListDataAccess _listDataAccess;
        private readonly VirtualPalletDetailsDataAccess _virtualPalletDetails;
        private readonly PalletAddService _addService;
        private readonly PalletRunService _runService;
        private readonly PalletFinishService _finishService;

        public PalletsController(
            PalletListDataAccess listDataAccess,
            VirtualPalletDetailsDataAccess virtualPalletDetails,
            PalletAddService addService,
            PalletRunService runService,
            PalletFinishService finishService)
        {
            _listDataAccess = listDataAccess;
            _virtualPalletDetails = virtualPalletDetails;
            _addService = addService;
            _runService = runService;
            _finishService = finishService;
        }

        [HttpPost("api/pallet/run")]
        [ProducesResponseType(typeof(PalletRunResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RunPallet([FromBody] PalletRunRequest request)
        {
            var result = await _runService.RunPallet(request);

            return Ok(result);
        }


        [HttpPost("api/pallet/finish")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FinishPallet([FromBody] PalletFinishRequest request)
        {
            await _finishService.FinishPallet(request);

            return Ok();
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

        [HttpGet("api/virtualPallet/{virtualPalletId}")]
        [ProducesResponseType(typeof(VirtualPalletDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetVirtualPalletDetails(string virtualPalletId)
        {
            var result = await _virtualPalletDetails.GetVirtualPalletDetails(virtualPalletId);

            return Ok(result);
        }
    }
}
