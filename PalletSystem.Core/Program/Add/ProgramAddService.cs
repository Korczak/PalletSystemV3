using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramAddService
    {
        private readonly ProgramAddAccess _access;

        public ProgramAddService(ProgramAddAccess access)
        {
            _access = access;
        }

        public async Task AddProgram(ProgramAddRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var programToAdd = new ProgramAdded(request.Name, request.Description, request.Instructions);

            await _access.AddProgram(programToAdd);
        }
    }
}
