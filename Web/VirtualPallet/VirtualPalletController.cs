using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.VirtualPallet;
using Core.VirtualPallet.Details;
using Core.VirtualPallet.List;
using Microsoft.AspNetCore.Mvc;

namespace Web.VirtualPallet
{
    public class VirtualPalletController : Controller
    {
        private readonly VirtualPalletService _virtualPalletService;

        public VirtualPalletController(VirtualPalletService virtualPalletService)
        {
            _virtualPalletService = virtualPalletService;
        }

        [HttpGet("api/virtualpallet/getvirtualpallets")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<VirtualPalletInformation>))]
        public async Task<IActionResult> GetVirtualPallets()
        {
            return Ok(await _virtualPalletService.GetVirtualPalletList());
        }

        [HttpGet("api/virtualpallet/{id}/getpalletdetails")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VirtualPalletDetails))]
        public async Task<IActionResult> GetVirtualPalletDetails(int id)
        {
            return Ok(await _virtualPalletService.GetVirtualPalletDetails(id));
        }
    }
}
