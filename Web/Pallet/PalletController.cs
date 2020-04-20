using Core.Pallet.ProgramPallet;
using Core.Pallets;
using Core.Pallets.List;
using Core.Pallets.PalletData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Web.Pallet
{
    [Authorize]
    public class PalletController : Controller
    {
        private readonly PalletService _palletService;

        public PalletController(PalletService palletService)
        {
            _palletService = palletService;
        }

        [HttpGet("api/pallet/getpallets")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PalletInformation>))]
        public async Task<IActionResult> GetPallets()
        {
            return Ok(await _palletService.GetPalletList());
        }

        [HttpPut("api/pallet/createpallet")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PalletToInsertResponse))]
        public async Task<IActionResult> CreatePallet([FromBody] PalletToInsertRequest request)
        {
            return Ok(await _palletService.InsertPallet(request));
        }

        [HttpGet("api/pallet/{id}/getPalletToProgram")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PalletToInsertResponse))]
        public async Task<IActionResult> GetPalletToProgram(int id)
        {
            return Ok(await _palletService.GetPalletToProgramInformation(id));
        }

        [HttpPost("api/pallet/programPallet")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PalletToProgramResponse))]
        public async Task<IActionResult> ProgramPallet([FromBody] PalletToProgramRequest request)
        {
            return Ok(await _palletService.ProgramPallet(request));
        }

    }
}