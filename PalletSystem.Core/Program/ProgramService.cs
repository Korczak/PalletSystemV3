using PalletSystem.Core.Program.Details;
using PalletSystem.Core.Program.List;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Program
{
    public class ProgramService
    {
        private readonly ProgramListAccess _programListDataAccess;
        private readonly ProgramDetailsDataAccess _programDetailsDataAccess;

        public ProgramService(ProgramListAccess programListDataAccess, ProgramDetailsDataAccess programDetailsDataAccess)
        {
            _programListDataAccess = programListDataAccess;
            _programDetailsDataAccess = programDetailsDataAccess;
        }

        public async Task<IEnumerable<ProgramInformation>> GetProgramList()
        {

            var programs = await _programListDataAccess.GetProgramList();
            return programs;
        }

        public async Task<ProgramDetails> GetProgramDetails(int id)
        {
            var program = await _programDetailsDataAccess.GetProgramDetails(id);
            return program;
        }
    }
}
