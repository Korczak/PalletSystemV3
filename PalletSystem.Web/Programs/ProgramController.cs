using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using PalletSystem.Core.Program.List;
using PalletSystem.Core.Program.Add;

namespace PalletSystem.Web.Programs
{
    public class ProgramController : ControllerBase
    {
        private readonly ProgramListAccess _listDataAccess;
        private readonly ProgramAddService _addService;

        public ProgramController(ProgramListAccess listDataAccess, ProgramAddService addService)
        {
            _listDataAccess = listDataAccess;
            _addService = addService;
        }

        [HttpPut("api/program/add")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddProgram([FromBody] ProgramAddRequest request)
        {
            await _addService.AddProgram(request);

            return Ok();
        }


        [HttpGet("api/program/list")]
        [ProducesResponseType(typeof(List<ProgramInformation>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPrograms()
        {
            var result = await _listDataAccess.GetProgramList();

            return Ok(result);
        }
    }
}
