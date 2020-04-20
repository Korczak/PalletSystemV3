using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.Program;
using Core.Program.Details;
using Core.Program.List;
using Microsoft.AspNetCore.Mvc;

namespace Web.Programme
{
    public class ProgramController : Controller
    {
        private readonly ProgramService _programService;

        public ProgramController(ProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet("api/program/getprograms")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProgramInformation>))]
        public async Task<IActionResult> GetVirtualPallets()
        {
            return Ok(await _programService.GetProgramList());
        }

        [HttpGet("api/program/{id}/getprogramdetails")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProgramDetails))]
        public async Task<IActionResult> GetVirtualPalletDetails(int id)
        {
            return Ok(await _programService.GetProgramDetails(id));
        }
    }
}
